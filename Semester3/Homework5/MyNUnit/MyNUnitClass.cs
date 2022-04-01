using Attributes;
using System.Reflection;
using System.Diagnostics;

namespace MyNUnit;

/// <summary>
/// MyNUnit testing class
/// </summary>
public class MyNUnitClass
{
    private static List<TestResult> testsResult = new();

    public static List<TestResult> ResultList { get => testsResult; }

    public static void RunTesting(string path)
    {
        var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
        var classes = files.Select(Assembly.LoadFrom)
            .SelectMany(a => a.ExportedTypes)
            .Where(t => t.IsClass);
        var testClasses = classes.Where(c => c.GetMethods().Any(m => m.GetCustomAttributes().Any(a => a is TestAttribute)));
        Parallel.ForEach(testClasses, StartTests);
    }

    public static void PrintResult()
    {
        foreach (var test in testsResult)
        {
            switch (test.Result)
            {
                case ResultState.Failed:
                case ResultState.Passed:
                    Console.WriteLine($"Test named \"{test.Name}\" {test.Result}. Elapsed time: {test.ElapsedTime.TotalMilliseconds} ms");
                    break;
                case ResultState.Ignored:
                    Console.WriteLine($"Test named \"{test.Name}\" Ignored. Reason: {test.IgnoreReason}. Elapsed time: {test.ElapsedTime.TotalMilliseconds} ms");
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Starts testing
    /// </summary>
    private static void StartTests(Type testClass)
    {
        var methods = SortByAttributes(testClass);
        if (!RunMethods(methods.BeforeClass, methods.Test))
        {
            return;
        }

        foreach (var test in methods.Test)
        {
            if (!RunBeforeAfterTestMethod(methods.Before, testClass))
            {
                testsResult.Add(new TestResult(test.Name, ResultState.Ignored, TimeSpan.Zero, "Before test method failed"));
                continue;
            }

            var result = RunTest(test, testClass);
            if (result.Result == ResultState.Ignored || result.Result == ResultState.Failed)
            {
                testsResult.Add(result);
                continue;
            }

            if (!RunBeforeAfterTestMethod(methods.After, testClass))
            {
                testsResult.Add(new TestResult(test.Name, ResultState.Failed, TimeSpan.Zero, null));
            }
            else
            {
                testsResult.Add(result);
            }
        }

        RunMethods(methods.AfterClass, methods.Test);
    }

    /// <summary>
    /// Runs methods from AfterClass or BeforeClass 
    /// </summary>
    /// <param name="methods">Before or After class methods</param>
    /// <param name="tests">Test methods</param>
    /// <returns>Whether it's failed</returns>
    private static bool RunMethods(List<MethodInfo> methods, List<MethodInfo> tests)
    {
        bool result = true;
        try
        {
            Parallel.ForEach(methods, method => method.Invoke(null, null));
        }
        catch (Exception)
        {
            foreach (var test in tests)
            {
                testsResult.RemoveAll(item => item.Name == test.Name);
                testsResult.Add(new TestResult(test.Name, ResultState.Ignored, TimeSpan.Zero, "Before or After class method failed"));
            }
            result = false;
        }
        return result;
    }

    /// <summary>
    /// Runs test
    /// </summary>
    /// <param name="method">Test method</param>
    /// <param name="testClass">Test method class</param>
    private static TestResult RunTest(MethodInfo method, Type testClass)
    {
        var properties = (TestAttribute?)method.GetCustomAttribute(typeof(TestAttribute));
        if (properties?.Ignore != null)
        {
            return new TestResult(method.Name, ResultState.Ignored, TimeSpan.Zero, properties.Ignore);
        }

        var testClassInstance = Activator.CreateInstance(testClass);
        var stopwatch = new Stopwatch();
        try
        {
            stopwatch.Start();
            method.Invoke(testClassInstance, null);
            stopwatch.Stop();
            if (properties?.Expected != null)
            {
                return new TestResult(method.Name, ResultState.Failed, stopwatch.Elapsed, null);
            }
        }
        catch (Exception e)
        {
            stopwatch.Stop();
            if (properties?.Expected != null && e.InnerException?.GetType() != properties.Expected || properties?.Expected == null)
            {
                return new TestResult(method.Name, ResultState.Failed, stopwatch.Elapsed, null);
            }
        }
        return new TestResult(method.Name, ResultState.Passed, stopwatch.Elapsed, null);
    }

    private static bool RunBeforeAfterTestMethod(List<MethodInfo> methods, Type testClass)
    {
        var testClassInstance = Activator.CreateInstance(testClass);
        foreach (var method in methods)
        {
            try
            {
                method.Invoke(testClassInstance, null);
            }
            catch (Exception)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Sorts methods by attributes
    /// </summary>
    /// <returns>Class containing lists</returns>
    private static MethodsList SortByAttributes(Type testClass)
    {
        var methodsList = new MethodsList();
        foreach (var method in testClass.GetMethods())
        {
            foreach (var attribute in Attribute.GetCustomAttributes(method))
            {
                switch (attribute)
                {
                    case TestAttribute:
                        methodsList.Test.Add(method);
                        break;
                    case AfterAttribute:
                        methodsList.After.Add(method);
                        break;
                    case BeforeAttribute:
                        methodsList.Before.Add(method);
                        break;
                    case AfterClassAttribute:
                        if (!method.IsStatic)
                        {
                            throw new InvalidOperationException("After class methods should be static");
                        }
                        methodsList.AfterClass.Add(method);
                        break;
                    case BeforeClassAttribute:
                        if (!method.IsStatic)
                        {
                            throw new InvalidOperationException("Before class methods should be static");
                        }
                        methodsList.BeforeClass.Add(method);
                        break;
                    default:
                        break;
                }
            }
        }

        return methodsList;
    }
}

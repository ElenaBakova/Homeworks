namespace MyNUnit;

using System.Collections.Concurrent;
using Attributes;
using System.Reflection;
using System.Diagnostics;

/// <summary>
/// MyNUnit testing class
/// </summary>
public class MyNUnitClass
{
    /// <summary>
    /// Concurrent bag with result of the testing
    /// </summary>
    public ConcurrentBag<TestResult> ResultList { get; private set; } = new();

    /// <summary>
    /// Runs tests in the given directory
    /// </summary>
    /// <param name="path">Directory path</param>
    public void RunTesting(string path)
    {
        var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
        var classes = files.Select(Assembly.LoadFrom)
            .SelectMany(a => a.ExportedTypes)
            .Where(t => t.IsClass);
        var testClasses = classes.Where(c => c.GetMethods().Any(m => m.GetCustomAttributes().Any(a => a is TestAttribute)));
        Parallel.ForEach(testClasses, StartTests);
    }

    /// <summary>
    /// Prints result of the testing
    /// </summary>
    public void PrintResult()
    {
        var distinctResult = ResultList.DistinctBy(test => test.Name);
        foreach (var test in distinctResult)
        {
            switch (test.Result)
            {
                case ResultState.Failed:
                case ResultState.Passed:
                    Console.WriteLine($"Test named \"{test.Name}\" {test.Result}. Elapsed time: {test.ElapsedTime.TotalMilliseconds} ms");
                    break;
                case ResultState.Ignored:
                    Console.WriteLine($"Test named \"{test.Name}\" Ignored. Reason: {test.IgnoreReason}.");
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Starts testing
    /// </summary>
    private void StartTests(Type testClass)
    {
        var methods = SortByAttributes(testClass);
        if (!RunMethods(methods.BeforeClass, methods.Test))
        {
            return;
        }

        Parallel.ForEach(methods.Test, test => ExecuteTest(methods, testClass, test));

        RunMethods(methods.AfterClass, methods.Test);
    }

    private void ExecuteTest(MethodsList methods, Type testClass, MethodInfo test)
    {
        if (!RunBeforeAfterTestMethod(methods.Before, testClass))
        {
            ResultList.Add(new TestResult(test.Name, ResultState.Ignored, TimeSpan.Zero, "Before test method failed"));
            return;
        }

        var result = RunTest(test, testClass);
        if (result.Result == ResultState.Ignored || result.Result == ResultState.Failed)
        {
            ResultList.Add(result);
            return;
        }

        if (!RunBeforeAfterTestMethod(methods.After, testClass))
        {
            ResultList.Add(new TestResult(test.Name, ResultState.Failed, TimeSpan.Zero, null));
        }
        else
        {
            ResultList.Add(result);
        }
    }

    /// <summary>
    /// Runs methods from AfterClass or BeforeClass 
    /// </summary>
    /// <param name="methods">Before or After class methods</param>
    /// <param name="tests">Test methods</param>
    /// <returns>Whether it's failed</returns>
    private bool RunMethods(List<MethodInfo> methods, List<MethodInfo> tests)
    {
        bool result = true;
        foreach (var method in methods)
        {
            try
            {
                method.Invoke(null, null);
            }
            catch (Exception)
            {
                foreach (var test in tests)
                {
                    ResultList.Add(new TestResult(test.Name, ResultState.Ignored, TimeSpan.Zero, "Before or After class method failed"));
                }
                result = false;
            }
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
                        if (method.ReturnType != typeof(void))
                        {
                            throw new InvalidOperationException("Test methods return type should be void");
                        }
                        methodsList.Test.Add(method);
                        break;
                    case AfterAttribute:
                        if (method.ReturnType != typeof(void))
                        {
                            throw new InvalidOperationException("After test methods return type should be void");
                        }
                        if (method.GetParameters().Length != 0)
                        {
                            throw new InvalidOperationException("After test methods shouldn't have any parameters");
                        }
                        methodsList.After.Add(method);
                        break;
                    case BeforeAttribute:
                        if (method.ReturnType != typeof(void))
                        {
                            throw new InvalidOperationException("Before test methods return type should be void");
                        }
                        if (method.GetParameters().Length != 0)
                        {
                            throw new InvalidOperationException("Before test methods shouldn't have any parameters");
                        }
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

using Attributes;
using System.Reflection;
using System.Diagnostics;

/// <summary>
/// MyNUnit testing class
/// </summary>
class MyNUnit
{
    List<TestResult> testsResult = new();

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="path">Directory path</param>
    public MyNUnit(string path)
    {
        var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
        var classes = files.Distinct()
            .Select(Assembly.Load)
            .SelectMany(a => a.ExportedTypes)
            .Where(t => t.IsClass);
        var testClasses = classes.Where(c => c.GetMethods().Any(m => m.GetCustomAttributes().Any(a => a is TestAttribute)));
        Parallel.ForEach(testClasses, StartTests);
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
        Parallel.ForEach(methods.Test, test => RunTest(test, testClass));
        RunMethods(methods.BeforeClass, methods.Test);
    }

    /// <summary>
    /// Runs methods from AfterClass or BeforeClass 
    /// </summary>
    /// <param name="methods">Before or After class methods</param>
    /// <param name="tests">Test methods</param>
    /// <returns>Whether it's failed</returns>
    private bool RunMethods(List<MethodInfo> methods, List<MethodInfo> tests)
    {
        try
        {
            Parallel.ForEach(methods, method => method.Invoke(null, null));
        }
        catch (Exception)
        {
            foreach (var test in tests)
            {
                testsResult.RemoveAll(t => t.Name == test.Name);
                testsResult.Add(new TestResult(test.Name, ResultState.Ignored, TimeSpan.Zero, "Before or After class method failed"));
            }
            return false;
        }
        return true;
    }

    /// <summary>
    /// Runs test
    /// </summary>
    /// <param name="method">Test method</param>
    /// <param name="testClass">Test method class</param>
    private void RunTest(MethodInfo method, Type testClass)
    {
        var properties = (TestAttribute?)method.GetCustomAttribute(typeof(TestAttribute));
        if (properties?.Ignore != null)
        {
            testsResult.Add(new TestResult(method.Name, ResultState.Ignored, TimeSpan.Zero, properties.Ignore));
            return;
        }

        var testClassInstance = Activator.CreateInstance(testClass);
        var stopwatch = new Stopwatch();
        //var result = ResultState.Passed;
        try
        {
            stopwatch.Start();
            method.Invoke(testClassInstance, null);
            stopwatch.Stop();
        }
        catch (Exception e)
        {
            stopwatch.Stop();
            var result = ResultState.Passed;
            if (properties?.Expected != null && e.InnerException != properties.Expected)
            {
                result = ResultState.Failed;
            }
            testsResult.Add(new TestResult(method.Name, result, stopwatch.Elapsed, null));
            return;
        }
        if (properties?.Expected != null)
        {
            //result = ResultState.Failed;
            testsResult.Add(new TestResult(method.Name, ResultState.Failed, stopwatch.Elapsed, null));
        }
    }

    /// <summary>
    /// Sorts methods by attributes
    /// </summary>
    /// <returns>Class containing lists</returns>
    private MethodsList SortByAttributes(Type testClass)
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
                        methodsList.AfterClass.Add(method);
                        break;
                    case BeforeClassAttribute:
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

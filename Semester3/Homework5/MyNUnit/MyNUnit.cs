using Attributes;
using System.Reflection;

/// <summary>
/// MyNUnit testing class
/// </summary>
class MyNUnit
{
   // List<TestInfo> testsResult;

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
        Parallel.ForEach(testClasses, t => StartTests(t));
    }

    private void StartTests(Type testClass)
    {
        var methods = SortByAttributes(testClass);
        //RunBeforeTestingClass()
        Parallel.ForEach(methods.Test, test => RunTest(test, testClass));
        //RunAfterTestingClass()
    }

    private void RunTest(MethodInfo method, Type testClass)
    {
        var properties = (TestAttribute?)method.GetCustomAttribute(typeof(TestAttribute));
        if (properties?.Ignore != null)
        {

        }
    }

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

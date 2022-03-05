using Attributes;
using System.Reflection;

namespace MyNUnit
{
    /// <summary>
    /// MyNUnit testing class
    /// </summary>
    class MyNUnit
    {
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

        /// <summary>
        /// Class for sorting methods by attributes
        /// </summary>
        private class MethodsList
        {
            public List<MethodInfo> After { get; } = new();
            public List<MethodInfo> AfterClass { get; } = new();
            public List<MethodInfo> Before { get; } = new();
            public List<MethodInfo> BeforeClass { get; } = new();
            public List<MethodInfo> Test { get; } = new();
        }
    }
}

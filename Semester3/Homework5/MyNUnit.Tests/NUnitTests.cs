using NUnit.Framework;
using System.Collections.Generic;

namespace MyNUnit.Tests;

public static class Tests
{
    private static bool Check(List<TestResult> result, List<(string, ResultState)> list)
    {
        bool areEqual = true;
        foreach (var item in result)
        {
            areEqual = list.Contains(new(item.Name, item.Result));
        }
        return areEqual;
    }

    [TestCase("..\\..\\..\\..\\TestProject\\bin")]
    public static void Test(string path)
    {
        var answer = new List<(string, ResultState)>
        {
            ("NoExceptionTest", ResultState.Failed),
            ("TestFromIgnoredTest", ResultState.Ignored),
            ("Ignored", ResultState.Ignored),
            ("Test1", ResultState.Passed),
            ("Test2", ResultState.Passed),
            ("MyTest", ResultState.Passed),
            ("NotMatchingExceptionsTest", ResultState.Failed),
            ("MatchingExceptionsTest", ResultState.Passed),
            ("TestFromFailingBeforeClass", ResultState.Ignored),
            ("TestFromBeforeTestFail", ResultState.Ignored),
            ("ExceptionTest", ResultState.Failed)
        };
        MyNUnitClass.RunTesting(path);
        Assert.IsTrue(Check(MyNUnitClass.ResultList, answer));
    }
}

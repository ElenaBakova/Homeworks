namespace TestProject;

using Attributes;

public class FailingBeforeClass
{
    [BeforeClass]
    public static void BeforeTestsMethod()
        => throw new Exception();

    private int a = 1;

    [Test]
    public void Test()
        => a++;
}
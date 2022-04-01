using Attributes;

namespace TestProject;

public class FailingBeforeClass
{
    [BeforeClass]
    public static void BeforeTestsMethod()
        => throw new Exception();

    private int a = 1;

    [Test]
    public void TestFromFailingBeforeClass()
        => a++;
}
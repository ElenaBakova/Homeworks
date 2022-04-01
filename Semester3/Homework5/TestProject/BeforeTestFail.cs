namespace TestProject;

using Attributes;

public class BeforeTestFail
{
    [Before]
    public void BeforeMethod()
        => throw new Exception();

    private int a = 1;

    [Test]
    public void TestFromBeforeTestFail()
        => a++;
}

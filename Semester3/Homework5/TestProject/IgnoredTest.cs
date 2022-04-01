namespace TestProject;

using Attributes;

public class IgnoredTest
{
    private int a = 1;

    [Test(Ignore = "Want to ignore it")]
    public void TestFromIgnoredTest()
        => a++;
}

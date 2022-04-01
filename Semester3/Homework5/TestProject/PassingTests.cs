using Attributes;

namespace TestProject;

public class PassingTests
{
    private static string myString;

    [BeforeClass]
    public static void BeforeTests()
        => myString = "Hello world!";

    [Test(Ignore = "No need")]
    public void Ignored()
        => myString.Concat("LL");

    [Test]
    public void Test1()
    {
        if (!myString.Contains("H"))
        {
            throw new Exception();
        }
    }

    [Test]
    public void Test2()
    {
        if (!myString.Contains("He"))
        {
            throw new Exception();
        }
    }

    [Test]
    public void MyTest()
    {
        if (myString.Length == 0)
        {
            throw new Exception();
        }
    }

    [AfterClass]
    public static void AfterTests()
    {
        if (myString != "Hello world!")
        {
            throw new Exception();
        }
    }
}

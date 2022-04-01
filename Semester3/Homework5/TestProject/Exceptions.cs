using Attributes;

namespace TestProject;

public class Exceptions
{
    private int a = 1;

    [Test(Expected = typeof(ArgumentNullException))]
    public void NoExceptionTest()
        => a++;

    [Test(Expected = typeof(ArgumentNullException))]
    public void NotMatchingExceptionsTest()
        => throw new ArgumentOutOfRangeException();

    [Test(Expected = typeof(ArgumentNullException))]
    public void MatchingExceptionsTest()
        => throw new ArgumentNullException();

    [Test]
    public void ExceptionTest()
        => throw new ArgumentException();
}
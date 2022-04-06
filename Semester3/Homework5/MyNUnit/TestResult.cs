namespace MyNUnit;

/// <summary>
/// Class for tests result information
/// </summary>
public class TestResult
{
    // Test name
    public string Name { get; }

    // Test result
    public ResultState Result { get; }

    // Time test taken
    public TimeSpan ElapsedTime { get; }

    // Reason of ignoring test
    public string? IgnoreReason { get; }

    public TestResult(string name, ResultState result, TimeSpan time, string? reason)
    {
        Name = name;
        Result = result;
        ElapsedTime = time;
        IgnoreReason = reason;
    }
}
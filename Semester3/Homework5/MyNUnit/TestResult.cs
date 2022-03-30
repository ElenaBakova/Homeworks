/// <summary>
/// Class for tests result information
/// </summary>
internal class TestResult
{
    public string Name { get; set; }
    public ResultState Result { get; set; }
    public TimeSpan ElapsedTime { get; set; }
    public string? IgnoreReason { get; set; }

    public TestResult(string name, ResultState result, TimeSpan time, string? reason)
    {
        Name = name;
        Result = result;
        ElapsedTime = time;
        IgnoreReason = reason;
    }
}
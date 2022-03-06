using System.Reflection;

/// <summary>
/// Class for sorting methods by attributes
/// </summary>
internal class MethodsList
{
    public List<MethodInfo> After { get; } = new();
    public List<MethodInfo> AfterClass { get; } = new();
    public List<MethodInfo> Before { get; } = new();
    public List<MethodInfo> BeforeClass { get; } = new();
    public List<MethodInfo> Test { get; } = new();
}

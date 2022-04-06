using System.Reflection;

namespace MyNUnit;

/// <summary>
/// Class for sorting methods by attributes
/// </summary>
internal class MethodsList
{
    // List of methods containing 'After' attribute
    public List<MethodInfo> After { get; } = new();

    // List of methods containing 'AfterClass' attribute
    public List<MethodInfo> AfterClass { get; } = new();

    // List of methods containing 'Before' attribute
    public List<MethodInfo> Before { get; } = new();

    // List of methods containing 'BeforeClass' attribute
    public List<MethodInfo> BeforeClass { get; } = new();

    // List of methods  containing 'Test' attribute
    public List<MethodInfo> Test { get; } = new();
}

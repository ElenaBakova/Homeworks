namespace Attributes;

/// <summary>
/// Test method attribute
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class TestAttribute : Attribute
{
    // Expected exception type
    public Type? Expected { get; set; }

    // Inore reason
    public string? Ignore { get; set; }
}
namespace Attributes;

/// <summary>
/// Test method attribute
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class TestAttribute : Attribute
{
    public TestAttribute()
    {

    }

    public Type? Expected { get; set; }

    public string? Ignore { get; set; }
}
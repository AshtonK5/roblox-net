
using System.Text.Json;

public class ApiDump
{
    public int? Version { get; set; }
    public List<ApiClass>? Classes { get; set; }
}

public class ApiClass
{
    public string? Name { get; set; }
    public string? SuperClass { get; set; }
    public List<ApiMember>? Members { get; set; }
}

public class ApiMember
{
    public string? MemberType { get; set; }
    public string? Name { get; set; }

    public ValueTypeInfo? ValueType { get; set; } // For properties
    public JsonElement? ReturnType { get; set; } // For functions/events
    public List<ApiParameter>? Parameters { get; set; } // For functions
    public List<JsonElement>? Tags { get; set; }
}


public class ApiParameter
{
    public string? Name { get; set; }
    public ValueTypeInfo? Type { get; set; }
    public bool Optional { get; set; }
}


public class ValueTypeInfo
{
    public string? Category { get; set; }
    public string? Name { get; set; }
}

public enum EAccesSpecifier
{
    Public,
    Private,
    Protected,
    File,
    Internal,
    None
}


public class InterfaceGenerator : BaseGenerator
{
    public override string Name { get; protected set; }

    public InterfaceGenerator(string name)
    {
        Name = name;
    }

    public override string Generate()
    {
        return "";
    }
}

public struct InterfaceDefinition
{
    public string Name { get; private set; }
    public object Object { get; private set; }

    public InterfaceDefinition(string name, object typeObject)
    {
        Name = name;
        Object = typeObject;
    }
}

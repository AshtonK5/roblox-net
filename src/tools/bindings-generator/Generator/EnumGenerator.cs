
public class EnumGenerator : BaseGenerator
{
    public override string Name { get; protected set; }
    public List<string> Enumerations { get; protected set; } = new List<string>();

    public EnumGenerator(string name)
    {
        Name = name;
    }

    public override string Generate()
    {
        return "";
    }
}

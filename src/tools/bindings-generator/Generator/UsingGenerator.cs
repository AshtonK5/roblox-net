
public class UsingGenerator : BaseGenerator
{
    public override string Name { get; protected set; }

    public override string Generate()
    {
        return $"using {Name};";
    }

    public UsingGenerator(string name)
    {
        Name = name;
    }
}

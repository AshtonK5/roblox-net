
public class DelegateGenerator : BaseGenerator
{
    public override string Name { get; protected set; }

    public DelegateGenerator(string methodName)
    {
        Name = methodName;
    }

    public override string Generate()
    {
        return "";
    }
}

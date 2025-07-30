
public abstract class BaseGenerator
{
    public abstract string Name { get; protected set; }
    public abstract string Generate();

    protected string Indent(string source, int spaces = 4)
    {
        string indent = new string(' ', spaces);
        return string.Join("\n", source
            .Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None)
            .Select(line => indent + line));
    }

}

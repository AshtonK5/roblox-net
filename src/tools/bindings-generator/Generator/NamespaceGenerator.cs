
using System.Text;

public class NamespaceGenerator : BaseGenerator
{
    public override string Name { get; protected set; }
    public NamespaceContents Contents { get; protected set; }

    public NamespaceGenerator(string name)
    {
        Name = name;
        Contents = new NamespaceContents();
    }

    public override string Generate()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append("namespace");
        stringBuilder.Append(" ");
        stringBuilder.Append(Name);

        stringBuilder.AppendLine();
        stringBuilder.AppendLine("{");

        // Render all clases
        foreach (var classGen in Contents.Classes)
        {
            stringBuilder.AppendLine(Indent(classGen.Generate()));
        }

        stringBuilder.AppendLine("}");

        return stringBuilder.ToString();
    }
}

public struct NamespaceContents
{
    public List<ClassGenerator> Classes { get; private set; } = new List<ClassGenerator>();

    public NamespaceContents()
    {

    }
}

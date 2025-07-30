
using System.Text;

public class ClassGenerator : BaseGenerator
{
    public override string Name { get; protected set; }
    public NamespaceGenerator? Namespace { get; private set; }
    public ClassGeneratorOptions Options;

    public ClassGenerator(string name, ClassGeneratorOptions options)
    {
        Name = name;
        Options = options;
    }

    public ClassGenerator(string name, NamespaceGenerator apartOfNamespace, ClassGeneratorOptions options)
    {
        Name = name;
        Namespace = apartOfNamespace;
        Options = options;
    }

    public override string Generate()
    {
        StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.AppendLine();

        string visibilitySpecifier = "";
        switch (Options.accesSpecifier)
        {
            case EAccesSpecifier.Internal:
                visibilitySpecifier = "internal";
                break;

            case EAccesSpecifier.Public:
                visibilitySpecifier = "public";
                break;

            case EAccesSpecifier.Protected:
                visibilitySpecifier = "protected";
                break;

            case EAccesSpecifier.Private:
                visibilitySpecifier = "private";
                break;

            case EAccesSpecifier.File:
                visibilitySpecifier = "file";
                break;
        }

        // Visiblity Specifier
        if (visibilitySpecifier != "")
        {
            stringBuilder.Append(visibilitySpecifier);
            stringBuilder.Append(" ");
        }

        // Options
        if (Options.isAbstract)
        {
            stringBuilder.Append("abstract");
            stringBuilder.Append(" ");
        }

        stringBuilder.Append("class");
        stringBuilder.Append(" ");
        stringBuilder.Append(Name);

        stringBuilder.AppendLine();
        stringBuilder.AppendLine("{");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("}");

        return stringBuilder.ToString();
    }
}

public struct ClassGeneratorOptions
{
    public bool isAbstract = false;
    public EAccesSpecifier accesSpecifier = EAccesSpecifier.None;

    public ClassGeneratorOptions()
    {

    }
}


using System.Text;

public class Generator
{
    private NamespaceGenerator RootNamespace;

    private List<ClassGenerator> Classes = new List<ClassGenerator>();
    private List<NamespaceGenerator> Namespaces = new List<NamespaceGenerator>();

    public Generator()
    {
        RootNamespace = RegisterNamespace("RobloxEngine");

    }

    public ClassGenerator RegisterClass(string name, ClassGeneratorOptions options, bool shouldWrapRootNamespace = true)
    {
        ClassGenerator generator = new ClassGenerator(name, options);

        if (shouldWrapRootNamespace)
        {
            RootNamespace.Contents.Classes.Add(generator);
        }
        else
        {
            Classes.Add(generator);
        }

        return generator;
    }

    public NamespaceGenerator RegisterNamespace(string name)
    {
        NamespaceGenerator namespaceGenerator = new NamespaceGenerator(name);

        Namespaces.Add(namespaceGenerator);

        return namespaceGenerator;
    }

    public void Parse(ApiDump apiDump)
    {
        if (apiDump.Classes != null)
        {
            // Create class
            foreach (ApiClass? cl in apiDump.Classes)
            {
                if (cl != null && cl.Name != null)
                {
                    RegisterClass(cl.Name, new ClassGeneratorOptions
                    {
                        isAbstract = true,
                        accesSpecifier = EAccesSpecifier.Public
                    });
                }
            }
        }
    }

    public string Render()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine();

        foreach (ClassGenerator generator in Classes)
        {
            stringBuilder.AppendLine(generator.Generate());
        }

        foreach (NamespaceGenerator generator in Namespaces)
        {
            stringBuilder.AppendLine(generator.Generate());
        }

        return stringBuilder.ToString();
    }
}

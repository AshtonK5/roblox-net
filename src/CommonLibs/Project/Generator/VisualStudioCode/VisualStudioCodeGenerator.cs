
namespace Common.Project;

public class VisualStudioCodeGenerator : Generator
{

    public VisualStudioCodeGenerator(string path) : base(path)
    {

    }

    public override void Generate()
    {
        ProjectFileSource = $$"""
            {
                "folders": [
                    { "path": "." }
                ]
            }
        """;

        base.Generate();
    }
}

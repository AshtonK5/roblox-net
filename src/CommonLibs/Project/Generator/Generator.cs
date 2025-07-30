
namespace Common.Project;

public abstract class Generator
{
    public string Name { get; private set; } = "";
    public string FilePath { get; private set; }

    protected string ProjectFileSource = "";

    public Generator(string path)
    {
        FilePath = path;

    }

    public virtual void Generate()
    {
        File.WriteAllText(FilePath, ProjectFileSource);
    }
}


namespace rbxnc.Build;

public abstract class SourceFile
{
    public string FilePath { get; private set; }

    public SourceFile(string path)
    {
        FilePath = path;

    }
}

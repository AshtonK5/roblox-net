
using System.CommandLine;
using rbxnc.Build;

public class RobloxCompilerProgram : RootCommand
{
    public RobloxCompilerProgram() : base("Rbxnc - Roblox Net Compiler (compiles C# -> Luau)")
    {
        Argument<string> pathToSource = new Argument<string>("sourceFile");

        Option<string> outputPath = new Option<string>("-o", "--out")
        {
            Required = true
        };

        Arguments.Add(pathToSource);
        Options.Add(outputPath);

        SetAction((parseResult) =>
            Execute(
                parseResult.GetValue<string>("sourceFile"),
                parseResult.GetValue<string>("-o")
            )
        );
    }

    private void Execute(string? path, string? output)
    {
        if (path != null && output != null)
        {
            CSSourceFile sourceFile = new CSSourceFile(path);
            sourceFile.Compile(output);
        }
    }

    public static int Main(string[] args)
    {
        RobloxCompilerProgram program = new RobloxCompilerProgram();
        var parseResult = program.Parse(args);

        return parseResult.Invoke();
    }
}

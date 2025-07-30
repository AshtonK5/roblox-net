using System.CommandLine;

public class RobloxNetProgram : RootCommand
{
    public RobloxNetProgram() : base("Roblox-net A C# to Luau Compiler For Roblox.")
    {
        Subcommands.Add(new NewCommand());
        Subcommands.Add(new BuildCommand());

    }

    public static int Main(string[] args)
    {
        RobloxNetProgram program = new RobloxNetProgram();

        var parseResult = program.Parse(args);
        return parseResult.Invoke();
    }
}

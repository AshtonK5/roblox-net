
using Common.Project;
using System.CommandLine;

public class NewCommand : Command
{
    public NewCommand() : base("new", "create a new roblox-net project")
    {
        Argument<string> pathArgument = new Argument<string>("path")
        {
            Description = "path to create project files in"

        };

        Argument<RobloxNetProjectOptions.ProjectType> projectType = new Argument<RobloxNetProjectOptions.ProjectType>("projectType")
        {
            Description = "type of project you want to create",
            DefaultValueFactory = (argResult) => RobloxNetProjectOptions.ProjectType.Game
        };

        Option<RobloxNetProjectOptions.GeneratorType> projectGenerator = new Option<RobloxNetProjectOptions.GeneratorType>("-G", "--Generator")
        {
            Description = "code editor project generator",
            Required = false
        };

        Arguments.Add(pathArgument);
        Arguments.Add(projectType);

        Options.Add(projectGenerator);

        SetAction((parseResult) =>
            Execute(
                parseResult.GetValue<string>("path"),
                parseResult.GetValue<RobloxNetProjectOptions.ProjectType>("projectType"),
                parseResult.GetValue<RobloxNetProjectOptions.GeneratorType>("-G")
        ));
    }

    private void Execute(
        string? path, 
        RobloxNetProjectOptions.ProjectType? projectType, 
        RobloxNetProjectOptions.GeneratorType? generator)
    {
        if (path != null && projectType != null)
        {
            RobloxNetProject robloxNetProject = new RobloxNetProject(path, new RobloxNetProjectOptions()
            {
                generator = generator ?? RobloxNetProjectOptions.GeneratorType.VisualStudioCode,
                projectType = (RobloxNetProjectOptions.ProjectType)projectType
            });

            robloxNetProject.GenerateProject();

        }
    }
}

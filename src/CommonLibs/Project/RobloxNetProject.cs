
namespace Common.Project
{
    public class RobloxNetProject : BaseProject
    {
        public RobloxNetProjectOptions ProjectOptions { get; private set; }

        public RobloxNetProject(string path) : base(path)
        {

        }

        public RobloxNetProject(string path, RobloxNetProjectOptions projectOptions) : base(path)
        {

        }

        public override void GenerateProject()
        {
            base.GenerateProject();

            DirectoryInfo projectDirectory = Directory.CreateDirectory(FilePath);

            switch (ProjectOptions.projectType)
            {

                // Project type 'Game'
                case RobloxNetProjectOptions.ProjectType.Game:
                    {
                        // Create project files
                        DirectoryInfo sourceDirectory = projectDirectory.CreateSubdirectory("./src");

                        DirectoryInfo clientDirectory = sourceDirectory.CreateSubdirectory("./Client");
                        DirectoryInfo serverDirectory = sourceDirectory.CreateSubdirectory("./Server");
                        DirectoryInfo sharedDirectory = sourceDirectory.CreateSubdirectory("./Shared");

                        File.WriteAllText($"{clientDirectory.FullName}/Main.client.cs", """"
                        using RobloxEngine;

                        public class GameClient
                        {
                            public static int Main()
                            {
                                Luau.Print("Hello, Client From CS!");
                                    
                                GameShared.Print();

                                return 0;
                            }
                        }
                        """");

                        File.WriteAllText($"{sharedDirectory.FullName}/Main.shared.cs", """"
                        using RobloxEngine;

                        public class GameShared
                        {
                            public static void Print()
                            {
                                Luau.Print("Hello, Shared From CS!");
                            }
                        }
                        """");

                        File.WriteAllText($"{serverDirectory.FullName}/Main.server.cs", """"
                        using RobloxEngine;

                        public class GameServer
                        {
                            public static int Main()
                            {
                                Luau.Print("Hello, Server From CS!");

                                GameShared.Print();

                                return 0;
                            }
                        }
                        """");

                        RojoProject generatedRojoProject = new RojoProject($"{projectDirectory.FullName}/default.project.json");
                        generatedRojoProject.GenerateProject();

                        break;
                    }
            }

            switch (ProjectOptions.generator)
            {
                case (RobloxNetProjectOptions.GeneratorType.VisualStudioCode):
                {
                    VisualStudioCodeGenerator generatedCodeWorkspace = new VisualStudioCodeGenerator($"{projectDirectory.FullName}/{projectDirectory.Name}.code-workspace");
                    generatedCodeWorkspace.Generate();
                    
                    break;
                }
            }
        }
    }

    public struct RobloxNetProjectOptions
    {
        public enum ProjectType
        {
            Game,
            Plugin,
            Package
        }

        public enum GeneratorType
        {
            VisualStudioCode,
            VisualStudio
        }

        public ProjectType projectType = ProjectType.Game;
        public GeneratorType generator = GeneratorType.VisualStudioCode;

        public RobloxNetProjectOptions()
        {

        }
    }
}

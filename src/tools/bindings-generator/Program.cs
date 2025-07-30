using System.Diagnostics;
using System.Text;
using System.Text.Json;

public class BindingsGeneratorProgram
{
    public static string APIDumpURL
    {
        get;
        private set;
    } = "https://raw.githubusercontent.com/MaximumADHD/Roblox-Client-Tracker/refs/heads/roblox/API-Dump.json";

    public static async Task<int> Main(string[] args)
    {
        Console.WriteLine("Generating Bindings...");
        Stopwatch stopwatch = Stopwatch.StartNew();
        using HttpClient client = new HttpClient();

        string generatedPath = "../../generated";
        string buildPath = $"{generatedPath}/build";

        Directory.CreateDirectory($"{buildPath}/logs");

        try
        {
            HttpResponseMessage response = await client.GetAsync(APIDumpURL);
            response.EnsureSuccessStatusCode(); // Throws if not 2xx

            string apiDumpJson = await response.Content.ReadAsStringAsync();
            ApiDump? apiDump = JsonSerializer.Deserialize<ApiDump>(apiDumpJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            if (apiDump != null)
            {
                Generator generator = new Generator();
                generator.Parse(apiDump);

                string robloxApi = generator.Render();
                
                DirectoryInfo generatedDirectory = Directory.CreateDirectory(generatedPath);
                DirectoryInfo buildDirectory = Directory.CreateDirectory(buildPath);

                // Write json to file for debugging
                await File.WriteAllTextAsync($"{buildPath}/robloxapidump.json", apiDumpJson);

                // Write to file
                await File.WriteAllTextAsync($"{buildPath}/RobloxEngine.generated.cs", robloxApi);

                // Create library project file
                await File.WriteAllTextAsync($"{buildPath}/generated.csproj", """
                <!-- THIS FILE IS GENERATED EDIT WITH CAUTION IT COULD MESS UP FINAL BUILD -->
                <Project Sdk="Microsoft.NET.Sdk">
                    <PropertyGroup>
                        <OutputType>Library</OutputType>
                        <TargetFramework>net9.0</TargetFramework>
                        <ImplicitUsings>enable</ImplicitUsings>
                        <Nullable>enable</Nullable>
                        <AssemblyName>RobloxEngine</AssemblyName>
                        <OutputPath>../out</OutputPath>
                    </PropertyGroup>
                    <ItemGroup>
                        <None Remove="generated.code-workspace" />
                        <None Remove="robloxapidump.json" />
                        <None Remove="logs\**" />
                        <None Remove="build\**" />
                        <None Remove="out\**" />
                    </ItemGroup>
                </Project>
                
                """);

                // Create vscode workspace (Mostly for crossplatform editing & Simplicity)
                await File.WriteAllTextAsync($"{buildPath}/generated.code-workspace", $$"""
                    {
                        "folders": [
                            { "path": "." }
                        ]
                    }
                """);
            }

            stopwatch.Stop();
            Console.WriteLine($"Bindings Generated Elapsed: ({stopwatch.Elapsed})");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Client Request Error: {e.Message}");
        }

        ProcessStartInfo buildStartInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
#if DEBUG
            Arguments = $"build {buildPath}/generated.csproj -c Debug",
#else
            Arguments = $"publish {buildPath}/generated.csproj -c Release -o ./generated/out/publish",
#endif
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };

        StringBuilder buildOutput = new StringBuilder();

        using Process process = new Process { StartInfo = buildStartInfo };
        process.OutputDataReceived += (sender, e) => { Console.WriteLine(e.Data); buildOutput.AppendLine(e.Data); };
        process.ErrorDataReceived += (sender, e) => { Console.Error.WriteLine(e.Data); buildOutput.AppendLine(e.Data); };

        Console.WriteLine("Building generated project..");
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Build failed with exit code: {process.ExitCode}");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Build succeeded.");
        }

        File.WriteAllText($"{buildPath}/logs/BuildOutput.txt", buildOutput.ToString());
        Console.WriteLine("Press any key to Exit.");
        Console.ReadKey();

        return 0;
    }
}

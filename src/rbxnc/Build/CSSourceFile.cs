
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.Text;

namespace rbxnc.Build;

public class CSSourceFile : SourceFile
{
    public CSSourceFile(string path) : base(path)
    {

    }

    public void Compile(string output)
    {
        if (File.Exists(FilePath))
        {
            var version = Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion ?? "unkown";

            var fileName = Path.GetFileNameWithoutExtension(FilePath);
            Console.WriteLine($"Compiling [{fileName}]...");

            var sourceCode = File.ReadAllText(FilePath);

            StringBuilder compiledSource = new StringBuilder();
            compiledSource.AppendLine($"--// Compiled with rbxnc v_{version}");
            compiledSource.AppendLine();

            SyntaxTree csharpSyntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            Console.WriteLine(csharpSyntaxTree.GetRoot());

            FileStream compiledOutput = File.Create($"{output}{fileName}.luau");
            compiledOutput.Close();

            File.WriteAllText(compiledOutput.Name, compiledSource.ToString());
        }
        else
        {
            throw new Exception($"File doesn't exist: {FilePath}");
        }
    }
}

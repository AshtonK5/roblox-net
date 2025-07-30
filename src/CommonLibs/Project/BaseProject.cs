
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Common.Project;

public abstract class BaseProject
{
    public string? Name { get; private set; }
    public string FilePath { get; private set; }

    public BaseProject(string path)
    {
        FilePath = path;

    }

    public virtual void GenerateProject()
    {

    }

    public bool CheckAftmanInstalled()
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "aftman",
                Arguments = "--version",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using var process = Process.Start(startInfo);
            process?.WaitForExit();

            return process?.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }

    public void PromptInstallAftman()
    {
        if (CheckAftmanInstalled()) return;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Aftman is not installed. Please install it via:");
        Console.WriteLine("winget install LPGhatguy.Aftman");
        Console.WriteLine("Or visit https://github.com/LPGhatguy/aftman");
        Console.ResetColor();

        Console.WriteLine("Would you like to download Aftman automatically? (using 'winget' or 'homebrew' must be installed first!) [Y/n]: ");

        var keyInstall = Console.ReadKey();

        // Return and don't run code under this if user doesn't want to download
        if (keyInstall.Key == ConsoleKey.N)
        {
            return;
        }

        // Try to auto-download using winget if not installed
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            try
            {
                Process? wingetProcess = Process.Start(new ProcessStartInfo()
                {
                    FileName = "winget",
                    Arguments = "install LPGhatguy.Aftman",
                    UseShellExecute = false
                });
                wingetProcess?.WaitForExit();

                if (wingetProcess != null)
                {
                    var exitCode = wingetProcess.ExitCode;

                    switch (exitCode)
                    {
                        // Success
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Aftman successfully installed.");
                            Console.ResetColor();
                            break;

                        // Error
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Aftman installation failed!");
                            Console.ResetColor();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error running winget: {e.Message}");
                Console.ResetColor();
            }
        }

        // Try to auto-download on Unix platforms using home-brew if installed
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) | RuntimeInformation.IsOSPlatform(OSPlatform.Linux) | RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
        {

        }
    }
}

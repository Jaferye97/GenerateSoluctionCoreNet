using System.Diagnostics;

namespace CoreNet8.Cli.Helpers;

public static class ProcessHelper
{
    // Executes a system command (e.g., dotnet CLI commands)
    public static void Run(string command, string arguments, string workingDir)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                WorkingDirectory = workingDir,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            }
        };

        process.Start();
        process.WaitForExit();
    }
}

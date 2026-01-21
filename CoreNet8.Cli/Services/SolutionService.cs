namespace CoreNet8.Cli.Services;

public class SolutionService
{
    // Contains business logic for solution creation
    public void Create(string rootPath, string solutionName)
    {
        Directory.CreateDirectory(rootPath);

        // Delegates OS execution to ProcessService
        ProcessService.Run(
            "dotnet",
            $"new sln -n {solutionName}",
            rootPath
        );
    }
}

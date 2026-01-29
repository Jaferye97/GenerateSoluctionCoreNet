namespace CoreNet8.Cli.Helpers;

public class SolutionHelper
{
    // Contains business logic for solution creation
    public void Create(string rootPath, string solutionName)
    {
        Directory.CreateDirectory(rootPath);

        // Delegates OS execution to ProcessService
        ProcessHelper.Run(
            "dotnet",
            $"new sln -n {solutionName}",
            rootPath
        );
    }
}

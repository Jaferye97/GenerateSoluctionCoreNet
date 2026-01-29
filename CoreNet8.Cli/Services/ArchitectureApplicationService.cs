using CoreNet8.Cli.Helpers;

namespace CoreNet8.Cli.Services;

public class ArchitectureApplicationService
{
    private static void CreateBaseProject(string rootPath)
    {
        Console.WriteLine();

        // Create Application project
        ProjectHelper.RunDotNetCommand(rootPath, "new classlib -n Application -f net8.0");

        // Add Application project to solution
        ProjectHelper.RunDotNetCommand(rootPath, "sln add Application/Application.csproj");

        // Create SubDirectory Ports/Persistence
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(rootPath, "Application/Ports/Persistence"));

        // Create SubDirectory Ports/RepositoryEntityFrameworkSqlServer
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(rootPath, "Application/Ports/RepositoryEntityFrameworkSqlServer"));

        // Create SubDirectory Commons
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(rootPath, "Application/Commons"));

        // Create SubDirectory Services
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(rootPath, "Application/Services"));

        // Create SubDirectory Features
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(rootPath, "Application/Features"));

        Console.WriteLine("🛠️  (Application) Build");
        Console.WriteLine("     ⚙️  Base project created");
    }

    private static void CreateClasses(string rootPath)
    {
        Console.WriteLine();

        // GlobalUsings.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            "Application",
            "GlobalUsings.cs",
            Path.Combine("Templates", "ArchitectureApplication", "GlobalUsings.cs.txt")
        );

        // Commons/Result.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine("Application", "Commons"),
            "Result.cs",
            Path.Combine("Templates", "ArchitectureApplication", "Commons", "Result.cs.txt")
        );

        // Application/Commons/ResultType.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine("Application", "Commons"),
            "ResultType.cs",
            Path.Combine("Templates", "ArchitectureApplication", "Commons", "ResultType.cs.txt")
        );

        // Application/Ports/Persistence/IUnitOfWork.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine("Application", "Ports", "Persistence"),
            "IUnitOfWork.cs",
            Path.Combine("Templates", "ArchitectureApplication", "Ports", "Persistence", "IUnitOfWork.cs.txt")
        );

        Console.WriteLine("     ✅ (Application) Classes created");
    }

    private static void RemoveUnnecessaryFiles(string rootPath)
    {
        Console.WriteLine();

        // Remove default Class1.cs
        ProjectHelper.DeleteFileIfExists(Path.Combine(rootPath, "Application/Class1.cs"));

        // Remove .gitkeep from Commons
        ProjectHelper.DeleteFileIfExists(Path.Combine(rootPath, "Application/Commons/.gitkeep"));

        // Remove .gitkeep from Persistence
        ProjectHelper.DeleteFileIfExists(Path.Combine(rootPath, "Application/Ports/Persistence/.gitkeep"));

        Console.WriteLine("     ♻️  (Application) Unnecessary files removed");
    }

    public void CreateArchitectureBaseProject(string rootPath)
    {
        Console.WriteLine();
        CreateBaseProject(rootPath);
        CreateClasses(rootPath);
        RemoveUnnecessaryFiles(rootPath);
    }
}

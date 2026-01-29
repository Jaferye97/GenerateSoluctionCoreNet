using CoreNet8.Cli.Helpers;

namespace CoreNet8.Cli.Services;

public class ArchitectureDomainService
{
    private static void CreateBaseProject(string rootPath)
    {
        Console.WriteLine();

        // Create Domain project
        ProjectHelper.RunDotNetCommand(rootPath, "new classlib -n Domain -f net8.0");

        // Add Domain project to solution
        ProjectHelper.RunDotNetCommand(rootPath, "sln add Domain/Domain.csproj");

        // Create SubDirectory
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(rootPath, "Domain/Models/Commons"));

        Console.WriteLine("🛠️  (Domain) Build");
        Console.WriteLine("     ⚙️  Base project created");
    }

    private static void CreateClasses(string rootPath)
    {
        Console.WriteLine();

        // GlobalUsings.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            "Domain",
            "GlobalUsings.cs",
            Path.Combine("Templates", "ArchitectureDomain", "GlobalUsings.cs.txt")
        );

        // FilterModel.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine("Domain", "Models", "Commons"),
            "FilterModel.cs",
            Path.Combine("Templates", "ArchitectureDomain", "Models", "Commons", "FilterModel.cs.txt")
        );

        // PagedResultModel.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine("Domain", "Models", "Commons"),
            "PagedResultModel.cs",
            Path.Combine("Templates", "ArchitectureDomain", "Models", "Commons", "PagedResultModel.cs.txt")
        );

        Console.WriteLine("     ✅ (Domain) Classes created");
    }

    private static void RemoveUnnecessaryFiles(string rootPath)
    {
        Console.WriteLine();

        // Remove default Class1.cs
        ProjectHelper.DeleteFileIfExists(Path.Combine(rootPath, "Domain/Class1.cs"));

        // Remove .gitkeep from Commons
        ProjectHelper.DeleteFileIfExists(Path.Combine(rootPath, "Domain/Models/Commons/.gitkeep"));

        Console.WriteLine("     ♻️  (Domain) Unnecessary files removed");
    }

    public void CreateArchitectureBaseProject(string rootPath)
    {
        Console.WriteLine();
        CreateBaseProject(rootPath);
        CreateClasses(rootPath);
        RemoveUnnecessaryFiles(rootPath);
    }
}


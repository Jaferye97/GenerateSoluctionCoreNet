namespace CoreNet8.Cli.Services;

public class ArchitectureDomainService
{
    private static void CreateBaseProject(string rootPath)
    {
        Console.WriteLine();

        // Create Domain project
        ProcessService.Run(
            "dotnet",
            $"new classlib -n Domain -f net8.0",
            rootPath
        );

        // Add Domain project to solution
        ProcessService.Run(
            "dotnet",
            $"sln add Domain/Domain.csproj",
            rootPath
        );

        // Create SubDirectory
        var modelsCommonsPath = Path.Combine(rootPath, "Domain/Models/Commons");
        var gitKeepPath = Path.Combine(modelsCommonsPath, ".gitkeep");

        Directory.CreateDirectory(modelsCommonsPath);
        File.WriteAllText(gitKeepPath, string.Empty);

        Console.WriteLine("🛠️  (Domain) Build");
        Console.WriteLine("     ⚙️  Base project created");
    }

    private static void CreateClasses(string rootPath)
    {
        Console.WriteLine();

        // Read content GlobalUsings.cs.txt
        string contentGlobalUsing =
            File.ReadAllText(
                Path.Combine("Templates/ArchitectureDomain", "GlobalUsings.cs.txt")
            );

        // Create class GlobalUsings.cs
        File.WriteAllText(
            Path.Combine(
                rootPath,
                "Domain",
                "GlobalUsings.cs"
            ),
            contentGlobalUsing
        );

        Console.WriteLine("     📄 (Domain) GlobalUsings.cs created");

        var filePathBaseModelCommons = Path.Combine("Domain", "Models", "Commons");

        var filterModelFilePath =
            Path.Combine(
                rootPath,
                filePathBaseModelCommons,
                "FilterModel.cs"
            );

        // Read content FilterModel.cs.txt
        string contentFilterModel =
            File.ReadAllText(
                Path.Combine("Templates",
                    "ArchitectureDomain",
                    "Models",
                    "Commons",
                    "FilterModel.cs.txt"
                )
            );

        // Create class FilterModel.cs
        File.WriteAllText(
            filterModelFilePath,
            contentFilterModel
        );

        Console.WriteLine("     📄 (Domain/Models/Commons) FilterModel.cs created");

        var pagedResultModelFilePath =
            Path.Combine(
                rootPath,
                filePathBaseModelCommons,
                "PagedResultModel.cs"
            );

        // Read content PagedResultModel.cs.txt
        string contentPagedResultModel =
            File.ReadAllText(
                Path.Combine("Templates",
                    "ArchitectureDomain",
                    "Models",
                    "Commons",
                    "PagedResultModel.cs.txt"
                )
            );

        // Create class PagedResultModel.cs
        File.WriteAllText(
            pagedResultModelFilePath,
            contentPagedResultModel
        );

        Console.WriteLine("     📄 (Domain/Models/Commons) PagedResultModel.cs created");

        Console.WriteLine("     ✅ (Domain) Classes created");
    }

    private static void RemovedFiles(string rootPath)
    {
        Console.WriteLine();

        File.Delete(
                    Path.Combine(
                        rootPath,
                        "Domain",
                        "Class1.cs"
                    )
                );

        File.Delete(
            Path.Combine(
                rootPath,
                "Domain/Models/Commons",
                ".gitkeep"
            )
        );

        Console.WriteLine("     ♻️  (Domain) Unnecessary files removed");
    }

    public void CreateArchitectureBaseProject(string rootPath)
    {
        Console.WriteLine();
        CreateBaseProject(rootPath);
        CreateClasses(rootPath);
        RemovedFiles(rootPath);
    }
}


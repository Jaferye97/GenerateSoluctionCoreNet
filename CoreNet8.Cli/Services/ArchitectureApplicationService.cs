namespace CoreNet8.Cli.Services;

public class ArchitectureApplicationService
{
    private static void CreateBaseProject(string rootPath)
    {
        Console.WriteLine();

        // Create Application project
        ProcessService.Run(
            "dotnet",
            $"new classlib -n Application -f net8.0",
            rootPath
        );

        // Add Application project to solution
        ProcessService.Run(
            "dotnet",
            $"sln add Application/Application.csproj",
            rootPath
        );

        // Create SubDirectory Ports/Persistence
        var portsPersistencePath = Path.Combine(rootPath, "Application/Ports/Persistence");

        Directory.CreateDirectory(portsPersistencePath);
        File.WriteAllText(Path.Combine(portsPersistencePath, ".gitkeep"), string.Empty);

        // Create SubDirectory Ports/RepositoryEntityFrameworkSqlServer
        var portsRepositoryEntityFrameworkSqlServerPath = Path.Combine(rootPath, "Application/Ports/RepositoryEntityFrameworkSqlServer");

        Directory.CreateDirectory(portsRepositoryEntityFrameworkSqlServerPath);
        File.WriteAllText(Path.Combine(portsRepositoryEntityFrameworkSqlServerPath, ".gitkeep"), string.Empty);

        // Create SubDirectory Commons
        var commonsPath = Path.Combine(rootPath, "Application/Commons");

        Directory.CreateDirectory(commonsPath);
        File.WriteAllText(Path.Combine(commonsPath, ".gitkeep"), string.Empty);

        // Create SubDirectory Services
        var servicesPath = Path.Combine(rootPath, "Application/Services");

        Directory.CreateDirectory(servicesPath);
        File.WriteAllText(Path.Combine(servicesPath, ".gitkeep"), string.Empty);

        // Create SubDirectory UseCases
        var useCasesPath = Path.Combine(rootPath, "Application/UseCases");

        Directory.CreateDirectory(useCasesPath);
        File.WriteAllText(Path.Combine(useCasesPath, ".gitkeep"), string.Empty);

        Console.WriteLine("🛠️  (Application) Build");
        Console.WriteLine("     ⚙️  Base project created");
    }

    private static void CreateClasses(string rootPath)
    {
        Console.WriteLine();

        // Read content GlobalUsings.cs.txt
        string contentGlobalUsing =
            File.ReadAllText(
                Path.Combine("Templates/ArchitectureApplication", "GlobalUsings.cs.txt")
            );

        // Create class GlobalUsings.cs
        File.WriteAllText(
            Path.Combine(
                rootPath,
                "Application",
                "GlobalUsings.cs"
            ),
            contentGlobalUsing
        );

        Console.WriteLine("     📄 (Application) GlobalUsings.cs created");

        var resultCommonsFilePath =
            Path.Combine(
                rootPath,
                "Application/Commons",
                "Result.cs"
            );

        // Read content Result.cs.txt
        string resultCommonsContent =
            File.ReadAllText(
                Path.Combine("Templates/ArchitectureApplication", "Commons", "Result.cs.txt")
            );

        // Create class Result.cs
        File.WriteAllText(
            resultCommonsFilePath,
            resultCommonsContent
        );

        Console.WriteLine("     📄 (Application/Commons) Result.cs created");

        var resultTypeCommonsFilePath =
            Path.Combine(
                rootPath,
                "Application/Commons",
                "ResultType.cs"
            );

        // Read content ResultType.cs.txt
        string resultTypeCommonsContent =
            File.ReadAllText(
                Path.Combine("Templates/ArchitectureApplication", "Commons", "ResultType.cs.txt")
            );

        // Create class ResultType.cs
        File.WriteAllText(
            resultTypeCommonsFilePath,
            resultTypeCommonsContent
        );

        Console.WriteLine("     📄 (Application/Commons) Result.cs created");

        var unitOfWorkFilePath = 
            Path.Combine(
                rootPath,
                "Application/Ports/Persistence",
                "IUnitOfWork.cs"
            );

        // Read content IUnitOfWork.cs.txt
        string contentIUnitOfWork = 
            File.ReadAllText(
                Path.Combine("Templates/ArchitectureApplication", "Ports", "Persistence", "IUnitOfWork.cs.txt")
            );

        // Create class IUnitOfWork.cs
        File.WriteAllText(
            unitOfWorkFilePath,
            contentIUnitOfWork
        );

        Console.WriteLine("     📄 (Application/Ports/Persistence) IUnitOfWork.cs created");

        Console.WriteLine("     ✅ (Application) Classes created");
    }

    private static void RemovedFiles(string rootPath)
    {
        Console.WriteLine();

        File.Delete(
            Path.Combine(
                rootPath,
                "Application",
                "Class1.cs"
            )
        );

        File.Delete(
            Path.Combine(
                rootPath,
                "Application/Commons",
                ".gitkeep"
            )
        );

        File.Delete(
            Path.Combine(
                rootPath,
                "Application/Ports/Persistence",
                ".gitkeep"
            )
        );

        Console.WriteLine("     ♻️  (Application) Unnecessary files removed");
    }

    public void CreateArchitectureBaseProject(string rootPath)
    {
        Console.WriteLine();
        CreateBaseProject(rootPath);
        CreateClasses(rootPath);
        RemovedFiles(rootPath);
    }
}



namespace CoreNet8.Cli.Services;

public class ArchitectureInfrastructureService
{
    public static void CreateBaseProjectInfrastructure(string rootPath)
    {
        Console.WriteLine();

        // Create Directory
        var infraPath = Path.Combine(rootPath, "Infrastructure");
        Directory.CreateDirectory(infraPath);

        // Create SubDirectory
        Directory.CreateDirectory(Path.Combine(infraPath, "Adapters"));
        Directory.CreateDirectory(Path.Combine(infraPath, "Adapters", "In"));
        Directory.CreateDirectory(Path.Combine(infraPath, "Adapters", "Out"));

        // Create WebApi project
        var webApiPath = Path.Combine(infraPath, "Adapters", "In");

        ProcessService.Run(
            "dotnet",
            $"new webapi -n WebApi -f net8.0",
            webApiPath
        );

        // Create RepositoryEntityFrameworkSqlServer project
        var repositoryEntityFrameworkSqlServerPath = Path.Combine(infraPath, "Adapters", "Out");

        ProcessService.Run(
            "dotnet",
            $"new classlib -n RepositoryEntityFrameworkSqlServer -f net8.0",
            repositoryEntityFrameworkSqlServerPath
        );

        // Add WebApi project to solution
        ProcessService.Run(
            "dotnet",
            $"sln add Infrastructure/Adapters/In/WebApi/WebApi.csproj",
            rootPath
        );

        // Create SubDirectory WebApi/Extensions/DependencyInjection
        var extensionsDependencyInjectionPath = Path.Combine(rootPath, "Infrastructure/Adapters/In/WebApi/Extensions/DependencyInjection");

        Directory.CreateDirectory(extensionsDependencyInjectionPath);
        File.WriteAllText(Path.Combine(extensionsDependencyInjectionPath, ".gitkeep"), string.Empty);

        // Create SubDirectory WebApi/Mapping
        var extensionsMappingPath = Path.Combine(rootPath, "Infrastructure/Adapters/In/WebApi/Mapping");

        Directory.CreateDirectory(extensionsMappingPath);
        File.WriteAllText(Path.Combine(extensionsMappingPath, ".gitkeep"), string.Empty);

        // Add RepositoryEntityFrameworkSqlServer project to solution
        ProcessService.Run(
            "dotnet",
            $"sln add Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/RepositoryEntityFrameworkSqlServer.csproj",
            rootPath
        );

        // Create SubDirectory RepositoryEntityFrameworkSqlServer/Context
        var contextRepositoryEntityFrameworkSqlServerPath = Path.Combine(rootPath, "Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Context");

        Directory.CreateDirectory(contextRepositoryEntityFrameworkSqlServerPath);
        File.WriteAllText(Path.Combine(contextRepositoryEntityFrameworkSqlServerPath, ".gitkeep"), string.Empty);

        // Create SubDirectory RepositoryEntityFrameworkSqlServer/Entities/Constants
        var entitiesRepositoryEntityFrameworkSqlServerPath = Path.Combine(rootPath, "Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Entities/Constants");

        Directory.CreateDirectory(entitiesRepositoryEntityFrameworkSqlServerPath);
        File.WriteAllText(Path.Combine(entitiesRepositoryEntityFrameworkSqlServerPath, ".gitkeep"), string.Empty);

        // Create SubDirectory RepositoryEntityFrameworkSqlServer/Mappers
        var mappersRepositoryEntityFrameworkSqlServerPath = Path.Combine(rootPath, "Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Mappers");

        Directory.CreateDirectory(mappersRepositoryEntityFrameworkSqlServerPath);
        File.WriteAllText(Path.Combine(mappersRepositoryEntityFrameworkSqlServerPath, ".gitkeep"), string.Empty);

        // Create SubDirectory RepositoryEntityFrameworkSqlServer/Repositories
        var repositoriesRepositoryEntityFrameworkSqlServerPath = Path.Combine(rootPath, "Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Repositories/Implementations");

        Directory.CreateDirectory(repositoriesRepositoryEntityFrameworkSqlServerPath);
        File.WriteAllText(Path.Combine(repositoriesRepositoryEntityFrameworkSqlServerPath, ".gitkeep"), string.Empty);

        // Create SubDirectory RepositoryEntityFrameworkSqlServer/Persistence
        var persistenceRepositoryEntityFrameworkSqlServerPath = Path.Combine(rootPath, "Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Persistence/EntityFramework");

        Directory.CreateDirectory(persistenceRepositoryEntityFrameworkSqlServerPath);
        File.WriteAllText(Path.Combine(persistenceRepositoryEntityFrameworkSqlServerPath, ".gitkeep"), string.Empty);

        Console.WriteLine("🛠️  (Infrastructure) Build");
        Console.WriteLine("     ⚙️  Base project created");
    }

    private static void CreateClassBaseProjectAdaptersInWebApi(string rootPath)
    {
        Console.WriteLine();

        var filePathBase = Path.Combine(rootPath, "Infrastructure", "Adapters", "In", "WebApi");
        var templatesPathBase = Path.Combine("Templates", "ArchitectureInfrastructure", "Adapters", "In", "WebApi");

        // Read content GlobalUsings.cs.txt
        string contentGlobalUsing =
            File.ReadAllText(
                Path.Combine(templatesPathBase, "GlobalUsings.cs.txt")
            );

        // Create class GlobalUsings.cs
        File.WriteAllText(
            Path.Combine(
                filePathBase,
                "GlobalUsings.cs"
            ),
            contentGlobalUsing
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/In/WebApi) GlobalUsings.cs created");

        // Read content Program.cs.txt
        string programContent =
            File.ReadAllText(
                Path.Combine(templatesPathBase, "Program.cs.txt")
            );

        // Create class Program.cs
        File.WriteAllText(
            Path.Combine(
                filePathBase,
                "Program.cs"
            ),
            programContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/In/WebApi) Program.cs edited");

        var resultExtensionsFilePath =
            Path.Combine(
                filePathBase,
                "Extensions",
                "ResultExtensions.cs"
            );

        // Read content /Extensions/ResultExtensionsFilePath.cs.txt
        string resultExtensionsContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Extensions",
                    "ResultExtensions.cs.txt"
                )
            );

        // Create class /Extensions/DependencyInjection/ResultExtensionsFilePath.cs
        File.WriteAllText(
            resultExtensionsFilePath,
            resultExtensionsContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/In/WebApi/Extensions) ResultExtensions.cs created");

        var CqrsExtensionsFilePath =
            Path.Combine(
                filePathBase,
                "Extensions",
                "DependencyInjection",
                "CqrsExtensions.cs"
            );

        // Read content /Extensions/DependencyInjection/CqrsExtensions.cs.txt
        string CqrsExtensionsContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Extensions",
                    "DependencyInjection",
                    "CqrsExtensions.cs.txt"
                )
            );

        // Create class /Extensions/DependencyInjection/CqrsExtensions.cs
        File.WriteAllText(
            CqrsExtensionsFilePath,
            CqrsExtensionsContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/In/WebApi/Extensions/DependencyInjection) CqrsExtensions.cs created");

        var corsExtensionsFilePath =
            Path.Combine(
                filePathBase,
                "Extensions",
                "DependencyInjection",
                "CorsExtensions.cs"
            );

        // Read content /Extensions/DependencyInjection/CorsExtensions.cs.txt
        string corsExtensionsContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Extensions", 
                    "DependencyInjection",
                    "CorsExtensions.cs.txt"
                )
            );

        // Create class /Extensions/DependencyInjection/CorsExtensions.cs
        File.WriteAllText(
            corsExtensionsFilePath,
            corsExtensionsContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/In/WebApi/Extensions/DependencyInjection) CorsExtensions.cs created");

        var infrastructureExtensionsFilePath =
            Path.Combine(
                filePathBase,
                "Extensions",
                "DependencyInjection",
                "InfrastructureExtensions.cs"
            );

        // Read content /Extensions/DependencyInjection/InfrastructureExtensions.cs.txt
        string infrastructureExtensionsContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Extensions",
                    "DependencyInjection",
                    "InfrastructureExtensions.cs.txt"
                )
            );

        // Create class /Extensions/DependencyInjection/InfrastructureExtensions.cs
        File.WriteAllText(
            infrastructureExtensionsFilePath,
            infrastructureExtensionsContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/In/WebApi/Extensions/DependencyInjection) InfrastructureExtensions.cs created");

        var repositoryPortsExtensionsFilePath =
            Path.Combine(
                filePathBase,
                "Extensions",
                "DependencyInjection",
                "RepositoryPortsExtensions.cs"
            );

        // Read content /Extensions/DependencyInjection/RepositoryPortsExtensions.cs.txt
        string repositoryPortsExtensionsContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Extensions",
                    "DependencyInjection",
                    "RepositoryPortsExtensions.cs.txt"
                )
            );

        // Create class /Extensions/DependencyInjection/RepositoryPortsExtensions.cs
        File.WriteAllText(
            repositoryPortsExtensionsFilePath,
            repositoryPortsExtensionsContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/In/WebApi/Extensions/DependencyInjection) RepositoryPortsExtensions.cs created");

        var fluentValidationExtensionsExtensionsFilePath =
            Path.Combine(
                filePathBase,
                "Extensions",
                "DependencyInjection",
                "FluentValidationExtensions.cs"
            );

        // Read content /Extensions/DependencyInjection/FluentValidationExtensions.cs.txt
        string fluentValidationExtensionsContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Extensions",
                    "DependencyInjection",
                    "FluentValidationExtensions.cs.txt"
                )
            );

        // Create class /Extensions/DependencyInjection/FluentValidationExtensions.cs
        File.WriteAllText(
            fluentValidationExtensionsExtensionsFilePath,
            fluentValidationExtensionsContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/In/WebApi/Extensions/DependencyInjection) FluentValidationExtensions.cs created");

        var swaggerExtensionsFilePath =
            Path.Combine(
                filePathBase,
                "Extensions",
                "DependencyInjection",
                "SwaggerExtensions.cs"
            );

        // Read content /Extensions/DependencyInjection/SwaggerExtensions.cs.txt
        string swaggerExtensionsContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Extensions",
                    "DependencyInjection",
                    "SwaggerExtensions.cs.txt"
                )
            );

        // Create class /Extensions/DependencyInjection/SwaggerExtensions.cs
        File.WriteAllText(
            swaggerExtensionsFilePath,
            swaggerExtensionsContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/In/WebApi/Extensions/DependencyInjection) SwaggerExtensions.cs created");

        Console.WriteLine("     ✅ (Infrastructure/Adapters/In/WebApi) Classes created");
    }

    private static void CreateClassesAdaptersOutRepositoryEntityFrameworkSqlServer(string rootPath)
    {
        Console.WriteLine();

        var filePathBase = Path.Combine("Infrastructure", "Adapters", "Out", "RepositoryEntityFrameworkSqlServer");
        var templatesPathBase = Path.Combine("Templates", "ArchitectureInfrastructure", "Adapters", "Out", "RepositoryEntityFrameworkSqlServer");

        // Read content GlobalUsings.cs.txt
        string contentGlobalUsing =
            File.ReadAllText(
                Path.Combine(templatesPathBase, "GlobalUsings.cs.txt")
            );

        // Create class GlobalUsings.cs
        File.WriteAllText(
            Path.Combine(
                rootPath,
                filePathBase,
                "GlobalUsings.cs"
            ),
            contentGlobalUsing
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer) GlobalUsings.cs created");

        var entityDbContextFilePath =
            Path.Combine(
                rootPath,
                filePathBase,
                "Context",
                "EntityDbContext.cs"
            );

        // Read content /Context/EntityDbContext.cs.txt
        string entityDbContextContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Context",
                    "EntityDbContext.cs.txt"
                )
            );

        // Create class /Context/EntityDbContext.cs
        File.WriteAllText(
            entityDbContextFilePath,
            entityDbContextContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Context) EntityDbContext.cs created");

        var iEntityFilePath =
            Path.Combine(
                rootPath,
                filePathBase,
                "Entities",
                "Constants",
                "IEntity.cs"
            );

        // Read content /Entities/Constants/IEntity.cs.txt
        string iEntityContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Entities",
                    "Constants",
                    "IEntity.cs.txt"
                )
            );

        // Create class /Entities/Constants/IEntity.cs
        File.WriteAllText(
            iEntityFilePath,
            iEntityContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Entities/Constants) IEntity.cs created");

        var persistenceFilePath =
            Path.Combine(
                rootPath,
                filePathBase,
                "Persistence",
                "EntityFramework",
                "UnitOfWork.cs"
            );

        // Read content /Persistence/EntityFramework/UnitOfWork.cs.txt
        string persistenceContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Persistence",
                    "EntityFramework",
                    "UnitOfWork.cs.txt"
                )
            );

        // Create class /Entities/Constants/IEntity.cs
        File.WriteAllText(
            persistenceFilePath,
            persistenceContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Persistence/EntityFramework) UnitOfWork.cs created");

        var baseRepositoryFilePath =
            Path.Combine(
                rootPath,
                filePathBase,
                "Repositories",
                "IBaseRepository.cs"
            );

        // Read content /Repositories/IBaseRepository.cs.txt
        string baseRepositoryContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Repositories",
                    "IBaseRepository.cs.txt"
                )
            );

        // Create class /Repositories/IBaseRepository.cs
        File.WriteAllText(
            baseRepositoryFilePath,
            baseRepositoryContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Repositories) IBaseRepository.cs created");

        var baseRepositoryImplementationsFilePath =
            Path.Combine(
                rootPath,
                filePathBase,
                "Repositories",
                "Implementations",
                "BaseRepository.cs"
            );

        // Read content /Repositories/BaseRepository.cs.txt
        string baseRepositoryImplementationsContent =
            File.ReadAllText(
                Path.Combine(
                    templatesPathBase,
                    "Repositories",
                    "Implementations",
                    "BaseRepository.cs.txt"
                )
            );

        // Create class /Repositories/Implementations/BaseRepository.cs
        File.WriteAllText(
            baseRepositoryImplementationsFilePath,
            baseRepositoryImplementationsContent
        );

        Console.WriteLine("     📄 (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Repositories/Implementations) BaseRepository.cs created");

        Console.WriteLine("     ✅ (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer) Classes created");
    }

    private static void RemovedFiles(string rootPath)
    {
        Console.WriteLine();

        var filePathBase = Path.Combine("Infrastructure", "Adapters");
        var filePathBaseOutRepositoryEntityFrameworkSqlServer = Path.Combine(rootPath, filePathBase, "Out", "RepositoryEntityFrameworkSqlServer");
        var filePathBaseInWebApi = Path.Combine(rootPath, filePathBase, "In", "WebApi");

        // (Infrastructure/Adapters/In/WebApi)
        File.Delete(
            Path.Combine(
                filePathBaseInWebApi,
                "Extensions",
                "DependencyInjection",
                ".gitkeep"
            )
        );

        Console.WriteLine("     ♻️  (Infrastructure/Adapters/In/WebApi) Unnecessary files removed");

        // (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer)
        File.Delete(
            Path.Combine(
                filePathBaseOutRepositoryEntityFrameworkSqlServer,
                "Class1.cs"
            )
        );

        File.Delete(
            Path.Combine(
                filePathBaseOutRepositoryEntityFrameworkSqlServer,
                "Context",
                ".gitkeep"
            )
        );

        File.Delete(
           Path.Combine(
               filePathBaseOutRepositoryEntityFrameworkSqlServer,
               "Entities",
               "Constants",
               ".gitkeep"
           )
       );

        File.Delete(
            Path.Combine(
                filePathBaseOutRepositoryEntityFrameworkSqlServer,
                "Persistence",
                "EntityFramework",
                ".gitkeep"
            )
        );

        File.Delete(
            Path.Combine(
                filePathBaseOutRepositoryEntityFrameworkSqlServer,
                "Repositories",
                "Implementations",
                ".gitkeep"
            )
        );

        Console.WriteLine("     ♻️  (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer) Unnecessary files removed");

        Console.WriteLine("     ♻️  (Application) Unnecessary files removed");
    }

    public void CreateArchitectureBaseProject(string rootPath)
    {
        Console.WriteLine();
        CreateBaseProjectInfrastructure(rootPath);

        CreateClassBaseProjectAdaptersInWebApi(rootPath);
        CreateClassesAdaptersOutRepositoryEntityFrameworkSqlServer(rootPath);

        RemovedFiles(rootPath);
    }
}

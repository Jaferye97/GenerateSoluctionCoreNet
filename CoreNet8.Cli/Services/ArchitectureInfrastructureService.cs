

using CoreNet8.Cli.Helpers;

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
        ProjectHelper.RunDotNetCommand(
            Path.Combine(infraPath, "Adapters", "In"),
            "new webapi -n WebApi -f net8.0"
        );

        // Add Application project to solution
        ProjectHelper.RunDotNetCommand(rootPath, "sln add Infrastructure/Adapters/In/WebApi/WebApi.csproj");

        var webApiPath = Path.Combine(infraPath, "Adapters", "In", "WebApi");

        // Create SubDirectory Infrastructure/Adapters/In/WebApi/Extensions/DependencyInjection
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(webApiPath, "Extensions/DependencyInjection"));

        // Create SubDirectory Infrastructure/Adapters/In/WebApi/Mapping
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(webApiPath, "Mapping"));

        // Create RepositoryEntityFrameworkSqlServer project
        ProjectHelper.RunDotNetCommand(
            Path.Combine(infraPath, "Adapters", "Out"),
            "new classlib -n RepositoryEntityFrameworkSqlServer -f net8.0"
        );

        // Add RepositoryEntityFrameworkSqlServer project to solution
        ProjectHelper.RunDotNetCommand(
            rootPath,
            "sln add Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/RepositoryEntityFrameworkSqlServer.csproj"
        );

        var repositoryEntityFrameworkSqlServerPath = Path.Combine(infraPath, "Adapters", "Out", "RepositoryEntityFrameworkSqlServer");

        // Create SubDirectory Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Context
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(repositoryEntityFrameworkSqlServerPath, "Context"));

        // Create SubDirectory Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Entities/Constants
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(repositoryEntityFrameworkSqlServerPath, "Entities", "Constants"));

        // Create SubDirectory Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Mappers
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(repositoryEntityFrameworkSqlServerPath, "Mappers"));

        // Create SubDirectory Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Repositories/Implementations
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(repositoryEntityFrameworkSqlServerPath, "Repositories", "Implementations"));

        // Create SubDirectory Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Persistence/EntityFramework
        ProjectHelper.CreateDirectoryWithGitKeep(Path.Combine(repositoryEntityFrameworkSqlServerPath, "Persistence", "EntityFramework"));

        Console.WriteLine("🛠️  (Infrastructure) Build");
        Console.WriteLine("     ⚙️  Base project created");
    }

    private static void CreateClassBaseProjectAdaptersInWebApi(string rootPath)
    {
        Console.WriteLine();

        var filePathBase = Path.Combine("Infrastructure", "Adapters", "In", "WebApi");
        var templatesPathBase = Path.Combine("Templates", "ArchitectureInfrastructure", "Adapters", "In", "WebApi");

        // GlobalUsings.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            filePathBase,
            "GlobalUsings.cs",
            Path.Combine(templatesPathBase, "GlobalUsings.cs.txt")
        );

        // Program.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            filePathBase,
            "Program.cs",
            Path.Combine(templatesPathBase, "Program.cs.txt")
        );

        // Extensions/ResultActionResultExtensions.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Extensions"),
            "ResultActionResultExtensions.cs",
            Path.Combine(templatesPathBase, "Extensions", "ResultActionResultExtensions.cs.txt")
        );

        // Extensions/DependencyInjection/DependencyInjection.CORS.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Extensions", "DependencyInjection"),
            "DependencyInjection.CORS.cs",
            Path.Combine(templatesPathBase, "Extensions", "DependencyInjection", "DependencyInjection.CORS.cs.txt")
        );

        // Extensions/DependencyInjection/DependencyInjection.CQRS.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Extensions", "DependencyInjection"),
            "DependencyInjection.CQRS.cs",
            Path.Combine(templatesPathBase, "Extensions", "DependencyInjection", "DependencyInjection.CQRS.cs.txt")
        );

        // Extensions/DependencyInjection/DependencyInjection.FluentValidation.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Extensions", "DependencyInjection"),
            "DependencyInjection.FluentValidation.cs",
            Path.Combine(templatesPathBase, "Extensions", "DependencyInjection", "DependencyInjection.FluentValidation.cs.txt")
        );

        // Extensions/DependencyInjection/DependencyInjection.Infrastructure.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Extensions", "DependencyInjection"),
            "DependencyInjection.Infrastructure.cs",
            Path.Combine(templatesPathBase, "Extensions", "DependencyInjection", "DependencyInjection.Infrastructure.cs.txt")
        );

        // Extensions/DependencyInjection/DependencyInjection.Repository.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Extensions", "DependencyInjection"),
            "DependencyInjection.Repository.cs",
            Path.Combine(templatesPathBase, "Extensions", "DependencyInjection", "DependencyInjection.Repository.cs.txt")
        );

        // Extensions/DependencyInjection/DependencyInjection.Swagger.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Extensions", "DependencyInjection"),
            "DependencyInjection.Swagger.cs",
            Path.Combine(templatesPathBase, "Extensions", "DependencyInjection", "DependencyInjection.Swagger.cs.txt")
        );

        Console.WriteLine("     ✅ (Infrastructure/Adapters/In/WebApi) Classes created");
    }

    private static void CreateClassesAdaptersOutRepositoryEntityFrameworkSqlServer(string rootPath)
    {
        Console.WriteLine();

        var filePathBase = Path.Combine("Infrastructure", "Adapters", "Out", "RepositoryEntityFrameworkSqlServer");
        var templatesPathBase = Path.Combine("Templates", "ArchitectureInfrastructure", "Adapters", "Out", "RepositoryEntityFrameworkSqlServer");

        // GlobalUsings.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            filePathBase,
            "GlobalUsings.cs",
            Path.Combine(templatesPathBase, "GlobalUsings.cs.txt")
        );

        // Context/GlobalUsings.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Context"),
            "EntityDbContext.cs",
            Path.Combine(templatesPathBase, "Context", "EntityDbContext.cs.txt")
        );

        // Entities/Constants/GlobalUsings.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Entities", "Constants"),
            "IEntity.cs",
            Path.Combine(templatesPathBase, "Entities", "Constants", "IEntity.cs.txt")
        );

        // Persistence/EntityFramework/UnitOfWork.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Persistence", "EntityFramework"),
            "UnitOfWork.cs",
            Path.Combine(templatesPathBase, "Persistence", "EntityFramework", "UnitOfWork.cs.txt")
        );

        // Repositories/IBaseRepository.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Repositories"),
            "IBaseRepository.cs",
            Path.Combine(templatesPathBase, "Repositories", "IBaseRepository.cs.txt")
        );

        // Repositories/Implementations/IBaseRepository.cs
        ProjectHelper.CreateFileFromTemplate(
            rootPath,
            Path.Combine(filePathBase, "Repositories", "Implementations"),
            "BaseRepository.cs",
            Path.Combine(templatesPathBase, "Repositories", "Implementations", "BaseRepository.cs.txt")
        );

        Console.WriteLine("     ✅ (Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer) Classes created");
    }

    private static void RemoveUnnecessaryFiles(string rootPath)
    {
        Console.WriteLine();

        var filePathBase = Path.Combine("Infrastructure", "Adapters");
        var filePathBaseOutRepositoryEntityFrameworkSqlServer = Path.Combine(rootPath, filePathBase, "Out", "RepositoryEntityFrameworkSqlServer");
        var filePathBaseInWebApi = Path.Combine(rootPath, filePathBase, "In", "WebApi");

        // Remove .gitkeep from Infrastructure/Adapters/In/WebApi
        ProjectHelper.DeleteFileIfExists(
            Path.Combine(
                filePathBaseInWebApi,
                "Extensions",
                "DependencyInjection",
                ".gitkeep"
            )
        );

        Console.WriteLine("     ♻️  (Infrastructure/Adapters/In/WebApi) Unnecessary files removed");

        // Remove default Class1.cs from Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer
        ProjectHelper.DeleteFileIfExists(
            Path.Combine(
                filePathBaseOutRepositoryEntityFrameworkSqlServer,
                "Class1.cs"
            )
        );

        // Remove .gitkeep from Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Context
        ProjectHelper.DeleteFileIfExists(
            Path.Combine(
                filePathBaseOutRepositoryEntityFrameworkSqlServer,
                "Context",
                ".gitkeep"
            )
        );

        // Remove .gitkeep from Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Entities/Constants
        ProjectHelper.DeleteFileIfExists(
            Path.Combine(
                filePathBaseOutRepositoryEntityFrameworkSqlServer,
                "Entities",
                "Constants",
                ".gitkeep"
            )
        );

        // Remove .gitkeep from Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Persistence/EntityFramework
        ProjectHelper.DeleteFileIfExists(
            Path.Combine(
                filePathBaseOutRepositoryEntityFrameworkSqlServer,
                "Persistence",
                "EntityFramework",
                ".gitkeep"
            )
        );

        // Remove .gitkeep from Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/Repositories/Implementations
        ProjectHelper.DeleteFileIfExists(
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

        RemoveUnnecessaryFiles(rootPath);
    }
}

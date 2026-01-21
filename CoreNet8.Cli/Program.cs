using CoreNet8.Cli.Commands;
using CoreNet8.Cli.Services;

var solutionService = new SolutionService();

var architectureApplicationService = new ArchitectureApplicationService();
var architectureDomainService = new ArchitectureDomainService();
var architectureInfrastructureService = new ArchitectureInfrastructureService();

if (args[0] != "new")
{
    Console.WriteLine("Usage:");
    Console.WriteLine("  dotnet run -- new");
    return;
}

var resultNewSolution = NewSolutionCommand.Execute();

if (resultNewSolution is null)
{
    Console.WriteLine("❌ Solution creation aborted");
    return;
}

var (rootPath, solutionName) = resultNewSolution.Value;

solutionService.Create(rootPath, solutionName);

architectureApplicationService.CreateArchitectureBaseProject(rootPath);
architectureDomainService.CreateArchitectureBaseProject(rootPath);
architectureInfrastructureService.CreateArchitectureBaseProject(rootPath);

ProcessService.Run(
    "dotnet",
    "add Infrastructure/Adapters/In/WebApi/WebApi.csproj reference " +
    "Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/RepositoryEntityFrameworkSqlServer.csproj",
    rootPath
);

ProcessService.Run(
    "dotnet",
    "add Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/RepositoryEntityFrameworkSqlServer.csproj reference " +
    "Application/Application.csproj",
    rootPath
);

ProcessService.Run(
    "dotnet",
    "add Infrastructure/Adapters/Out/RepositoryEntityFrameworkSqlServer/RepositoryEntityFrameworkSqlServer.csproj reference " +
    "Domain/Domain.csproj",
    rootPath
);

ProcessService.Run(
    "dotnet",
    "add Application/Application.csproj reference " +
    "Domain/Domain.csproj",
    rootPath
);

// Create .gitignore
ProcessService.Run("dotnet", "new gitignore", rootPath);

Console.WriteLine();
Console.WriteLine("🎉 Solution created successfully!");
Console.WriteLine();
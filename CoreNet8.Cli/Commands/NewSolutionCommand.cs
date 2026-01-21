namespace CoreNet8.Cli.Commands;

public static class NewSolutionCommand
{
    public static (string, string)? Execute()
    {
        Console.WriteLine();
        Console.WriteLine("🚀 CoreNet8 Generator");
        // 📍 current directory → CoreNet8.Cli
        var currentDir = Directory.GetCurrentDirectory();

        // 📍 parent directory
        var parentDir = Directory.GetParent(currentDir)?.FullName;

        if (parentDir is null)
        {
            Console.WriteLine("❌ Unable to determine parent directory");
            return null;
        }

        Console.WriteLine();
        Console.Write($"Root folder name where the solution will be located: ");
        var folderName = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(folderName))
        {
            Console.WriteLine("❌ Unable to determine the folder where the solution will be located");
            return null;
        }

        // 📍 final path where EVERYTHING will be created
        var rootPath = Path.Combine(parentDir, folderName);

        if (Directory.Exists(rootPath))
        {
            Console.WriteLine("❌ The solution folder already exists");
            return null;
        }

        // 📌 Solution name
        var solutionName = folderName;

        Console.WriteLine();
        Console.Write($"Solution name (press enter to use \"{folderName}\"): ");
        solutionName = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(solutionName))
            solutionName = folderName;

        Console.WriteLine();
        Console.WriteLine($"📁 Creating solution at: {rootPath}");
        Directory.CreateDirectory(rootPath);

        return (rootPath, solutionName);
    }
}
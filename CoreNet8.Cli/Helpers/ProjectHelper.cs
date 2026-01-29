namespace CoreNet8.Cli.Helpers;

public static class ProjectHelper
{
    /// <summary>
    /// Run a dotnet command in the specified path.
    /// </summary>
    public static void RunDotNetCommand(string rootPath, string args)
    {
        ProcessHelper.Run("dotnet", args, rootPath);
    }

    /// <summary>
    /// Create a file from a template.
    /// If the template does not exist, display a warning.
    /// </summary>
    public static void CreateFileFromTemplate(string rootPath, string targetFolder, string fileName, string templatePath)
    {
        var templateFullPath = Path.Combine(templatePath);
        var targetFullPath = Path.Combine(rootPath, targetFolder, fileName);

        if (!File.Exists(templateFullPath))
        {
            Console.WriteLine($"     ⚠️ Template not found: {templateFullPath}");
            return;
        }

        Directory.CreateDirectory(Path.Combine(rootPath, targetFolder));
        File.WriteAllText(targetFullPath, File.ReadAllText(templateFullPath));

        Console.WriteLine($"     📄 Created {targetFolder}/{fileName}");
    }

    /// <summary>
    /// Create a folder and a .gitkeep file inside it.
    /// </summary>
    public static void CreateDirectoryWithGitKeep(string path, bool withGitkeep = true)
    {
        Directory.CreateDirectory(path);

        if (withGitkeep) 
        { 
            var gitKeepPath = Path.Combine(path, ".gitkeep");
            if (!File.Exists(gitKeepPath))
                File.WriteAllText(gitKeepPath, string.Empty);
        }
    }

    /// <summary>
    /// Delete a file if it exists.
    /// </summary>
    public static void DeleteFileIfExists(string path)
    {
        if (File.Exists(path))
            File.Delete(path);
    }
}

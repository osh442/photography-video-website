namespace PhotoNetwork.Services.Storage;

public class LocalFileStorage : IFileStorage
{
    private readonly string _rootPath;

    public LocalFileStorage(string rootPath)
    {
        _rootPath = Path.GetFullPath(rootPath);
    }

    public async Task<string> SaveAsync(Stream content, string extension, string folder)
    {
        // Името на файла е случайно, за да не се използва името от потребителя.
        var fileName = $"{Guid.NewGuid():N}{extension}";
        var relativePath = Path.Combine(folder, fileName);
        var fullPath = GetFullPath(relativePath);

        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

        await using var file = File.Create(fullPath);
        await content.CopyToAsync(file);

        return relativePath.Replace('\\', '/');
    }

    public void Delete(string relativePath)
    {
        var fullPath = GetFullPath(relativePath);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }

    // Не позволява път, който излиза извън папката за качване.
    private string GetFullPath(string relativePath)
    {
        var fullPath = Path.GetFullPath(Path.Combine(_rootPath, relativePath));

        if (!fullPath.StartsWith(_rootPath, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Invalid file path.");
        }

        return fullPath;
    }
}

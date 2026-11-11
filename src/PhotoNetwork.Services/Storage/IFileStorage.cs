namespace PhotoNetwork.Services.Storage;

// Абстракция над съхранението на файлове.
// Сега снимките се пазят на диска, а по-късно може да се добави Azure Blob Storage.
public interface IFileStorage
{
    // Записва файла и връща относителния път, който се пази в базата.
    Task<string> SaveAsync(Stream content, string extension, string folder);

    void Delete(string relativePath);
}

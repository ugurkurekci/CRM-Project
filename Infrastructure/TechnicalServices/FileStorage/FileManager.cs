namespace Infrastructure.TechnicalServices.FileStorage;

public class FileManager
{
    public string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public void WriteFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }

    public void DeleteFile(string filePath)
    {
        File.Delete(filePath);
    }

    public bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }
}
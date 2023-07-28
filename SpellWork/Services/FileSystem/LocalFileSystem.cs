namespace SpellWork.Services;

public class LocalFileSystem : IFileSystem
{
    public async Task<byte[]> ReadFile(string path)
    {
        return await File.ReadAllBytesAsync(path);
    }

    public bool Exists(string path)
    {
        return File.Exists(path);
    }
}
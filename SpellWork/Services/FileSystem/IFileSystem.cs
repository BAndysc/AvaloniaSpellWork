namespace SpellWork.Services;

public interface IFileSystem
{ 
    Task<byte[]> ReadFile(string path);
    bool Exists(string path);
}
using System.IO.Compression;

namespace SpellWork.Services;

public class RemoteFileSystem : IFileSystem
{
    private readonly string host;
    private HttpClient httpClient;
    
    public RemoteFileSystem(string host)
    {
        this.host = host;
        httpClient = new HttpClient();
    }
    
    public async Task<byte[]> ReadFile(string path)
    {
        var bytes = await httpClient.GetByteArrayAsync(Path.Join(host, path));
        
        if (IsZipMagicNumber(bytes))
        {
            using var memoryStream = new MemoryStream(bytes);
            using var zip = new ZipArchive(memoryStream, ZipArchiveMode.Read);
            
            if (zip.Entries.Count != 1)
                throw new Exception("Zip archive must contain exactly one file");
            
            await using var stream = zip.Entries[0].Open();
            bytes = new byte[zip.Entries[0].Length];
            var output = new MemoryStream(bytes);
            await stream.CopyToAsync(output);
        }
        
        return bytes;
    }

    private static bool IsZipMagicNumber(byte[] bytes)
    {
        return bytes[0] == 0x50 && bytes[1] == 0x4B;
    }

    public bool Exists(string path)
    {
        return true;
    }
}
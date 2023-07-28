using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using SpellWork.Services;

namespace SpellWork.Avalonia.Browser;

public partial class WebRemoteFileSystem : IFileSystem
{
    private readonly string host;
    private HttpClient httpClient;
    private bool useCaching = false;
    
    public WebRemoteFileSystem(string host)
    {
        this.host = host;
        httpClient = new HttpClient();
    }
    
    [JSImport("localStorage.setValue", "main.js")]
    internal static partial void SetCachedValue(string key, string value);
    
    [JSImport("localStorage.getValue", "main.js")]
    internal static partial string? GetValue(string key);
    
    public async Task<byte[]> ReadFile(string path)
    {
        byte[] bytes;
        if (useCaching)
        {
            var cached = GetValue(path);
            if (cached != null)
            {
                await Task.Delay(1);
                bytes = Convert.FromBase64String(cached);
            }
            else
            {
                bytes = await httpClient.GetByteArrayAsync(Path.Join(host, path));
                SetCachedValue(path, Convert.ToBase64String(bytes));
            }
        }
        else
        {
            bytes = await httpClient.GetByteArrayAsync(Path.Join(host, path));
        }
        
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
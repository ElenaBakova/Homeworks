using System.Net;
using System.Net.Sockets;

namespace MyFTP;

/// <summary>
/// FTP client class
/// </summary>
public class Client
{
    private readonly int port;
    private readonly IPAddress ip;

    /// <summary>
    /// Clent's constructor
    /// </summary>
    public Client(int port, IPAddress ip)
    {
        this.port = port;
        this.ip = ip;
    }

    /// <summary>
    /// Clent's constructor
    /// </summary>
    public Client(int port, string ip)
    {
        this.port = port;
        this.ip = IPAddress.Parse(ip);
    }

    /// <summary>
    /// Returns list of files in the directory 
    /// </summary>
    /// <param name="path">Directory path</param>
    public async Task<List<(string name, bool isDir)>> List(string path, CancellationTokenSource cts)
    {
        using var client = new TcpClient();
        await client.ConnectAsync(ip.ToString(), port);
        using var stream = client.GetStream();
        using var writer = new StreamWriter(stream) { AutoFlush = true };
        writer.WriteLine($"1 {path}");

        using var reader = new StreamReader(stream);
        var readString = await reader.ReadLineAsync();
        var data = readString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var size = int.Parse(data[0]);
        if (size == -1)
        {
            throw new DirectoryNotFoundException();
        }

        var list = new List<(string, bool)>();
        for (int i = 1; i <= 2 * size; i += 2)
        {
            if (cts.IsCancellationRequested)
            {
                return null;
            }
            var name = data[i];
            var isDir = bool.Parse(data[i + 1]);
            list.Add((name, isDir));
        }
        return list;
    }

    /// <summary>
    /// Returns file and its size
    /// </summary>
    /// <param name="path">File path</param>
    public async Task Get(string path, CancellationTokenSource cts, Stream respondStream)
    {
        using var client = new TcpClient(ip.ToString(), port);
        using var stream = client.GetStream();
        using var writer = new StreamWriter(stream) { AutoFlush = true };
        writer.WriteLine($"2 {path}");

        using var reader = new StreamReader(stream);
        var size = long.Parse(await reader.ReadLineAsync());
        if (size == -1)
        {
            throw new FileNotFoundException();
        }

        if (cts.IsCancellationRequested)
        {
            return;
        }
        await stream.CopyToAsync(respondStream);
        respondStream.Position = 0;
    }
}

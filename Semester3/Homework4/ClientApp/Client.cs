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
    /// Client's constructor
    /// </summary>
    public Client(int port, IPAddress ip)
    {
        this.port = port;
        this.ip = ip;
    }

    /// <summary>
    /// Client's constructor
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
    public async Task<List<(string name, bool isDir)>> List(string path, CancellationToken token)
    {
        using var client = new TcpClient();
        await client.ConnectAsync(ip.ToString(), port, token);
        await using var stream = client.GetStream();
        await using var writer = new StreamWriter(stream) {AutoFlush = true};
        await writer.WriteLineAsync($"1 {path}");

        using var reader = new StreamReader(stream);
        var readString = await reader.ReadLineAsync();
        var data = readString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var size = int.Parse(data[0]);
        if (size == -1)
        {
            throw new DirectoryNotFoundException();
        }

        var list = new List<(string, bool)>();
        for (var i = 1; i <= 2 * size; i += 2)
        {
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
    public async Task Get(string path, Stream respondStream, CancellationToken token)
    {
        using var client = new TcpClient();
        await client.ConnectAsync(ip.ToString(), port, token);
        await using var stream = client.GetStream();
        await using var writer = new StreamWriter(stream) {AutoFlush = true};
        await writer.WriteLineAsync($"2 {path}");

        using var reader = new StreamReader(stream);
        var parseResult = long.TryParse(await reader.ReadLineAsync(), out var size);
        if (size == -1 || !parseResult)
        {
            throw new FileNotFoundException();
        }

        await stream.CopyToAsync(respondStream, token);
        respondStream.Position = 0;
    }
}
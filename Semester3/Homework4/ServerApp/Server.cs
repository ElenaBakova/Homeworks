using System.Net;
using System.Net.Sockets;

namespace MyFTP;

/// <summary>
/// FTP server class
/// </summary>
public class Server
{
    private readonly AutoResetEvent shutdownControl = new(false);
    private readonly CancellationTokenSource cancellationTokenSource = new();
    private readonly TcpListener listener;
    private readonly List<Task> clientsList = new();
    private volatile int runningTasks = 0;

    /// <summary>
    /// Server's constructor
    /// </summary>
    public Server(int port, IPAddress ip)
        => listener = new TcpListener(ip, port);

    /// <summary>
    /// Server's constructor
    /// </summary>
    public Server(int port, string ip)
        => listener = new TcpListener(IPAddress.Parse(ip), port);

    /// <summary>
    /// Starts server
    /// </summary>
    public async Task Start()
    {
        listener.Start();
        while (!cancellationTokenSource.IsCancellationRequested)
        {
            cancellationTokenSource.Token.Register(() => listener.Stop());
            try
            {
                var client = await listener.AcceptTcpClientAsync();
                var clientTask = Task.Run(() => Execute(client, cancellationTokenSource.Token));
                clientsList.Add(clientTask);
            }
            catch (SocketException)
            {
                Console.WriteLine("Server disconnected");
                return;
            }
        }

        Task.WaitAll(clientsList.ToArray());
        listener.Stop();
    }

    /// <summary>
    /// Query processing method
    /// </summary>
    /// <param name="client">TCP client</param>
    private async Task Execute(TcpClient client, CancellationToken token)
    {
        //using (client)
        {
            Interlocked.Increment(ref runningTasks);
            await using var stream = client.GetStream();
            await using var writer = new StreamWriter(stream) {AutoFlush = true};
            using var reader = new StreamReader(stream);
            var requestString = await reader.ReadLineAsync();
            var request = requestString.Split(' ');

            switch (request[0])
            {
                case "1":
                    await List(request[1], writer);
                    break;
                case "2":
                    await Get(request[1], writer, token);
                    break;
            }

            Interlocked.Decrement(ref runningTasks);
            shutdownControl.Set();
        }
    }

    private static async Task List(string path, StreamWriter writer)
    {
        var directory = new DirectoryInfo(path);
        if (!directory.Exists)
        {
            await writer.WriteLineAsync("-1");
            return;
        }

        var directories = directory.GetDirectories();
        var files = directory.GetFiles();
        await writer.WriteAsync($"{files.Length + directories.Length} ");
        foreach (var folder in directories)
        {
            await writer.WriteAsync($"{folder.Name} true ");
        }

        foreach (var file in files)
        {
            await writer.WriteAsync($"{file.Name} false ");
        }
    }

    private static async Task Get(string path, StreamWriter writer, CancellationToken token)
    {
        var file = new FileInfo(path);
        if (!file.Exists)
        {
            await writer.WriteLineAsync("-1");
            return;
        }

        await writer.WriteLineAsync(file.Length.ToString());
        await using var fileStream = file.OpenRead();
        await fileStream.CopyToAsync(writer.BaseStream, token);
    }

    /// <summary>
    /// Shuts down server
    /// </summary>
    public void Shutdown()
    {
        cancellationTokenSource.Cancel();
        while (runningTasks > 0)
        {
            shutdownControl.WaitOne();
        }
    }
}
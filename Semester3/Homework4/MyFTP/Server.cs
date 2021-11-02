using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace MyFTP
{
    /// <summary>
    /// FTP server class
    /// </summary>
    public class Server
    {
        private AutoResetEvent shutdownControl = new(false);
        private CancellationTokenSource cancellationTokenSource = new();
        private TcpListener listener;
        private int runningTasks = 0;

        /// <summary>
        /// Server's constructor
        /// </summary>
        public Server(int port, IPAddress iP)
            => listener = new TcpListener(iP, port);

        /// <summary>
        /// Starts server
        /// </summary>
        public async Task Start()
        {
            listener.Start();
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                var client = await listener.AcceptTcpClientAsync();
                await Task.Run(() => Execute(client));
            }
            listener.Stop();
        }

        /// <summary>
        /// Query processing method
        /// </summary>
        /// <param name="client">TCP client</param>
        private async Task Execute(TcpClient client)
        {
            Interlocked.Increment(ref runningTasks);
            using var stream = client.GetStream();
            var writer = new StreamWriter(stream) { AutoFlush = true};
            var reader = new StreamReader(stream);
            var requestString = await reader.ReadLineAsync();
            var request = requestString.Split(' ');

            switch (request[0])
            {
                case "1":
                    await List(request[1], writer);
                    break;
                case "2":
                    await Get(request[1], writer);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Start), "Invalid request");
            }
            Interlocked.Decrement(ref runningTasks);
            shutdownControl.Set();
        }

        private async Task List(string path, StreamWriter writer)
        {
            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                await writer.WriteLineAsync("-1");
                return;
            }

            var directories = directory.GetDirectories();
            var files = directory.GetFiles();
            await writer.WriteLineAsync((files.Length + directories.Length).ToString());
            foreach (var folder in directories)
            {
                await writer.WriteLineAsync($"{folder.Name} true");
            }
            foreach (var file in files)
            {
                await writer.WriteLineAsync($"{file.Name} false");
            }
        }

        private async Task Get(string path, StreamWriter writer)
        {
            var file = new FileInfo(path);
            if (!file.Exists)
            {
                await writer.WriteLineAsync("-1");
                return;
            }

            await writer.WriteLineAsync(file.Length.ToString());
            using var fileStream = file.OpenRead();
            await fileStream.CopyToAsync(writer.BaseStream);
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
}

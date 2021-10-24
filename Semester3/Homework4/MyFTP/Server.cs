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
        private readonly int port;
        private readonly IPAddress iP;
        private TcpListener listener;
        private int runningTasks = 0;

        /// <summary>
        /// Server's constructor
        /// </summary>
        public Server(int port, IPAddress iP)
        {
            this.port = port;
            this.iP = iP;
            listener = new TcpListener(iP, port);
        }

        /// <summary>
        /// Starts server
        /// </summary>
        public async Task StartAsync()
        {
            listener.Start();
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Execute(await listener.AcceptTcpClientAsync());
            }
            listener.Stop();
        }

        /// <summary>
        /// Query processing method
        /// </summary>
        /// <param name="client">TCP client</param>
        public async void Execute(TcpClient client)
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
                    List(request[1], writer);
                    break;
                case "2":
                    Get(request[1], writer);
                    break;
                default:
                    break;
            }
            Interlocked.Decrement(ref runningTasks);
            shutdownControl.Set();
        }

        private void List(string path, StreamWriter writer)
        {
            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                writer.WriteLine(-1);
                return;
            }
            var directories = directory.GetDirectories();
            var files = directory.GetFiles();
            writer.WriteLine(files.Length + directories.Length);
            foreach (var folder in directories)
            {
                writer.WriteLine($"{folder.Name} true");
            }
            foreach (var file in files)
            {
                writer.WriteLine($"{file.Name} false");
            }
        }

        private void Get(string path, StreamWriter writer)
        {
            var file = new FileInfo(path);
            if (!file.Exists)
            {
                writer.WriteLine(-1);
                return;
            }
            writer.WriteLine(file);
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

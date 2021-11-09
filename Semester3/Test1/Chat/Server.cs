using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace MyFTP
{
    /// <summary>
    /// Server class
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
        public Server(int port)
            => listener = new TcpListener(IPAddress.Any, port);

        /// <summary>
        /// Starts server
        /// </summary>
        public async Task Start()
        {
            listener.Start();
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                var client = await listener.AcceptTcpClientAsync();
                ThreadPool.QueueUserWorkItem(async obj => await Execute(client));
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
            using var writer = new StreamWriter(stream) { AutoFlush = true};
            using var reader = new StreamReader(stream);
            var requestString = await reader.ReadLineAsync();
            var request = requestString.Split(' ');

            Interlocked.Decrement(ref runningTasks);
            shutdownControl.Set();
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

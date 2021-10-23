using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public void Start()
        {
            listener.Start();
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Execute(listener.AcceptTcpClient());
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
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            var requestString = await reader.ReadLineAsync();
            var request = requestString.Split(' ');

            switch (request[0])
            {
                case "1":
                    List(request[1]);
                    break;
                case "2":
                    Get(request[1]);
                    break;
                default:
                    break;
            }
            Interlocked.Decrement(ref runningTasks);
            shutdownControl.Set();
        }

        private void List(string path)
        {

        }

        private void Get(string path)
        {

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

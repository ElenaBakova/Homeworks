using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Chat
{
    /// <summary>
    /// Client class
    /// </summary>
    public class Client : IDisposable
    {
        private TcpClient client;
        private readonly int port;
        private readonly IPAddress ip;

        /// <summary>
        /// Clent's constructor
        /// </summary>
        public Client(string ip, int port)
        {
            this.port = port;
            this.ip = IPAddress.Parse(ip);
            client = new TcpClient();
        }

        /// <summary>
        /// Runs client
        /// </summary>
        public async Task RunAsync()
        {
            try
            {
                await client.ConnectAsync(ip, port);
            }
            catch (SocketException)
            {
                Console.WriteLine("Connecting error");
                Dispose();
            }
            Console.WriteLine("Connected to the server");

            while (true)
            {
                SendMessage(client.GetStream());
                await GetMessage(client.GetStream());
            }
        }

        private async Task GetMessage(NetworkStream stream)
        {
            using var reader = new StreamReader(stream);
            while (true)
            {
                var data = await reader.ReadLineAsync();
                if (data == "exit")
                {
                    Dispose();
                }
                Console.WriteLine($"Server message: {data}");
            }
        }

        private void SendMessage(NetworkStream stream)
        {
            Task.Run(async () =>
            {
                using var writer = new StreamWriter(stream) { AutoFlush = true };
                while (true)
                {
                    var data = Console.ReadLine();
                    await writer.WriteLineAsync(data);
                    if (data == "exit")
                    {
                        Dispose();
                    }
                }
            });
        }

        /// <summary>
        /// Shuts down client
        /// </summary>
        public void Dispose()
        {
            client.Close();
            Environment.Exit(0);
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Chat
{
    /// <summary>
    /// Server class
    /// </summary>
    public class Server
    {
        private TcpListener listener;
        private TcpClient client;

        /// <summary>
        /// Server's constructor
        /// </summary>
        public Server(int port)
            => listener = new TcpListener(IPAddress.Any, port);

        /// <summary>
        /// Runs the server
        /// </summary>
        public async Task RunAsync()
        {
            while (true)
            {
                listener.Start();
                client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected");

                GetMessage(client.GetStream());
                SendMessage(client.GetStream());
            }
        }

        private void GetMessage(NetworkStream stream)
        {
            Task.Run(async () =>
            {
                using var reader = new StreamReader(stream);
                while (true)
                {
                    var data = await reader.ReadLineAsync();
                    if (data == "exit")
                    {
                        Shutdown();
                    }
                    Console.WriteLine($"Client message: {data}");
                }
            });
        }
        
        private void SendMessage(NetworkStream stream)
        {
            Task.Run(async () =>
            {
                using var writer = new StreamWriter(stream) { AutoFlush = true };
                while (true)
                {
                    Console.WriteLine("Your message: ");
                    var data = Console.ReadLine();
                    if (data == "exit")
                    {
                        Shutdown();
                    }
                    await writer.WriteLineAsync(data);
                }
            });
        }

        /// <summary>
        /// Shuts down server
        /// </summary>
        private void Shutdown()
        {
            listener.Stop();
            client.Close();
            Environment.Exit(0);
        }
    }
}

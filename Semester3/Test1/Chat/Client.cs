using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Chat
{
    /// <summary>
    /// Client class
    /// </summary>
    public class Client
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
            catch (Exception)
            {
                Console.WriteLine("Connecting error");
                Shutdown();
            }
            Console.WriteLine("Connected to the server");

            SendMessage(client.GetStream());
            GetMessage(client.GetStream());
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
                    Console.WriteLine($"Server message: {data}");
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
        /// Shuts down client
        /// </summary>
        public void Shutdown()
        {
            client.Close();
            Environment.Exit(0);
        }
    }
}

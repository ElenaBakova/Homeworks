using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MyFTP
{
    /// <summary>
    /// FTP client class
    /// </summary>
    public class Client
    {
        private TcpClient client;
        private readonly int port;
        private readonly IPAddress ip;

        /// <summary>
        /// Clent's constructor
        /// </summary>
        public Client(int port, IPAddress ip)
        {
            this.port = port;
            this.ip = ip;
            client = new TcpClient();
        }

        /// <summary>
        /// Returns list of files in the directory 
        /// </summary>
        /// <param name="path">Directory path</param>
        public async Task<List<(string name, bool isDir)>> List(string path)
        {
            await client.ConnectAsync(ip.ToString(), port);
            using var stream = client.GetStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };
            writer.WriteLine($"1 {path}");

            var reader = new StreamReader(stream);
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
        public async Task<(long Size, byte[] File)> Get(string path)
        {
            client = new TcpClient(ip.ToString(), port);
            using var stream = client.GetStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };
            writer.WriteLine($"2 {path}");

            var reader = new StreamReader(stream);
            var size = long.Parse(await reader.ReadLineAsync());
            if (size == -1)
            {
                throw new FileNotFoundException();
            }

            var file = new byte[size];
            await stream.ReadAsync(file);
            return (size, file);
        }
    }
}

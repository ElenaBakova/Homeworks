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
        private readonly IPAddress iP;

        /// <summary>
        /// Clent's constructor
        /// </summary>
        public Client(int port, IPAddress iP)
        {
            this.port = port;
            this.iP = iP;
        }

        /// <summary>
        /// Returns list of files in the directory 
        /// </summary>
        /// <param name="path">Directory path</param>
        public async Task<List<(string, bool)>> List(string path)
        {
            client = new TcpClient(iP.ToString(), port);
            using var stream = client.GetStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };
            writer.WriteLine($"1 {path}");

            var reader = new StreamReader(stream);
            var size = int.Parse(await reader.ReadLineAsync());
            if (size == -1)
            {
                throw new DirectoryNotFoundException();
            }

            var list = new List<(string, bool)>();
            for (int i = 0; i < size; i++)
            {
                var respondString = await reader.ReadLineAsync();
                var respond = respondString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                list.Add((respond[0], bool.Parse(respond[1])));
            }
            return list;
        }

        /// <summary>
        /// Returns file and its size
        /// </summary>
        /// <param name="path">File path</param>
        public async Task<(long Size, byte[] File)> Get(string path)
        {
            client = new TcpClient(iP.ToString(), port);
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

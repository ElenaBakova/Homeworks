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

        /// <summary>
        /// Clent's constructor
        /// </summary>
        public Client(int port, IPAddress iP)
            => client = new(iP.ToString(), port);

        public async Task List(string path)
            => await SendRequest(1, path);

        public async Task Get(string path)
            => await SendRequest(2, path);

        private async Task<string> SendRequest(int request, string path)
        {
            using var stream = client.GetStream();
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream) { AutoFlush = true };
            writer.WriteLine($"{request} {path}");
            return await reader.ReadLineAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MyFTP
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
        public Client(int port, IPAddress ip)
        {
            this.port = port;
            this.ip = ip;
            client = new TcpClient();
        }

        /// <summary>
        /// Clent's constructor
        /// </summary>
        public Client(int port, string ip)
        {
            this.port = port;
            this.ip = IPAddress.Parse(ip);
            client = new TcpClient();
        }
    }
}

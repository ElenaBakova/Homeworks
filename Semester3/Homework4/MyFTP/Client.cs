using System.Net;

namespace MyFTP
{
    /// <summary>
    /// FTP client class
    /// </summary>
    public class Client
    {
        int port;
        IPAddress iP;

        /// <summary>
        /// Clent's constructor
        /// </summary>
        public Client(int port, IPAddress iP)
        {
            this.port = port;
            this.iP = iP;
        }
    }
}

using System.Net;
using System.Threading.Tasks;

namespace MyFTP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new Server(80, IPAddress.Parse("127.0.0.1"));
            await server.Start();
            server.Shutdown();
        }
    }
}

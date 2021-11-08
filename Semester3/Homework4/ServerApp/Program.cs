using MyFTP;
using System;
using System.Threading.Tasks;

namespace ServerApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Please enter port");
            var port = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter ip address");
            var ip = Console.ReadLine();
            var server = new Server(port, ip);
            await server.Start();
            server.Shutdown();
        }
    }
}

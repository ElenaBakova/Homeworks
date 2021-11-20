using System;
using System.Threading.Tasks;

namespace Chat
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool success;
            int port = 0;
            switch (args.Length)
            {
                case 1:
                    success = int.TryParse(args[0], out port);
                    if (!success || port < 0 || port > 65535)
                    {
                        Console.WriteLine("Invalid port");
                    }
                    var server = new Server(port);
                    await server.RunAsync();
                    break;
                case 2:
                    success = int.TryParse(args[1], out port);
                    if (!success || port < 0 || port > 65535)
                    {
                        Console.WriteLine("Invalid port");
                    }
                    var client = new Client(args[0], port);
                    await client.RunAsync();
                    break;
                default:
                    break;
            }
        }
    }
}

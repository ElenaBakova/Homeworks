using System.Threading.Tasks;

namespace Chat
{
    class Program
    {
        static async Task Main(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    var server = new Server(int.Parse(args[0]));
                    await server.RunAsync();
                    break;
                case 2:
                    var client = new Client(args[0], int.Parse(args[1]));
                    await client.RunAsync();
                    break;
                default:
                    break;
            }
        }
    }
}

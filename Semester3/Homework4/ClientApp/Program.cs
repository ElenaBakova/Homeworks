using MyFTP;
using System;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter port");
            var port = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter ip address");
            var ip = Console.ReadLine();
            var client = new Client(port, ip);
        }
    }
}

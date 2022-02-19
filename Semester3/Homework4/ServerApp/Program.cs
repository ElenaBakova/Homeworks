using MyFTP;
using System;

if (args.Length < 2)
{
    Console.WriteLine("args should provide ip and port");
    return;
}

var port = int.Parse(args[0]);
var ip = args[1];
var server = new Server(port, ip);
await server.Start();
server.Shutdown();

using MyFTP;

if (args.Length < 2)
{
    Console.WriteLine("args should provide ip and port");
    return;
}

var port = int.Parse(args[0]);
var ip = args[1];
var server = new Server(port, ip);
var serverTask = server.Start();
Console.WriteLine("Press enter to stop");
Console.ReadLine();
server.Shutdown();
await serverTask;


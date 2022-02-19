using MyFTP;

if (args.Length < 2)
{
    Console.WriteLine("Please, provide in args port and ip");
    return;
}

var port = int.Parse(args[0]);
var ip = args[1];
new Client(port, ip);

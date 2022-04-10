using MyFTP;

if (args.Length < 2)
{
    Console.WriteLine("Please, provide in args port and ip");
    return;
}

var port = int.Parse(args[0]);
var ip = args[1];
var client = new Client(port, ip);
var cts = new CancellationTokenSource();
var list = client.List("..\\..\\..\\..\\..\\..\\", cts.Token);
foreach(var element in list.Result)
{
    Console.WriteLine($"{element.name} -- {element.isDir}");
}

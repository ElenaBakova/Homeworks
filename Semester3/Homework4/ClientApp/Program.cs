using MyFTP;

if (args.Length < 4)
{
    Console.WriteLine("Please, provide in args port, ip, command (list or get) and path to the file or directory");
    return;
}

var parseResult = int.TryParse(args[0].Replace("--", ""), out var port);
if (!parseResult)
{
    Console.WriteLine("Couldn't get port");
    return;
}

var command = args[2];
var path = args[3];
if (!File.Exists(path) && !Directory.Exists(path))
{
    Console.WriteLine("Incorrect path");
    return;
}
var ip = args[1];
var client = new Client(port, ip);
var cts = new CancellationTokenSource();

switch (command)
{
    case "list":
        try
        {
            var list = await client.List(path, cts.Token);
            foreach (var element in list)
            {
                Console.WriteLine($"{element.name} -- {element.isDir}");
            }
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("There's no such directory");
        }

        break;
    case "get":
    {
        using var respondStream = new MemoryStream();
        await client.Get(path, respondStream, cts.Token);
        using var streamReader = new StreamReader(respondStream);
        var file = await streamReader.ReadToEndAsync();
        Console.WriteLine(file);
        break;
    }
    default:
        Console.WriteLine("Invalid request");
        break;
}
cts.Cancel();
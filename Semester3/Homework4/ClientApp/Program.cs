using MyFTP;

if (args.Length < 2)
{
    Console.WriteLine("Please, provide in args port and ip");
    return;
}

int.TryParse(args[0], out var port);
var ip = args[1];
var client = new Client(port, ip);
var cts = new CancellationTokenSource();

Console.WriteLine("Commands:\n0 - End session\n1 - List all files in the directory\n2 - Get file from server");
while (!cts.IsCancellationRequested)
{
    Console.WriteLine("\nPlease enter command code and path: ");
    var input = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (input == null || input.Length == 1 && input[0] != "0" || input.Length < 1)
    {
        Console.WriteLine("Invalid input, try again");
        continue;
    }

    switch (input[0])
    {
        case "0":
            cts.Cancel();
            break;
        case "1":
            try
            {
                var list = await client.List(input[1], cts.Token);
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
        case "2":
        {
            using var respondStream = new MemoryStream();
            await client.Get(input[1], respondStream, cts.Token);
            using var streamReader = new StreamReader(respondStream);
            var file = await streamReader.ReadToEndAsync();
            Console.WriteLine(file);
            break;
        }
        default:
            Console.WriteLine("Invalid request");
            break;
    }
}
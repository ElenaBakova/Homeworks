if (args.Length == 0)
{
    Console.WriteLine("Args should provide tests path");
    return;
}

if (Directory.Exists(args[0]))
{
    Console.WriteLine("There's no such directory");
    return;
}

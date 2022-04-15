using MyNUnit;

if (args.Length == 0)
{
    throw new ArgumentException("Args should provide tests path");
}

if (!Directory.Exists(args[0]))
{
    throw new ArgumentException("There's no such directory");
}

var nUnitClass = new MyNUnitClass();
nUnitClass.RunTesting(args[0]);
nUnitClass.PrintResult();
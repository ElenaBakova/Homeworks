using System;
using System.IO;

namespace RLEAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Too few arguments");
                Environment.Exit(1);
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Can't find a file");
                Environment.Exit(-1);
            }
            var array = File.ReadAllBytes(args[0]);
            if (args[1] == "-c")
            {

            }
            else if (args[1] == "-u")
            {

            }
        }
    }
}

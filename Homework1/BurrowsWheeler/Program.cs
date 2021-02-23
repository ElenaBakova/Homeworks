using System;

namespace BurrowsWheeler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Tests.Test())
            {
                Console.WriteLine("Tests failed");
                Environment.Exit(1);
            }
            Console.WriteLine("Tests succeed");

            Console.WriteLine("Please enter string");
            string inputString = Console.ReadLine();
            var bwtResult = Transform.BWTMethod(inputString);
            Console.WriteLine($"Burrows-Wheeler transformation result: {bwtResult.Item1}");
            string outputString = Transform.BWTReverseMethod(bwtResult.Item1, bwtResult.Item2);
            Console.WriteLine($"Reversed Burrows-Wheeler transformation result: {outputString}"); 
        }
    }
}
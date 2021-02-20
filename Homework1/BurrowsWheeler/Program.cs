using System;

namespace BurrowsWheeler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string");
            string inputString = Console.ReadLine();
            var bwtResult = Transform.BWTMethod(inputString);
            Console.WriteLine($"Burrows-Wheeler transformation result: {bwtResult.Item1}");
            string outputString = Transform.BWTReverseMethod(bwtResult.Item1, bwtResult.Item2);
            Console.WriteLine($"Reversed Burrows-Wheeler transformation result: {outputString}"); 
        }
    }
}

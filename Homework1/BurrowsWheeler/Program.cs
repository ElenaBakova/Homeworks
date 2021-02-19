using System;

namespace BurrowsWheeler
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string");
            string inputString = Console.ReadLine();
            Tuple<string, int> bwtResult = Transform.BWTMethod(inputString);
            Console.WriteLine("Burrows-Wheeler transformation result: {0}", bwtResult.Item1);
        }
    }
}

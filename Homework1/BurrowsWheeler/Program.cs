using System;

namespace BurrowsWheeler
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string");
            string inputString = Console.ReadLine();
            Transform.BWTMethod(inputString);
        }
    }
}

using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an expression");
            string read = Console.ReadLine();
            string[] numbers = read.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        }
    }
}

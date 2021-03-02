using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an expression");
            string read = Console.ReadLine();
            Console.WriteLine("Please enter a number 1 or 2");
            var variation = (Calculator.StackVariation)(Console.Read() % 2);
            var result = Calculator.CountAnExpression(read, variation);
            if (!result.Item2)
            {
                Console.WriteLine("An error occured");
                Environment.Exit(1);
            }
            Console.WriteLine($"Expression value: {result.Item1}");
        }
    }
}

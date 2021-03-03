using System;

namespace Calculator
{
    class Program
    {
        public enum StackVariation
        {
            ArrayStack,
            ListStack
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an expression");
            string read = Console.ReadLine();
            Console.WriteLine("Please enter a number 1 or 2");
            var variation = (StackVariation)(Console.Read() % 2);
            IStack stack = variation == StackVariation.ArrayStack ? new StackArray() : new StackList();
            var result = Calculator.CountAnExpression(read, stack);
            if (!result.Item2)
            {
                Console.WriteLine("An error occured");
                Environment.Exit(1);
            }
            Console.WriteLine($"Expression value: {result.Item1}");
        }
    }
}

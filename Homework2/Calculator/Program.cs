using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an expression");
            string read = Console.ReadLine();
            Console.WriteLine("Please enter number 0 or 1:\n0 - Array-based stack\n1 - List-based stack");
            IStack stack = Console.Read() == '0' ? new StackArray() as IStack : new StackList();
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

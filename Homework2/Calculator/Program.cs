using System;

namespace Calculator
{
    class Program
    {
        static double CountAnExpression(string expression)
        {
            string[] numbers = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IStack stack;
            for (int i =0; i < numbers.Length; i++)
            {
                int number;
                bool isNumber = int.TryParse(numbers[i], out number);
                if (isNumber)
                {
                    stack.Push(number);
                }
                else
                {
                    double first = stack.Pop();
                    double second = stack.Pop();
                    numbers[i] switch
                    {
                        "+" => stack.Push(first + second);
                    };
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an expression");
            string read = Console.ReadLine();
        }
    }
}

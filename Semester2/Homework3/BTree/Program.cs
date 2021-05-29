using System;

namespace BTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please define degree of the tree");
            string read = Console.ReadLine();
            string[] numbers = read.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var treeDegree = int.Parse(numbers[0]);
        }
    }
}

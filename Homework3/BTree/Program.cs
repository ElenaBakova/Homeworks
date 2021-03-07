using System;

namespace BTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please define order of the tree");
            string read = Console.ReadLine();
            string[] numbers = read.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var treeOrder = int.Parse(numbers[0]);
        }
    }
}

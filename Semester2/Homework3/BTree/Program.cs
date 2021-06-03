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
            var tree = new BTree(treeDegree);
            tree.Insert("1", "2");
            tree.Insert("3", "4");
            tree.Insert("0", "11");
            tree.Insert("5", "6");
            tree.Insert("8", "9");
            tree.Insert("6", "7");
            tree.Insert("2", "7");
            tree.Insert("4", "4");
            tree.Insert("01", "6");
            tree.Insert("7", "31");
            tree.Insert("07", "7");
            tree.Insert("9", "1");
        }
    }
}

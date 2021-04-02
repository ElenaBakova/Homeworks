using System;

namespace ParseTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var readString = Console.ReadLine();
            var elements = readString.Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var tree = new Tree();
            tree.BuildTree(elements);
            tree.Print();
            Console.Write($"= {tree.Count()}");
        }
    }
}

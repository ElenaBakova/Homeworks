using System;
using System.IO;

namespace ParseTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string readString = File.ReadAllText("../../../input.txt");
            var tree = new Tree(readString);
            tree.Print();
            Console.Write($"= {tree.Count()}");
        }
    }
}

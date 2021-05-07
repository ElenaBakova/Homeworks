using System;
using System.IO;

namespace ParseTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string readString;
            using (var reader = new StreamReader("../../../input.txt"))
            {
                readString = reader.ReadLine();
            }
            var tree = new Tree(readString);
            tree.Print();
            Console.Write($"= {tree.Count()}");
        }
    }
}

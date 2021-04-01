using System;

namespace ParseTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string readString = "* 2 ( - 0 (- 5 (+ 6 11) ) ) ";
            char[] separators = new char[] { ' ', '(', ')' };
            string[] elements = readString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Tree tree = new Tree();
            tree.BuildTree(elements);
        }
    }
}

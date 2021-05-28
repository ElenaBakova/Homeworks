using System;
using System.Collections.Generic;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 5, 2, 9 };
            BubbleSort.Sorting(list, (x, y) => x > y);
            foreach (var element in list)
            {
                Console.Write($"{element} ");
            }
        }
    }
}

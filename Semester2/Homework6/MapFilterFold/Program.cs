using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MapFilterFold
{
    class Program
    {
        public List<int> MapFilterFold(List<int> list, [Optional] int value, Func<int, T> function)
        {
            var answerList = new List<int>();
            foreach (var element in list)
            {
                var functionResult = function(element);
                if (functionResult is int)
                {
                    answerList.Add(functionResult);
                }
                if (functionResult is bool && functionResult)
                {
                    answerList.Add(element);
                }
            }
            return answerList;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

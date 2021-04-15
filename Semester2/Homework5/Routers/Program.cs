using System;
using System.Collections.Generic;
using System.IO;


namespace Routers
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Precalculations.ReadFromFile(args[0]);
            try
            {
                var answer = KruskalAlgorithm.GetMinimumSpanningTree(result.Item1, result.Item2);
            }
            catch (UnconnectedGraphException exception)
            {
                Console.Error.WriteLine(exception.Message);
            }
        }
    }
}

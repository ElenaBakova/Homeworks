using System;
using System.IO;
using System.Linq;

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
                using (FileStream fs = File.Open(args[1], FileMode.Open, FileAccess.Write))
                {
                    answer = answer.OrderBy(x => x.Start).ToList();

                }
            }
            catch (UnconnectedGraphException exception)
            {
                Console.Error.WriteLine(exception.Message);
                Environment.Exit(-1);
            }
        }
    }
}

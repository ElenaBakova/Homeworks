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
                using (var writer = new StreamWriter(args[1], false))
                {
                    answer = answer.OrderBy(x => x.Start).ToList();
                    int start = -1;
                    foreach (var current in answer)
                    {
                        if (start == current.Start)
                        {
                            writer.Write($"{current.Finish} ({-current.Weight}) ");
                            continue;
                        }
                        start = current.Start;
                        writer.Write($"\n{start}: {current.Finish} ({-current.Weight}) ");
                    }
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

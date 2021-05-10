using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Routers
{
    /// <summary>
    /// Class with methods for precalculations
    /// </summary>
    public class Precalculations
    {
        private static void DFS(int vertex, int[,] graph, ref bool[] used)
        {
            if (used[vertex])
            {
                return;
            }

            used[vertex] = true;
            for (int i = 0; i < used.Length; i++)
            {
                if (graph[vertex, i] == 1)
                {
                    DFS(i, graph, ref used);
                }
            }
        }

        /// <summary>
        /// Checks graph connectivity
        /// </summary>
        /// <param name="countVertices">Number of graph vertices</param>
        /// <param name="edges">List of graph edges</param>
        /// <returns>True if graph is connected</returns>
        public static bool CheckConnectivity(int countVertices, List<Edge> edges)
        {
            var graph = new int[countVertices, countVertices];
            foreach (var edge in edges)
            {
                graph[edge.Start - 1, edge.Finish - 1] = 1;
                graph[edge.Finish - 1, edge.Start - 1] = 1;
            }
            var used = new bool[countVertices];
            DFS(0, graph, ref used);
            return used.All(x => x);
    }

        /// <summary>
        /// Reads graph from file
        /// </summary>
        /// <param name="path">Input file path</param>
        /// <returns>Lists of edges and nodes</returns>
        public static (List<Edge>, HashSet<int>) ReadFromFile(string path)
        {
            var nodes = new HashSet<int>();
            var edges = new List<Edge>();
            using (StreamReader stream = File.OpenText(path))
            {
                string readString;
                var symbols = new char[] { ' ', '(', ')', ':', ',' };
                while ((readString = stream.ReadLine()) != null)
                {
                    var numbers = readString.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                    var start = int.Parse(numbers[0]);
                    nodes.Add(start);
                    for (int i = 2; i < numbers.Length; i += 2)
                    {
                        edges.Add(new Edge(start, int.Parse(numbers[i - 1]), -int.Parse(numbers[i])));
                        nodes.Add(int.Parse(numbers[i - 1]));
                    }
                }
            }
            return (edges, nodes);
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Routers
{
    /// <summary>
    /// Alghorithm which creates minimum spanning tree
    /// </summary>
    public class KruskalAlgorithm
    {
        /// <summary>
        /// Makes minimum spanning tree
        /// </summary>
        /// <param name="edges">List of graph edges</param>
        /// <param name="nodes">List of graph nodes</param>
        /// <returns>Minimum spanning tree</returns>
        public static List<Edge> GetMinimumSpanningTree(List<Edge> edges, HashSet<int> nodes)
        {
            if (!Precalculations.CheckConnectivity(nodes.Count, edges))
            {
                throw new UnconnectedGraphException();
            }

            var resultList = new List<Edge>();
            var dsu = new DSU();

            foreach (var node in nodes)
            {
                dsu.MakeSet(node);
            }

            edges = edges.OrderBy(x => x.Weight).ToList();
            // Тут еще точно работает, дальше тёмный лес
            foreach (var currentEdge in edges)
            {
                int first = currentEdge.Start;
                int second = currentEdge.Finish;
                int weight = currentEdge.Weight;

                if (dsu.FindSet(first) != dsu.FindSet(second))
                {
                    resultList.Add(currentEdge);
                    dsu.UnionSet(first, second);
                }
            }

            return resultList;
        }
    }
}

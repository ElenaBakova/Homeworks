using System.Collections.Generic;
using System.Linq;

namespace Routers
{
    /// <summary>
    /// Alghorithm which creates minimum spanning tree
    /// </summary>
    class KruskalAlgorithm
    {
        /// <summary>
        /// Makes minimum spanning tree
        /// </summary>
        /// <param name="edges">List of graph edges</param>
        /// <param name="nodes">List of graph nodes</param>
        /// <returns>Minimum spanning tree</returns>
        public List<Edge> GetMinimumSpanningTree(IEnumerable<Edge> edges, List<int> nodes)
        {
            var resultList = new List<Edge>();
            var dsu = new DSU();

            foreach (var node in nodes)
            {
                dsu.MakeSet(node);
            }

            edges = edges.OrderBy(x => x.Weight);
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

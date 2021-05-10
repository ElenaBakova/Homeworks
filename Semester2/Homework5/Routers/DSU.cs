using System.Collections.Generic;

namespace Routers
{
    /// <summary>
    /// Disjoint set union class
    /// </summary>
    class DSU
    {
        private Dictionary<int, int> parent;
        private Dictionary<int, int> rank;

        public DSU()
        {
            parent = new();
            rank = new();
        }

        /// <summary>
        /// Creates new set which contains one element
        /// </summary>
        /// <param name="vertex">Vertex for a set</param>
        public void MakeSet(int vertex)
        {
            parent.Add(vertex, vertex);
            rank.Add(vertex, 0);
        }

        /// <summary>
        /// Searches for main vertex of the set
        /// </summary>
        /// <returns>Main vertex of the set</returns>
        public int FindSet(int vertex)
            => (vertex == parent[vertex]) ? vertex : (parent[vertex] = FindSet(parent[vertex]));

        private void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        /// <summary>
        /// Unites two sets
        /// </summary>
        /// <param name="first">First set</param>
        /// <param name="second">Second set</param>
        public void UnionSet(int first, int second)
        {
            first = FindSet(first);
            second = FindSet(second);
            if (first == second)
            {
                return;
            }
            if (rank[first] < rank[second])
            {
                Swap(ref first, ref second);
            }
            parent[second] = first;
            if (rank[first] == rank[second])
            {
                rank[first]++;
            }
        }
    }
}

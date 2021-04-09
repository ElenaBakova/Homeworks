using System.Collections.Generic;

namespace Routers
{
    class DSU
    {
        private Dictionary<int, int> parent;
        private Dictionary<int, int> rank;

        public void Dsu()
        {
            parent = new();
            rank = new();
        }

        public void MakeSet(int vertex)
        {
            parent.Add(vertex, vertex);
            rank.Add(vertex, 0);
        }

        public int FindSet(int vertex)
            => (vertex == parent[vertex]) ? vertex : (parent[vertex] = FindSet(parent[vertex]));

        private void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

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

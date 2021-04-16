using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Routers.Tests
{
    public class Tests
    {
        [Test]
        public void UnconnectedGraphTest()
        {
            var edges = new List<Edge>();
            edges.Add(new Edge(1, 2, 10));
            var nodes = new HashSet<int> { 1, 2, 3 };
            Assert.Throws<UnconnectedGraphException>(() => KruskalAlgorithm.GetMinimumSpanningTree(edges, nodes));
        }

        private class ListComparer : IEqualityComparer<Edge>
        {
            public bool Equals(Edge first, Edge second)
            {
                if (second == null && first == null)
                {
                    return true;
                }
                if (second == null || first == null)
                {
                    return false;
                }
                return first.Start == second.Start && first.Finish == second.Finish && first.Weight == second.Weight;
            }

            public int GetHashCode(Edge edge)
            {
                int hCode = edge.Start ^ edge.Finish ^ edge.Weight;
                return hCode.GetHashCode();
            }
        }

        [Test]
        public void GraphTest()
        {
            var edges = new List<Edge>();
            edges.Add(new Edge(1, 2, -10));
            edges.Add(new Edge(2, 3, -20));
            edges.Add(new Edge(3, 5, -30));
            edges.Add(new Edge(5, 4, -40));
            edges.Add(new Edge(1, 4, -1));
            edges.Add(new Edge(1, 5, -3));
            edges.Add(new Edge(3, 4, -2));
            var answerList = new List<Edge>();
            answerList.Add(new Edge(5, 4, -40));
            answerList.Add(new Edge(3, 5, -30));
            answerList.Add(new Edge(2, 3, -20));
            answerList.Add(new Edge(1, 2, -10));
            var nodes = new HashSet<int> { 1, 2, 3, 4, 5 };
            Assert.IsTrue(answerList.SequenceEqual(KruskalAlgorithm.GetMinimumSpanningTree(edges, nodes), new ListComparer()));
        }
    }
}
using System.Collections.Generic;
using NUnit.Framework;

namespace Routers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var edges = new List<Edge>();
            edges.Add(new Edge(1, 2, 10));
            var nodes = new HashSet<int> { 1, 2, 3 };
            Assert.Throws<UnconnectedGraphException>(() => KruskalAlgorithm.GetMinimumSpanningTree(edges, nodes));
        }
    }
}
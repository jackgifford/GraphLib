using GraphLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib.Tests.Models
{
    [TestClass]
    public class AdjacencyTests
    {
        [TestMethod]
        public void BasicTests()
        {
            var adjList = new DirectedAdjacencyList<int>(2);

            adjList.AddVertex(10);
            adjList.AddVertex(20);

            adjList.CreateEdge(10, 20);

            Assert.IsTrue(adjList.Adjacent(10, 20));
            Assert.IsFalse(adjList.Adjacent(20, 10));

            var undirectedList = new UndirectedAdjacenyList<int>(2);

            undirectedList.AddVertex(10);
            undirectedList.AddVertex(20);

            undirectedList.CreateEdge(10, 20);

            Assert.IsTrue(undirectedList.Adjacent(10, 20));
            Assert.IsTrue(undirectedList.Adjacent(20, 10));
        }
    }
}

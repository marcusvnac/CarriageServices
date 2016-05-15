using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarriageServices.Models;
using CarriageServices.Business;

namespace CarriageServices.Tests.Business
{
    [TestClass]
    public class GraphBusinessTest
    {
        [TestMethod]
        public void CreateGraphTest()
        {
            // arrange
            string graphInfo = "AB6, AE4, BA6, BC2, BD4, CB3, CD1, CE7, DB8, EB5, ED7";

            // act
            Graph graphTest = GraphBusiness.CreateGraph(graphInfo);

            // assert
            Assert.IsTrue(graphTest.Nodes.Count == 5);
            Assert.IsTrue(graphTest.Nodes.Find(n => n.Name.Equals('A')).Connections.Count == 2);
            Assert.IsTrue(graphTest.Nodes.Find(n => n.Name.Equals('B')).Connections.Count == 3);
            Assert.IsTrue(graphTest.Nodes.Find(n => n.Name.Equals('C')).Connections.Count == 3);
            Assert.IsTrue(graphTest.Nodes.Find(n => n.Name.Equals('D')).Connections.Count == 1);
            Assert.IsTrue(graphTest.Nodes.Find(n => n.Name.Equals('E')).Connections.Count == 2);
        }
    }
}

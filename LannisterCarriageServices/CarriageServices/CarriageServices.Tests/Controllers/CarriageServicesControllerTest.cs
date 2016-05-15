using CarriageServices.Controllers;
using CarriageServices.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace CarriageServices.Tests.Controllers
{
    [TestClass]
    public class CarriageServicesControllerTest
    {
        [TestMethod]
        public void PostGraphTest()
        {
            // Arrange
            CarriageServicesController controller = new CarriageServicesController();

            // Act
            HttpStatusCode resp = controller.PostGraph("AB6, AE4, BA6, BC2, BD4, CB3, CD1, CE7, DB8, EB5, ED7");

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, resp);
        }


        [TestMethod]
        public void GetAllRoutesTest()
        {
            // Arrange
            CarriageServicesController controller = new CarriageServicesController();
            controller.PostGraph("AB6, AE4, BA6, BC2, BD4, CB3, CD1, CE7, DB8, EB5, ED7");

            // Act
            var resp = controller.GetAllRoutes('C', 'C', 3);

            // Assert
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void GetDistanceTest()
        {
            // Arrange
            CarriageServicesController controller = new CarriageServicesController();
            controller.PostGraph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");

            // Act
            int resp = controller.GetDistance("A-B-C");

            // Assert
            Assert.AreEqual(9, resp);
        }

        [TestMethod]
        public void GetShortestRouteTest()
        {
            // Arrange
            CarriageServicesController controller = new CarriageServicesController();
            controller.PostGraph("AB6, AE4, BA6, BC2, BD4, CB3, CD1, CE7, DB8, EB5, ED7");

            // Act
            var resp = controller.GetShortestRoute('C', 'C');

            // Assert
            Assert.IsNotNull(resp);
        }
    }
}

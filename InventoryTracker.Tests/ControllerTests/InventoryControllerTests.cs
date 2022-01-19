using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class InventoryControllerTests
    {
        [TestMethod]
        public void TestBuildReadQuery()
        {
            ITableRead inventoryController = new InventoryController();
            string returnedQuery = "";
            returnedQuery = inventoryController.BuildReadQuery();
            Assert.IsTrue(returnedQuery.Contains("GET\nSELECT"));
        }
    }
}
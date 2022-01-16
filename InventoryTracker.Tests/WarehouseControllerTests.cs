using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class WarehouseControllerTests
    {
        [TestMethod]
        public void TestBuildReadQuery()
        {
            ITableRead warehouseController = new WarehouseController();
            string returnedQuery = "";
            returnedQuery = warehouseController.BuildReadQuery();
            Assert.IsTrue(returnedQuery.Contains("GET\nSELECT"));
        }

        //[TestMethod]
        //public void TestBuildCUDQuery()
        //{
        //    ITableRead inventoryController = new InventoryController();
        //    string returnedQuery = "";
        //    returnedQuery = inventoryController.BuildReadQuery();
        //    Assert.IsTrue(returnedQuery.Contains("GET\nSELECT"));
        //}
    }
}

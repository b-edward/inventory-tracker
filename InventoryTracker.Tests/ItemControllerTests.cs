using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class ItemControllerTests
    {
        [TestMethod]
        public void TestBuildReadQuery()
        {
            ITableRead itemController = new InventoryController();
            string returnedQuery = "";
            returnedQuery = itemController.BuildReadQuery();
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

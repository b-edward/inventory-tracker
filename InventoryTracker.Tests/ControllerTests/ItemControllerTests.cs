using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class ItemControllerTests
    {
        [TestMethod]
        public void TestBuildReadQuery()
        {
            ITableRead itemController = new ItemController();
            string returnedQuery = "";
            returnedQuery = itemController.BuildReadQuery();
            Assert.IsTrue(returnedQuery.Contains("GET\nSELECT"));
        }

        [TestMethod]
        public void TestBuildReadNewestQuery()
        {
            ItemController itemController = new ItemController();
            string returnedQuery = "";
            returnedQuery = itemController.BuildReadNewestQuery();
            Assert.IsTrue(returnedQuery.Contains("LIMIT 1"));
        }

        [TestMethod]
        public void TestBuildCUDQueryPUT()
        {
            ITableCUD itemController = new ItemController();
            Item itemTable = new Item();
            itemTable.ProductID = "3";
            itemTable.IsAssigned = 0;
            itemTable.IsSold = 0;

            string returnedQuery = itemController.BuildCUDQuery(itemTable, "PUT");
            Assert.IsTrue(returnedQuery.Contains("PUT\nINSERT"));
        }

        [TestMethod]
        public void TestBuildCUDQueryPOST()
        {
            ITableCUD itemController = new ItemController();
            Item itemTable = new Item();
            itemTable.ItemID = "1";
            itemTable.ProductID = "3";
            itemTable.IsAssigned = 1;
            itemTable.IsSold = 1;

            string returnedQuery = itemController.BuildCUDQuery(itemTable, "POST");
            Assert.IsTrue(returnedQuery.Contains("POST\nUPDATE"));
        }
    }
}

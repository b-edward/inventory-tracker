using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class WarehouseItemControllerTests
    {
        [TestMethod]
        public void TestBuildReadQuery()
        {
            ITableRead warehouseItemController = new WarehouseItemController();
            string returnedQuery = "";
            returnedQuery = warehouseItemController.BuildReadQuery();
            Assert.IsNull(returnedQuery);
        }

        [TestMethod]
        public void TestBuildCUDQueryPUT()
        {
            WarehouseItemController warehouseItemController = new WarehouseItemController();
            WarehouseItem warehouseItemTable = new WarehouseItem();

            warehouseItemTable.WarehouseItemID = "1";
            warehouseItemTable.ItemID = "99999";

            string returnedQuery = warehouseItemController.BuildCUDQuery(warehouseItemTable, "PUT");
            Assert.IsTrue(returnedQuery.Contains("PUT\nINSERT"));
        }

        [TestMethod]
        public void TestBuildCUDQueryPOST()
        {
            WarehouseItemController warehouseItemController = new WarehouseItemController();
            WarehouseItem warehouseItemTable = new WarehouseItem();

            warehouseItemTable.WarehouseItemID = "2";
            warehouseItemTable.ItemID = "99999";

            string returnedQuery = warehouseItemController.BuildCUDQuery(warehouseItemTable, "POST");
            Assert.IsTrue(returnedQuery.Contains("POST\nUPDATE"));
        }

        [TestMethod]
        public void TestBuildCUDQueryDELETE()
        {
            WarehouseItemController warehouseItemController = new WarehouseItemController();
            WarehouseItem warehouseItemTable = new WarehouseItem();

            warehouseItemTable.WarehouseItemID = "2";
            warehouseItemTable.ItemID = "99999";

            string returnedQuery = warehouseItemController.BuildCUDQuery(warehouseItemTable, "DELETE");
            Assert.IsTrue(returnedQuery.Contains("DELETE\nDELETE"));
        }
    }
}

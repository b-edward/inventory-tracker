using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void TestBuildCUDQueryPUT()
        {
            WarehouseController warehouseController = new WarehouseController();
            Warehouse warehouseTable = new Warehouse();
            Guid randomName = Guid.NewGuid();

            warehouseTable.WarehouseID = "";
            warehouseTable.StreetAndNo = randomName.ToString();
            warehouseTable.City = "San Francisco";
            warehouseTable.ProvinceOrState = "California";
            warehouseTable.Country = "USA";
            warehouseTable.PostalCode = "90219";
            warehouseTable.IsActive = 1;

            string returnedQuery = warehouseController.BuildCUDQuery(warehouseTable, "PUT");
            Assert.IsTrue(returnedQuery.Contains("PUT\nINSERT"));
        }

        [TestMethod]
        public void TestBuildCUDQueryPOST()
        {
            WarehouseController warehouseController = new WarehouseController();
            Warehouse warehouseTable = new Warehouse();
            Guid randomName = Guid.NewGuid();

            warehouseTable.WarehouseID = "";
            warehouseTable.StreetAndNo = randomName.ToString();
            warehouseTable.City = "Los Angeles";
            warehouseTable.ProvinceOrState = "California";
            warehouseTable.Country = "USA";
            warehouseTable.PostalCode = "90210";
            warehouseTable.IsActive = 1;

            string returnedQuery = warehouseController.BuildCUDQuery(warehouseTable, "POST");
            Assert.IsTrue(returnedQuery.Contains("POST\nUPDATE"));
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
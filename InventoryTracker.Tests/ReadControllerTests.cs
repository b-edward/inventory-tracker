using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class ReadControllerTests
    {
        [TestMethod]
        public void TestGetInventory()
        {
            IReadController readController = new ReadController();
            DataTable inventoryTable = null;

            // Check that GetInventory() is returning a DataTable
            inventoryTable = readController.GetInventory();
            Assert.IsNotNull(inventoryTable);
        }

        [TestMethod]
        public void TestGetTableProduct()
        {
            IReadController readController = new ReadController();
            DataTable datatable = null;

            // Check that GetTable() is returning a DataTable
            datatable = readController.GetTable("Product");
            Assert.IsNotNull(datatable);
        }

        [TestMethod]
        public void TestGetTableItem()
        {
            IReadController readController = new ReadController();
            DataTable datatable = null;

            // Check that GetTable() is returning a DataTable
            datatable = readController.GetTable("Item");
            Assert.IsNotNull(datatable);
        }

        [TestMethod]
        public void TestGetTableWarehouse()
        {
            IReadController readController = new ReadController();
            DataTable datatable = null;

            // Check that GetTable() is returning a DataTable
            datatable = readController.GetTable("Warehouse");
            Assert.IsNotNull(datatable);
        }

    }
}
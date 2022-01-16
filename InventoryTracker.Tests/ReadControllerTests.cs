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
        public void TestGetTable()
        {
            IReadController readController = new ReadController();
            DataTable datatable = null;
            string[] tables = new string[3] { "Product", "Item", "Warehouse" };

            for (int i = 0; i < tables.Length -1; i++)
            {
                // Reset table to null
                datatable = null;
                // Check that GetTable() is returning a DataTable
                datatable = readController.GetTable("");
                Assert.IsNotNull(datatable);
            }
        }
    }
}
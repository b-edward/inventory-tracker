using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class EditControllerTests
    {
        [TestMethod]
        public void TestExecuteCUD()
        {
            IEditController editController = new EditController();
            IProduct table = new Product();
            string command = "PUT";
            string tableName = "Product";

            string returnString = editController.ExecuteCUD(table, command, tableName);

            Assert.IsTrue(returnString.Contains("200"));
        }
    }
}
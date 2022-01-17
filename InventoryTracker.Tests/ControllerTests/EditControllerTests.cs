using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class EditControllerTests
    {
        [TestMethod]
        public void TestExecutePUT()
        {
            IEditController editController = new EditController();
            Guid randomName = Guid.NewGuid();
            IProduct table = new Product();
            table.ProductID = "";
            table.ProductName = randomName.ToString();
            table.IsActive = 1;

            string command = "PUT";
            string tableName = "Product";

            string returnString = editController.ExecuteCUD(table, command, tableName);

            Assert.AreEqual(returnString, "Request executed successfully.");
        }

        [TestMethod]
        public void TestExecutePUTException()
        {
            IEditController editController = new EditController();
            Guid randomName = Guid.NewGuid();
            IProduct table = new Product();
            table.ProductID = "";
            table.ProductName = "";
            table.IsActive = 7;

            string command = "PUT";
            string tableName = "Product";

            string returnString = editController.ExecuteCUD(table, command, tableName);

            Assert.AreNotEqual(returnString, "Request executed successfully.");
        }

        [TestMethod]
        public void TestExecutePOST()
        {
            IEditController editController = new EditController();
            Guid randomName = Guid.NewGuid();
            IProduct table = new Product();
            table.ProductID = "1";
            table.ProductName = "NewNew";
            table.IsActive = 1;

            string command = "POST";
            string tableName = "Product";

            string returnString = editController.ExecuteCUD(table, command, tableName);

            Assert.AreEqual(returnString, "Request executed successfully.");
        }

        [TestMethod]
        public void TestExecutePOSTException()
        {
            IEditController editController = new EditController();
            Guid randomName = Guid.NewGuid();
            IProduct table = new Product();
            table.ProductID = "";
            table.ProductName = "";
            table.IsActive = 7;

            string command = "POST";
            string tableName = "Product";

            string returnString = editController.ExecuteCUD(table, command, tableName);

            Assert.AreNotEqual(returnString, "Request executed successfully.");
        }
    }
}
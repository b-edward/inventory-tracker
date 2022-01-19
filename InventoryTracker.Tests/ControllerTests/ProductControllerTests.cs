using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void TestBuildReadQuery()
        {
            ITableRead productController = new ProductController();
            string returnedQuery = "";
            returnedQuery = productController.BuildReadQuery();
            Assert.IsTrue(returnedQuery.Contains("GET\nSELECT"));
        }

        [TestMethod]
        public void TestBuildCUDQueryPUT()
        {
            ITableCUD productController = new ProductController();
            Product productTable = new Product();
            Guid randomName = Guid.NewGuid();

            productTable.ProductID = "";
            productTable.ProductName = randomName.ToString();
            productTable.IsActive = 1;

            string returnedQuery = productController.BuildCUDQuery(productTable, "PUT");
            Assert.IsTrue(returnedQuery.Contains("PUT\nINSERT"));
        }

        [TestMethod]
        public void TestBuildCUDQueryPOST()
        {
            ITableCUD productController = new ProductController();
            Product productTable = new Product();
            Guid randomName = Guid.NewGuid();

            productTable.ProductID = "1";
            productTable.ProductName = randomName.ToString();
            productTable.IsActive = 1;

            string returnedQuery = productController.BuildCUDQuery(productTable, "POST");
            Assert.IsTrue(returnedQuery.Contains("POST\nUPDATE"));
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataServer.ServerClasses;
using DataServer.Interfaces;

namespace DataServer.Tests
{
    [TestClass]
    public class DataHandlerTests
    {
        [TestMethod]
        public void TestCreateHappy()
        {
            IDataHandler dbAccess = new DataHandler();

            string query = "CREATE TABLE IF NOT EXISTS `Products` (`productID` INT NOT NULL AUTO_INCREMENT," +
                            "`productName` VARCHAR(255) NOT NULL, PRIMARY KEY(`productID`)) ENGINE = InnoDB " +
                            "DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;";

            Assert.IsTrue(dbAccess.Create(query));
        }

        [TestMethod]
        public void TestCreateQueryNull()
        {
            IDataHandler dbAccess = new DataHandler();

            string query = null;

            Assert.IsFalse(dbAccess.Create(query));
        }

        [TestMethod]
        public void TestReadHappy()
        {
            IDataHandler dbAccess = new DataHandler();

            string query = "SELECT * FROM `Products`;";

            Assert.IsTrue(dbAccess.Create(query));
        }

        [TestMethod]
        public void TestReadQueryNull()
        {
            IDataHandler dbAccess = new DataHandler();

            string query = null;

            Assert.IsFalse(dbAccess.Create(query));
        }
    }
}

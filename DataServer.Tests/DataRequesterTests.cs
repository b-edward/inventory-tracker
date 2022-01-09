using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataServer.ServerClasses;
using DataServer.Interfaces;

namespace DataServer.Tests
{
    [TestClass]
    public class DataRequesterTests
    {
        [TestMethod]
        public void TestCreateHappy()
        {
            IDataRequester dbAccess = new DataRequester();

            string query = "CREATE TABLE IF NOT EXISTS `Products` (`productID` INT NOT NULL AUTO_INCREMENT," +
                            "`productName` VARCHAR(255) NOT NULL, PRIMARY KEY(`productID`)) ENGINE = InnoDB " +
                            "DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;";

            string response = dbAccess.Create(query);

            Assert.AreNotEqual(response, "error");
        }

        [TestMethod]
        public void TestCreateQueryNull()
        {
            IDataRequester dbAccess = new DataRequester();

            string query = null;

            string response = dbAccess.Create(query);

            Assert.AreEqual(response, "error");
        }

        [TestMethod]
        public void TestReadHappy()
        {
            IDataRequester dbAccess = new DataRequester();

            string query = "SELECT * FROM `Products`;";

            string response = dbAccess.Create(query);

            Assert.AreNotEqual(response, "error");
        }

        [TestMethod]
        public void TestReadQueryNull()
        {
            IDataRequester dbAccess = new DataRequester();

            string query = null;

            string response = dbAccess.Create(query);

            Assert.AreEqual(response, "error");
        }
    }
}

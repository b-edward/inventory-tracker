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
        public void TestCreateQueryNull()
        {
            IDataHandler dataHandler = new DataHandler();
            string query = null;
            Assert.IsFalse(dataHandler.Create(query));
        }

        [TestMethod]
        public void TestReadQueryNull()
        {
            IDataHandler dataHandler = new DataHandler();
            string query = null;
            string response = dataHandler.Read(query);
            Assert.IsNull(response);
        }

        [TestMethod]
        public void TestUpdateQueryNull()
        {
            IDataHandler dataHandler = new DataHandler();
            string query = null;
            Assert.IsFalse(dataHandler.Update(query));
        }

        [TestMethod]
        public void TestDeleteQueryNull()
        {
            IDataHandler dataHandler = new DataHandler();
            string query = null;
            Assert.IsFalse(dataHandler.Delete(query));
        }

        [TestMethod]
        public void ExecuteCUDHappyQueryNull()
        {
            DataHandler dataHandler = new DataHandler();
            bool status = dataHandler.ExecuteCUD(null);
            Assert.IsFalse(status);
        }
    }
}

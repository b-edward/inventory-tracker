using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InventoryTracker.DataServerAccess;
using InventoryTracker.Interfaces;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class ServerHandlerTests
    {
        [TestMethod]
        public void TestSendToServer()
        {
            IServerHandler serverHandler = new ServerHandler();
            string serverResponse = "";
            string request = "GET\nSELECT * FROM `Product`;";
            serverResponse = serverHandler.SendToServer(request);
            bool success = serverResponse.Contains("200");
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestSendToServerException()
        {
            IServerHandler serverHandler = new ServerHandler();
            string serverResponse = "";
            string request = "";
            serverResponse = serverHandler.SendToServer(request);
            Assert.IsTrue(serverResponse.Contains("400"));
        }
    }
}


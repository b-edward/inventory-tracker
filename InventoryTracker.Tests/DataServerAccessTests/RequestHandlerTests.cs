using InventoryTracker.DataServerAccess;
using InventoryTracker.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class RequestHandlerTests
    {
        [TestMethod]
        public void TestSendRequest()
        {
            IRequestHandler requestHandler = new RequestHandler();
            string serverResponse = "";
            string request = "GET\nSELECT * FROM `Product`;";
            serverResponse = requestHandler.SendRequest(request);
            bool success = serverResponse.Contains("200");
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestSendRequestException()
        {
            IRequestHandler requestHandler = new RequestHandler();
            string serverResponse = "";
            string request = "BREW\nDoppio espresso per favore";
            serverResponse = requestHandler.SendRequest(request);
            bool success = serverResponse.Contains("200");
            Assert.IsFalse(success);
        }
    }
}
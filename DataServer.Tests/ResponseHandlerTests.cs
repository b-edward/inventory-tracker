using DataServer.ServerClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;

namespace DataServer.Tests
{
    [TestClass]
    public class ResponseHandlerTests
    {
        [TestMethod]
        public void TestSendResponseClientNull()
        {
            ResponseHandler responseHandler = new ResponseHandler();

            NetworkStream stream = null;

            bool status = responseHandler.SendResponse(stream, "This is the response");

            Assert.IsFalse(status);
        }
    }
}
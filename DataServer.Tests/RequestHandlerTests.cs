using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataServer.ServerClasses;
using DataServer.Interfaces;
using System.Net.Sockets;

namespace DataServer.Tests
{
    [TestClass]
    public class RequestHandlerTests
    {
        [TestMethod]
        public void TestHandleRequestClientNull()
        {
            IRequestHandler handler = new RequestHandler();

            TcpClient client = null;

            bool status = handler.HandleRequest(client);
            Assert.IsFalse(status);
        }

        [TestMethod]
        public void TestGetRequestStreamNull()
        {
            IRequestHandler handler = new RequestHandler();

            NetworkStream stream = null;

            string response = handler.GetRequest(stream);

            Assert.IsTrue(response.Contains("500"));
        }
    }
}

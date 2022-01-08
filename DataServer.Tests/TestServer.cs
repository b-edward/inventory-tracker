using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataServer;

namespace DataServer.Tests
{
    [TestClass]
    public class TestServer
    {
        [TestMethod]
        public void TestSingletonServer()
        {
            Server testServer = Server.GetServerInstance;
            Server anotherTestServer = Server.GetServerInstance;

            Assert.AreEqual(testServer, anotherTestServer);
        }
    }
}

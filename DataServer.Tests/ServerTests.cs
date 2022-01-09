using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataServer.ServerClasses;

namespace DataServer.Tests
{
    [TestClass]
    public class ServerTests
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

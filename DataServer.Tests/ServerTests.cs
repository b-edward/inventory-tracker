using DataServer.ServerClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
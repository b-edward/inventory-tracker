using DataServer.Interfaces;
using DataServer.ServerClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataServer.Tests
{
    [TestClass]
    public class RequestParserTests
    {
        [TestMethod]
        public void TestParseReceivedException()
        {
            IRequestParser requestParser = new RequestParser();

            string request = "BREW\nEsspresso";

            string response = requestParser.ParseReceived(request);

            Assert.IsTrue(response.Contains("405"));
        }
    }
}
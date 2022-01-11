using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataServer.ServerClasses;
using DataServer.Interfaces;

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
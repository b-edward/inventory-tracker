using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataServer.Log;
using DataServer.Interfaces;

namespace DataServer.Tests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void TestConstructorHappy()
        {
            string testFile = "TestLog.txt";
            ILogger serverLog = new Logger(testFile);
            Assert.IsTrue(serverLog.LogPath.Contains(testFile));
        }

        [TestMethod]
        public void TestConstructorInvalidFileName()
        {
            string testFile = "Tes!%$tLog.txt";
            ILogger serverLog = new Logger(testFile);
            Assert.IsTrue(serverLog.LogPath.Contains(testFile));
        }

        [TestMethod]
        public void TestLogHappy()
        {
            string testFile = "TestLog.txt";
            ILogger serverLog = new Logger(testFile);            
            Assert.IsTrue(serverLog.Log("All good!"));
        }

        [TestMethod]
        public void TestLogMessageNull()
        {
            string testFile = "TestLog.txt";
            ILogger serverLog = new Logger(testFile);
            Assert.IsFalse(serverLog.Log(null));
        }
    }
}

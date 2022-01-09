﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataServer.DataAccess;
using DataServer.Interfaces;
using System.Data;

namespace DataServer.Tests
{
    [TestClass]
    public class DatabaseHandlerTests
    {
        [TestMethod]
        public void TestExecuteHappy()
        {
            IDatabase db = new DatabaseHandler();
            db.Connect();
            bool status = db.Execute("INSERT INTO `Products` (`productName`) VALUES ('Test Product');");
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void TestExecuteNullQuery()
        {
            IDatabase db = new DatabaseHandler();
            db.Connect();
            bool status = db.Execute(null);
            Assert.IsFalse(status);
        }

        [TestMethod]
        public void TestSelectHappy()
        {
            IDatabase db = new DatabaseHandler();
            db.Connect();
            DataTable returnedData = db.Select("SELECT * FROM `Products`;");
            Assert.IsNotNull(returnedData);
        }

        [TestMethod]
        public void TestSelectNullQuery()
        {
            IDatabase db = new DatabaseHandler();
            db.Connect();
            DataTable returnedData = db.Select(null);
            Assert.IsNull(returnedData);
        }
    }
}

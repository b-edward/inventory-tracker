using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataServer.DataAccess;
using DataServer.Interfaces;
using System.Data;

namespace DataServer.Tests
{
    [TestClass]
    public class DataTableConverterTests
    {
        [TestMethod]
        public void TestConvertDataTableToStringNull()
        {
            DataTable datatable = null;
            string response = DataTableConverter.ConvertDataTableToString(datatable);
            Assert.IsTrue(response.Contains("500"));
        }

        [TestMethod]
        public void TestConvertDataTableToStringHappy()
        {
            // Create and fill a table
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Name");
            datatable.Columns.Add("Ability");
            DataRow pokemon = datatable.NewRow();
            pokemon["Name"] = "Gengar";
            pokemon["Ability"] = "Shadow Tag";
            datatable.Rows.Add(pokemon);

            string response = DataTableConverter.ConvertDataTableToString(datatable);
            Assert.IsTrue(response.Contains("Gengar"));
        }
    }
}

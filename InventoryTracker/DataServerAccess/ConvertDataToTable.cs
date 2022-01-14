using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InventoryTracker.DataServerAccess
{
    public class ConvertDataToTable
    {
        // Take the server's return data string to fill out a data table
        public static DataTable ConvertToDataTable(string data)
        {
            DataTable dataTable = new DataTable();

            return dataTable;
        }
    }
}
using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InventoryTracker.DataServerAccess
{
    public class ResponseHandler : IResponseHandler
    {
        public ResponseHandler()
        {
        }

        // Use the converter to parse the response and fill the data table
        public DataTable GetDataTable(string response)
        {
            DataTable dataTable = ConvertDataToTable.GetInventoryTable(response);
            return dataTable;
        }
    }
}
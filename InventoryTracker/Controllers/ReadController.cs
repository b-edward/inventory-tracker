using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    public class ReadController : IReadController
    {
        private IRequestHandler requestHandler;
        private IResponseHandler responseHandler;
        private IController controller;

        public DataTable GetInventory()
        {
            DataTable dataTable = new DataTable();

            return dataTable;
        }
        
        public DataTable GetTable(string tableName)
        {
            DataTable dataTable = new DataTable();

            return dataTable;
        }
    }
}
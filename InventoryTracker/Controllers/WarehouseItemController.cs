using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    // This class will be used when user wants to assign an item to a warehouse
    // it will create, update, or delete warehouseItems
    public class WarehouseItemController : ITableRead, ITableCUD, IController
    {
        private IModel warehouseItemTable;

        public WarehouseItemController()
        {
        }

        // Create SQL query to execute the command in the warehouse table
        public string BuildCUDQuery(object table, string command)
        {
            string query = "";

            // Convert the object parameter into a warehouse
            warehouseItemTable = (WarehouseItem)table;

            // Use warehouseItemTable properties to build the command query 

            return query;
        }



        // Read is not used in this release, but included for use is future features
        // Create SQL query to get inventory of all items
        public string BuildReadQuery()
        {
            string query = "";

            // Use itemTable properties to build select query string

            return query;
        }
    }
}
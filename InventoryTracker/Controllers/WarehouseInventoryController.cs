using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    // This class will be used when user wants to assign an item to a warehouse
    // it will create, update, or delete warehouseItems
    // WarehouseItems table is not read here because Inventory already displays
    // the same data as part of the inventory report
    public class WarehouseItemController : ITableRead, ITableCUD
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
    }
}
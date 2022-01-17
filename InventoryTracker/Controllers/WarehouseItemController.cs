using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    // This class will be used when user wants to assign an item to a warehouse
    // it will create, update, or delete warehouseItems
    public class WarehouseItemController : ITableRead, ITableCUD
    {
        private WarehouseItem warehouseItemTable;

        public WarehouseItemController()
        {
        }

        // Create SQL query to execute the command in the warehouse table
        public string BuildCUDQuery(object table, string command)
        {
            // Convert the object parameter into a warehouse
            warehouseItemTable = (WarehouseItem)table;

            string query = GetQuery(table, command);

            return query;
        }

        private string GetQuery(object table, string command)
        {
            string query = "";

            switch (command.ToUpper())
            {
                case "PUT":
                    query = InsertQuery(table, command);
                    break;
                case "POST":
                    query = UpdateQuery(table, command);
                    break;
                case "DELETE":
                    query = DeleteQuery(table, command);
                    break;
            }
            return query;
        }

        private string InsertQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nINSERT INTO `WarehouseItem` (`warehouseID`, `itemID`) " +
                $"VALUES({warehouseItemTable.WarehouseItemID}, {warehouseItemTable.ItemID});";
            return query;
        }

        private string UpdateQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nUPDATE `WarehouseItem` SET warehouseID={warehouseItemTable.WarehouseItemID} " +
                $"WHERE itemID={warehouseItemTable.ItemID};";
            return query;
        }

        private string DeleteQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nDELETE from `WarehouseItem` WHERE itemID={warehouseItemTable.ItemID};";
            return query;
        }


            // Read is not used in this release, but included for use is future features
            // Create SQL query to get inventory of all WarehouseItems
            public string BuildReadQuery()
        {
            string query = "";
            return query;
        }
    }
}
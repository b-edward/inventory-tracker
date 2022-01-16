using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class WarehouseController : ITableRead, ITableCUD
    {
        private IModel warehouseTable;

        public WarehouseController()
        {
        }

        // Create SQL query to execute the command in the warehouse table
        public string BuildCUDQuery(object table, string command)
        {
            // Convert the object parameter into a warehouse
            warehouseTable = (Warehouse)table;

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
            }
            return query;
        }

        private string InsertQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nINSERT INTO `Product` (`productName`, `isActive`) " +
                    $"VALUES ('{warehouseTable.ProductName}', {warehouseTable.IsActive});";
            return query;
        }

        private string UpdateQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nUPDATE `Product` SET productName='{warehouseTable.ProductName}', " +
                    $"isActive={warehouseTable.IsActive} WHERE productID={warehouseTable.ProductID};";
            return query;
        }






        // Create SQL query to get inventory of all warehouses
        public string BuildReadQuery()
        {
            string query = "GET\nSELECT * FROM `Warehouse`;";
            return query;
        }
    }
}
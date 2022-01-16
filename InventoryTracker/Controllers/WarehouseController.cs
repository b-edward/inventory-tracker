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
            string query = "";

            // Convert the object parameter into a warehouse
            warehouseTable = (Warehouse)table;

            // Use warehouseTable properties to build the command query

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
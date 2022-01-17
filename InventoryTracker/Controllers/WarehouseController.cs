using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class WarehouseController : ITableRead, ITableCUD
    {
        private ILocation warehouseTable;

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
            query = $"{command.ToUpper()}\nINSERT INTO `Warehouse` (`streetAndNo`, `city`, `provinceOrState`, " +
                    $"`country`, `postalCode`, `isActive`) VALUES ('{warehouseTable.StreetAndNo}', '{warehouseTable.City}', " +
                    $"'{warehouseTable.ProvinceOrState}', '{warehouseTable.Country}', '{warehouseTable.PostalCode}', " +
                    $"'{warehouseTable.IsActive}');";
            return query;
        }

        private string UpdateQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nUPDATE `Warehouse` SET streetAndNo='{warehouseTable.StreetAndNo}', " +
                $"city='{warehouseTable.City}', provinceOrState='{warehouseTable.ProvinceOrState}', " +
                $"country='{warehouseTable.Country}', postalCode='{warehouseTable.PostalCode}', " +
                $"isActive='{warehouseTable.IsActive}' WHERE warehouseID={warehouseTable.ID};";
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
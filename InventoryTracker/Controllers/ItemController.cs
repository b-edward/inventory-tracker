using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class ItemController : ITableRead, ITableCUD
    {
        private Item itemTable;

        public ItemController()
        {
        }

        // Create SQL query to execute the command in the item table
        public string BuildCUDQuery(object table, string command)
        {
            // Convert the object parameter into a Product
            itemTable = (Item)table;

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
            query = $"{command.ToUpper()}\nINSERT INTO `Item` (`productID`, `isAssigned`, `isSold`) " +
                $"VALUES({itemTable.ProductID}, {itemTable.IsAssigned}, {itemTable.IsSold});";
            return query;
        }

        private string UpdateQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nUPDATE `Item` SET productID={itemTable.ProductID}, " +
                $"isAssigned={itemTable.IsAssigned}, isSold={itemTable.IsSold} WHERE itemID={itemTable.ItemID};";
            return query;
        }


        // Create SQL query to get inventory of all items
        public string BuildReadQuery()
        {
            string query = "GET\nSELECT Item.itemID, Product.productID, Product.productName, Item.isAssigned, WarehouseItem.warehouseID, Item.isSold FROM Item " +
                            "LEFT JOIN Product ON Item.productID = Product.productID " +
                            "LEFT JOIN WarehouseItem ON Item.itemID = WarehouseItem.itemID;";
            return query;
        }

        // Get a SQL query for reading the most recently added item
        public string BuildReadNewestQuery()
        {
            string query = "GET\nSELECT * FROM `Item` ORDER BY itemID DESC LIMIT 1;";
            return query;
        }
    }
}
using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class ItemController : ITableRead, ITableCUD
    {
        private IModel itemTable;

        public ItemController()
        {
        }

        // Create SQL query to execute the command in the item table
        public string BuildCUDQuery(object table, string command)
        {
            string query = "";

            // Convert the object parameter into a Product
            itemTable = (Item)table;

            // Use itemTable properties to build the command query

            return query;
        }

        // Create SQL query to get inventory of all items
        public string BuildReadQuery()
        {
            string query = "GET\nSELECT Item.itemID, Product.productName, Item.isAssigned, Item.isSold FROM Item " +
                            "LEFT JOIN Product ON Item.productID = Product.productID;";
            return query;
        }
    }
}
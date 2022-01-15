using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    public class InventoryController : ITableRead
    {
        private IModel itemTable;
        private IModel productTable;
        private IModel warehouseTable;
        private IModel warehouseItemTable;

        public InventoryController()
        {
            // Instantiate models
            itemTable = new Item();
            productTable = new Product();
            warehouseTable = new Warehouse();
            warehouseItemTable = new WarehouseItem();
        }

        // Method to get the total inventory of all active && unsold items
        public string BuildReadQuery()
        {
            string query = "GET\nSELECT Item.itemID, Product.productName, Warehouse.city, Warehouse.warehouseID FROM Item " +
                            "LEFT JOIN Product ON Item.productID = Product.productID " +
                            "LEFT JOIN WarehouseItem ON Item.itemID = WarehouseItem.itemID " +
                            "LEFT JOIN Warehouse ON WarehouseItem.warehouseID = Warehouse.warehouseID;";

            // Use IModel properties to build SQL query string
            // Need a join to get the item ID (Item), productName (Product), warehouseCity (Warehouse & WarehouseItem),
            // warehouseID (WarehouseItem) for all unsold items
            

            return query;
        }
    }
}
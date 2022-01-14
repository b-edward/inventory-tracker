using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Models
{
    public class Inventory : IInventory, IModel
    {
        private int itemID;
        private string productName;
        private string warehouseCity;
        private int warehouseID;

        public int ID { get { return itemID; } set { itemID = value; } }
        public int ItemID { get { return itemID; } set { itemID = value; } }
        public string ProductName { get { return productName; } set { productName = value; } }
        public string WarehouseCity  { get { return warehouseCity; } set { warehouseCity = value; } }
        public int WarehouseID { get { return warehouseID; } set { warehouseID = value; } }
    }
}
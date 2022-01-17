using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Inventory : IInventory, IModel
    {
        private string itemID;
        private string productName;
        private string warehouseCity;
        private string warehouseID;

        public string ID
        { get { return itemID; } set { itemID = value; } }
        public string ItemID
        { get { return itemID; } set { itemID = value; } }
        public string ProductName
        { get { return productName; } set { productName = value; } }
        public string WarehouseCity
        { get { return warehouseCity; } set { warehouseCity = value; } }
        public string WarehouseID
        { get { return warehouseID; } set { warehouseID = value; } }
    }
}
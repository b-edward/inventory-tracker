using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class WarehouseItem : IWarehouseItem, IModel
    {
        private string itemID;
        private string warehouseID;

        public string ID
        { get { return itemID; } set { itemID = value; } }
        public string ItemID
        { get { return itemID; } set { itemID = value; } }
        public string WarehouseItemID
        { get { return warehouseID; } set { warehouseID = value; } }
    }
}
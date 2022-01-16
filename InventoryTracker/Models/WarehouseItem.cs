using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class WarehouseItem : IWarehouseItem, IModel
    {
        private int itemID;
        private int warehouseID;

        public int ID
        { get { return itemID; } set { itemID = value; } }
        public int ItemID
        { get { return itemID; } set { itemID = value; } }
        public int WarehouseItemID
        { get { return warehouseID; } set { warehouseID = value; } }
    }
}
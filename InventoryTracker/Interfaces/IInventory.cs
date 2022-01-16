namespace InventoryTracker.Interfaces
{
    // This interface will implement the standard inventory process, allowing extension for
    // different types of inventory in future (e.g. Company inventory, location inventory)
    public interface IInventory
    {
        int ItemID { get; set; }
        string ProductName { get; set; }
        string WarehouseCity { get; set; }
        int WarehouseID { get; set; }
    }
}
namespace InventoryTracker.Interfaces
{
    public interface IItem
    {
        string ItemID { get; set; }
        string ProductID { get; set; }
        bool IsAssigned { get; set; }
        bool IsSold { get; set; }
    }
}
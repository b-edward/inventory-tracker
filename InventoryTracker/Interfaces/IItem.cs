namespace InventoryTracker.Interfaces
{
    public interface IItem
    {
        int ItemID { get; set; }
        string ProductID { get; set; }
        bool IsAssigned { get; set; }
        bool IsSold { get; set; }
    }
}
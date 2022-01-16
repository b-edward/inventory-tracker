namespace InventoryTracker.Interfaces
{
    public interface IItem
    {
        string ItemID { get; set; }
        string ProductID { get; set; }
        int IsAssigned { get; set; }
        int IsSold { get; set; }
    }
}
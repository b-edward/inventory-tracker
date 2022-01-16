namespace InventoryTracker.Interfaces
{
    // This interface will implement a generic product, allowing extension for different
    // types of products in future (e.g. furniture, vehicles, clothes, etc)
    public interface IProduct
    {
        string ProductID { get; set; }
        string ProductName { get; set; }
        bool IsActive { get; set; }
    }
}
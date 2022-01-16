using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Product : IProduct, IModel
    {
        private string productID;
        private string productName;
        private bool isActive;

        public string ProductID
        { get { return productID; } set { productID = value; } }
        public string ProductName
        { get { return productName; } set { productName = value; } }
        public bool IsActive
        { get { return isActive; } set { isActive = value; } }
        public int ID
        { get; set; }
    }
}
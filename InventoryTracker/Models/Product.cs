using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Product : IProduct, IModel
    {
        private int productID;
        private string productName;
        private bool isActive;

        public int ID
        { get { return productID; } set { productID = value; } }
        public int ProductID
        { get { return productID; } set { productID = value; } }
        public string ProductName
        { get { return productName; } set { productName = value; } }
        public bool IsActive
        { get { return isActive; } set { isActive = value; } }
    }
}
using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Item : IItem, IModel
    {
        private string itemID;
        private string productID;
        private int isAssigned;
        private int isSold;

        public string ItemID
        { get { return itemID; } set { itemID = value; } }
        public string ProductID
        { get { return productID; } set { productID = value; } }
        public int IsAssigned
        { get { return isAssigned; } set { isAssigned = value; } }
        public int IsSold
        { get { return isSold; } set { isSold = value; } }

        // ID property should not be used, implemented only for IModel usage
        public int ID { get; set; }
    }
}
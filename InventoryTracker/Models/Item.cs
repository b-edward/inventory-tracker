using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Models
{
    public class Item : IItem, IModel
    {
        private int itemID;
        private string productID;
        private bool isActive;
        
        public int ItemID { get { return itemID; } set { itemID = value; } }
        public string ProductID { get { return productID; } set { productID = value; } }
        public bool IsActive { get { return isActive; } set { isActive = value; } }

        // ID property should not be used, implemented only for IModel usage
        public int ID { get { return itemID; } set { itemID = itemID; } }
    }
}
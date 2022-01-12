using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    public class ProductController : IProduct
    {
        private string productID;
        private string productName;
        private bool isActive;

        public string ProductID { get { return productID; } set { productID = value; } }
        public string ProductName { get { return productName; } set { productName = value; } }
        public bool IsActive { get { return isActive; } set { isActive = value; } }
    }
}
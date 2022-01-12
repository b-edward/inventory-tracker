using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Product : IProduct
    {
        private string productID;
        private string productName;
        private bool isActive;

        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
    }
}
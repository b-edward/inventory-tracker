using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    public class InventoryController : IInventory
    {
        // Method to get the total inventory of all products
        public int GetTotal()
        {
            return 0;
        }

        // Method to get the inventory for a single product
        public int GetTotal(string productID)
        {
            return 0;
        }
    }
}
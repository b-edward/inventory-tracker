using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Interfaces
{
    // This interface will implement the standard inventory process, allowing extension for
    // different types of inventory in future (e.g. Company inventory, location inventory)
    public interface IInventory
    {
        int GetTotal();                     // Method to get the total inventory of all products
        int GetTotal(string productID);     // Method to get the inventory for a single product
    }
}

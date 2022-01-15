using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Interfaces
{
    public interface IWarehouseItem
    {
        int ItemID { get; set; }
        int WarehouseItemID { get; set; }
    }
}

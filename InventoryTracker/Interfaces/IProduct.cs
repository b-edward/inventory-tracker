﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker
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
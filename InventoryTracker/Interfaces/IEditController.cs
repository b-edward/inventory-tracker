﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Interfaces
{
    public interface IEditController
    {
        string ExecuteCUD(object table, string command, string tableName);
    }
}

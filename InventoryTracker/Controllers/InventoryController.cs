﻿using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    public class InventoryController : ITableRead, IController
    {
        private IModel itemTable;
        private IModel productTable;
        private IModel warehouseTable;
        private IModel warehouseItemTable;

        public InventoryController(string tableToRead)
        {
            // Instantiate models
            itemTable = new Item();
            productTable = new Product();
            warehouseTable = new Warehouse();
            warehouseItemTable = new WarehouseItem();
        }

        // Method to get the total inventory of all active && unsold items
        public string BuildReadQuery()
        {
            string query = "";

            // Use IModel properties to build SQL query string
            // Need a join to get the item ID (Item), productName (Product), warehouseCity (Warehouse & WarehouseItem),
            // warehouseID (WarehouseItem) for all unsold items

            return query;
        }
    }
}
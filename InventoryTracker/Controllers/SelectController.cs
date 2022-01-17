using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    public static class SelectController
    {
        public static object GetController(string tableName)
        {
            Object controller;

            // Switch to select the controller
            switch (tableName.ToUpper())
            {
                case "INVENTORY":
                    controller = new InventoryController();
                    break;
                case "ITEM":
                    controller = new ItemController();
                    break;
                case "PRODUCT":
                    controller = new ProductController();
                    break;
                case "WAREHOUSE":
                    controller = new WarehouseController();
                    break;
                case "WAREHOUSEITEM":
                    controller = new WarehouseItemController();
                    break;
                default:
                    controller = null;
                    break;
            }
            return controller;
        }
    }
}
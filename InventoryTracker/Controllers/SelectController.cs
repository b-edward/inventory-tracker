/*
 * FILE             : SelectController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 13
 * DESCRIPTION      : This file contains the SelectController class. It will take a table name and
 *                    return the corresponding controller.
 */

using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    public static class SelectController
    {
        /*
        *	NAME	:	GetController
        *	PURPOSE	:	This method will select and instantiate a controller based on the argument
        *	INPUTS	:	string tableName - the name of the database table 
        *	RETURNS	:	Object controller - an instance of the selected conroller
        */
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
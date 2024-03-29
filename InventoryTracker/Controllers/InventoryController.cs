﻿/*
 * FILE             : InventoryController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 13
 * DESCRIPTION      : This file contains the InventoryController class, which implements the IInventoryController interface.
 *                    It will provide a SQL query for accessing the inventory data.
 */

using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class InventoryController : ITableRead
    {
        /*
        *	NAME	:	BuildReadQuery
        *	PURPOSE	:	This method will provide a SQL query to get the total inventory of unsold items
        *	INPUTS	:	string query - the SQL query to be sent
        *	RETURNS	:	string response - server status message for user feedback
        */

        public string BuildReadQuery()
        {
            string query = "GET\nSELECT Item.itemID, Product.productName, Warehouse.city, Warehouse.warehouseID FROM Item " +
                            "LEFT JOIN Product ON Item.productID = Product.productID " +
                            "LEFT JOIN WarehouseItem ON Item.itemID = WarehouseItem.itemID " +
                            "LEFT JOIN Warehouse ON WarehouseItem.warehouseID = Warehouse.warehouseID " +
                            "WHERE Item.isSold=0;";
            return query;
        }
    }
}
/*
 * FILE             : Inventory.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the Inventory class, which models a database inventory report. This class
 *                    implements the IInventory and IModel interfaces.
 */

using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Inventory : IInventory, IModel
    {
        // Data members
        private string itemID;
        private string productName;
        private string warehouseCity;
        private string warehouseID;

        // Properties
        public string ID
        { get { return itemID; } set { itemID = value; } }

        public string ItemID
        { get { return itemID; } set { itemID = value; } }

        public string ProductName
        { get { return productName; } set { productName = value; } }

        public string WarehouseCity
        { get { return warehouseCity; } set { warehouseCity = value; } }

        public string WarehouseID
        { get { return warehouseID; } set { warehouseID = value; } }
    }
}
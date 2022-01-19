/*
 * FILE             : WarehouseItem.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the WarehouseItem class, which models a database WarehouseItem record. This class
 *                    implements the IWarehouseItem and IModel interfaces.
 */

using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class WarehouseItem : IWarehouseItem, IModel
    {
        // Data members
        private string itemID;
        private string warehouseID;

        // Properties
        public string ID
        { get { return itemID; } set { itemID = value; } }

        public string ItemID
        { get { return itemID; } set { itemID = value; } }

        public string WarehouseItemID
        { get { return warehouseID; } set { warehouseID = value; } }
    }
}
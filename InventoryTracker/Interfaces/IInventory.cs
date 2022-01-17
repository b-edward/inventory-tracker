/*
 * FILE             : IInventory.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IInventory interface, which provides an abstraction layer for
 *                    implementing the Inventory class. This interface will implement the standard inventory template, 
 *                    allowing easy extension for different types of inventory in future 
 *                    (e.g. Company inventory, location inventory).
 */

namespace InventoryTracker.Interfaces
{
    // 
    public interface IInventory
    {
        string ItemID { get; set; }
        string ProductName { get; set; }
        string WarehouseCity { get; set; }
        string WarehouseID { get; set; }
    }
}
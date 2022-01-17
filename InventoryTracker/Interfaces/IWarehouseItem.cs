/*
 * FILE             : IWarehouseItem.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IWarehouseItem interface, which provides an abstraction layer for
 *                    implementing the WarehouseItem class. It models a database warehouseItem record.
 */

namespace InventoryTracker.Interfaces
{
    public interface IWarehouseItem
    {
        string ItemID { get; set; }
        string WarehouseItemID { get; set; }
    }
}
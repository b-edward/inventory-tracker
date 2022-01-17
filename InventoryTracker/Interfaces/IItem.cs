/*
 * FILE             : IItem.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IItem interface, which provides an abstraction layer for
 *                    implementing the Item class. It models a database item record.
 */

namespace InventoryTracker.Interfaces
{
    public interface IItem
    {
        string ItemID { get; set; }
        string ProductID { get; set; }
        int IsAssigned { get; set; }
        int IsSold { get; set; }
    }
}
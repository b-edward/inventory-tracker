/*
 * FILE             : ITableCUD.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the ITableCUD interface, which provides an abstraction layer for
 *                    implementing controller classes. Its purpose is to provide flexibility to take advantage
 *                    of polymorphism among model controller classes that need Create, Update, or Delete functionality.
 */

namespace InventoryTracker.Interfaces
{
    public interface ITableCUD
    {
        string BuildCUDQuery(object table, string command);
    }
}
/*
 * FILE             : ITableRead.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the ITableRead interface, which provides an abstraction layer for
 *                    implementing controller classes. Its purpose is to provide flexibility to take advantage
 *                    of polymorphism among model controller classes that need Read functionality.
 */

namespace InventoryTracker.Interfaces
{
    public interface ITableRead
    {
        string BuildReadQuery();
    }
}
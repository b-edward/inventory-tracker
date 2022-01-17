/*
 * FILE             : IReadController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IReadController interface, which provides an abstraction layer for
 *                    implementing the ReadController class.
 */

using System.Data;

namespace InventoryTracker.Interfaces
{
    public interface IReadController
    {
        DataTable GetTable(string tableName);
        string GetNewItemID();
    }
}
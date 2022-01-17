/*
 * FILE             : IEditController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IEditController interface, which provides an abstraction layer for
 *                    implementing the EditController class.
 */

namespace InventoryTracker.Interfaces
{
    public interface IEditController
    {
        string ExecuteCUD(object table, string command, string tableName);
    }
}
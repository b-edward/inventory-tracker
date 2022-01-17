/*
 * FILE             : IModel.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IModel interface, which provides an abstraction layer for
 *                    implementing model classes. Its purpose is to provide flexibility to take advantage
 *                    of polymorphism among the data models.
 */

namespace InventoryTracker.Interfaces
{
    public interface IModel
    {
        string ID { get; set; }
    }
}
/*
 * FILE             : IProduct.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IProduct interface, which provides an abstraction layer for
 *                    implementing the Product class. This interface will implement a generic product, allowing extension for 
 *                    different types of products in future (e.g. furniture, vehicles, clothes, etc)
 */

namespace InventoryTracker.Interfaces
{
    public interface IProduct
    {
        string ProductID { get; set; }
        string ProductName { get; set; }
        int IsActive { get; set; }
    }
}
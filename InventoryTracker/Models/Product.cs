/*
 * FILE             : Product.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the Product class, which models a database Product record. This class
 *                    implements the IProduct and IModel interfaces.
 */

using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Product : IProduct, IModel
    {
        // Data members
        private string productID;
        private string productName;
        private int isActive;

        // Properties
        public string ProductID
        { get { return productID; } set { productID = value; } }

        public string ProductName
        { get { return productName; } set { productName = value; } }

        public int IsActive
        { get { return isActive; } set { isActive = value; } }

        public string ID
        { get; set; }
    }
}
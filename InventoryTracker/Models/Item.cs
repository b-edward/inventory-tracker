/*
 * FILE             : Item.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the Item class, which models a database item record. This class
 *                    implements the IItem and IModel interfaces.
 */

using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Item : IItem, IModel
    {
        // Data members
        private string itemID;
        private string productID;
        private int isAssigned;
        private int isSold;

        // Properties
        public string ItemID
        { get { return itemID; } set { itemID = value; } }

        public string ProductID
        { get { return productID; } set { productID = value; } }

        public int IsAssigned
        { get { return isAssigned; } set { isAssigned = value; } }

        public int IsSold
        { get { return isSold; } set { isSold = value; } }

        // ID property should not be used, implemented only for IModel usage
        public string ID { get; set; }
    }
}
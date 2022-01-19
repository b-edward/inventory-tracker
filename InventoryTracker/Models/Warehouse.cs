/*
 * FILE             : Warehouse.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the Warehouse class, which models a database Warehouse record. This class
 *                    implements the IWarehouse and IModel interfaces.
 */

using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Warehouse : ILocation, IModel
    {
        // Data members
        private string warehouseID;
        private string streetAndNo;
        private string city;
        private string provinceOrState;
        private string country;
        private string postalCode;
        private int isActive;

        // Properties
        public string WarehouseID
        { get { return ID; } set { ID = value; } }

        public string StreetAndNo
        { get { return streetAndNo; } set { streetAndNo = value; } }

        public string City
        { get { return city; } set { city = value; } }

        public string ProvinceOrState
        { get { return provinceOrState; } set { provinceOrState = value; } }

        public string Country
        { get { return country; } set { country = value; } }

        public string PostalCode
        { get { return postalCode; } set { postalCode = value; } }

        public int IsActive
        { get { return isActive; } set { isActive = value; } }

        public string ID
        { get { return warehouseID; } set { warehouseID = value; } }
    }
}
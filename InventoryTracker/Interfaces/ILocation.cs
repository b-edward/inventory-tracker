/*
 * FILE             : ILocation.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the ILocation interface, which provides an abstraction layer for
 *                    implementing the location subclasses, such as warehouses class. This interface implements a
 *                    generic location, allowing easy extension of location types in future (e.g. Warehouse, Store).
 */

namespace InventoryTracker.Interfaces
{
    public interface ILocation
    {
        string ID { get; set; }
        string StreetAndNo { get; set; }
        string City { get; set; }
        string ProvinceOrState { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        int IsActive { get; set; }
    }
}
using InventoryTracker.Interfaces;

namespace InventoryTracker.Models
{
    public class Warehouse : ILocation, IModel
    {
        private string warehouseID;
        private string streetAndNo;
        private string city;
        private string provinceOrState;
        private string country;
        private string postalCode;
        private bool isActive;

        public string WarehouseID
        { get { return warehouseID; } set { warehouseID = value; } }
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
        public bool IsActive
        { get { return isActive; } set { isActive = value; } }
        public int ID
        { get; set; }
    }
}
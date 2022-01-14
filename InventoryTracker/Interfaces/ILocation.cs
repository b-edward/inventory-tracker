using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Interfaces
{
    // This interface implements a generic location, allowing extension of location
    // types in future (e.g. Warehouse, Store)
    public interface ILocation
    {
        int ID { get; set; }
        string StreetAndNo { get; set; }
        string City { get; set; }
        string ProvinceOrState { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        bool IsActive { get; set; }
    }
}

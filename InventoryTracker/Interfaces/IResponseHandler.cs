using System.Data;

namespace InventoryTracker.Interfaces
{
    public interface IResponseHandler
    {
        DataTable GetDataTable(string response);
    }
}
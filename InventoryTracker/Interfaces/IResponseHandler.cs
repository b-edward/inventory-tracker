using System.Data;

namespace InventoryTracker.Interfaces
{
    public interface IResponseHandler
    {
        DataTable GetDataTable(string tableName, string response);
        string ParseResponse(string queryResponse);
    }
}
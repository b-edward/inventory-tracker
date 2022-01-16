using InventoryTracker.Interfaces;
using System.Data;

namespace InventoryTracker.DataServerAccess
{
    public class ResponseHandler : IResponseHandler
    {
        public ResponseHandler()
        {
        }

        // Use the converter to parse the response and fill the data table
        public DataTable GetDataTable(string tableName, string response)
        {
            DataTable dataTable = ConvertDataToTable.GetDataTable(tableName, response);
            return dataTable;
        }
    }
}
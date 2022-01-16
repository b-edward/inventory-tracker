using InventoryTracker.DataServerAccess;
using InventoryTracker.Interfaces;
using System.Data;

namespace InventoryTracker.Controllers
{
    public class ReadController : IReadController
    {
        private IRequestHandler requestHandler;
        private IResponseHandler responseHandler;
        private ITableRead tableRead;
        public DataTable dataTable;

        public ReadController()
        {
            requestHandler = new RequestHandler();
            responseHandler = new ResponseHandler();
        }

        public DataTable GetInventory()
        {
            // Instantiate an inventory controller
            tableRead = new InventoryController();
            // Get the inventory query string
            string query = tableRead.BuildReadQuery();
            // Send the request and get server response
            string response = requestHandler.SendRequest(query);

            // If query was successful then convert it
            if (response.Contains("200"))
            {
                // Split the status code from the response
                string[] getResponse = response.Split('\n');
                // Convert the response to a datatable
                dataTable = responseHandler.GetDataTable(getResponse[1]);
            }

            return dataTable;
        }

        public DataTable GetTable(string tableName)
        {
            DataTable dataTable = new DataTable();

            return dataTable;
        }
    }
}
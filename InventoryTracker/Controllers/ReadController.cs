using InventoryTracker.DataServerAccess;
using InventoryTracker.Interfaces;
using System;
using System.Data;

namespace InventoryTracker.Controllers
{
    public class ReadController : IReadController
    {
        private IRequestHandler requestHandler;
        private IResponseHandler responseHandler;
        private ITableRead tableRead;

        public ReadController()
        {
            requestHandler = new RequestHandler();
            responseHandler = new ResponseHandler();
        }

        public DataTable GetTable(string tableName)
        {
            DataTable dataTable = null;
            tableRead = null;

            // Return immediately if invalid argument
            if (tableName == null || tableName.Length < 1)
            {
                return dataTable;
            }

            // Instantiate controller based on tableName
            tableRead = (ITableRead)SelectController.GetController(tableName);
            if(tableRead != null)
            {
                // Get the inventory query string and send it
                string query = tableRead.BuildReadQuery();
                string response = SendQuery(query);

                // If query was successful then convert it
                if (response.Contains("200"))
                {
                    dataTable = ConvertTable(tableName, response);
                }
                else
                {
                    Console.WriteLine($"[ERROR] - {response}");
                    dataTable = null;
                }
            }
            
            return dataTable;
        }

        private string SendQuery(string query)
        {
            // Send the request and get server response
            string response = requestHandler.SendRequest(query);
            return response;
        }

        private DataTable ConvertTable(string tableName, string data)
        {
            // Split the status code from the response
            string[] getResponse = data.Split('\n');
            // Convert the response to a datatable
            DataTable dataTable = responseHandler.GetDataTable(tableName, getResponse[1]);
            return dataTable;
        }
    }
}
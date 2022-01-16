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


        // Method to parse response and return server message
        public string ParseResponse(string queryResponse)
        {
            string response = "";
            string[] serverResponse = ParseData(queryResponse);
            if(serverResponse[0].Contains("200"))
            {
                response = "Request executed successfully.";
            }
            else
            {
                response = serverResponse[1];
            }
            return response;
        }

        private string[] ParseData(string queryResponse)
        {
            string[] response = queryResponse.Split('\n');
            return response;
        }
    }
}
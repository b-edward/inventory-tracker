using InventoryTracker.DataServerAccess;
using InventoryTracker.Interfaces;

namespace InventoryTracker.Controllers
{
    public class EditController : IEditController
    {
        private IRequestHandler requestHandler;
        private IResponseHandler responseHandler;
        private ITableCUD tableEditor;

        public EditController()
        {
            requestHandler = new RequestHandler();
            responseHandler = new ResponseHandler();
        }

        public string ExecuteCUD(object table, string command, string tableName)
        {
            string response = "";
            tableEditor = null;

            // Return immediately if invalid arguments
            if (table == null || command == null || command.Length < 1 || tableName == null || tableName.Length < 1)
            {
                response = "Invalid arguments. Please try again.";
                return response;
            }

            // Instantiate controller based on tableName
            tableEditor = (ITableCUD)SelectController.GetController(tableName);
            if (tableEditor != null)
            {
                // Get the command query string and send it
                string query = tableEditor.BuildCUDQuery(table, command);
                string queryResponse = SendQuery(query);

                // Parse the response using ResponseHandler
                response = responseHandler.ParseResponse(queryResponse);
            }
            // Return server response
            return response;
        }


        private string SendQuery(string query)
        {
            // Send the request and get server response
            string response = requestHandler.SendRequest(query);
            return response;
        }
    }
}
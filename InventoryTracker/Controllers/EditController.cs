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
            string response = "200";


            return response;
        }
    }
}
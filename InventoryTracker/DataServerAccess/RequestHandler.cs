using InventoryTracker.Interfaces;

namespace InventoryTracker.DataServerAccess
{
    public class RequestHandler : IRequestHandler
    {
        private IServerHandler serverHandler;           // An interface for data access

        public RequestHandler()
        {
            serverHandler = new ServerHandler();
        }

        // Send the request to the data server
        public string SendRequest(string request)
        {
            string serverResponse = serverHandler.SendToServer(request);

            return serverResponse;
        }
    }
}
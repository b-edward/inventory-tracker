using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InventoryTracker.DataServerAccess
{
    public class RequestHandler : IRequestHandler
    {
        IServerHandler serverHandler;           // An interface for data access

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
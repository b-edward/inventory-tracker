using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.DataServerAccess
{
    public class RequestHandler : IRequestHandler
    {
        IDataHandler dataHandler;       // An interface for data access

        public RequestHandler()
        {
            dataHandler = new ServerHandler();
        }

        // Send the request to the data server
        public string SendRequest(string request)
        {
            string requestString = "";

            return requestString;
        }
    }
}
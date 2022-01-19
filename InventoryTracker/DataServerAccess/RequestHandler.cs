/*
 * FILE             : RequestHandler.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 13
 * DESCRIPTION      : This file contains the RequestHandler class, which will implements the IRequestHandler interface.
 *                    It will send the request to the DataServer.
 */

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

        /*
        *	NAME	:	ConvertToInventoryTable
        *	PURPOSE	:	This method will take the inventory data and put it in a DataTable
        *	            string request - the request string using DataServer protocol
        *	RETURNS	:	string serverResponse - the server's response, status code and read data
        */

        public string SendRequest(string request)
        {
            string serverResponse = serverHandler.SendToServer(request);
            return serverResponse;
        }
    }
}
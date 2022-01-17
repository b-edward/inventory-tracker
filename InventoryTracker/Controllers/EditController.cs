/*
 * FILE             : EditController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 12
 * DESCRIPTION      : This file contains the EditController class, which implements the IEditController interface. It will
 *                    handle create, update, and delete requests and facilitate communication from UI to DatabaseServer.
 */

using InventoryTracker.DataServerAccess;
using InventoryTracker.Interfaces;

namespace InventoryTracker.Controllers
{
    public class EditController : IEditController
    {
        // Interfaces for abstraction
        private IRequestHandler requestHandler;
        private IResponseHandler responseHandler;
        private ITableCUD tableEditor;

        /*
        *	NAME	:	EditController -- Constructor
        *	PURPOSE	:	This constructor will override the default constructor and initialize data members.
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
        public EditController()
        {
            requestHandler = new RequestHandler();
            responseHandler = new ResponseHandler();
        }


        /*
        *	NAME	:	ExecuteCUD
        *	PURPOSE	:	This method will execute create, update, and delete requests.
        *	INPUTS	:	object table - the user input data to be sent
        *	            string command -  the create, update, or delete command
        *	            string tableName - the name of the table to be edited
        *	RETURNS	:	string response - server status message for user feedback
        */
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

                // If WarehouseItem edited, queryResponse code 200, customize queryResponse message
                if(tableName.ToUpper() == "ITEM" || tableName.ToUpper() == "WAREHOUSEITEM")
                {
                    if(queryResponse.Contains("200"))
                    {
                        response = queryResponse;
                    }
                }
                else
                {
                    // Parse the response using ResponseHandler
                    response = responseHandler.ParseResponse(queryResponse);
                }
            }
            // Return server response
            return response;
        }


        /*
        *	NAME	:	SendQuery
        *	PURPOSE	:	This method will send the query to the server.
        *	INPUTS	:	string query - the SQL query to be sent
        *	RETURNS	:	string response - server status message for user feedback
        */
        private string SendQuery(string query)
        {
            // Send the request and get server response
            string response = requestHandler.SendRequest(query);
            return response;
        }

    }
}
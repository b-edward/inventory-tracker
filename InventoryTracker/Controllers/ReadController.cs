/*
 * FILE             : ReadController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 12
 * DESCRIPTION      : This file contains the ReadController class, which implements the IReadController interface. It will
 *                    handle read requests and facilitate communication from UI to DatabaseServer.
 */

using InventoryTracker.DataServerAccess;
using InventoryTracker.Interfaces;
using System;
using System.Data;

namespace InventoryTracker.Controllers
{
    public class ReadController : IReadController
    {
        // Interfaces for abstraction
        private IRequestHandler requestHandler;
        private IResponseHandler responseHandler;
        private ITableRead tableRead;

        /*
        *	NAME	:	ReadController -- Constructor
        *	PURPOSE	:	This constructor will override the default constructor and initialize data members.
        *	INPUTS	:	None
        *	RETURNS	:	None
        */

        public ReadController()
        {
            requestHandler = new RequestHandler();
            responseHandler = new ResponseHandler();
        }

        /*
        *	NAME	:	GetTable
        *	PURPOSE	:	This method will get a datatable with the records from the selected table
        *	INPUTS	:	string tableName - the name of the database table
        *	RETURNS	:	DataTable dataTable - the return data formatted as DataTable
        */

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
            if (tableRead != null)
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

        /*
        *	NAME	:	ConvertTable
        *	PURPOSE	:	This method will send the query to the server.
        *	INPUTS	:	string tableName - the name of the database table
        *	            string data - the returned data in ascii string format
        *	RETURNS	:	DataTable dataTable - the return data formatted as DataTable
        */

        private DataTable ConvertTable(string tableName, string data)
        {
            // Split the status code from the response
            string[] getResponse = data.Split('\n');
            // Convert the response to a datatable
            DataTable dataTable = responseHandler.GetDataTable(tableName, getResponse[1]);
            return dataTable;
        }

        /*
        *	NAME	:	GetNewItemID
        *	PURPOSE	:	This method will get the newest itemID added to the Item table.
        *	INPUTS	:	None
        *	RETURNS	:	string newItemID - the returned itemID
        */

        public string GetNewItemID()
        {
            // Instantiate controller
            ItemController itemController = new ItemController();

            // Get the query string and send it
            string query = itemController.BuildReadNewestQuery();
            string response = SendQuery(query);

            // If query was successful then convert it
            string newItemID = "";
            if (response.Contains("200"))
            {
                newItemID = responseHandler.ParseItemID(response);
            }
            return newItemID;
        }
    }
}
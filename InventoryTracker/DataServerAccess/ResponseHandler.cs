/*
 * FILE             : ResponseHandler.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 13
 * DESCRIPTION      : This file contains the ResponseHandler class, which will implements the IResponseHandler interface.
 *                    It will parse the return strings from the DataServer.
 */

using InventoryTracker.Interfaces;
using System.Data;

namespace InventoryTracker.DataServerAccess
{
    public class ResponseHandler : IResponseHandler
    {
        /*
        *	NAME	:	WarehouseItemController -- Constructor
        *	PURPOSE	:	Default constructor.
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
        public ResponseHandler()
        {
        }

        /*
        *	NAME	:	GetDataTable
        *	PURPOSE	:	This method will take the response data and return it in DataTable format
        *	INPUTS	:   string tableName - the name of the table to be edited
        *	        	string response - server status message for user feedback
        *	RETURNS	:	DataTable dataTable - the return data formatted as DataTable
        */
        public DataTable GetDataTable(string tableName, string response)
        {
            DataTable dataTable = ConvertDataToTable.GetDataTable(tableName, response);
            return dataTable;
        }


        /*
        *	NAME	:	ParseResponse
        *	PURPOSE	:	This method will parse the response string, remove status code and return server message
        *	INPUTS	:	string queryResponse - server's response to the query
        *	RETURNS	:	string response - the response message
        */
        public string ParseResponse(string queryResponse)
        {
            string response = "";
            // Send string for parsing
            string[] serverResponse = ParseData(queryResponse);
            // Remove 200 status code
            if(serverResponse[0].Contains("200"))
            {
                response = "Request executed successfully.";
            }
            else
            {
                // Keep the server's message
                response = serverResponse[1];
            }
            return response;
        }

        /*
        *	NAME	:	ParseItemID
        *	PURPOSE	:	This method will parse the response item record string to get the itemID
        *	INPUTS	:	string itemResponse - server's response to the query
        *	RETURNS	:	string itemID - the returned itemID
        */
        public string ParseItemID(string itemResponse)
        {
            string[] item = ParseData(itemResponse);
            string[] itemFields = item[1].Split(',');
            string itemID = itemFields[0];
            return itemID;
        }

        /*
        *	NAME	:	ParseData
        *	PURPOSE	:	This method will parse the status code from the server message
        *	INPUTS	:	string queryResponse - server's response to the query
        *	RETURNS	:	string[] response - an array containing the status code and message
        */
        private string[] ParseData(string queryResponse)
        {
            string[] response = queryResponse.Split('\n');
            return response;
        }


    }
}
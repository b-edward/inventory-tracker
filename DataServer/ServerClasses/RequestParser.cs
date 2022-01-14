/*
 * FILE             : RequestParser.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains the RequestParser class, which will parse client requests,
 *                    to determine which CRUD method to call.
 */

using DataServer.Interfaces;

namespace DataServer.ServerClasses
{
    public class RequestParser : IRequestParser
    {
        private ResponseHandler responseHandler;

        /*
        *	NAME	:	RequestParser -- Constructor
        *	PURPOSE	:	This method will override the default constructor and set data member values.
        *	INPUTS	:	None
        *	RETURNS	:	None
        */

        public RequestParser()
        {
            responseHandler = new ResponseHandler();
        }

        /*
        *	NAME	:	ParseReceived
        *	PURPOSE	:	This method will take the received string, check what action needs to be taken,
        *	            and call method to handle it.
        *	INPUTS	:	string received - the string from the client
        *	RETURNS	:	string  response - the returned response from the method that is called
        */

        public string ParseReceived(string received)
        {
            string response = "";
            string command = "";
            string query = "";

            // Parse the string to get the request command
            string[] receivedFields = received.Split('\n');

            try
            {
                command = receivedFields[0];         // Zeroth index is the command
                query = receivedFields[1];           // First index is the query
            }
            catch
            {
                // Set bad request return code
                response = "400\n";
                return response;
            }

            // Remove \r if present
            if (command.Contains("\r"))
            {
                int lastIndex = command.Length - 1;
                command = command.Substring(0, lastIndex);
            }

            // Call the method to handle the command
            switch (command.ToUpper())
            {
                case "PUT":
                    response = responseHandler.create(query);
                    break;

                case "GET":
                    response = responseHandler.read(query);
                    break;

                case "POST":
                    response = responseHandler.update(query);
                    break;

                case "DELETE":
                    response = responseHandler.delete(query);
                    break;

                default:
                    // Set Method Not Allowed return code
                    response = "405\n";
                    break;
            }
            return response;
        }
    }
}
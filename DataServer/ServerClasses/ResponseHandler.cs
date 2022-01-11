/*
 * FILE             : ResponseHandler.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains the ResponseHandler class, which will take action based upon the 
 *                    request, and send the response to the client.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServer.Log;
using DataServer.Interfaces;
using System.Configuration;
using System.Net.Sockets;

// A delegate for handling CRUD commands
public delegate string CrudHandler(string s);

namespace DataServer.ServerClasses
{
    public class ResponseHandler 
    {
        private static ILogger serverLog;           // The logger
        private static IDataHandler dataHandler;    // Access to the database

        // Delegate instances for handling each CRUD command
        public CrudHandler create = new CrudHandler(ReceivedCreate);
        public CrudHandler read = new CrudHandler(ReceivedRead);
        public CrudHandler update = new CrudHandler(ReceivedUpdate);
        public CrudHandler delete = new CrudHandler(ReceivedDelete);

        /*
        *	NAME	:	ResponseHandler -- Constructor
        *	PURPOSE	:	This method will override the default constructor and set data member values.
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
        public ResponseHandler()
        {
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
            dataHandler = new DataHandler();
        }


        /*
        *	NAME	:	ReceivedCreate
        *	PURPOSE	:	This method will take the received string, and use a data handler to execute the
        *	            create request.
        *	INPUTS	:	string received - the string from the client
        *	RETURNS	:	string  response - the response to the client
        */
        public static string ReceivedCreate(string query)
        {
            string response = "";
            bool status = dataHandler.Create(query);        // Call method to execute create query
            response = AddStatusCode(status, response);     // Call method to add return code
            return response;
        }


        /*
        *	NAME	:	ReceivedDelete
        *	PURPOSE	:	This method will take the received string, and use a data handler to execute the
        *	            delete request.
        *	INPUTS	:	string received - the string from the client
        *	RETURNS	:	string response - the response to the client
        */
        public static string ReceivedRead(string query)
        {
            string response = "";
            
            // Call method to execute read query
            response = dataHandler.Read(query);        
            bool readResult = false;

            // Set the bool true if read was okay
            if (response != null)
            {
                // Check if the select command read anything
                if(response == "")
                {
                    // If blank, set Not Found return code
                    response = "404\n";
                }
                else
                {
                    readResult = true;
                    // Call method to add return code
                    response = AddStatusCode(readResult, response);     
                }
            }
            return response;
        }


        /*
        *	NAME	:	ReceivedUpdate
        *	PURPOSE	:	This method will take the received string, and use a data handler to execute the
        *	            update request.
        *	INPUTS	:	string received - the string from the client
        *	RETURNS	:	string response - the response to the client
        */
        public static string ReceivedUpdate(string query)
        {
            string response = "";
            bool status = dataHandler.Update(query);        // Call method to execute update query
            response = AddStatusCode(status, response);     // Call method to add return code
            return response;
        }


        /*
        *	NAME	:	ReceivedDelete
        *	PURPOSE	:	This method will take the received string, and use a data handler to execute the
        *	            delete request.
        *	INPUTS	:	string received - the string from the client
        *	RETURNS	:	string response - the response to the client
        */
        public static string ReceivedDelete(string query)
        {
            string response = "";
            bool status = dataHandler.Delete(query);        // Call method to execute delete query
            response = AddStatusCode(status, response);     // Call method to add return code
            return response;
        }


        /*
        *	NAME	:	AddStatusCode
        *	PURPOSE	:	This method will add an appropriate status code to the response string
        *	INPUTS	:	string received - the string from the client
        *	RETURNS	:	string response - the response to the client
        */
        private static string AddStatusCode(bool status, string response)
        {
            // Check if status was true
            if(status)
            {
                // Set OK return code
                response = response.Insert(0, "200\n");
            }
            else
            {
                // Otherwise set Internal Server Error return code
                response = response.Insert(0, "500\n");
            }
            return response;
        }


        /*
        *	NAME	:	SendResponse
        *	PURPOSE	:	This method will send the response to the client.
        *	INPUTS	:	Object clientObject - holds the TCPClient object that was connected to the client
        *	RETURNS	:	bool status - true if successful 
        */
        public bool SendResponse(Object networkObject, string response)
        {
            NetworkStream stream = (NetworkStream)networkObject;
            bool status = true;
            try
            {
                // Convert string response to bytes and send to client
                byte[] responseBytes = System.Text.Encoding.ASCII.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);
                Console.WriteLine("[SENT] - Response sent to client");
                serverLog.Log("[SENT] - Response sent to client: " + response);
            }
            catch
            {
                serverLog.Log("[ERROR] Could not write response to client");
                Console.WriteLine("[ERROR] Could not write response to client");
                status = false;
            }
            return status;
        }
    }
}

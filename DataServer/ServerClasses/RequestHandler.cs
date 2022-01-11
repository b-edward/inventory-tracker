/*
 * FILE             : RequestHandler.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains the RequestHandler class, which will process client requests,
 *                    then use the other handlers to create and send a response.
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataServer.Log;
using DataServer.Interfaces;

namespace DataServer.ServerClasses
{
    public class RequestHandler : IRequestHandler
    {
        private static ILogger serverLog;               // The logger
        public static IRequestParser requestParser;     // Interface to parse the request
        public static ResponseHandler responseHandler;  // Class to send the response

        /*
        *	NAME	:	RequestHandler -- Constructor
        *	PURPOSE	:	This method will override the default constructor and set data member values.
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
        public RequestHandler()
        {
            // Instantiate interfaces
            requestParser = new RequestParser();
            responseHandler = new ResponseHandler();

            // Instantiate log file
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
        }


        /*
        *	NAME	:	HandleRequest
        *	PURPOSE	:	This method will allow a single task thread to connect to a client request in parallel.
        *	INPUTS	:	Object clientObject - holds the TCPClient object that was connected to the client
        *	RETURNS	:	bool status - true if successful 
        */
        public bool HandleRequest(Object clientObject)
        {
            TcpClient client = (TcpClient)clientObject;
            NetworkStream stream = null;
            string packageReceived = null;
            bool status = true;

            // Get a stream object for reading and writing
            try
            {
                stream = client.GetStream();            
                // Log connection
                Console.WriteLine("[CONNECTED] - Connected to client");
                serverLog.Log("[CONNECTED] - Connected to client");
            }
            catch
            {
                Console.WriteLine("[ERROR] - Connecting to client failed");
                serverLog.Log("[ERROR] - Connecting to client failed");
                status = false;
                return status;
            }

            // Get data from socket and convert to string
            packageReceived = GetRequest(stream);

            string packageToSend = "";

            // Validate the request had no errors
            if (!packageReceived.Contains("400") && !packageReceived.Contains("500"))
            {
                // Parse the received request
                packageToSend = requestParser.ParseReceived(packageReceived);
            }

            // Send response back
            responseHandler.SendResponse(stream, packageToSend);

            // Disconnect from client and log
            client.Close();
            Console.WriteLine("[DISCONNECTED] - Closed client connection");
            serverLog.Log("[DISCONNECTED] - Closed client connection");

            return status;
        }


        /*
        *	NAME	:	GetRequest
        *	PURPOSE	:	This method will read the request from the client and return it.
        *	INPUTS	:	Object clientObject - holds the TCPClient object that was connected to the client
        *	RETURNS	:	string request - the client request as a string
        */
        public string GetRequest(Object networkObject)
        {
            NetworkStream stream = (NetworkStream)networkObject;
            string request = "";

            // Buffer for reading data
            Byte[] bytes = new Byte[1024];

            try
            {
                // Convert bytes to ascii string.   
                int numBytes = stream.Read(bytes, 0, bytes.Length);
                request = System.Text.Encoding.ASCII.GetString(bytes, 0, numBytes);

                // Validate the request is not blank
                if (request.Length > 0)
                {
                    // Log the received
                    serverLog.Log("[RECEIVED] - Data from client received: " + request);
                    Console.WriteLine("[RECEIVED] - Data from client received");
                }
                else
                {
                    // Set bad request return code
                    request = "400\n";      
                    Console.WriteLine("[ERROR] - No data received from client");
                }
            }
            catch
            {
                // Set Internal Server Error return code
                request = "500\n";
                // Log errors
                serverLog.Log("[ERROR] Could not read data from client");
                Console.WriteLine("[ERROR] Could not read data from client");
            }
            return request;
        }
    }
}

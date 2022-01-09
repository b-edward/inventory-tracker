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
        private static ILogger serverLog;        // The logger
        public static IRequestParser parser;

        // Constructor
        public RequestHandler()
        {
            // Instantiate parser
            parser = new RequestParser();

            // Instantiate log file
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
        }


        /*
        *	NAME	:	HandleRequest
        *	PURPOSE	:	This method will allow a single task thread to handle a client request in parallel.
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

            // Parse the received string
            string packageToSend = parser.ParseReceived(packageReceived);

            // Send response back
            SendResponse(stream, packageToSend);

            // Disconnect from client and log
            client.Close();
            Console.WriteLine("[DISCONNECTED] - Closed client connection");
            serverLog.Log("[DISCONNECTED] - Closed client connection");

            return status;
        }


        /*
        *	NAME	:	GetRequest
        *	PURPOSE	:	This method will send the response to the client.
        *	INPUTS	:	Object clientObject - holds the TCPClient object that was connected to the client
        *	RETURNS	:	bool - true if successful 
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
                if (request.Length > 0)
                {
                    // Log the received
                    serverLog.Log("[RECEIVED] - Data from client received: " + request);
                    Console.WriteLine("[RECEIVED] - Data from client received");
                }
                else
                {
                    request = "error";
                    Console.WriteLine("[ERROR] - No data received from client");
                }
            }
            catch
            {
                request = "error";
                // Log errors
                serverLog.Log("[ERROR] Could not read data from client");
                Console.WriteLine("[ERROR] Could not read data from client");
            }
            return request;
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
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);
                stream.Write(msg, 0, msg.Length);
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

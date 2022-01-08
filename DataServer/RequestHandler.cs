using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataServer
{
    class RequestHandler
    {
        private static Logger serverLog;
        public static RequestParser parser;

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
        *	RETURNS	:	void 
        */
        public void HandleRequest(Object clientObject)
        {
            TcpClient client = (TcpClient)clientObject;
            // Buffer for reading data
            Byte[] bytes = new Byte[1024];
            string packageReceived = null;

            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();
            // Log connection
            Console.WriteLine("[CONNECTED] - Connected to client");
            serverLog.Log("[CONNECTED] - Connected to client");

            // Get data from socket and convert to string
            try
            {
                // Convert bytes to ascii string.   
                int numBytes = stream.Read(bytes, 0, bytes.Length);
                packageReceived = System.Text.Encoding.ASCII.GetString(bytes, 0, numBytes);
                // Log the received
                serverLog.Log("[RECEIVED] - Data from client received: " + packageReceived);
                Console.WriteLine("[RECEIVED] - Data from client received");
            }
            catch
            {
                // Log errors
                serverLog.Log("[ERROR] Could not read data from client");
                Console.WriteLine("[ERROR] Could not read data from client");
            }

            // Parse the received string
            string packageToSend = parser.ParseReceived(packageReceived);

            // Send response back
            try
            {
                // Convert string response to bytes and send to client
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(packageToSend);
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("[SENT] - Response sent to client");
                serverLog.Log("[SENT] - Response sent to client: " + packageToSend);
            }
            catch
            {
                serverLog.Log("[ERROR] Could not write response to client");
                Console.WriteLine("[ERROR] Could not write response to client");
            }

            // Disconnect from client and log
            client.Close();
            Console.WriteLine("[DISCONNECTED] - Closed client connection");
            serverLog.Log("[DISCONNECTED] - Closed client connection");
        }
    }
}

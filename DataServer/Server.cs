/*
 * FILE            : Server.cs
 * PROJECT         : Shopify Backend Developer Intern Challenge 2022
 * PROGRAMMER      : Edward Boado
 * FIRST VERSION   : 2021 - 12 - 04
 * DESCRIPTION     : This file contains the Server class, which will handle database access by listening and connecting with 
 *                   clients via TCP socket. When a client connects and sends a SQL query, the Server will parse the received 
 *                   string, call DatabaseHandler methods to run the query, then build and return the response before disconnecting.
 */


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataServer
{
    public sealed class Server
    {
        public static volatile bool Done = false;                       // Volatile bool for start/stop
        private static readonly object lockServer = new object();       // Lock object to make critical code thread safe
        private static Server gameServer = null;                        // A private instance of the server
        private static Logger serverLog;

        // Private constructor
        private Server()
        {
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
        }

        // Method to create/return an instance, and only allow one instance
        public static Server getServerInstance
        {
            get
            {
                // make thread safe
                lock (lockServer)
                {
                    if (gameServer == null)
                    {
                        gameServer = new Server();
                    }
                    return gameServer;
                }
            }
        }

        /*
        *	NAME	:	Run
        *	PURPOSE	:	This method will initiate running of the server by calling the Listen method until
        *	            the service is stopped.
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
        public void Run()
        {
            while (!Done)
            {
                Listen();
            }
        }

        /*
        *	NAME	:	Listen
        *	PURPOSE	:	This method will listen for a client request, connect with the client,
        *	            and use multithreading to assign processing tasks in parallel.
        *	INPUTS	:	None
        *	RETURNS	:	void Task
        */
        public static async Task Listen()
        {
            TcpListener server = null;

            string readIP = ConfigurationManager.AppSettings.Get("ip");
            string readPort = ConfigurationManager.AppSettings.Get("port");

            // Validate port and IP
            bool readPortSuccess = Int32.TryParse(readPort, out int parsedPort);
            bool readIPSuccess = IPAddress.TryParse(readIP, out IPAddress parsedIP);

            IPAddress localIP = null;
            Int32 port = 0;

            // Assign properties if valid
            if (readPortSuccess && parsedPort > 0)
            {
                port = parsedPort;
            }
            if (readIPSuccess)
            {
                localIP = parsedIP;
            }

            try
            {
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localIP, port);

                // Start listening for client requests.

                server.Start();

                // Enter the listening loop.
                while (!Done)
                {
                    if (server.Pending())
                    {
                        // Get a new connection
                        TcpClient client = server.AcceptTcpClient();

                        // Create a task and supply delegate
                        Task processRequest = new Task(() => HandleRequest(client));
                        // New task run by a thread while main thread returns to listening loop
                        processRequest.Start();
                    }
                    else
                    {
                        Thread.Sleep(1);
                    }
                }
            }
            // Handle exeptions
            catch
            {
                serverLog.Log("[ERROR] - Could not establish connection to a client.");
            }
            finally
            {
                // Stop listening for new clients.
                if (server != null)
                {
                    server.Stop();
                }
            }
        }


        /*
        *	NAME	:	HandleRequest
        *	PURPOSE	:	This method will allow a single task thread to handle a client request in parallel.
        *	INPUTS	:	Object clientObject - holds the TCPClient object that was connected to the client
        *	RETURNS	:	void 
        */
        public static void HandleRequest(Object clientObject)
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
            string packageToSend = ParseReceived(packageReceived);

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
            Console.WriteLine("[DISCONNECTED] - Connection from client closed");
            serverLog.Log("[DISCONNECTED] - Connection from client closed");
        }


        /*
        *	NAME	:	ParseReceived
        *	PURPOSE	:	This method will take the received string, check what action needs to be taken, 
        *	            and call method to handle it.
        *	INPUTS	:	string received - the string from the client
        *	RETURNS	:	string  responseToSend.ToString() - the returned response from the method that is called
        */
        public static string ParseReceived(string received)
        {
            StringBuilder responseToSend = new StringBuilder();
            responseToSend.Append("This is my reply");
            return responseToSend.ToString();
        }

    }
}
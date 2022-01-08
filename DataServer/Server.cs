﻿/*
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
        private static Server dataServer = null;                        // A private instance of the server

        private static Logger serverLog;
        private static RequestHandler handler;

        // Private constructor
        private Server()
        {
            // Instantiate request handler
            handler = new RequestHandler();

            // Instantiate log file
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
        }

        // Method to create/return an instance, and only allow one instance
        public static Server GetServerInstance
        {
            get
            {
                // make thread safe
                lock (lockServer)
                {
                    if (dataServer == null)
                    {
                        dataServer = new Server();
                    }
                    return dataServer;
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
                        Task processRequest = new Task(() => handler.HandleRequest(client));
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
    }
}
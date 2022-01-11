using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServer.Log;
using DataServer.Interfaces;
using System.Configuration;
using System.Net.Sockets;

public delegate string CrudHandler(string s);

namespace DataServer.ServerClasses
{
    public class ResponseHandler 
    {
        private static ILogger serverLog;           // The logger
        private static IDataHandler dataHandler;      // Access to the database

        // Delegate instances for handling CRUD commands
        public CrudHandler create = new CrudHandler(ReceivedCreate);
        public CrudHandler read = new CrudHandler(ReceivedRead);
        public CrudHandler update = new CrudHandler(ReceivedUpdate);
        public CrudHandler delete = new CrudHandler(ReceivedDelete);

        public ResponseHandler()
        {
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
            dataHandler = new DataHandler();
        }

        public static string ReceivedCreate(string query)
        {
            string response = "";

            if (query.Length > 0)
            {
                bool status = dataHandler.Create(query);
                response = AddStatusCode(status, response);
            }
            else
            {
                response = "400\n";
            }

            return response;
        }


        public static string ReceivedRead(string query)
        {
            string response = "";

            if (query.Length > 0)
            {
                response = dataHandler.Read(query);
                bool readResult = false;
                // Set the bool true if read was okay
                if (response != null)
                {
                    if(response == "")
                    {
                        response = "404\n";
                    }
                    else
                    {
                        readResult = true;
                        // Add the status code
                        response = AddStatusCode(readResult, response);
                    }
                }
            }
            else
            {
                response = "400\n";
            }
            return response;
        }


        public static string ReceivedUpdate(string query)
        {
            string response = "";
            if (query.Length > 0)
            {
                bool status = dataHandler.Update(query);
                response = AddStatusCode(status, response);
            }
            else
            {
                response = "400\n";
            }
            return response;
        }


        public static string ReceivedDelete(string query)
        {
            string response = "";
            if (query.Length > 0)
            {
                bool status = dataHandler.Delete(query);
                response = AddStatusCode(status, response);
            }
            else
            {
                response = "400\n";
            }
            return response;
        }


        private static string AddStatusCode(bool status, string response)
        {
            if(status)
            {
                response = response.Insert(0, "200\n");
            }
            else
            {
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

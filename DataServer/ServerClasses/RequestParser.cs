using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServer.Log;
using DataServer.Interfaces;
using System.Data;
using System.Reflection;

namespace DataServer.ServerClasses
{
    public class RequestParser : IRequestParser
    {
        private static ILogger serverLog;           // The logger
        private static IDataHandler dataHandler;      // Access to the database

        // Constructor
        public RequestParser()
        {
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
            dataHandler = new DataHandler();
        }


        /*
        *	NAME	:	ParseReceived
        *	PURPOSE	:	This method will take the received string, check what action needs to be taken, 
        *	            and call method to handle it.
        *	INPUTS	:	string received - the string from the client
        *	RETURNS	:	string  responseToSend.ToString() - the returned response from the method that is called
        */
        public string ParseReceived(string received)
        {
            string response = "";

            if (received != null)
            {
                // Parse the string to get the request command
                string[] receivedFields = received.Split('\n');             // Zeroth index is the command
                int lastIndex = receivedFields[0].Length - 1;   
                string command = receivedFields[0].Substring(0, lastIndex);

                // Call the method to handle the command
                switch (command)                      
                {
                    case "PUT":
                        response = ReceivedCreate(receivedFields[1]);      // First index is the query
                        break;
                    case "GET":
                        response = ReceivedRead(receivedFields[1]);
                        break;
                    case "POST":
                        response = ReceivedUpdate(receivedFields[1]);
                        break;
                    case "DELETE":
                        response = ReceivedDelete(receivedFields[1]);
                        break;
                    default:
                        response = "400\n";
                        break;
                }
            }
            else
            {
                response = "400\n";
            }
            return response;
        }


        private string ReceivedCreate(string query)
        {
            string response = "";
            bool status = dataHandler.Create(query);
            response = status.ToString();
            return response;
        }


        private string ReceivedRead(string query)
        {
            string response = "";
            response = dataHandler.Read(query);
            return response;
        }


        private string ReceivedUpdate(string query)
        {
            string response = "";
            bool status = dataHandler.Update(query);
            response = status.ToString();
            return response;
        }


        private string ReceivedDelete(string query)
        {
            string response = "";
            bool status = dataHandler.Delete(query);
            response = status.ToString();
            return response;
        }
    }
}

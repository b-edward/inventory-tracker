using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServer.Log;
using DataServer.Interfaces;

namespace DataServer.ServerClasses
{
    public class RequestParser : IRequestParser
    {
        private static ILogger serverLog;           // The logger
        private static IDataRequester dbAccess;      // Access to the database

        // Constructor
        public RequestParser()
        {
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
            dbAccess = new DataRequester();
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
            StringBuilder response = new StringBuilder();

            if (received != null)
            {
                response.Append("This is my reply");
            }
            else
            {
                response.Append("error");
            }
            return response.ToString();
        }

        //

    }
}

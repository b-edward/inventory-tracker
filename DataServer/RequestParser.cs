using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer
{
    class RequestParser
    {
        private static Logger serverLog;

        // Constructor
        public RequestParser()
        {
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
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
            StringBuilder responseToSend = new StringBuilder();
            responseToSend.Append("This is my reply");
            return responseToSend.ToString();
        }
    }
}

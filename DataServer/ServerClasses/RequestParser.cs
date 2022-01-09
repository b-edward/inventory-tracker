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
        private static IDataHandler dbAccess;      // Access to the database

        // Constructor
        public RequestParser()
        {
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
            dbAccess = new DataHandler();
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
            DataTable data = new DataTable();
            string response = "";

            if (received != null)
            {
                if(received == "read")
                {
                    data = dbAccess.Read("query");
                    response = ConvertDataTableToString(data);
                }              
                
            }
            else
            {
                response = null;
            }
            return response;
        }


        public string ConvertDataTableToString(DataTable datatable)
        {
            string response = "";
            if (datatable != null)
            {
                response = ConvertDataTable<Product>(datatable);
            }
            else
            {
                serverLog.Log("[ERROR] - Could not convert DataTable to string");
            }

            return response.ToString();
        }


        private static string ConvertDataTable<T>(DataTable dt)
        {
            StringBuilder response = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                int columns = row.ItemArray.Length;
                for (int i = 0; i < columns; i++)
                {
                    response.Append(row.ItemArray[i] + ",");
                }
                response.Length--;
                response.Append("&");
            }
            response.Append("/");
            return response.ToString();
        }
    }
}

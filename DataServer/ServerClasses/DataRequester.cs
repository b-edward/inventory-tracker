using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServer.Interfaces;
using DataServer.DataAccess;
using DataServer.Log;


namespace DataServer.ServerClasses
{
    public class DataRequester : IDataRequester
    {
        private static IDatabase db;            // Represents the MySQL database
        private static ILogger serverLog;       // The logger

        public DataRequester()
        {
            db = new DatabaseHandler();
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
        }

        public string Create(string query)
        {
            string response = "";

            if(query == null)
            {
                response = "error";
            }

            return response;
        }

        public string Read(string query)
        {
            string response = "";

            if (query == null)
            {
                response = "error";
            }

            return response;
        }

        public string Update(string query)
        {
            string response = "";

            if (query == null)
            {
                response = "error";
            }

            return response;
        }

        public string Delete(string query)
        {
            string response = "";

            if (query == null)
            {
                response = "error";
            }

            return response;
        }

    }
}

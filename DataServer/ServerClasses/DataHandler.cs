using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServer.Interfaces;
using DataServer.DataAccess;
using DataServer.Log;
using System.Data;

namespace DataServer.ServerClasses
{
    public class DataHandler : IDataHandler
    {
        private static IDatabaseHandler databaseHandler;            // Represents the MySQL database
        private static ILogger serverLog;       // The logger

        public DataHandler()
        {
            databaseHandler = new DatabaseHandler();
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
        }

        public bool Create(string query)
        {
            bool status = false;
            if (query != null)
            {
                status = ExecuteCUD(query);
            }
            return status;
        }

        public string Read(string query)
        {
            DataTable data = new DataTable();
            string response = "";

            if (query != null)
            {
                databaseHandler.Connect();
                data = databaseHandler.Select(query);
                databaseHandler.Disconnect();

                if(data != null)
                {
                    response = DataTableConverter.ConvertDataTableToString(data);
                }
            }
            else
            {
                response = null;
            }

            return response;
        }

        public bool Update(string query)
        {
            bool status = false;
            if (query != null)
            {
                status = ExecuteCUD(query);
            }
            return status;
        }

        public bool Delete(string query)
        {
            bool status = false;
            if (query != null)
            {
                status = ExecuteCUD(query);
            }
            return status;
        }

        public bool ExecuteCUD(string query)
        {
            bool status = false;
            if (query != null)
            {
                databaseHandler.Connect();
                status = databaseHandler.Execute(query);
                databaseHandler.Disconnect();
            }
            return status;
        }
    }
}

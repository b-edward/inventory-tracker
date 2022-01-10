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
        private static IDatabase db;            // Represents the MySQL database
        private static ILogger serverLog;       // The logger

        public DataHandler()
        {
            db = new DatabaseHandler();
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
        }

        public bool Create(string query)
        {
            bool status = true;

            if(query == null)
            {
                status = false;
            }

            return status;
        }

        public string Read(string query)
        {
            DataTable data = new DataTable();
            string response = "";

            if (query != null)
            {
                db.Connect();
                data = db.Select(query);
                if(data != null)
                {
                    response = DataTableConverter.ConvertDataTableToString(data);
                    response.Insert(0, "200\n");
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
            bool status = true;

            if (query == null)
            {
                status = false;
            }

            return status;
        }

        public bool Delete(string query)
        {
            bool status = true;

            if (query == null)
            {
                status = false;
            }

            return status;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServer.Log;
using DataServer.Interfaces;
using System.Configuration;

namespace DataServer.ServerClasses
{
    public class ResponseHandler : IResponseHandler
    {
        private static ILogger serverLog;           // The logger
        private static IDataHandler dataHandler;      // Access to the database

        public ResponseHandler()
        {
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
            dataHandler = new DataHandler();
        }

        public string ReceivedCreate(string query)
        {
            string response = "";
            bool status = dataHandler.Create(query);
            response = AddStatusCode(status, response);
            return response;
        }


        public string ReceivedRead(string query)
        {
            string response = "";
            response = dataHandler.Read(query);

            // Add the status code
            if(response != null)
            {
                response = AddStatusCode(true, response);
            }
            else
            {
                response = AddStatusCode(false, response);
            }

            return response;
        }


        public string ReceivedUpdate(string query)
        {
            string response = "";
            bool status = dataHandler.Update(query);
            response =  AddStatusCode(status, response);
            return response;
        }


        public string ReceivedDelete(string query)
        {
            string response = "";
            bool status = dataHandler.Delete(query);
            response = AddStatusCode(status, response);
            return response;
        }


        private string AddStatusCode(bool status, string response)
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
    }
}

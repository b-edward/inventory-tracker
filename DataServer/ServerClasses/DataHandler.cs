/*
 * FILE             : DataHandler.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 09
 * DESCRIPTION      : This file contains the DataHandler class, which will handle the data requests from the
 *                    server handlers to the database handler.
 */

using DataServer.DataAccess;
using DataServer.Interfaces;
using DataServer.Log;
using System.Configuration;
using System.Data;

namespace DataServer.ServerClasses
{
    public class DataHandler : IDataHandler
    {
        private static IDatabaseHandler databaseHandler;        // Represents the MySQL database
        private static ILogger serverLog;                       // The logger

        /*
        *	NAME	:	DataHandler -- Constructor
        *	PURPOSE	:	This method will override the default constructor and set data member values.
        *	INPUTS	:	None
        *	RETURNS	:	None
        */

        public DataHandler()
        {
            databaseHandler = new DatabaseHandler();
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
        }

        /*
        *	NAME	:	Create
        *	PURPOSE	:	This method will take a query string and forward to the database handler
        *	            for executiong a create request.
        *	INPUTS	:	string query - the query that was parsed from the request
        *	RETURNS	:	bool status - true if the command was successfully executed
        */

        public bool Create(string query)
        {
            bool status = false;
            // Validate a query is present
            if (query != null)
            {
                // Call method to handle execute commands
                status = ExecuteCUD(query);
            }
            return status;
        }

        /*
        *	NAME	:	Read
        *	PURPOSE	:	This method will take a query string and use the database handler
        *	            for executing a read request.
        *	INPUTS	:	string query - the query that was parsed from the request
        *	RETURNS	:	string response - the data returned from the database
        */

        public string Read(string query)
        {
            DataTable data = new DataTable();
            string response = "";

            // Validate a query is present
            if (query != null)
            {
                databaseHandler.Connect();
                data = databaseHandler.Select(query);
                databaseHandler.Disconnect();

                // Validate returned table before sending for conversion
                if (data != null)
                {
                    // Use the DataTableConverter to get the string
                    response = DataTableConverter.ConvertDataTableToString(data);
                }
            }
            else
            {
                response = null;
            }

            return response;
        }

        /*
        *	NAME	:	Update
        *	PURPOSE	:	This method will take a query string and forward to the database handler
        *	            for executing an update request.
        *	INPUTS	:	string query - the query that was parsed from the request
        *	RETURNS	:	bool status - true if the command was successfully executed
        */

        public bool Update(string query)
        {
            bool status = false;
            // Validate a query is present
            if (query != null)
            {
                // Call method to handle execute commands
                status = ExecuteCUD(query);
            }
            return status;
        }

        /*
        *	NAME	:	Delete
        *	PURPOSE	:	This method will take a query string and forward to the database handler
        *	            for executing a delete request.
        *	INPUTS	:	string query - the query that was parsed from the request
        *	RETURNS	:	bool status - true if the command was successfully executed
        */

        public bool Delete(string query)
        {
            bool status = false;
            // Validate a query is present
            if (query != null)
            {
                // Call method to handle execute commands
                status = ExecuteCUD(query);
            }
            return status;
        }

        /*
        *	NAME	:	ExecuteCUD
        *	PURPOSE	:	This method will take a query string, connect/disconnect the database handler,
        *	            and execute the command.
        *	INPUTS	:	string query - the query to execute
        *	RETURNS	:	bool status - true if the command was successfully executed
        */

        public bool ExecuteCUD(string query)
        {
            bool status = false;
            databaseHandler.Connect();
            status = databaseHandler.Execute(query);
            databaseHandler.Disconnect();
            return status;
        }
    }
}
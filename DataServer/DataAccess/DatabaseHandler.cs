/*
 * FILE             : DatabaseHandler.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2021 - 12 - 08
 * DESCRIPTION      : This file contains the DatabaseHandler class, which will connect to a MySQL database server. It will
 *                    take queries/commands, run them on the database, and then return the response data.
 */

using DataServer.Log;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace DataServer.DataAccess
{
    public class DatabaseHandler : IDatabaseHandler
    {
        // Data members
        private MySqlConnection connection;     // The connection

        private static ILogger serverLog;       // The logger

        /*
        *	NAME	:	DatabaseHandler -- Constructor
        *	PURPOSE	:	This method will override the default constructor and set data member values.
        *	INPUTS	:	None
        *	RETURNS	:	None
        */

        public DatabaseHandler()
        {
            // Set initial values
            connection = null;
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            // Instantiate an object for logging
            serverLog = new Logger(logFile);
        }

        /*
        *	NAME	:	Connect
        *	PURPOSE	:	This method will get server settings from a config file and use them to
        *	            connect to a MySQL database.
        *	INPUTS	:	None
        *	RETURNS	:	bool connected - true if the connection was successfully opened
        */

        public bool Connect()
        {
            bool connected = false;

            // Get configurable database server settings from file
            string ip = ConfigurationManager.AppSettings.Get("ip");
            string database = ConfigurationManager.AppSettings.Get("database");
            string username = ConfigurationManager.AppSettings.Get("user");
            string password = ConfigurationManager.AppSettings.Get("password");

            // Create connection string and connection
            string connectionString = "SERVER=" + ip + ";DATABASE=" + database + ";UID=" + username + ";PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

            // Open connection using login info
            try
            {
                connection.Open();
                connected = true;
            }
            catch
            {
                connected = false;
                serverLog.Log("[ERROR] - Could not log into the database");
            }
            return connected;
        }

        /*
        *	NAME	:	Disconnect
        *	PURPOSE	:	This method will close the connection to the database
        *	INPUTS	:	None
        *	RETURNS	:	bool closed - true if the connection was successfully closed
        */

        public bool Disconnect()
        {
            bool closed = false;

            // Close the connection
            try
            {
                connection.Close();
                closed = true;
            }
            catch
            {
                closed = false;
                serverLog.Log("[ERROR] - Could not close the database");
            }

            return closed;
        }

        /*
        *	NAME	:	Execute
        *	PURPOSE	:	This method will execute MySQL queries to create, update and delete from a table
        *	INPUTS	:	string sqlCommand - the query to execute
        *	RETURNS	:	bool executed - true if the query was successfully executed
        */

        public bool Execute(string sqlCommand)
        {
            bool executed = false;

            // Run the query on the connected database
            MySqlCommand command = new MySqlCommand(sqlCommand, connection);
            try
            {
                // Validate that the command was executed
                if (command.ExecuteNonQuery() > 0)
                {
                    executed = true;
                }
            }
            catch
            {
                serverLog.Log("[ERROR] - Could not execute command: " + sqlCommand);
            }
            return executed;
        }

        /*
        *	NAME	:	Select
        *	PURPOSE	:	This method will execute MySQL queries to read from a table
        *	INPUTS	:	string selectQuery - the query to execute
        *	RETURNS	:	DataTable selectedData - a table with the data returned by the database
        */

        public DataTable Select(string selectQuery)
        {
            DataTable selectedData = null;

            try
            {
                // create command and adapter
                MySqlCommand selector = new MySqlCommand(selectQuery, connection);
                MySqlDataAdapter selectAdaptor = new MySqlDataAdapter(selector);

                // fill table
                selectedData = new DataTable();
                selectAdaptor.Fill(selectedData);
            }
            catch
            {
                serverLog.Log("[ERROR] - Could not select command: " + selectQuery);
                selectedData = null;
            }
            return selectedData;
        }
    }
}
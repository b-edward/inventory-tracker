/*
 * FILE             : DatabaseHandler.cs
 * PROJECT          : Quiz_Server - Demo Day
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2021 - 12 - 08
 * DESCRIPTION      : This file contains the DatabaseHandler class, which will connect to a MySQL database server. It will
 *                    take queries/commands, run them on the database, and then return the response data.
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DataServer.Log;

namespace DataServer.DataAccess
{
    public class DatabaseHandler : IDatabase
    {
        // Data members
        private MySqlConnection connection;     // The connection
        private static ILogger serverLog;       // The logger

        // constructor
        public DatabaseHandler()
        {
            connection = null;
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            serverLog = new Logger(logFile);
        }

        // login method
        public bool Connect()
        {
            bool connected = false;

            // Get configurable database server settings from file
            string ip = ConfigurationManager.AppSettings.Get("ip");
            string database = ConfigurationManager.AppSettings.Get("database");
            string username = ConfigurationManager.AppSettings.Get("user");
            string password = ConfigurationManager.AppSettings.Get("password");

            // create connection string and connection
            string connectionString = "SERVER=" + ip + ";DATABASE=" + database + ";UID=" + username + ";PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

            // open connection using login info
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


        // method to disconnect
        public bool Disconnect()
        {
            bool closed = false;       

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

        // method for executing Create, Update, Delete commands
        public bool Execute(string sqlCommand)
        {
            bool executed = false;

            MySqlCommand command = new MySqlCommand(sqlCommand, connection);
            try
            {
                if(command.ExecuteNonQuery() > 0)
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

        // Method for Read queries
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

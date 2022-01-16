/*
 * FILE             : DataTableConverter.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 10
 * DESCRIPTION      : This file contains the DataTableConverter class, which will convert a DataTable
 *                    into a string. It is a static class so it does not get instantiated.
 */

using DataServer.Log;
using System.Configuration;
using System.Data;
using System.Text;

namespace DataServer.DataAccess
{
    public static class DataTableConverter
    {
        private static ILogger serverLog;           // The logger

        /*
        *	NAME	:	ConvertDataTableToString
        *	PURPOSE	:	This method will validate the table before the conversion
        *	INPUTS	:	DataTable datatable - the table to be converted to string
        *	RETURNS	:	string response - the table as a string, or error code if invalid
        */

        public static string ConvertDataTableToString(DataTable datatable)
        {
            string response = "";

            // Validate the table has data
            if (datatable != null)
            {
                // Call method to convert
                response = ConvertDataTable(datatable);
            }
            else
            {
                string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
                serverLog = new Logger(logFile);
                serverLog.Log("[ERROR] - Could not convert DataTable to string");
                response = "500\nCould not retrieve data.";
            }
            // Return the converted data table as a string
            return response;
        }

        /*
        *	NAME	:	ConvertDataTable
        *	PURPOSE	:	This method will extract the data from the table and build a string from it
        *	INPUTS	:	DataTable datatable - the table to be converted to string
        *	RETURNS	:	string response - the table data as a string
        */

        private static string ConvertDataTable(DataTable datatable)
        {
            StringBuilder response = new StringBuilder();

            // Iterate through each row
            foreach (DataRow row in datatable.Rows)
            {
                int columns = row.ItemArray.Length;
                // Iterate through each column
                for (int i = 0; i < columns; i++)
                {
                    // Save each item and add a ',' to separate each field
                    response.Append(row.ItemArray[i] + ",");
                }
                response.Length--;      // Clear the last comma
                response.Append("&");   // Add an '&' to separate each row
            }

            // Return the string that was built
            return response.ToString();
        }
    }
}
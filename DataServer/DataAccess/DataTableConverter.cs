using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServer.Log;
using DataServer.Interfaces;

namespace DataServer.DataAccess
{
    public static class DataTableConverter
    {
        private static ILogger serverLog;           // The logger

        // Method to check the datatable for conversion
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
                response = "500\n";
            }
            // Return the converted data table as a string
            return response;
        }


        // Method to extract the data from the table and build a string from it
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

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryTracker
{
    public partial class startPage : System.Web.UI.Page
    {
        private MySqlConnection connection;     // The connection

        protected void Page_Load(object sender, EventArgs e)
        {
            Connect();
        }

        // login method
        public bool Connect()
        {
            bool connected = false;

            // Get configurable database server settings from file
            string serverName = "eb-inventory.mysql.database.azure.com";
            string database = "quiz";
            string username = "edward";
            string password = "Nh&sJXOf@UTmz3j3bC%!P1lz%AwDj3w7hs5C04Ww7$xL!V$X&zJkB%7N65@xk4YamtY*F";

            // create connection string and connection
            string connectionString = "SERVER=" + serverName + ";DATABASE=" + database + ";UID=" + username + ";PASSWORD=" + password + ";";
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
                Console.WriteLine("[ERROR] - Could not log into the database");
            }
            return connected;
        }


        // method for select queries
        public void Select()
        {
            DataTable selectedData = null;
            string selectQuery = "SELECT * FROM `questions`;";

            try
            {
                // create command and adapter
                MySqlCommand selector = new MySqlCommand(selectQuery, connection);
                MySqlDataAdapter selectAdaptor = new MySqlDataAdapter(selector);

                // fill table
                selectedData = new DataTable();
                selectAdaptor.Fill(selectedData);


                if (selectedData != null)
                {
                    // Check the correct questionID
                    foreach (DataRow row in selectedData.Rows)
                    {
                        // print to screen
                        txtOutput.Text += "questionText = " + row.Field<string>("questionText") + "\n";
                        
                    }
                }

            }
            catch
            {
                Console.WriteLine("[ERROR] - Could not select command: " + selectQuery);
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Select();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = ""; 
        }
    }
}

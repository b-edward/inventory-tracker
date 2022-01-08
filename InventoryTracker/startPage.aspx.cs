using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryTracker
{
    public partial class startPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /*
        *	NAME	:	SendToServer
        *	PURPOSE	:	This method will establish a connection with the server, and build a package string to send a request.
        *	            It will use the established package protocol to send and receive data from the server, then call a method
        *	            to process the response.
        *	INPUTS	:	None
        *	RETURNS	:	void 
        */
        public void SendToServer(string stringToSend)
        {
            try
            {
                // Create a new TCP Client
                TcpClient client = new TcpClient("13.92.120.219", 13000);

                // Translate the passed message into ASCII and store it as a Byte array.
                byte[] data = System.Text.Encoding.ASCII.GetBytes(stringToSend);

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                // Reset buffer to store the server response bytes.
                data = new byte[32767];

                // String to store the response ASCII representation.
                string responseData = string.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                string packageReceived = responseData;

                // Close connection
                stream.Close();
                client.Close();

                // Print the response
                txtOutput.Text = packageReceived;
            }
            catch
            {
                Console.WriteLine("[ERROR] - could not send to server");
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            SendToServer(txtOutput.Text);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = ""; 
        }
    }
}

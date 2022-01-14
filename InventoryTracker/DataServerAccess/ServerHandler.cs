using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Text;
using InventoryTracker.Interfaces;

namespace InventoryTracker.DataServerAccess
{
    public class ServerHandler : IDataHandler
    {
        public ServerHandler()
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
        public string SendToServer(string stringToSend)
        {
            string response = "";

            if(stringToSend.Length > 0)
            {
                try
                {
                    // Create a new TCP Client
                    TcpClient client = new TcpClient("127.0.0.1", 13000);    //13.92.120.219
                    
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

                    // Read the DataServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    response = responseData;

                    // Close connection
                    stream.Close();
                    client.Close();

                }
                catch
                {
                    Console.WriteLine("[ERROR] - could not send to server");
                }
            }
            else
            {
                response = "There's nothing to send.";
            }

            // return the response
            return response;
        }

        // Create a new record in the database
        public bool Create(string query)
        {
            bool status = false;
            return status;
        }

        // Read one or more records from the database
        public string Read(string query)
        {
            string serverResponse = "";
            return serverResponse;
        }

        // Modify an existing entry
        public bool Update(string query)
        {
            bool status = false;
            return status;
        }

        // Delete an existing entry
        public bool Delete(string query)
        {
            bool status = false;
            return status;
        }

    }
}
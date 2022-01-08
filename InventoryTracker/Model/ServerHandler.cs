﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;

namespace InventoryTracker
{
    public class ServerHandler : IDatabaseCommand
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
            string packageReceived = "";

            try
            {
                // Create a new TCP Client
                TcpClient client = new TcpClient("127.0.0.1", 13000);

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
                packageReceived = responseData;

                // Close connection
                stream.Close();
                client.Close();

            }
            catch
            {
                Console.WriteLine("[ERROR] - could not send to server");
            }

            // return the response
            return packageReceived;
        }

        // Create a new record in the database
        public string Create(string newRecord)
        {
            string serverResponse = "";
            return serverResponse;
        }

        // Overloaded method to read all records
        public string Read()
        {
            string serverResponse = "";
            return serverResponse;
        }

        // Overloaded method to read a single record
        public string Read(string id)
        {
            string serverResponse = "";
            return serverResponse;
        }

        // Modify an existing entry
        public string Update(string id, string updates)
        {
            string serverResponse = "";
            return serverResponse;
        }

        // Delete an existing entry
        public string Delete(string id)
        {
            string serverResponse = "";
            return serverResponse;
        }
    }
}
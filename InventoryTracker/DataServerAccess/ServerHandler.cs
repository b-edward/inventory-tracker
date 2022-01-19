/*
 * FILE             : ServerHandler.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 12
 * DESCRIPTION      : This file contains the ServerHandler class, which will implements the IServerHandler interface.
 *                    It will connect to the DataServer, send and receive messages by TCP/IP.
 */

using InventoryTracker.Interfaces;
using System;
using System.Net.Sockets;

namespace InventoryTracker.DataServerAccess
{
    public class ServerHandler : IServerHandler
    {
        /*
        *	NAME	:	SendToServer
        *	PURPOSE	:	This method will establish a connection with the server, and send it a request string.
        *	            It will convert ascii strings to byte arrays for transferring over TCP.
        *	INPUTS	:	string stringToSend
        *	RETURNS	:	string response - the response from the server
        */

        public string SendToServer(string stringToSend)
        {
            string response = "";

            if (stringToSend.Length > 0)
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
                response = "400\nThere's nothing to send.";
            }

            // return the response
            return response;
        }
    }
}
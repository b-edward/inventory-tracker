using DataServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.ServerClasses
{
    public class RequestParser : IRequestParser
    {
        IResponseHandler responseHandler;

        // Constructor
        public RequestParser()
        {
            responseHandler = new ResponseHandler();
        }

        /*
        *	NAME	:	ParseReceived
        *	PURPOSE	:	This method will take the received string, check what action needs to be taken, 
        *	            and call method to handle it.
        *	INPUTS	:	string received - the string from the client
        *	RETURNS	:	string  responseToSend.ToString() - the returned response from the method that is called
        */
        public string ParseReceived(string received)
        {
            string response = "";

            if (received != null)
            {
                // Parse the string to get the request command
                string[] receivedFields = received.Split('\n');             // Zeroth index is the command
                int lastIndex = receivedFields[0].Length - 1;   
                string command = receivedFields[0].Substring(0, lastIndex);

                // Call the method to handle the command
                switch (command.ToUpper())                      
                {
                    case "PUT":
                        response = responseHandler.ReceivedCreate(receivedFields[1]);      // First index is the query
                        break;
                    case "GET":
                        response = responseHandler.ReceivedRead(receivedFields[1]);
                        break;
                    case "POST":
                        response = responseHandler.ReceivedUpdate(receivedFields[1]);
                        break;
                    case "DELETE":
                        response = responseHandler.ReceivedDelete(receivedFields[1]);
                        break;
                    default:
                        response = "400\n";
                        break;
                }
            }
            else
            {
                response = "400\n";
            }
            return response;
        }
    }
}

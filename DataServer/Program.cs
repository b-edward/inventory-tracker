using DataServer.Log;
using DataServer.ServerClasses;
using System;
using System.Configuration;

namespace DataServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Instantiate the server
            Server dataServer = Server.GetServerInstance;

            // Log startup
            string logFile = ConfigurationManager.AppSettings.Get("serverLogFile");
            ILogger serverLog = new Logger(logFile);
            serverLog.Log("[SERVER INITIALIZED] - Listening for clients");
            Console.WriteLine($"[SERVER INITIALIZED] - Listening for clients\n" +
                $"[NOTE] - See {logFile} for detailed logs.");

            // Call method to start async listening
            Listen();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            serverLog.Log("[SERVER SHUTDOWN] - Program closed");
        }

        /*
        *	NAME	:	Listen
        *	PURPOSE	:	This asynchronous method will call the server's listener method, and run it in an asyncrhonous loop.
        *	INPUTS	:	None
        *	RETURNS	:	void Task
        */

        public static async void Listen()
        {
            // Always listen for requests
            while (true)
            {
                await Server.Listen();
            }
        }
    }
}
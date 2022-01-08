using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the server
            Server gameServer = Server.getServerInstance;

            Console.WriteLine("[SERVER INITIALIZED] - Listening for clients");

            // Call method to start async listening
            Listen();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
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

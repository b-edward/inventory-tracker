using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    public class ItemController : ITableRead, ITableCUD
    {
        private IModel itemTable;
        
        public ItemController()
        {
        }

        // Create SQL query to execute the command in the item table
        public string BuildCUDQuery(object table, string command)
        {
            string query = "";

            // Convert the object parameter into a Product
            itemTable = (Product)table;

            // Use itemTable properties to build the command query 

            return query; 
        }


        // Create SQL query to get inventory of all items
        public string BuildReadQuery()
        {
            string query = "";

            // Use itemTable properties to build select query string

            return query;
        }
    }
}
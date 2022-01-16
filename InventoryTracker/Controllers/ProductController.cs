﻿using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class ProductController : ITableRead, ITableCUD
    {
        private IModel productTable;

        public ProductController()
        {
        }

        // Create SQL query to execute the command in the product table
        public string BuildCUDQuery(object table, string command)
        {
            string query = "";

            // Convert the object parameter into a Product
            productTable = (Product)table;

            // Use productTable properties to build the command query

            return query;
        }

        // Create SQL query to get inventory of all products
        public string BuildReadQuery()
        {
            string query = "GET\nSELECT * FROM `Product`;";
            return query;
        }
    }
}
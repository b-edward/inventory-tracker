/*
 * FILE             : ProductController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 13
 * DESCRIPTION      : This file contains the ProductController class, which implements the ITableRead and ITableCUD interfaces.
 *                    It will provide SQL queries for accessing the product data table.
 */

using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class ProductController : ITableRead, ITableCUD
    {
        // Interface for abstraction
        private IProduct productTable;

        /*
        *	NAME	:	BuildCUDQuery
        *	PURPOSE	:	This method will call a method to get the correct query based on the command
        *	INPUTS	:	object table - the user input data to be sent
        *	            string command -  the create, update, or delete command
        *	RETURNS	:	string query - the SQL query
        */

        public string BuildCUDQuery(object table, string command)
        {
            // Convert the object parameter into a Product
            productTable = (Product)table;
            string query = GetQuery(table, command);
            return query;
        }

        /*
        *	NAME	:	GetQuery
        *	PURPOSE	:	This method take the command and select a method to call
        *	INPUTS	:	object table - the user input data to be sent
        *	            string command -  the create, update, or delete command
        *	RETURNS	:	string query - the SQL query
        */

        private string GetQuery(object table, string command)
        {
            string query = "";

            switch (command.ToUpper())
            {
                case "PUT":
                    query = InsertQuery(table, command);
                    break;

                case "POST":
                    query = UpdateQuery(table, command);
                    break;
            }
            return query;
        }

        /*
        *	NAME	:	InsertQuery
        *	PURPOSE	:	This method take the table data and build a SQL query for inserting into a table
        *	INPUTS	:	object table - the user input data to be sent
        *	            string command -  the create, update, or delete command
        *	RETURNS	:	string query - the SQL query
        */

        private string InsertQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nINSERT INTO `Product` (`productName`, `isActive`) " +
                    $"VALUES ('{productTable.ProductName}', {productTable.IsActive});";
            return query;
        }

        /*
        *	NAME	:	UpdateQuery
        *	PURPOSE	:	This method take the table data and build a SQL query for updating a table
        *	INPUTS	:	object table - the user input data to be sent
        *	            string command -  the create, update, or delete command
        *	RETURNS	:	string query - the SQL query
        */

        private string UpdateQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nUPDATE `Product` SET productName='{productTable.ProductName}', " +
                    $"isActive={productTable.IsActive} WHERE productID={productTable.ProductID};";
            return query;
        }

        /*
        *	NAME	:	BuildReadQuery
        *	PURPOSE	:	This method provide a SQL query to get an inventory of all products
        *	INPUTS	:	None
        *	RETURNS	:	string query - the SQL query
        */

        public string BuildReadQuery()
        {
            string query = "GET\nSELECT * FROM `Product`;";
            return query;
        }
    }
}
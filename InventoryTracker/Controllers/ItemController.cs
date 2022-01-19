/*
 * FILE             : ItemController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 13
 * DESCRIPTION      : This file contains the ItemController class, which implements the ITableRead and ITableCUD interfaces.
 *                    It will provide SQL queries for accessing the item data table.
 */

using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class ItemController : ITableRead, ITableCUD
    {
        // Interface for abstraction
        private Item itemTable;

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
            itemTable = (Item)table;
            // Get a query string
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
            query = $"{command.ToUpper()}\nINSERT INTO `Item` (`productID`, `isAssigned`, `isSold`) " +
                $"VALUES({itemTable.ProductID}, {itemTable.IsAssigned}, {itemTable.IsSold});";
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
            query = $"{command.ToUpper()}\nUPDATE `Item` SET productID={itemTable.ProductID}, " +
                $"isAssigned={itemTable.IsAssigned}, isSold={itemTable.IsSold} WHERE itemID={itemTable.ItemID};";
            return query;
        }

        /*
        *	NAME	:	BuildReadQuery
        *	PURPOSE	:	This method provide a SQL query to get an inventory of all items
        *	INPUTS	:	None
        *	RETURNS	:	string query - the SQL query
        */

        public string BuildReadQuery()
        {
            string query = "GET\nSELECT Item.itemID, Product.productID, Product.productName, Item.isAssigned, " +
                            "WarehouseItem.warehouseID, Item.isSold FROM Item " +
                            "LEFT JOIN Product ON Item.productID = Product.productID " +
                            "LEFT JOIN WarehouseItem ON Item.itemID = WarehouseItem.itemID;";
            return query;
        }

        /*
        *	NAME	:	BuildReadNewestQuery
        *	PURPOSE	:	This method provide a SQL query to get the most recently added record from the Item table
        *	INPUTS	:	None
        *	RETURNS	:	string query - the SQL query
        */

        public string BuildReadNewestQuery()
        {
            string query = "GET\nSELECT * FROM `Item` ORDER BY itemID DESC LIMIT 1;";
            return query;
        }
    }
}
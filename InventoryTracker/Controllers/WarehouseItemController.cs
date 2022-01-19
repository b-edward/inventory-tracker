/*
 * FILE             : WarehouseItemController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the WarehouseItemController class, which implements the ITableRead and ITableCUD interfaces.
 *                    It will provide SQL queries for accessing the warehouseItem data table.
 */

using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class WarehouseItemController : ITableRead, ITableCUD
    {
        private WarehouseItem warehouseItemTable;

        /*
        *	NAME	:	BuildCUDQuery
        *	PURPOSE	:	This method will call a method to get the correct query based on the command
        *	INPUTS	:	object table - the user input data to be sent
        *	            string command -  the create, update, or delete command
        *	RETURNS	:	string query - the SQL query
        */

        public string BuildCUDQuery(object table, string command)
        {
            // Convert the object parameter into a warehouse
            warehouseItemTable = (WarehouseItem)table;

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

                case "DELETE":
                    query = DeleteQuery(table, command);
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
            query = $"{command.ToUpper()}\nINSERT INTO `WarehouseItem` (`warehouseID`, `itemID`) " +
                $"VALUES({warehouseItemTable.WarehouseItemID}, {warehouseItemTable.ItemID});";
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
            query = $"{command.ToUpper()}\nUPDATE `WarehouseItem` SET warehouseID={warehouseItemTable.WarehouseItemID} " +
                $"WHERE itemID={warehouseItemTable.ItemID};";
            return query;
        }

        /*
        *	NAME	:	DeleteQuery
        *	PURPOSE	:	This method take the table data and build a SQL query for deleting from a table
        *	INPUTS	:	object table - the user input data to be sent
        *	            string command -  the create, update, or delete command
        *	RETURNS	:	string query - the SQL query
        */

        private string DeleteQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nDELETE from `WarehouseItem` WHERE itemID={warehouseItemTable.ItemID};";
            return query;
        }

        // Read is not used in this release, but is included for use is future features
        // Create SQL query to get inventory of all WarehouseItems
        public string BuildReadQuery()
        {
            string query = null;
            return query;
        }
    }
}
/*
 * FILE             : WarehouseController.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the WarehouseController class, which implements the ITableRead and ITableCUD interfaces.
 *                    It will provide SQL queries for accessing the warehouse data table.
 */

using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class WarehouseController : ITableRead, ITableCUD
    {
        // Interface for abstraction
        private ILocation warehouseTable;

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
            warehouseTable = (Warehouse)table;

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
            query = $"{command.ToUpper()}\nINSERT INTO `Warehouse` (`streetAndNo`, `city`, `provinceOrState`, " +
                    $"`country`, `postalCode`, `isActive`) VALUES ('{warehouseTable.StreetAndNo}', '{warehouseTable.City}', " +
                    $"'{warehouseTable.ProvinceOrState}', '{warehouseTable.Country}', '{warehouseTable.PostalCode}', " +
                    $"'{warehouseTable.IsActive}');";
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
            query = $"{command.ToUpper()}\nUPDATE `Warehouse` SET streetAndNo='{warehouseTable.StreetAndNo}', " +
                $"city='{warehouseTable.City}', provinceOrState='{warehouseTable.ProvinceOrState}', " +
                $"country='{warehouseTable.Country}', postalCode='{warehouseTable.PostalCode}', " +
                $"isActive='{warehouseTable.IsActive}' WHERE warehouseID={warehouseTable.ID};";
            return query;
        }

        /*
        *	NAME	:	BuildReadQuery
        *	PURPOSE	:	This method provide a SQL query to get an inventory of all warehouses
        *	INPUTS	:	None
        *	RETURNS	:	string query - the SQL query
        */

        public string BuildReadQuery()
        {
            string query = "GET\nSELECT * FROM `Warehouse`;";
            return query;
        }
    }
}
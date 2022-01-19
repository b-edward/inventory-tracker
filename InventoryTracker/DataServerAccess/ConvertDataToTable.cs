/*
 * FILE             : ConvertDataToTable.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the ConvertDataToTable class, which will convert response data (ascii) strings
 *                    into DataTable format for UI display.
 */

using System.Data;

// A delegate for converting string to Datatable
public delegate DataTable TableConverter(string data);

namespace InventoryTracker.DataServerAccess
{
    public class ConvertDataToTable
    {
        // Delegate instances for converting each type of table
        public static TableConverter inventoryConverter = new TableConverter(ConvertToInventoryTable);
        public static TableConverter productConverter = new TableConverter(ConvertToProductTable);
        public static TableConverter itemConverter = new TableConverter(ConvertToItemTable);
        public static TableConverter warehouseConverter = new TableConverter(ConvertToWarehouseTable);

        /*
        *	NAME	:	GetDataTable
        *	PURPOSE	:	This method will invoke a delegate method based on the provided table name.
        *	INPUTS	:	string tableName - the name of the table to be formatted
        *	            string data - the ascii response data from the DataServer
        *	RETURNS	:	DataTable dataTable - the return data formatted as DataTable
        */

        public static DataTable GetDataTable(string tableName, string data)
        {
            DataTable newDataTable = new DataTable();

            // Switch to select the converter
            switch (tableName.ToUpper())
            {
                case "INVENTORY":
                    newDataTable = inventoryConverter(data);
                    break;

                case "ITEM":
                    newDataTable = itemConverter(data);
                    break;

                case "PRODUCT":
                    newDataTable = productConverter(data);
                    break;

                case "WAREHOUSE":
                    newDataTable = warehouseConverter(data);
                    break;

                default:
                    newDataTable = null;
                    break;
            }
            return newDataTable;
        }

        /*
        *	NAME	:	ConvertToInventoryTable
        *	PURPOSE	:	This method will take the inventory data and put it in a DataTable
        *	            string data - the ascii response data from the DataServer
        *	RETURNS	:	DataTable dataTable - the return data formatted as DataTable
        */

        private static DataTable ConvertToInventoryTable(string data)
        {
            DataTable inventoryTable = new DataTable();

            inventoryTable.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("ItemID", typeof(string)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("WarehouseCity", typeof(string)),
                    new DataColumn("WarehouseID",typeof(string)) });

            // Get the records
            string[] records = ParseData(data);

            // Add the records to the DataTable
            for (int i = 0; i < records.Length - 1; i++)
            {
                // Get the fields
                string[] fields = records[i].Split(',');
                string itemID = fields[0];
                string productName = fields[1];
                // Validate location, set unassigned if blank
                string location = "";
                if (fields[2] != null && fields[2] != "")
                {
                    location = fields[2];
                }
                else
                {
                    location = "Unassigned";
                }
                // Get warehouseID
                string warehouseID = fields[3];

                // Add the fields to the row
                inventoryTable.Rows.Add(itemID, productName, location, warehouseID);
            }

            return inventoryTable;
        }

        /*
        *	NAME	:	ConvertToItemTable
        *	PURPOSE	:	This method will take the item data and put it in a DataTable
        *	            string data - the ascii response data from the DataServer
        *	RETURNS	:	DataTable dataTable - the return data formatted as DataTable
        */

        private static DataTable ConvertToItemTable(string data)
        {
            DataTable itemTable = new DataTable();
            itemTable.Columns.AddRange(new DataColumn[6] {
                    new DataColumn("ItemID", typeof(string)),
                    new DataColumn("ProductID", typeof(string)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("IsAssigned",typeof(string)),
                    new DataColumn("WarehouseID", typeof(string)),
                    new DataColumn("IsSold", typeof(string)) });

            // Get the records
            string[] records = ParseData(data);

            // Add the records to the DataTable
            for (int i = 0; i < records.Length - 1; i++)
            {
                // Get the fields
                string[] fields = records[i].Split(',');
                string itemID = fields[0];
                string productID = fields[1];
                string productName = fields[2];
                string isAssigned = fields[3];
                string warehouseID = fields[4];
                string isSold = fields[5];

                // Convert assigned status for display
                if (isAssigned == "0")
                {
                    isAssigned = "Not Assigned";
                }
                else
                {
                    isAssigned = "Assigned";
                }

                // Convert sold status for display
                if (isSold == "0")
                {
                    isSold = "Available";
                }
                else
                {
                    isSold = "Sold";
                }

                // Add the fields to the row
                itemTable.Rows.Add(itemID, productID, productName, isAssigned, warehouseID, isSold);
            }
            return itemTable;
        }

        /*
        *	NAME	:	ConvertToProductTable
        *	PURPOSE	:	This method will take the product data and put it in a DataTable
        *	            string data - the ascii response data from the DataServer
        *	RETURNS	:	DataTable dataTable - the return data formatted as DataTable
        */

        private static DataTable ConvertToProductTable(string data)
        {
            DataTable productTable = new DataTable();

            productTable.Columns.AddRange(new DataColumn[3] {
                    new DataColumn("ProductID", typeof(string)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("IsActive",typeof(string))});

            // Get the records
            string[] records = ParseData(data);

            // Add the records to the DataTable
            for (int i = 0; i < records.Length - 1; i++)
            {
                // Get the fields
                string[] fields = records[i].Split(',');
                string productID = fields[0];
                string productName = fields[1];
                string activeStatus = fields[2];

                // Convert active status for display
                if (activeStatus == "0")
                {
                    activeStatus = "Discontinued";
                }
                else
                {
                    activeStatus = "Active";
                }

                // Add the fields to the row
                productTable.Rows.Add(productID, productName, activeStatus);
            }
            return productTable;
        }

        /*
        *	NAME	:	ConvertToWarehouseTable
        *	PURPOSE	:	This method will take the warehouse data and put it in a DataTable
        *	            string data - the ascii response data from the DataServer
        *	RETURNS	:	DataTable dataTable - the return data formatted as DataTable
        */

        private static DataTable ConvertToWarehouseTable(string data)
        {
            DataTable warehouseTable = new DataTable();

            warehouseTable.Columns.AddRange(new DataColumn[7] {
                    new DataColumn("WarehouseID", typeof(string)),
                    new DataColumn("StreetAndNo", typeof(string)),
                    new DataColumn("City",typeof(string)),
                    new DataColumn("ProvinceOrState", typeof(string)),
                    new DataColumn("Country", typeof(string)),
                    new DataColumn("PostalCode", typeof(string)),
                    new DataColumn("IsActive", typeof(string)),});

            // Get the records
            string[] records = ParseData(data);

            // Add the records to the DataTable
            for (int i = 0; i < records.Length - 1; i++)
            {
                // Get the fields
                string[] fields = records[i].Split(',');
                string warehouseID = fields[0];
                string streetAndNo = fields[1];
                string provinceOrState = fields[2];
                string city = fields[3];
                string country = fields[4];
                string postalCode = fields[5];
                string isActive = fields[6];

                // Convert active status for display
                if (isActive == "0")
                {
                    isActive = "Closed";
                }
                else
                {
                    isActive = "Operating";
                }

                // Add the fields to the row
                warehouseTable.Rows.Add(warehouseID, streetAndNo, provinceOrState, city, country, postalCode, isActive);
            }

            return warehouseTable;
        }

        /*
        *	NAME	:	ParseData
        *	PURPOSE	:	This method parse the individual table records
        *	            string data - the ascii response data from the DataServer
        *	RETURNS	:	string[] records - an array of record rows
        */

        private static string[] ParseData(string data)
        {
            string[] records = data.Split('&');
            return records;
        }
    }
}
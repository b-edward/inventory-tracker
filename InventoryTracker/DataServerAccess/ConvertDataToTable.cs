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

        // Select a table converter based on first parameter
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


        // Convert to Inventory report
        private static DataTable ConvertToInventoryTable(string data)
        {
            DataTable inventoryTable = new DataTable();

            inventoryTable.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("ItemID", typeof(int)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("WarehouseCity", typeof(string)),
                    new DataColumn("WarehouseID",typeof(int)) });

            // Get the records
            string[] records = ParseData(data);

            // Add the records to the DataTable
            for (int i = 0; i < records.Length - 1; i++)
            {
                // Get the fields
                string[] fields = records[i].Split(',');
                int itemID = int.Parse(fields[0]);
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
                // Validate warehouse ID, set 0 if unassigned
                bool warehouseOK = int.TryParse(fields[3], out int warehouseID);
                if (!warehouseOK)
                {
                    warehouseID = 0;
                }
                // Add the fields to the row
                inventoryTable.Rows.Add(itemID, productName, location, warehouseID);
            }

            return inventoryTable;
        }



        // Convert to Item report
        private static DataTable ConvertToItemTable(string data)
        {
            DataTable itemTable = new DataTable();
            itemTable.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("ItemID", typeof(int)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("IsAssigned",typeof(string)),
                    new DataColumn("IsSold", typeof(string)) });

            // Get the records
            string[] records = ParseData(data);

            // Add the records to the DataTable
            for (int i = 0; i < records.Length - 1; i++)
            {
                // Get the fields
                string[] fields = records[i].Split(',');
                int itemID = int.Parse(fields[0]);
                string productName = fields[1];
                string isAssigned = fields[2];
                string isSold = fields[3];

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
                itemTable.Rows.Add(itemID, productName, isAssigned, isSold);
            }
            return itemTable;
        }


        // Convert to Product report
        private static DataTable ConvertToProductTable(string data)
        {
            DataTable productTable = new DataTable();

            productTable.Columns.AddRange(new DataColumn[3] {
                    new DataColumn("ProductID", typeof(int)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("IsActive",typeof(string))});

            // Get the records
            string[] records = ParseData(data);

            // Add the records to the DataTable
            for (int i = 0; i < records.Length - 1; i++)
            {
                // Get the fields
                string[] fields = records[i].Split(',');
                int productID = int.Parse(fields[0]);
                string productName = fields[1];
                string activeStatus = fields[2];

                // Convert active status for display
                if(activeStatus == "0")
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

        // Convert to Warehouse report
        private static DataTable ConvertToWarehouseTable(string data)
        {
            DataTable warehouseTable = new DataTable();
            return warehouseTable;
        }


        private static string[] ParseData(string data)
        {
            string[] records = data.Split('&');
            return records;
        }
    }
}
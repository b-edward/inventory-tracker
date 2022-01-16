using System.Data;

namespace InventoryTracker.DataServerAccess
{
    public class ConvertDataToTable
    {
        // Take the server's return data string to fill out a data table
        public static DataTable GetInventoryTable(string data)
        {
            DataTable inventoryTable = new DataTable();

            inventoryTable.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("ItemId", typeof(int)),
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

        private static string[] ParseData(string data)
        {
            string[] records = data.Split('&');
            return records;
        }
    }
}
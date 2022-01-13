using InventoryTracker.DataServerAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryTracker
{
    public partial class startPage : System.Web.UI.Page
    {
        ServerHandler serverHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeTracker();
        }        

        protected void InitializeTracker()
        {
            serverHandler = new ServerHandler();

            DataTable inventoryTable = new DataTable();
            inventoryTable.Columns.AddRange(new DataColumn[4] { 
                    new DataColumn("ItemId", typeof(int)),
                    new DataColumn("ProductId", typeof(int)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("WarehouseLocation",typeof(string)) });
            inventoryTable.Rows.Add(1, 1, "Rice", "Waterloo");
            inventoryTable.Rows.Add(2, 4, "Tea", "Tokyo");
            inventoryTable.Rows.Add(3, 3, "Noodles", "Toronto");
            inventoryTable.Rows.Add(2, 1, "Rice", "Hamilton");
            gvInventory.DataSource = inventoryTable;
            gvInventory.DataBind();

            DataTable productTable = new DataTable();
            productTable.Columns.AddRange(new DataColumn[3] {
                    new DataColumn("ProductId", typeof(int)),
                    new DataColumn("ProductName", typeof(string)),
                    new DataColumn("IsActive",typeof(string)) });
            productTable.Rows.Add(1, "Rice", "Active");
            productTable.Rows.Add(2, "Tea", "Active");
            productTable.Rows.Add(3, "Noodles", "Not Active");
            gvProduct.DataSource = productTable;
            gvProduct.DataBind();
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            //txtOutput.Text = serverHandler.SendToServer("GET\nSELECT * FROM `Product`;");
        }

        protected void GetWarehouses(object sender, EventArgs e)
        {
            
        }
    }
}

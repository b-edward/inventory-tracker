using InventoryTracker.Controllers;
using InventoryTracker.DataServerAccess;
using InventoryTracker.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace InventoryTracker
{
    public partial class startPage : System.Web.UI.Page
    {
        IReadController readController;
        IEditController editController;
        HtmlControl htmlControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            readController = new ReadController();
            editController = new EditController();
            InitializeTracker();
        }        

        protected void InitializeTracker()
        {
            // Stub data for display


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

            DataTable itemTable = new DataTable();
            itemTable.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("ItemId", typeof(int)),
                    new DataColumn("ProductId", typeof(int)),
                    new DataColumn("IsSold", typeof(int)),
                    new DataColumn("WarehouseID",typeof(int)) });
            itemTable.Rows.Add(1, 1, 0, 2);
            itemTable.Rows.Add(2, 2, 1, 3);
            itemTable.Rows.Add(3, 2, 1, 1);
            gvItem.DataSource = itemTable;
            gvItem.DataBind();

            DataTable warehouseTable = new DataTable();
            warehouseTable.Columns.AddRange(new DataColumn[7] {
                    new DataColumn("WarehouseID", typeof(int)),
                    new DataColumn("StreetAndNo", typeof(string)),
                    new DataColumn("City", typeof(string)),
                    new DataColumn("ProvinceOrState", typeof(string)),
                    new DataColumn("Country", typeof(string)),
                    new DataColumn("PostalCode", typeof(string)),
                    new DataColumn("IsActive",typeof(string)) });
            warehouseTable.Rows.Add(1, "13 Street", "Hamilton", "ON", "Canada", "L8S 4K1", 1);
            warehouseTable.Rows.Add(2, "45 Main Street", "New York", "NY", "USA", "42871", 1);
            warehouseTable.Rows.Add(3, "787 University Ave", "Waterloo", "ON", "Canada", "N83 4E1", 1);
            gvWarehouse.DataSource = warehouseTable;
            gvWarehouse.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // Get the inventory data table
            DataTable inventoryTable = readController.GetInventory();
            gvInventory.DataSource = inventoryTable;
            gvInventory.DataBind();

            // Get the viewInventory div and display i
            HideDisplay();
            htmlControl = FindControl("viewInventory") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Inventory";
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            HideDisplay();

            // Get the navTables div and display it
            DisplayNavTables();
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            HideDisplay();

            // Get the editProduct div and display it
            htmlControl = FindControl("editProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Get the submitButtons div and display it
            DisplaySubmitButtons();
            // Keep the navTables div displayed
            DisplayNavTables();

            // Read Product table and display it
            htmlControl = FindControl("viewProducts") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Products";
        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            HideDisplay();

            // Get the editItem div and display it
            htmlControl = FindControl("editItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Get the submitButtons div and display it
            DisplaySubmitButtons();
            // Keep the navTables div displayed
            DisplayNavTables();

            // Read Item table and display it
            htmlControl = FindControl("viewItems") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Items";
        }

        protected void btnWarehouse_Click(object sender, EventArgs e)
        {
            HideDisplay();

            // Get the editWarehouse div and display it
            htmlControl = FindControl("editWarehouse") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Get the submitButtons div and display it
            DisplaySubmitButtons();
            // Keep the navTables div displayed
            DisplayNavTables();

            // Read Warehouse table and display it
            htmlControl = FindControl("viewWarehouses") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Warehouses";
        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            // Get the form input data

            // Send create request to server
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            // Get the form input data

            // Send update/delete request to server
        }


        // Display navTables
        protected void DisplayNavTables()
        {
            // Get the navTables div and display it
            htmlControl = FindControl("navTables") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
        }

        // Display submitButtons
        protected void DisplaySubmitButtons()
        {
            // Get the submitButtons div and display it
            htmlControl = FindControl("submitButtons") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
        }

        // Hide all tables
        protected void HideDisplay()
        {
            // Get the navTables div and hide it
            htmlControl = FindControl("navTables") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            // Get the editProduct div and hide it
            htmlControl = FindControl("editProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            // Get the editItem div and hide it
            htmlControl = FindControl("editItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            // Get the editWarehouse div and hide it
            htmlControl = FindControl("editWarehouse") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            // Get the submitButtons div and hide it
            htmlControl = FindControl("submitButtons") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            // Get the viewInventory div and hide it
            htmlControl = FindControl("viewInventory") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            // Get the viewProducts div and hide it
            htmlControl = FindControl("viewProducts") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            // Get the viewItems div and hide it
            htmlControl = FindControl("viewItems") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            // Get the viewWarehouses div and hide it
            htmlControl = FindControl("viewWarehouses") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            // Clear the table title
            lblTableTitle.Text = "";
        }
    }
}

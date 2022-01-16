using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using System;
using System.Data;
using System.Web.UI.HtmlControls;

namespace InventoryTracker
{
    public partial class startPage : System.Web.UI.Page
    {
        private IReadController readController;
        private IEditController editController;
        private HtmlControl htmlControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            readController = new ReadController();
            editController = new EditController();
            DisplayInventory();
        }

        protected void DisplayInventory()
        {
            // Get the inventory data table
            DataTable inventoryTable = readController.GetInventory();
            gvInventory.DataSource = inventoryTable;
            gvInventory.DataBind();

            // Get the viewInventory div and display it
            HideDisplay();
            htmlControl = FindControl("viewInventory") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Inventory";
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            DisplayInventory();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            HideDisplay();

            // Get the navTables div and display it
            DisplayNavTables();
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();

            // Display edit product form
            htmlControl = FindControl("editProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            DisplaySubmitButtons();
            DisplayNavTables();

            // Get the Product data table and fill viewProducts
            DataTable productTable = readController.GetTable("Product");
            gvProduct.DataSource = productTable;
            gvProduct.DataBind();

            // Get the viewProducts div and display it
            htmlControl = FindControl("viewProducts") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Products";
        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();

            // Display edit item form
            htmlControl = FindControl("editItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            DisplaySubmitButtons();
            DisplayNavTables();

            // Get the item data table and fill viewItems
            DataTable itemTable = readController.GetTable("Item");
            gvItem.DataSource = itemTable;
            gvItem.DataBind();

            // Get the viewItems div and display it
            htmlControl = FindControl("viewItems") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Items";
        }

        protected void btnWarehouse_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();

            // Display edit warehouse form
            htmlControl = FindControl("editWarehouse") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            DisplaySubmitButtons();
            DisplayNavTables();

            // Get the warehouse data table and fill 
            DataTable warehouseTable = readController.GetTable("Warehouse");
            gvWarehouse.DataSource = warehouseTable;
            gvWarehouse.DataBind();

            // Get Warehouse div and display it
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
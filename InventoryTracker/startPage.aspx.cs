using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
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

        // Constants for db execute commands
        const string ADD = "PUT";
        const string EDIT = "POST";
        const string DELETE = "DELETE";

        protected void Page_Load(object sender, EventArgs e)
        {
            readController = new ReadController();
            editController = new EditController();
            DisplayInventory();
        }

        protected void DisplayInventory()
        {
            // Get the inventory data table
            DataTable inventoryTable = readController.GetTable("Inventory");

            // Check table is not null, update lblServerMessage if error


            gvInventory.DataSource = inventoryTable;
            gvInventory.DataBind();

            // Get the viewInventory div and display it
            HideDisplay();
            htmlControl = FindControl("viewInventory") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Inventory";
            lblTableNote.Text = "Note: To delete an item from inventory, edit item availability to 'sold'.";
        }

        protected void ClearInputs()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";

        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            HideDisplay();
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
            ClearInputs();

            // Display edit product form
            htmlControl = FindControl("editProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            lblTableNote.Text = "Note: A product is a type of item, for example 'Snowboard'";
            DisplayProductButtons();
            DisplayNavTables();

            // Get the Product data table and fill viewProducts
            DataTable productTable = readController.GetTable("Product");

            // Check table is not null, update lblServerMessage if error


            gvProduct.DataSource = productTable;
            gvProduct.DataBind();

            // Get the viewProducts div and display it
            htmlControl = FindControl("viewProducts") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Product";
            // Track which table is being edited
            lblCurrentEditTable.Text = "product";
        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();
            ClearInputs();

            // Display edit item form
            htmlControl = FindControl("editItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            lblTableNote.Text = "Notes: An item is an individual unit of a product, for example 'Item #2006', which could be " +
                                "one of many Snowboards. Items may be assigned to a warehouse, or may be left unassigned. " +
                                "Sold items are no long shown in the Inventory table.";
            DisplayItemButtons();
            DisplayNavTables();

            // Get the item data table and fill viewItems
            DataTable itemTable = readController.GetTable("Item");

            // Check table is not null, update lblServerMessage if error


            gvItem.DataSource = itemTable;
            gvItem.DataBind();

            // Get the viewItems div and display it
            htmlControl = FindControl("viewItems") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Item";
            // Track which table is being edited
            lblCurrentEditTable.Text = "item";
        }

        protected void btnWarehouse_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();
            ClearInputs();

            // Display edit warehouse form
            htmlControl = FindControl("editWarehouse") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            lblTableNote.Text = "";
            DisplayWarehouseButtons();
            DisplayNavTables();

            // Get the warehouse data table and fill 
            DataTable warehouseTable = readController.GetTable("Warehouse");

            // Check table is not null, update lblServerMessage if error


            gvWarehouse.DataSource = warehouseTable;
            gvWarehouse.DataBind();

            // Get Warehouse div and display it
            htmlControl = FindControl("viewWarehouses") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Update the table title
            lblTableTitle.Text = "Warehouse";
            // Track which table is being edited
            lblCurrentEditTable.Text = "warehouse";
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            // Get the form input data
            Object modelToAdd = GetModel();

            if(modelToAdd != null)
            {

                // For ITEMS, if warehouseID provided, must also send warehouseItem to add

                // Send create request to server
                string serverResponse = editController.ExecuteCUD(modelToAdd, ADD, lblCurrentEditTable.Text);
                lblServerMessage.Text = serverResponse;
            }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            // Get the form input data
            Object modelToAdd = GetModel();

            if (modelToAdd != null)
            {
                // For ITEMS, if warehouseID provided, must also send warehouseItem to add OR edit

                // Send update/delete request(s) to server
                string serverResponse = editController.ExecuteCUD(modelToAdd, EDIT, lblCurrentEditTable.Text);
                lblServerMessage.Text = serverResponse;
            }


        }


        // Select a table model to be used and then use input form to fill it
        protected Object GetModel()
        {
            Object newModel = null;

            // Switch to select the model
            switch (lblCurrentEditTable.Text.ToUpper())
            {
                case "ITEM":
                    newModel = GetItem();
                    break;
                case "PRODUCT":
                    newModel = GetProduct();
                    break;
                case "WAREHOUSE":
                    newModel = GetWarehouse();
                    break;
            }
            return newModel;
        }

        protected Object GetProduct()
        {
            Product newProduct = new Product();

            // Validate product ID
            bool isInt = int.TryParse(txtProductID.Text, out int id);
            if(isInt && id > 0)
            {
                // Set the product ID
                newProduct.ProductID = txtProductID.Text;
            }
            else
            {
                newProduct.ProductID = "";
            }

            // Set the product name
            newProduct.ProductName = txtProductName.Text;

            // Set the isActive field
            if (ddlProductActive.SelectedValue != "0")
            {
                // Convert active to tiny int true
                newProduct.IsActive = 1;
            }
            else
            {
                newProduct.IsActive = 0;
            }
            return newProduct;
        }

        protected Object GetItem()
        {
            IModel newItem = new Item();


            return newItem;
        }

        protected IModel GetWarehouse()
        {
            IModel newWarehouse = new Warehouse();


            return newWarehouse;
        }

        protected IModel GetWarehouseItem()
        {
            IModel newWarehouseItem = new WarehouseItem();


            return newWarehouseItem;
        }

        // Display navTables
        protected void DisplayNavTables()
        {
            // Get the navTables div and display it
            htmlControl = FindControl("navTables") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
        }

        // Display product buttons
        protected void DisplayProductButtons()
        {
            htmlControl = FindControl("submitProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
        }

        // Display item buttons
        protected void DisplayItemButtons()
        {
            htmlControl = FindControl("submitItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
        }

        // Display warehouse buttons
        protected void DisplayWarehouseButtons()
        {
            htmlControl = FindControl("submitWarehouse") as HtmlControl;
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
            // Get the submit buttons and hide them
            htmlControl = FindControl("submitProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            htmlControl = FindControl("submitItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:none;";
            htmlControl = FindControl("submitWarehouse") as HtmlControl;
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
            // Clear the labels
            lblTableTitle.Text = "";
            lblServerMessage.Text = "";            
        }
    }


}
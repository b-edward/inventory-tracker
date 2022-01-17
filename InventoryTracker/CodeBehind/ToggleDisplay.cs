using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace InventoryTracker
{
    public partial class startPage
    {

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
            ddlProductActive.SelectedValue = "";
            txtItemId.Text = "";
            txtProductIDItems.Text = "";
            txtWarehouseIDItems.Text = "";
            ddlIsSold.SelectedValue = "";
            txtWarehouseID.Text = "";
            txtStreetAndNo.Text = "";
            txtCity.Text = "";
            txtProvinceOrState.Text = "";
            txtCountry.Text = "";
            txtPostalCode.Text = "";
            ddlWarehouseActive.SelectedValue = "";
        }


        // Display navTables
        protected void DisplayNavTables()
        {
            // Get the navTables div and display it
            htmlControl = FindControl("navTables") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
        }


        // Reload the editing screen
        protected void ReloadEditScreen()
        {
            // Find the screen to display
            switch (lblCurrentEditTable.Text.ToUpper())
            {
                case "PRODUCT":
                    DisplayProductEdit();
                    break;
                case "ITEM":
                    DisplayItemEdit();
                    break;
                case "WAREHOUSE":
                    DisplayWarehouseEdit();
                    break;
                default:
                    // If something went wrong just display inventory
                    DisplayInventory();
                    break;
            }
        }


        protected void DisplayProductEdit()
        {
            // Display product buttons
            htmlControl = FindControl("submitProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Display edit product form
            htmlControl = FindControl("editProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            lblTableNote.Text = "Note: A product is a type of item, for example 'Snowboard'";
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

        protected void DisplayItemEdit()
        {
            // Display item buttons
            htmlControl = FindControl("submitItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";

            // Display edit item form
            htmlControl = FindControl("editItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            lblTableNote.Text = "Notes: An item is an individual unit of a product, for example 'Item #2006', which could be " +
                                "one of many Snowboards. Assign item by entering warehouse ID, or enter 0 to un-assign. " +
                                "Sold items are no long shown in the Inventory table.";
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

        protected void DisplayWarehouseEdit()
        {
            // Display warehouse buttons
            htmlControl = FindControl("submitWarehouse") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";

            // Display edit warehouse form
            htmlControl = FindControl("editWarehouse") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            lblTableNote.Text = "";
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
            lblTableNote.Text = "";
        }
    }
}
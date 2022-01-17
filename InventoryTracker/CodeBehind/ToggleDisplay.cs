/*
 * FILE             : ToggleDisplay.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 16
 * DESCRIPTION      : This file contains part of the code behind. It will handle the hiding and displaying
 *                    of UI components.
 */

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
        /*
        *	NAME	:	DisplayInventory
        *	PURPOSE	:	This method will display the inventory table
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
        protected void DisplayInventory()
        {
            // Get the inventory data table
            DataTable inventoryTable = readController.GetTable("Inventory");

            // Check table is not null, update lblServerMessage if error
            if(inventoryTable != null)
            {
                gvInventory.DataSource = inventoryTable;
                gvInventory.DataBind();
                // Get the viewInventory div and display it
                HideDisplay();
                htmlControl = FindControl("viewInventory") as HtmlControl;
                htmlControl.Attributes["style"] = "display:flex;";
                // Update the table title
                lblTableTitle.Text = "Inventory";
                lblTableNote.Text = "<b>Note:</b><br/>- To delete an item from inventory, edit item availability to 'sold'.";
            }
            else
            {
                lblServerMessage.Text = "Could not retrieve inventory table.";
            }
        }

        /*
        *	NAME	:	ClearInputs
        *	PURPOSE	:	This method will clear all input form fields
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
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


        /*
        *	NAME	:	ClearInputs
        *	PURPOSE	:	This method will display the table navigational buttons
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
        protected void DisplayNavTables()
        {
            // Get the navTables div and display it
            htmlControl = FindControl("navTables") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
        }


        /*
        *	NAME	:	ReloadEditScreen
        *	PURPOSE	:	This method will reload the current editing form to update data
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
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


        /*
        *	NAME	:	DisplayProductEdit
        *	PURPOSE	:	This method will display the product editing form and product table data
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
        protected void DisplayProductEdit()
        {
            // Display product buttons
            htmlControl = FindControl("submitProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            // Display edit product form
            htmlControl = FindControl("editProduct") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            lblTableNote.Text = "<b>Note:</b><br/>- A product is a type of item, for example 'Snowboard'";
            DisplayNavTables();
            // Track which table is being edited
            lblCurrentEditTable.Text = "product";

            // Get the Product data table and fill viewProducts
            DataTable productTable = readController.GetTable("Product");

            // Check table is not null, update lblServerMessage if error
            if (productTable != null)
            {
                gvProduct.DataSource = productTable;
                gvProduct.DataBind();
                // Get the viewProducts div and display it
                htmlControl = FindControl("viewProducts") as HtmlControl;
                htmlControl.Attributes["style"] = "display:flex;";
                // Update the table title
                lblTableTitle.Text = "Product";
            }
            else
            {
                lblServerMessage.Text = "Could not retrieve product table.";
            }
        }

        /*
        *	NAME	:	DisplayItemEdit
        *	PURPOSE	:	This method will display the item editing form and item table data
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
        protected void DisplayItemEdit()
        {
            // Display item buttons
            htmlControl = FindControl("submitItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";

            // Display edit item form
            htmlControl = FindControl("editItem") as HtmlControl;
            htmlControl.Attributes["style"] = "display:flex;";
            lblTableNote.Text = "<b>Note:</b><br/>- An item is an individual unit of a product, for example 'Item #2006', which could be " +
                                "one of many Snowboards.<br/>- Assign item by entering warehouse ID, or enter 0 to un-assign.<br/>" +
                                "- Sold items are no long shown in the Inventory table.";
            DisplayNavTables();
            // Track which table is being edited
            lblCurrentEditTable.Text = "item";

            // Get the item data table and fill viewItems
            DataTable itemTable = readController.GetTable("Item");

            // Check table is not null, update lblServerMessage if error
            if(itemTable != null)
            {
                gvItem.DataSource = itemTable;
                gvItem.DataBind();
                // Get the viewItems div and display it
                htmlControl = FindControl("viewItems") as HtmlControl;
                htmlControl.Attributes["style"] = "display:flex;";
                // Update the table title
                lblTableTitle.Text = "Item";
            }
            else
            {
                lblServerMessage.Text = "Could not retrieve item table.";
            }
        }

        /*
        *	NAME	:	DisplayWarehouseEdit
        *	PURPOSE	:	This method will display the warehouse editing form and warehouse table data
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
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
            // Track which table is being edited
            lblCurrentEditTable.Text = "warehouse";

            // Get the warehouse data table and fill 
            DataTable warehouseTable = readController.GetTable("Warehouse");

            // Check table is not null, update lblServerMessage if error
            if (warehouseTable != null)
            {
                gvWarehouse.DataSource = warehouseTable;
                gvWarehouse.DataBind();
                // Get Warehouse div and display it
                htmlControl = FindControl("viewWarehouses") as HtmlControl;
                htmlControl.Attributes["style"] = "display:flex;";
                // Update the table title
                lblTableTitle.Text = "Warehouse";
            }
            else
            {
                lblServerMessage.Text = "Could not retrieve warehouse table.";
            }

        }


        /*
        *	NAME	:	HideDisplay
        *	PURPOSE	:	This method will hide all display divs and clear labels
        *	INPUTS	:	None
        *	RETURNS	:	None
        */
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
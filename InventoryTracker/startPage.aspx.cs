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
            // Display the inventory if this is the first render of the page
            if(!IsPostBack)
            {
                DisplayInventory();
            }
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
            // Display the product editing screen
            DisplayProductEdit();
        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();
            ClearInputs();
            // Display the item editing screen
            DisplayItemEdit();
        }

        protected void btnWarehouse_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();
            ClearInputs();
            // Display the item editing screen
            DisplayWarehouseEdit();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            // Get the form input data
            Object modelToAdd = GetModel();

            string serverResponse = "";
            if (modelToAdd != null)
            {
                // Send create request to server
                serverResponse = editController.ExecuteCUD(modelToAdd, ADD, lblCurrentEditTable.Text);

                // For ITEMS, if serverResponse 200, if warehouseID provided, must also send warehouseItem to INSERT new 
                if (lblCurrentEditTable.Text == "item" && serverResponse.Contains("200"))
                {
                    // Get the new item ID from the Item table
                    string newItemID = readController.GetNewItemID();

                    // Get the form input data
                    WarehouseItem warehouseItemModel = (WarehouseItem)GetWarehouseItem();
                    // Add the item ID to the model
                    warehouseItemModel.ItemID = newItemID;

                    if(int.Parse(txtWarehouseIDItems.Text) > 0)
                    {
                        // Insert item into WarehouseItem table if it was assigned to warehouse
                        serverResponse = editController.ExecuteCUD(warehouseItemModel, ADD, "warehouseItem");

                        if (serverResponse.Contains("200"))
                        {
                            serverResponse = "Item updated successfully.";
                        }
                        else
                        {
                            serverResponse = "Something went wrong when assigning item to the warehouse.";
                        }
                    }
                }
            }
            // Reload the editing screen
            ReloadEditScreen();
            lblServerMessage.Text = serverResponse;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the form input data
            Object modelToAdd = GetModel();

            string serverResponse = "";
            if (modelToAdd != null)
            {
                // Send update/delete request(s) to server
                serverResponse = editController.ExecuteCUD(modelToAdd, EDIT, lblCurrentEditTable.Text);

                // For ITEMS, if serverResponse 200, if warehouseID provided, must also send warehouseItem to UPDATE existing
                if(lblCurrentEditTable.Text == "item" && serverResponse.Contains("200"))
                {
                    // Get the form input data
                    modelToAdd = GetWarehouseItem();

                    if(ddlIsSold.SelectedValue == "1")
                    {
                        // Delete if warehouseItem sold
                        serverResponse = editController.ExecuteCUD(modelToAdd, DELETE, "warehouseItem");
                        if(serverResponse.Contains("200"))
                        {
                            serverResponse = "Item updated successfully.";
                        }
                        else
                        {
                            serverResponse = "Something went wrong when removing sold item from warehouse inventory.";
                        }
                    }
                    else
                    {
                        // POST if item reassigned
                        serverResponse = editController.ExecuteCUD(modelToAdd, EDIT, "warehouseItem");
                        if (!serverResponse.Contains("200"))
                        {
                            // PUT if warehouseItem was not already in the table
                            serverResponse = editController.ExecuteCUD(modelToAdd, ADD, "warehouseItem");

                            if(serverResponse.Contains("200"))
                            {
                                serverResponse = "Item updated successfully.";
                            }
                            else
                            {
                                serverResponse = "Something went wrong when updating item warehouse assignment.";
                            }
                        }
                        else
                        {
                            serverResponse = "Item updated successfully.";
                        }
                    }
                }
            }
            // Reload the editing screen
            ReloadEditScreen();
            lblServerMessage.Text = serverResponse;
        }
    }
}
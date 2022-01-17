﻿using InventoryTracker.Controllers;
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

                // For ITEMS, if warehouseID provided, must also send warehouseItem to add

                // Send create request to server
                serverResponse = editController.ExecuteCUD(modelToAdd, ADD, lblCurrentEditTable.Text);
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
                // For ITEMS, if warehouseID provided, must also send warehouseItem to add OR edit

                // Send update/delete request(s) to server
                serverResponse = editController.ExecuteCUD(modelToAdd, EDIT, lblCurrentEditTable.Text);
            }
            // Reload the editing screen
            ReloadEditScreen();
            lblServerMessage.Text = serverResponse;
        }
    }
}
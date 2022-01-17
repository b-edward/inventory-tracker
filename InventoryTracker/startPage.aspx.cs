/*
 * FILE             : startPage.aspx.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 08
 * DESCRIPTION      : This file contains the code behind to respond to user button click and page load events. It will
 *                    control the functionality of the application, and utilize various functions in order to send/receive
 *                    information to the DataServer database, and display feedback to the user.
 */

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


        /*
        *	NAME	:	Page_Load
        *	PURPOSE	:	This method will be executed in response to the Page Load event in the page's life cycle.
        *	            It will instantiate controllers for view and edit functionality, and display the inventory.
        *	INPUTS	:	object sender       Reference to the object that triggered the event
        *	            RoutedEventArgs e   The data identifying the event that was raised
        *	RETURNS	:	None
        */
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


        /*
        *	NAME	:	btnView_Click
        *	PURPOSE	:	This method will be executed in response to the btnView_Click event.
        *	            It will hide the edit displays and show the current inventory.
        *	INPUTS	:	object sender       Reference to the object that triggered the event
        *	            RoutedEventArgs e   The data identifying the event that was raised
        *	RETURNS	:	None
        */
        protected void btnView_Click(object sender, EventArgs e)
        {
            HideDisplay();
            DisplayInventory();
        }


        /*
        *	NAME	:	btnEdit_Click
        *	PURPOSE	:	This method will be executed in response to the btnEdit_Click event.
        *	            It will hide the current display and show the navigational buttons for editing.
        *	INPUTS	:	object sender       Reference to the object that triggered the event
        *	            RoutedEventArgs e   The data identifying the event that was raised
        *	RETURNS	:	None
        */
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            HideDisplay();
            // Get the navTables div and display it
            DisplayNavTables();
        }


        /*
        *	NAME	:	btnProduct_Click
        *	PURPOSE	:	This method will be executed in response to the btnProduct_Click event.
        *	            It will hide the current display, clear inputs fields, display the product records, and
        *	            display the product editing form.
        *	INPUTS	:	object sender       Reference to the object that triggered the event
        *	            RoutedEventArgs e   The data identifying the event that was raised
        *	RETURNS	:	None
        */
        protected void btnProduct_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();
            ClearInputs();
            // Display the product editing screen
            DisplayProductEdit();
        }

        /*
        *	NAME	:	btnItem_Click
        *	PURPOSE	:	This method will be executed in response to the btnItem_Click event.
        *	            It will hide the current display, clear inputs fields, display the item records, and
        *	            display the item editing form.
        *	INPUTS	:	object sender       Reference to the object that triggered the event
        *	            RoutedEventArgs e   The data identifying the event that was raised
        *	RETURNS	:	None
        */
        protected void btnItem_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();
            ClearInputs();
            // Display the item editing screen
            DisplayItemEdit();
        }


        /*
        *	NAME	:	btnWarehouse_Click
        *	PURPOSE	:	This method will be executed in response to the btnWarehouse_Click event.
        *	            It will hide the current display, clear inputs fields, display the warehouse records, and
        *	            display the warehouse editing form.
        *	INPUTS	:	object sender       Reference to the object that triggered the event
        *	            RoutedEventArgs e   The data identifying the event that was raised
        *	RETURNS	:	None
        */
        protected void btnWarehouse_Click(object sender, EventArgs e)
        {
            // Reset the display
            HideDisplay();
            ClearInputs();
            // Display the item editing screen
            DisplayWarehouseEdit();
        }


        /*
        *	NAME	:	btnAddNew_Click
        *	PURPOSE	:	This method will be executed in response to the btnAddNew_Click event. It will take the
        *	            user's input data and send a create request to the data server.
        *	INPUTS	:	object sender       Reference to the object that triggered the event
        *	            RoutedEventArgs e   The data identifying the event that was raised
        *	RETURNS	:	None
        */
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
                    serverResponse = AssignItemAdd();
                }
            }
            // Reload the editing screen
            ReloadEditScreen();
            lblServerMessage.Text = serverResponse;
        }


        /*
        *	NAME	:	btnUpdate_Click
        *	PURPOSE	:	This method will be executed in response to the btnUpdate_Click event. It will take the
        *	            user's input data and send a post request to the data server.
        *	INPUTS	:	object sender       Reference to the object that triggered the event
        *	            RoutedEventArgs e   The data identifying the event that was raised
        *	RETURNS	:	None
        */
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
                    serverResponse = AssignItemEdit(modelToAdd);
                }
            }
            // Reload the editing screen
            ReloadEditScreen();
            lblServerMessage.Text = serverResponse;
        }
    }
}
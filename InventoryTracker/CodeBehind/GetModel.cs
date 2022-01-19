/*
 * FILE             : GetModel.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 16
 * DESCRIPTION      : This file contains part of the code behind. It will take user input form data, and save it
 *                    in a table model for use by the server.
 */

using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using System;

namespace InventoryTracker
{
    public partial class startPage
    {
        /*
        *	NAME	:	GetModel
        *	PURPOSE	:	This method will select a model to be used and call a method to fill it
        *	INPUTS	:	None
        *	RETURNS	:	Object newModel - the selected model with the user input data
        */

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

        /*
        *	NAME	:	GetProduct
        *	PURPOSE	:	This method will get user input and fill out a product model class
        *	INPUTS	:	None
        *	RETURNS	:	Product newProduct - the product model with the user input data
        */

        protected Object GetProduct()
        {
            Product newProduct = new Product();

            // Validate product ID
            bool isInt = int.TryParse(txtProductID.Text, out int id);
            if (isInt && id > 0)
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

        /*
        *	NAME	:	GetItem
        *	PURPOSE	:	This method will get user input and fill out an item model class
        *	INPUTS	:	None
        *	RETURNS	:	Product newItem - the item model with the user input data
        */

        protected Object GetItem()
        {
            Item newItem = new Item();

            // Validate item ID
            bool isInt = int.TryParse(txtItemId.Text, out int itemID);
            if (isInt && itemID > 0)
            {
                // Set the item ID
                newItem.ItemID = txtItemId.Text;
            }
            else
            {
                newItem.ItemID = "";
            }

            // Set the product name
            newItem.ProductID = txtProductIDItems.Text;

            // Set the isAssigned field (warehouse ID)
            isInt = int.TryParse(txtWarehouseIDItems.Text, out int warehouseID);
            if (isInt && warehouseID > 0)
            {
                // Convert active to tiny int true
                newItem.IsAssigned = 1;
            }
            else if (warehouseID == 0)
            {
                newItem.IsAssigned = 0;
            }

            // Set the isSold field
            if (ddlIsSold.SelectedValue == "1")
            {
                // Convert active to tiny int true
                newItem.IsSold = 1;
                // If sold, un-assign it
                newItem.IsAssigned = 0;
            }
            else
            {
                newItem.IsSold = 0;
            }
            return newItem;
        }

        /*
        *	NAME	:	GetWarehouse
        *	PURPOSE	:	This method will get user input and fill out a warehouse model class
        *	INPUTS	:	None
        *	RETURNS	:	Product newWarehouse - the warehouse model with the user input data
        */

        protected Object GetWarehouse()
        {
            ILocation newWarehouse = new Warehouse();

            // Validate warehouse ID
            bool isInt = int.TryParse(txtWarehouseID.Text, out int id);
            if (isInt && id > 0)
            {
                // Set the product ID
                newWarehouse.ID = txtWarehouseID.Text;
            }
            else
            {
                newWarehouse.ID = "";
            }

            // Set the atomized address fields
            newWarehouse.StreetAndNo = txtStreetAndNo.Text;
            newWarehouse.City = txtCity.Text;
            newWarehouse.ProvinceOrState = txtProvinceOrState.Text;
            newWarehouse.Country = txtCountry.Text;
            newWarehouse.PostalCode = txtPostalCode.Text;

            // Set the isActive field
            if (ddlWarehouseActive.SelectedValue != "0")
            {
                // Convert active to tiny int true
                newWarehouse.IsActive = 1;
            }
            else
            {
                newWarehouse.IsActive = 0;
            }
            return newWarehouse;
        }

        /*
        *	NAME	:	GetWarehouseItem
        *	PURPOSE	:	This method will get user input and fill out a warehouseItem model class
        *	INPUTS	:	None
        *	RETURNS	:	WarehouseItem newWarehouseItem - the warehouseItem model with the user input data
        */

        protected Object GetWarehouseItem()
        {
            WarehouseItem newWarehouseItem = new WarehouseItem();

            // Validate item ID
            bool isInt = int.TryParse(txtItemId.Text, out int itemID);
            if (isInt && itemID > 0)
            {
                // Set the item ID
                newWarehouseItem.ItemID = txtItemId.Text;
            }
            else
            {
                newWarehouseItem.ItemID = "";
            }

            // Validate the warehouse ID
            isInt = int.TryParse(txtWarehouseIDItems.Text, out int warehouseID);
            if (isInt && warehouseID > 0)
            {
                // Set the warehouse ID
                newWarehouseItem.WarehouseItemID = txtWarehouseIDItems.Text;
            }
            else
            {
                newWarehouseItem.WarehouseItemID = "";
            }

            return newWarehouseItem;
        }
    }
}
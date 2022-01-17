using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker
{
    public partial class startPage
    {
        protected string AssignItemAdd()
        {
            string serverResponse = "";

            // Get the new item ID from the Item table
            string newItemID = readController.GetNewItemID();

            // Get the form input data
            WarehouseItem warehouseItemModel = (WarehouseItem)GetWarehouseItem();
            // Add the item ID to the model
            warehouseItemModel.ItemID = newItemID;

            if (int.Parse(txtWarehouseIDItems.Text) > 0)
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
            return serverResponse;
        }



        protected string AssignItemEdit(Object modelToAdd)
        {
            string serverResponse = "";

            // Get the form input data
            modelToAdd = GetWarehouseItem();

            if (ddlIsSold.SelectedValue == "1" || txtWarehouseIDItems.Text == "0")
            {
                // Delete if warehouseItem sold
                serverResponse = editController.ExecuteCUD(modelToAdd, DELETE, "warehouseItem");
                if (serverResponse.Contains("200"))
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

                    if (serverResponse.Contains("200"))
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
            return serverResponse;
        }
    }
}
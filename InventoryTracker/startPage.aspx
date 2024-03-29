﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startPage.aspx.cs" Inherits="InventoryTracker.startPage" %>

<!DOCTYPE html>

<!--
    FILE            : startPage.aspx
    PROJECT         : Inventory Tracker
    PROGRAMMERS     : Edward Boado
    FIRST VERSION   : 2022-01-08
    DESCRIPTION     : This file contains the default ASP.NET page for the inventory tracker web application. It provides a user interface
                      allowing the viewing of unsold inventory. The user may also view, or edit products, items, and warehouses. In addition,
                      the user can assign (or un-assign) items to warehouses, which will add or update them in the warehouse inventory. Items
                      that are sold are removed from the inventory.
-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="Scripts/InputValidation.js"></script>
    <style type="text/css">
        .centre-div {
            justify-content: center;
            margin: 20px;
        }
    </style>
    <title>EB Logistics Corp.</title>
</head>
<body style="background: #5E8E3E; padding: 1%;">
    <form id="mainUI" runat="server" style="display: flex; justify-content: center; background: white;">
        <div>
            <div class="nav" style="display: flex; justify-content: center;">
                <h1 style="color: #5E8E3E; font-weight: bolder;">Inventory Tracking Application</h1>
            </div>
            <!-- Main Navigation -->
            <div id="navMain" style="display: flex; justify-content: center; margin: 20px;">
                <table>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnView" runat="server" Text="View Inventory" ToolTip="View all unsold items" Width="150px" OnClick="btnView_Click" /></td>
                        <td></td>
                        <td>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit Inventory" ToolTip="Edit inventory tables" Width="150px" OnClick="btnEdit_Click" /></td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <!-- Table Navigation -->
            <div id="navTables" class="centre-div" runat="server" style="display: none;">
                <div style="float: left">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnProduct" runat="server" Text="Products" ToolTip="Select a data table to edit" Width="150px" OnClick="btnProduct_Click" /></td>
                            <td></td>
                            <td>
                                <asp:Button ID="btnItem" runat="server" Text="Items" ToolTip="Select a data table to edit" Width="150px" OnClick="btnItem_Click" /></td>
                            <td></td>
                            <td>
                                <asp:Button ID="btnWarehouse" runat="server" Text="Warehouses" ToolTip="Select a data table to edit" Width="150px" OnClick="btnWarehouse_Click" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- Help Button -->
            <div>
                <a href="https://github.com/b-edward/inventory-tracker/blob/main/README.md" target="_blank">
                    <img src="Images/help.png" alt="Help" id="helpButton" style="height: 30px; width: 30px; position: fixed; top: 7%; left: 3%;">
                </a>
            </div>
            <!-- Table title -->
            <div style="display: flex; justify-content: center;">
                <asp:Label ID="lblTableTitle" runat="server" Text="" Font-Bold="True" ForeColor="#5E8E3E" Font-Size="X-Large" Font-Underline="True"></asp:Label>
            </div>
            <!-- Edit Product Form -->
            <div id="editProduct" class="centre-div" runat="server" style="display: none;">
                <div>
                    <table>
                        <tr>
                            <td>Product ID:</td>
                            <td>
                                <asp:TextBox ID="txtProductID" runat="server" ToolTip="Product ID not required for Add New, as database automatically assigns a new ID" Width="100%" /></td>
                            <td>
                        </tr>
                        <tr>
                            <td>Product Name:</td>
                            <td>
                                <asp:TextBox ID="txtProductName" runat="server" ToolTip="Enter the product name" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td>Product Status:</td>
                            <td>
                                <asp:DropDownList ID="ddlProductActive" runat="server">
                                    <asp:ListItem Text=""></asp:ListItem>
                                    <asp:ListItem Text="Discontinued" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- Buttons for submitting Product form -->
                <div id="submitProduct" class="centre-div" runat="server" style="display: none;">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnAddProduct" runat="server" Text="Add New" ToolTip="Create a new product in the database" Width="150px" OnClick="btnAddNew_Click" OnClientClick="if (!validateAddProduct()) {return false;}" UseSubmitBehavior="False" /></td>
                            <td>

                                <asp:Button ID="btnUpdateProduct" runat="server" Text="Update" ToolTip="Update a product currently in the database" Width="150px" OnClick="btnUpdate_Click" OnClientClick="if (!validateEditProduct()) {return false;}" UseSubmitBehavior="False" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- Edit Item Form -->
            <div id="editItem" class="centre-div" runat="server" style="display: none;">
                <div>
                    <table>
                        <tr>
                            <td>Item ID:</td>
                            <td>
                                <asp:TextBox ID="txtItemId" runat="server" ToolTip="Item ID not required for Add New, as database automatically assigns a new ID" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td>Product ID:</td>
                            <td>
                                <asp:TextBox ID="txtProductIDItems" runat="server" ToolTip="Enter a product ID that already exists in the database!" Width="100%" /></td>
                            <td>
                        </tr>
                        <tr>
                            <td>Warehouse ID:</td>
                            <!-- Selecting a location sets item as assigned, and creates a new warehouseItem -->
                            <td>
                                <asp:TextBox ID="txtWarehouseIDItems" runat="server" ToolTip="Enter a warehouseID or 0 to un-assign. Warehouse must already exist in the database!" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td>Availability:</td>
                            <td>
                                <asp:DropDownList ID="ddlIsSold" runat="server" ToolTip="Select 'Sold' will remove this item from the total inventory">
                                    <asp:ListItem Text=""></asp:ListItem>
                                    <asp:ListItem Text="Sold" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Available" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- Buttons for submitting Item form -->
                <div id="submitItem" class="centre-div" runat="server" style="display: none;">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnAddItem" runat="server" Text="Add New" ToolTip="Create a new item in the database" Width="150px" OnClick="btnAddNew_Click" OnClientClick="if (!validateAddItem()) {return false;}" UseSubmitBehavior="False" /></td>
                            <td>

                                <asp:Button ID="btnEditItem" runat="server" Text="Update" ToolTip="Update an item currently in the database" Width="150px" OnClick="btnUpdate_Click" OnClientClick="if (!validateEditItem()) {return false;}" UseSubmitBehavior="False" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- Edit Warehouse Form -->
            <div id="editWarehouse" class="centre-div" runat="server" style="display: none;">
                <div>
                    <table>
                        <tr>
                            <td>Warehouse ID:</td>
                            <td>
                                <asp:TextBox ID="txtWarehouseID" runat="server" ToolTip="Warehouse ID not required for Add New, as database automatically assigns a new ID" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td>Street and Number:</td>
                            <td>
                                <asp:TextBox ID="txtStreetAndNo" runat="server" ToolTip="Enter the street and number" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" ToolTip="Enter the city" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td>Province/State:</td>
                            <td>
                                <asp:TextBox ID="txtProvinceOrState" runat="server" ToolTip="Enter the province or state" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td>Country:</td>
                            <td>
                                <asp:TextBox ID="txtCountry" runat="server" ToolTip="Enter the country" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td>Postal Code:</td>
                            <td>
                                <asp:TextBox ID="txtPostalCode" runat="server" ToolTip="Enter the postal code" Width="100%" /></td>
                        </tr>
                        <tr>
                            <td>Status:</td>
                            <td>
                                <asp:DropDownList ID="ddlWarehouseActive" runat="server">
                                    <asp:ListItem Text=""></asp:ListItem>
                                    <asp:ListItem Text="Closed / Not Active" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Actively Operating" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- Buttons for submitting Warehouse form -->
                <div id="submitWarehouse" class="centre-div" runat="server" style="display: none;">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnAddWarehouse" runat="server" Text="Add New" ToolTip="Create a new warehouse location in the database" Width="150px" OnClick="btnAddNew_Click" OnClientClick="if (!validateAddWarehouse()) {return false;}" UseSubmitBehavior="False" /></td>
                            <td>

                                <asp:Button ID="btnEditWarehouse" runat="server" Text="Update" ToolTip="Update a warehouse currently in the database" Width="150px" OnClick="btnUpdate_Click" OnClientClick="if (!validateEditWarehouse()) {return false;}" UseSubmitBehavior="False" /></td>
                        </tr>
                    </table>
                </div>
            </div>

            <!-- Track current table -->
            <asp:Label ID="lblCurrentEditTable" runat="server" Text="" Visible="False"></asp:Label>

            <!-- Server Response Output -->
            <div style="display: flex; justify-content: center; margin: 15px;">
                <asp:Label ID="lblServerMessage" runat="server" Text="" Font-Bold="True" ForeColor="#0000CC" Font-Size="Large"></asp:Label>
            </div>

            <!-- Display Input Error Message -->
            <div class="error" style="display: flex; justify-content: center;">
                <p id="errorMessage" style="color: red"></p>
            </div>

            <!-- Table note -->
            <div style="display: flex; justify-content: center; margin: 15px">
                <asp:Label ID="lblTableNote" runat="server" Text="" Font-Size="Medium" Width="100%"></asp:Label>
            </div>

            <!-- Display Output -->
            <div class="output">
                <!-- View Inventory -->
                <div id="viewInventory" class="centre-div" runat="server" style="display: flex;">
                    <asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="ItemID" HeaderText="Item ID" ItemStyle-Width="100" />
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-Width="250" />
                            <asp:BoundField DataField="WarehouseCity" HeaderText="Location" ItemStyle-Width="150" />
                            <asp:BoundField DataField="WarehouseID" HeaderText="Warehouse ID" ItemStyle-Width="100" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!-- View Products -->
                <div id="viewProducts" class="centre-div" runat="server" style="display: none;">
                    <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="ProductID" HeaderText="Product ID" ItemStyle-Width="100" />
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-Width="250" />
                            <asp:BoundField DataField="IsActive" HeaderText="Active Status" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!-- View Items -->
                <div id="viewItems" class="centre-div" runat="server" style="display: none;">
                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="ItemID" HeaderText="Item ID" ItemStyle-Width="100" />
                            <asp:BoundField DataField="ProductID" HeaderText="Product ID" ItemStyle-Width="100" />
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-Width="250" />
                            <asp:BoundField DataField="IsAssigned" HeaderText="Assigned To Warehouse" ItemStyle-Width="150" />
                            <asp:BoundField DataField="WarehouseID" HeaderText="Warehouse ID" ItemStyle-Width="100" />
                            <asp:BoundField DataField="IsSold" HeaderText="Availability for Sale" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!-- View Warehouses -->
                <div id="viewWarehouses" class="centre-div" runat="server" style="display: none;">
                    <asp:GridView ID="gvWarehouse" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="WarehouseID" HeaderText="Warehouse ID" ItemStyle-Width="100" />
                            <asp:BoundField DataField="StreetAndNo" HeaderText="Street and Number" ItemStyle-Width="250" />
                            <asp:BoundField DataField="City" HeaderText="City" ItemStyle-Width="150" />
                            <asp:BoundField DataField="ProvinceOrState" HeaderText="Province or State" ItemStyle-Width="150" />
                            <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
                            <asp:BoundField DataField="PostalCode" HeaderText="Postal Code" ItemStyle-Width="150" />
                            <asp:BoundField DataField="IsActive" HeaderText="Operating Status" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
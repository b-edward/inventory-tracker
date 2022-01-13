<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startPage.aspx.cs" Inherits="InventoryTracker.startPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .centre-div {
            justify-content: center; 
            margin: 20px;
        }
    </style>
    <title>EB Logistics Corp.</title>
</head>
<body style="background:#95BF47; padding:1%;">
    <form id="mainUI" runat="server" style="display: flex; justify-content: center; background:white;">
        <div>
            <div class="nav" style="display: flex; justify-content: center;">
            <h1 style="color:#5E8E3E; font-weight:bolder;">Inventory Tracking Application</h1>
        </div>
            <!-- Main Navigation -->
            <div id="navMain" style="display: flex; justify-content: center; margin: 20px;">
                <table >
                    <tr>
                        <td></td>
                        <td><asp:Button ID="btnView" runat="server" Text="View Inventory" Width="150px" OnClick="btnView_Click"/></td>
                        <td></td>
                        <td><asp:Button ID="btnEdit" runat="server" Text="Edit Inventory" Width="150px" OnClick="btnEdit_Click"/></td>
                        <td></td>
                    </tr> 
                </table>
            </div>
            <!-- Table Navigation -->
            <div id="navTables" class="centre-div" runat="server" style="display: none;">
                <table >
                    <tr>
                        <td><asp:Button ID="btnProduct" runat="server" Text="Products" Width="150px" OnClick="btnProduct_Click"/></td>
                        <td></td>
                        <td><asp:Button ID="btnItem" runat="server" Text="Items" Width="150px" OnClick="btnItem_Click"/></td>
                        <td></td>
                        <td><asp:Button ID="btnWarehouse" runat="server" Text="Warehouses" Width="150px" OnClick="btnWarehouse_Click"/></td>
                    </tr> 
                </table>
            </div>
            <!-- Edit Product Form -->
            <div id="editProduct" class="centre-div" runat="server" style="display: none;">
                <table>
                    <tr>           
                        <td>Product ID:</td>
                        <td><asp:TextBox id="txtProductID" runat="server" ToolTip="Enter the product ID" width="100%"/></td>
                    </tr>
                    <tr>
                        <td>Product Name:</td>
                        <td><asp:TextBox id="txtProductName" runat="server" ToolTip="Enter the product name" width="100%"/></td>
                    </tr>
                    <tr>
                        <td>Product Status:</td>
                        <td>                            
                            <asp:DropDownList ID="ddlProductActive" runat="server">                     
                                <asp:listitem text=""></asp:listitem>                      
                                <asp:listitem text="Discontinued" value="0"></asp:listitem>                     
                                <asp:listitem text="Active" value="1"></asp:listitem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>                        
            <!-- Edit Item Form -->
            <div id="editItem" class="centre-div" runat="server" style="display: none;">
                <table>
                    <tr>           
                        <td>Item ID:</td>
                        <td><asp:TextBox id="txtItemId" runat="server" ToolTip="Enter the item ID" width="100%"/></td>
                    </tr>
                    <tr>           
                        <td>Product ID:</td>
                        <td><asp:TextBox id="txtProductIDItems" runat="server" ToolTip="Enter the product ID" width="100%"/></td>
                    </tr>
                    <tr>
                        <td>Warehouse ID (optional):</td>
                        <!-- Selecting a location sets item as assigned, and creates a new warehouseItem -->
                        <td><asp:TextBox id="txtWarehouseIDItems" runat="server" ToolTip="Enter a warehouseID or leave blank if unassigned" width="100%"/></td>
                    </tr>
                    <tr>
                        <td>Availability:</td>
                        <td>                            
                            <asp:DropDownList ID="ddlIsSold" runat="server">                     
                                <asp:listitem text=""></asp:listitem>                      
                                <asp:listitem text="Sold" value="0"></asp:listitem>                     
                                <asp:listitem text="For Sale" value="1"></asp:listitem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>            
            <!-- Edit Warehouse Form -->
            <div id="editWarehouse" class="centre-div" runat="server" style="display: none;">
                <table>
                    <tr>           
                        <td>Warehouse ID:</td>
                        <td><asp:TextBox id="txtWarehouseID" runat="server" ToolTip="Enter the warehouse ID" width="100%"/></td>
                    </tr>
                    <tr>           
                        <td>Street and Number:</td>
                        <td><asp:TextBox id="txtStreetAndNo" runat="server" ToolTip="Enter the street and number" width="100%"/></td>
                    </tr>
                    <tr>
                        <td>City:</td>
                        <td><asp:TextBox id="txtCity" runat="server" ToolTip="Enter the city" width="100%"/></td>
                    </tr>
                    <tr>
                        <td>Province/State:</td>
                        <td><asp:TextBox id="txtProvinceOrState" runat="server" ToolTip="Enter the province or state" width="100%"/></td>
                    </tr>
                    <tr>
                        <td>Country:</td>
                        <td><asp:TextBox id="txtCountry" runat="server" ToolTip="Enter the country" width="100%"/></td>
                    </tr>
                    <tr>
                        <td>Postal Code:</td>
                        <td><asp:TextBox id="txtPostalCode" runat="server" ToolTip="Enter the postal code" width="100%"/></td>
                    </tr>
                    <tr>
                        <td>Status:</td>
                        <td>                            
                            <asp:DropDownList ID="ddlWarehouseActive" runat="server">                     
                                <asp:listitem text=""></asp:listitem>                      
                                <asp:listitem text="Closed / Not Active" value="0"></asp:listitem>                     
                                <asp:listitem text="Actively Operating" value="1"></asp:listitem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- Buttons for submitting forms -->
            <div id="submitButtons" class="centre-div" runat="server" style="display: none;">                                    
                <table>
                    <tr>
                        <td><asp:Button ID="btnAddNew" runat="server" Text="Add New" Width="150px" OnClick="btnAddNew_Click"/></td>
                        <td><asp:Button ID="btnUpdateProduct" runat="server" Text="Update" Width="150px" OnClick="btnUpdateProduct_Click"/></td>
                    </tr>    
                </table>
            </div>

            <!-- Display Output -->
            <div class="output">
                <!-- View Inventory -->
                <div id="viewInventory" class="centre-div" runat="server" style="display: flex;">   
                     <asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="false" >    
                         <Columns>    
                             <asp:BoundField DataField="ItemId" HeaderText="Item ID" ItemStyle-Width="150" />   
                             <asp:BoundField DataField="ProductId" HeaderText="Product ID" ItemStyle-Width="150" />     
                             <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-Width="150" />    
                             <asp:BoundField DataField="WarehouseLocation" HeaderText="WarehouseLocation" ItemStyle-Width="150" />    
                         </Columns>    
                     </asp:GridView>    
                </div>  
                <!-- View Products -->
                <div id="viewProducts" class="centre-div" runat="server" style="display: none;">   
                     <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="false" >    
                         <Columns>     
                             <asp:BoundField DataField="ProductId" HeaderText="Product ID" ItemStyle-Width="150" />     
                             <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-Width="150" />    
                             <asp:BoundField DataField="IsActive" HeaderText="Active" ItemStyle-Width="150" />    
                         </Columns>    
                     </asp:GridView>    
                </div>  
                <!-- View Items -->
                <div id="viewItems" class="centre-div" runat="server" style="display: none;">   
                     <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" >    
                         <Columns>    
                             <asp:BoundField DataField="ItemId" HeaderText="Item ID" ItemStyle-Width="150" />   
                             <asp:BoundField DataField="ProductId" HeaderText="Product ID" ItemStyle-Width="150" />     
                             <asp:BoundField DataField="IsSold" HeaderText="Availability" ItemStyle-Width="150" />    
                             <asp:BoundField DataField="WarehouseID" HeaderText="WarehouseID" ItemStyle-Width="150" />    
                         </Columns>    
                     </asp:GridView>    
                </div>  
                <!-- View Warehouses -->
                <div id="viewWarehouses" class="centre-div" runat="server" style="display: none;">   
                     <asp:GridView ID="gvWarehouse" runat="server" AutoGenerateColumns="false" >    
                         <Columns>    
                             <asp:BoundField DataField="WarehouseId" HeaderText="Item ID" ItemStyle-Width="150" />   
                             <asp:BoundField DataField="StreetAndNo" HeaderText="Street and Number" ItemStyle-Width="150" />     
                             <asp:BoundField DataField="City" HeaderText="City" ItemStyle-Width="150" />    
                             <asp:BoundField DataField="ProvinceOrState" HeaderText="Province or State" ItemStyle-Width="150" />    
                             <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />    
                             <asp:BoundField DataField="PostalCode" HeaderText="Postal Code" ItemStyle-Width="150" />    
                             <asp:BoundField DataField="IsActive" HeaderText="Actively Operating" ItemStyle-Width="150" />    
                         </Columns>    
                     </asp:GridView>    
                </div>  
            </div>
        </div>
    </form>
</body>
</html>

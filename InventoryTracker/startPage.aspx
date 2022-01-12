<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startPage.aspx.cs" Inherits="InventoryTracker.startPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EB Logistics Corp.</title>
</head>
<body style="background:#95BF47; padding:1%;">
    <form id="mainUI" runat="server" style="display: flex; justify-content: center; background:white;">
        <div>
            <div class="nav" style="display: flex; justify-content: center;">
            <h1 style="color:#5E8E3E; font-weight:bolder;">Inventory Tracking Application</h1>
            </div>
            <!-- Navigation buttons -->
            <div class="nav" style="display: flex; justify-content: center;">
                <table >
                    <tr height="15px">
                        <th width="25%"></th>                   
                        <th width="12.5%"></th>
                        <th width="25%"></th>                        
                        <th width="12.5%"></th>
                        <th width="25%"></th>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnProduct" runat="server" Text="Products" Width="150px"/></td>
                        <td></td>
                        <td><asp:Button ID="btnItem" runat="server" Text="Items" Width="150px"/></td>
                        <td></td>
                        <td><asp:Button ID="btnWarehouse" runat="server" Text="Warehouses" Width="150px"/></td>
                    </tr> 
                    <tr height="15px">
                        <td></td>
                    </tr>
                </table>
            </div>
            <!-- Display output -->
            <div class="output">
                <asp:TextBox ID="txtOutput" runat="server" Height="400px" TextMode="MultiLine" Width="900px" ReadOnly="True"></asp:TextBox>
            </div>
            <!-- Product Query table -->
            <div class="products">
                <table>
                    <!-- Set up columns -->
                    <tr>
                        <th width="25%"></th>                   
                        <th width="20%"></th>
                        <th width="20%"></th>                        
                        <th width="20%"></th>
                        <th width="15%"></th>
                    </tr>
                        <tr>           
                            <td></td>
                            <td>Product ID</td>
                            <td><asp:TextBox id="txtProductID" runat="server" ToolTip="Enter the product ID" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Product Name</td>
                            <td><asp:TextBox id="txtProductName" runat="server" ToolTip="Enter the product name" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Is Active?</td>
                            <td><asp:RadioButton ID="radActive" runat="server" Text="Active" GroupName="IsActive" /></td>
                            <td><asp:RadioButton ID="radInactive" runat="server" Text="Inactive" GroupName="IsActive" /></td>
                            <td></td>
                        </tr>
                </table>
                <!-- Buttons for submit/clear -->
                <div class="buttons" style="display: flex; justify-content: center; margin:20px;">                                    
                    <table>
                        <!-- Set up columns -->
                        <tr>
                            <th width="25%"></th>                   
                            <th width="20%"></th>
                            <th width="20%"></th>                        
                            <th width="20%"></th>
                            <th width="15%"></th>
                        </tr>
                        <tr>
                            <td><asp:Button ID="btnCreateProduct" runat="server" Text="CREATE" Width="150px"/></td>
                            <td></td>
                            <td><asp:Button ID="btnUpdateProduct" runat="server" Text="UPDATE" Width="150px"/></td>
                            <td></td>
                            <td><asp:Button ID="btnDeleteProduct" runat="server" Text="DELETE" Width="150px"/></td>
                        </tr>    
                    </table>
                </div>
            </div>     
            <!-- Item Query table -->
            <div class="items">
                <table>
                    <!-- Set up columns -->
                    <tr>
                        <th width="25%"></th>                   
                        <th width="20%"></th>
                        <th width="20%"></th>                        
                        <th width="20%"></th>
                        <th width="15%"></th>
                    </tr>
                        <tr>          
                            <td></td> 
                            <td>Item ID</td>
                            <td><asp:TextBox id="txtItemID" runat="server" ToolTip="Enter the item ID" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Product ID</td>
                            <td><asp:TextBox id="txtProductID2" runat="server" ToolTip="Enter the product ID" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Is Assigned?</td>
                            <td><asp:RadioButton ID="RadioButton1" runat="server" Text="Active" GroupName="IsActive" /></td>
                            <td><asp:RadioButton ID="RadioButton2" runat="server" Text="Inactive" GroupName="IsActive" /></td>
                        </tr>
                </table>
                <!-- Buttons for submit/clear -->
                <div class="buttons" style="display: flex; justify-content: center; margin:20px;">                                    
                    <table>
                        <!-- Set up columns -->
                        <tr>
                            <th width="15%"></th>                   
                            <th width="30%"></th>
                            <th width="10%"></th>                        
                            <th width="30%"></th>
                            <th width="15%"></th>
                        </tr>
                        <tr>
                            <td><asp:Button ID="btnCreateItem" runat="server" Text="CREATE" Width="150px"/></td>
                            <td></td>
                            <td><asp:Button ID="btnUpdateItem" runat="server" Text="UPDATE" Width="150px"/></td>
                            <td></td>
                            <td><asp:Button ID="btnDeleteItem" runat="server" Text="DELETE" Width="150px"/></td>
                        </tr>    
                    </table>
                </div>
            </div>     
            <!-- Warehouse Item Query table -->
            <div class="warehouseItems">
                <table>
                    <!-- Set up columns -->
                    <tr>
                        <th width="25%"></th>                   
                        <th width="20%"></th>
                        <th width="20%"></th>                        
                        <th width="20%"></th>
                        <th width="15%"></th>
                    </tr>
                        <tr>           
                            <td></td>
                            <td>Warehouse ID</td>
                            <td><asp:TextBox id="txtWarehouseID" runat="server" ToolTip="Enter the warehouse ID" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Item ID</td>
                            <td><asp:TextBox id="txtWarehouseItemID" runat="server" ToolTip="Enter the item ID" width="100%"/></td>
                            <td></td>
                        </tr>
                </table>
                <!-- Buttons for submit/clear -->
                <div class="buttons" style="display: flex; justify-content: center; margin:20px;">                                    
                    <table>
                        <!-- Set up columns -->
                        <tr>
                            <th width="25%"></th>                   
                            <th width="20%"></th>
                            <th width="20%"></th>                        
                            <th width="20%"></th>
                            <th width="15%"></th>
                        </tr>
                        <tr>
                            <td><asp:Button ID="btnCreateWarehouseItem" runat="server" Text="CREATE" Width="150px"/></td>
                            <td></td>
                            <td><asp:Button ID="btnUpdateWarehouseItem" runat="server" Text="UPDATE" Width="150px"/></td>
                            <td></td>
                            <td><asp:Button ID="btnDeleteWarehouseItem" runat="server" Text="DELETE" Width="150px"/></td>
                        </tr>    
                    </table>
                </div>
            </div>      
            <!-- Warehouse Query table -->
            <div class="warehouses">
                <table>
                    <!-- Set up columns -->
                    <tr>
                        <th width="25%"></th>                   
                        <th width="20%"></th>
                        <th width="20%"></th>                        
                        <th width="20%"></th>
                        <th width="15%"></th>
                    </tr>
                        <tr>           
                            <td></td>
                            <td>Warehouse ID</td>
                            <td><asp:TextBox id="txtWarehouseID2" runat="server" ToolTip="Enter the warehouse ID" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Street and Number</td>
                            <td><asp:TextBox id="txtStreetAndNo" runat="server" ToolTip="Enter the street and number" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>City</td>
                            <td><asp:TextBox id="txtCity" runat="server" ToolTip="Enter the city" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Prov or State</td>
                            <td><asp:TextBox id="txtProvOrState" runat="server" ToolTip="Enter the province or state" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Country</td>
                            <td><asp:TextBox id="txtCountry" runat="server" ToolTip="Enter the country" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Postal Code</td>
                            <td><asp:TextBox id="txtPostalCode" runat="server" ToolTip="Enter the postal code" width="100%"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Is Active?</td>
                            <td><asp:RadioButton ID="RadioButton3" runat="server" Text="Active" GroupName="IsActive" /></td>
                            <td><asp:RadioButton ID="RadioButton4" runat="server" Text="Inactive" GroupName="IsActive" /></td>
                        </tr>
                </table>
                <!-- Buttons for submit/clear -->
                <div class="buttons" style="display: flex; justify-content: center; margin:20px;">                                    
                    <table>
                        <!-- Set up columns -->
                        <tr>
                            <th width="25%"></th>                   
                            <th width="20%"></th>
                            <th width="20%"></th>                        
                            <th width="20%"></th>
                            <th width="15%"></th>
                        </tr>
                        <tr>
                            <td><asp:Button ID="Button1" runat="server" Text="CREATE" Width="150px"/></td>
                            <td></td>
                            <td><asp:Button ID="Button2" runat="server" Text="UPDATE" Width="150px"/></td>
                            <td></td>
                            <td><asp:Button ID="Button3" runat="server" Text="DELETE" Width="150px"/></td>
                        </tr>    
                    </table>
                </div>
            </div>  
        </div>
    </form>
</body>
</html>

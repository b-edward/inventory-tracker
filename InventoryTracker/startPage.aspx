<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startPage.aspx.cs" Inherits="InventoryTracker.startPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EB Logistics Corp.</title>
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
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
                    <tr>
                        <td><asp:Button ID="btnProduct" runat="server" Text="Products" Width="150px" OnClick="btnProduct_Click"/></td>
                        <td></td>
                        <td><asp:Button ID="btnItem" runat="server" Text="Items" Width="150px"/></td>
                        <td></td>
                        <td><asp:Button ID="btnWarehouse" runat="server" Text="Warehouses" Width="150px"/></td>
                        <td></td>
                        <td><asp:Button ID="btnWarehouseItems" runat="server" Text="Warehouse Items" Width="150px"/></td>
                    </tr> 
                    <tr height="15px">
                        <td></td>
                    </tr>
                </table>
            </div>
            <!-- Display output -->
            <div class="output">
<%--                <asp:TextBox ID="txtOutput" runat="server" Height="350px" TextMode="MultiLine" Width="900px" ReadOnly="True"></asp:TextBox>--%>

                <div>   
                     <asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="false" >    
                         <Columns>    
                             <asp:BoundField DataField="ItemId" HeaderText="Item ID" ItemStyle-Width="150" />   
                             <asp:BoundField DataField="ProductId" HeaderText="Product ID" ItemStyle-Width="150" />     
                             <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-Width="150" />    
                             <asp:BoundField DataField="WarehouseLocation" HeaderText="WarehouseLocation" ItemStyle-Width="150" />    
                         </Columns>    
                     </asp:GridView>    
                </div>  
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
                            <td class="auto-style1"></td>
                            <td class="auto-style1">Product Name</td>
                            <td class="auto-style1"><asp:TextBox id="txtProductName" runat="server" ToolTip="Enter the product name" width="100%"/></td>
                            <td class="auto-style1"></td>
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
                        <!-- If item sold, hide warehouses, delete warehouseItem -->
                        <td>Is Sold?</td>
                        <td><asp:RadioButton ID="radioSold" runat="server" Text="Sold" GroupName="IsActive" /></td>
                        <td><asp:RadioButton ID="radioNotSold" runat="server" Text="In Stock" GroupName="IsActive" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>Assigned to warehouse:</td>
                        <td>                                                 
                            <!-- If warehouse selected, changes Item isAssigned to true, creates warehouseItem -->
                            <asp:DropDownList ID="DropDownList1" runat="server">                            
                             <asp:listitem text="None" value="0"></asp:listitem>                     
                             <asp:listitem text="Waterloo" value="1"></asp:listitem>
                             <asp:listitem text="Toronto" value="2"></asp:listitem>
                             <asp:listitem text="Ottawa" value="3"></asp:listitem>
                        </asp:DropDownList></td>
                        <td></td>
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

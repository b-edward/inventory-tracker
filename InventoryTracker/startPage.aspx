<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startPage.aspx.cs" Inherits="InventoryTracker.startPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EB Logistics Corp.</title>
</head>
<body>
    <form id="mainUI" runat="server" style="display: flex; justify-content: center;">
        <div>
            <div class="nav" style="display: flex; justify-content: center;">
            <h3>Inventory Tracking Application</h3>
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
                <asp:TextBox ID="txtOutput" runat="server" Height="303px" TextMode="MultiLine" Width="900px" ReadOnly="True"></asp:TextBox>
            </div>
            <!-- Input table -->
            <div class="input">
                <table>
                    <!-- Set up columns -->
                    <tr>
                        <th width="20%"></th>                   
                        <th width="20%"></th>
                        <th width="20%"></th>                        
                        <th width="20%"></th>
                        <th width="20%"></th>
                    </tr>
                        <tr>           
                            <td text-align="right">First and Last Name: </td>
                            <td><input type="text" size="35" placeholder="e.g. John Smith" name="name" id="name"/></td>
                            <td>
    <%--                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>Street Address:</td>
                            <td><input type="text" size="35" placeholder="e.g. 123 Any Street" name="address" id="address"/></td>
    <%--                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator></td>--%>
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
                            <td></td>
                            <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="150px"/></td>
                            <td></td>
                            <td><asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Width="150px"/></td>
                            <td></td>
                        </tr>    
                    </table>
                </div>
            </div>      
        </div>
    </form>
</body>
</html>

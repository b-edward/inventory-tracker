<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startPage.aspx.cs" Inherits="InventoryTracker.startPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EB Logistics Corp.</title>
</head>
<body>
    <form id="mainUI" runat="server">
        <div>
            <h1>Inventory Tracking Application</h1>
        </div>
        <div>
            <asp:TextBox ID="txtOutput" runat="server" Height="303px" TextMode="MultiLine" Width="766px" ReadOnly="True"></asp:TextBox>
        </div>
        
        <div>
            <asp:TextBox ID="txtInput" runat="server" Height="100px" TextMode="MultiLine" Width="500px"></asp:TextBox>
        </div>
        <div>            
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
        </div>

    </form>
</body>
</html>

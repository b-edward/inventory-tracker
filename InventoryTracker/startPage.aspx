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
        <asp:TextBox ID="txtOutput" runat="server" Height="303px" TextMode="MultiLine" Width="766px"></asp:TextBox>

        <p>
            <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select" />
        </p>
        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />

    </form>
</body>
</html>

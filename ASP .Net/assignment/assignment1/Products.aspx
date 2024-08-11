
﻿﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="assignment1.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:Image ID="imgProduct" runat="server" Width="400px" Height="400px" />
            <br />
            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />
            <br />
            <asp:Label ID="lblPrice" runat="server" ForeColor="YellowGreen"></asp:Label>
            </div>
    </form>
</body>
</html>

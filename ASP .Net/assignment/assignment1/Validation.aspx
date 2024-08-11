
﻿﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation.aspx.cs" Inherits="assignment1.Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Name:</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <label>Family Name:</label>
            <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
            <br />
            <label>Address:</label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <br />
            <label>City:</label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <br />
            <label>Zip Code:</label>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
            <br />
            <label>Phone:</label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click"></asp:Button>
            <br />
            <asp:Label ID="lblResult" runat="server" ForeColor="Black"></asp:Label>
        </div>
    </form>
</body>
</html>

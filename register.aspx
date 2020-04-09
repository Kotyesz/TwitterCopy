<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="TwitterCopy_V2.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Username:</label><br/>
            <asp:TextBox ID="usernameField" runat="server"></asp:TextBox><br/>
            <label>Email:</label><br/>
            <asp:TextBox ID="emailField" runat="server"></asp:TextBox><br/>
            <label>Password:</label><br/>
            <asp:TextBox ID="pwField" runat="server" TextMode="Password"></asp:TextBox><br/>
            <label>Password Confirm:</label><br/>
            <asp:TextBox ID="pwconfirmField" runat="server" TextMode="Password"></asp:TextBox><br/>
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitClick" /><br/>
            <asp:Label ID="outputLabel" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>

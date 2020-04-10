<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TwitterCopy_V2.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Username/Email</label><br />
            <asp:TextBox ID="usermail" runat="server"></asp:TextBox><br />
            <label>Password</label><br />
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitClick" /><br/>
            <asp:Label ID="outputLabel" runat="server" /><br/>
            <a href="/register">Not registered?</a>
        </div>
    </form>
</body>
</html>

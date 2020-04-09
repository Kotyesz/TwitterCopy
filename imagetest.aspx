<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imagetest.aspx.cs" Inherits="TwitterCopy_V2.imagetest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background: black;">
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="submit" Text="Submit" runat="server" OnClick="submitClick" />
            <br/>
            <asp:Image ID="Output" runat="server" width="1000"/><br/>
            <asp:Label ID="outtext" runat="server" />
        </div>
    </form>
</body>
</html>

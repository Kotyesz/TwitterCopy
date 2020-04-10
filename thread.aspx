<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thread.aspx.cs" Inherits="TwitterCopy_V2.thread" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <!--
                Diveket/Spanokat nyugodtan cserelheted mivel nem tudom mit csinalok. :DD
                -->
            <div style="float:left">
                <div>
                    <img src="#" />
                </div>
                <div>
                <a>Home</a>
                </div>
                <div>
                <a>Profile</a>
                </div>
                <div>
                <asp:Button text="Post" runat="server"/>
                </div>
                <div>
                <a>Logout</a>
                </div>
            </div>
            <div style="float:left">
                <div>
                    <p>Latest posts</p>
                <div>
                    <div style="float:left">
                        <asp:Image runat="server"/>
                    </div>
                    <div style="float:left">
                        <asp:Textbox placeholder="What's happening" runat="server" />
                    </div>
                    <div>
                        <asp:FileUpload ID="ImageUpload" accept="image/*" multiple="false" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        </div>
    </form>
</body>
</html>

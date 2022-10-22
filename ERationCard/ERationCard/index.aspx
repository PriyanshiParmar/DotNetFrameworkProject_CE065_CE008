<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ERationCard.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:HyperLink ID="linkShkLogin" runat="server" NavigateUrl="~/shopkeeperLogin.aspx">Shopkeeper login</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="linkAdminLogin" runat="server" NavigateUrl="~/adminLogin.aspx">Admin login</asp:HyperLink>

        </div>
    </form>
</body>
</html>

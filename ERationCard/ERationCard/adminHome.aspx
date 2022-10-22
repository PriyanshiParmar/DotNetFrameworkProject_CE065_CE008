<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminHome.aspx.cs" Inherits="ERationCard.adminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="mngShopkeeper" runat="server" NavigateUrl="~/shopkeeperManagement.aspx">Manage Shopkeepers</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="mngCustomer" runat="server" NavigateUrl="~/customerManage.aspx">Manage Customers</asp:HyperLink>
        </div>
    </form>
</body>
</html>

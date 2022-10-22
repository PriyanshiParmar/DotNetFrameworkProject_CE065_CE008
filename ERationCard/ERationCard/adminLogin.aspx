<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="ERationCard.adminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAdmin" runat="server" AssociatedControlID="tbAdminName" Text="Username: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAdminName" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="lblAdminPswd" runat="server" AssociatedControlID="tbAdminPswd" Text="Password: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAdminPswd" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/index.aspx">Back to Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewBill.aspx.cs" Inherits="ERationCard.viewBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="BillId" HeaderText="BillId" SortExpression="BillId" />
                    <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" SortExpression="CustomerId" />
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" SortExpression="ProductId" />
                    <asp:BoundField DataField="ProductWeight" HeaderText="ProductWeight" SortExpression="ProductWeight" />
                    <asp:BoundField DataField="ProductRate" HeaderText="ProductRate" SortExpression="ProductRate" />
                    <asp:BoundField DataField="ProductTotalPrice" HeaderText="ProductTotalPrice" SortExpression="ProductTotalPrice" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Bills]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>

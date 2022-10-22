<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateBill.aspx.cs" Inherits="ERationCard.GenerateBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 137px;
        }
        .auto-style3 {
            width: 392px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblPrdName" runat="server" Text="Product Name: "></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlProduct" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Name], [Id], [Price] FROM [Product]"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrdName" runat="server" ControlToValidate="ddlProduct" ErrorMessage="Product Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblPrdAmt" runat="server" Text="Product amount: "></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="tbPrdAmt" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;<asp:RangeValidator ID="RangeValidatorPrdAmt" runat="server" ControlToValidate="tbPrdAmt" ErrorMessage="Amount should be between 1 kg to 5kg" ForeColor="Red" MaximumValue="5" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblPrdPrice" runat="server" Text="Price per kg: "></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="tbPrdPrice" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="btnAddPrd" runat="server" OnClick="btnAddPrd_Click" Text="Add Product" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" style="height: 29px" Text="Cancel" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Label ID="lblCustId" runat="server" AssociatedControlID="tbCustID" Text="Customer Id:" Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbCustID" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblBillId" runat="server" AssociatedControlID="tbBillId" Text="Bill Id: " Visible="False"></asp:Label>
            <asp:TextBox ID="tbBillId" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" Visible="False" >
            </asp:GridView>
            <br />
            <asp:Label ID="lblTotalAmt" runat="server" AssociatedControlID="tbTotalAmt" Text="Total Amount: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="tbTotalAmt" runat="server" ReadOnly="True" TextMode="Number" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnCancelBill" runat="server" OnClick="btnCancelBill_Click" Text="Cancel Bill Generation" Visible="False" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Ok" Visible="False" />
        </div>
    </form>
</body>
</html>

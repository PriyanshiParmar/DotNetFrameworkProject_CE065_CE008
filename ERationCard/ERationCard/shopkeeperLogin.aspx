<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopkeeperLogin.aspx.cs" Inherits="ERationCard.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 36px;
        }
        .auto-style3 {
            height: 36px;
            width: 133px;
        }
        .auto-style4 {
            width: 133px;
            height: 29px;
        }
        .auto-style5 {
            height: 29px;
        }
        .auto-style6 {
            height: 36px;
            width: 393px;
        }
        .auto-style7 {
            width: 393px;
            height: 29px;
        }
    </style>
</head>
<body style="width: 1371px">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblShkId" runat="server" Text="Shopkeeper Id"></asp:Label>
&nbsp;&nbsp; </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="tbShKId" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorShKId" runat="server" ControlToValidate="tbShKId" ErrorMessage="Id is required." ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblShKPswd" runat="server" Text="Password"></asp:Label>
&nbsp; </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="tbShKpswd" runat="server" MaxLength="6" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorShKPswd" runat="server" ControlToValidate="tbShKpswd" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/index.aspx">Back to home</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

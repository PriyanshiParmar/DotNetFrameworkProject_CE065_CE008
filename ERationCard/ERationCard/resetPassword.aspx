<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPassword.aspx.cs" Inherits="ERationCard.resetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblOldPswd" runat="server" AssociatedControlID="tbOldPswd" Text="Old Password: "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbOldPswd" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOldPswd" runat="server" ControlToValidate="tbOldPswd" ErrorMessage="Old Password is Required." ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="lblNewPswd" runat="server" AssociatedControlID="tbNewPswd" Text="New Password: "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNewPswd" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPswd" runat="server" ControlToValidate="tbNewPswd" ErrorMessage="New Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorNewPswd" runat="server" ControlToValidate="tbNewPswd" ErrorMessage="New Password should be an alphnumeric string of 6 letters." ForeColor="Red" ValidationExpression="[0-9|a-z|A-Z]{6}"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblConfirmPswd" runat="server" Text="Confirm new Password: "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbConfirmPswd" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPswd" runat="server" ControlToValidate="tbConfirmPswd" ErrorMessage="Confirm New Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
        <asp:CompareValidator ID="CompareValidatorConfirmPswd" runat="server" ControlToCompare="tbNewPswd" ControlToValidate="tbConfirmPswd" ErrorMessage="Confirm Password should be same as New Password" ForeColor="Red"></asp:CompareValidator>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    </form>
</body>
</html>

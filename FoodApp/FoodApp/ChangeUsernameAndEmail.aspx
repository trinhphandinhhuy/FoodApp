<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeUsernameAndEmail.aspx.cs" Inherits="FoodApp.UserAccount" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Account</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" /><br />
        Username:<br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        Email:<br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredUsername" runat="server" ErrorMessage="Please enter an username" ForeColor="Red" ControlToValidate="txtUsername" Display="None"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredEmailAddress" runat="server" ErrorMessage="Please enter an email address" ForeColor="Red" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator><br />
        <asp:RegularExpressionValidator ID="RegularExpressionEmailAddress" runat="server" ErrorMessage="Invalid E-mail Address" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator><br />
        <asp:Button ID="btnChangeUsernameAndEmailAddress" runat="server" Text="Save Change(s)" OnClick="btnChangeUsernameAndEmailAddress_Click" /><br />
    </form>
</body>
</html>

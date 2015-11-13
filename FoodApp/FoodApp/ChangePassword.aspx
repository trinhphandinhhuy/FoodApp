<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="FoodApp.ChangePassword" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        Old Password:<br />
        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        New Password:<br />
        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        Confirm Password:<br />
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" /><br />
        <asp:RequiredFieldValidator ID="RequiredOldPassword" runat="server" ErrorMessage="Please enter old password" ForeColor="Red" ControlToValidate="txtOldPassword" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredNewPassword" runat="server" ErrorMessage="Please enter new password" ForeColor="Red" ControlToValidate="txtNewPassword" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredConfirmPassword" runat="server" ErrorMessage="Please confirm new password" ForeColor="Red" ControlToValidate="txtConfirmPassword" Display="None"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="ComparePassword" runat="server" ErrorMessage="Password and Confirm Password did not matched" ForeColor="Red" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" Display="None"></asp:CompareValidator>
        <asp:CustomValidator ID="CheckOldPassword" runat="server" ErrorMessage="Old Password is Invalid" ForeColor="Red" ControlToValidate="txtOldPassword" OnServerValidate="CheckOldPassword_ServerValidate" Display="None"></asp:CustomValidator>
    </form>
</body>
</html>

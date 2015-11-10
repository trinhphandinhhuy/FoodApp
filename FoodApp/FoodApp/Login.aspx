<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodApp.Login" EnableSessionState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        .style4
        {
            width: 212px;
        }
        .style7
        {
            width: 212px;
            height: 31px;
        }
        .style9
        {
            height: 26px;
        }
        .style11
        {
            width: 259px;
        }
        .style12
        {
            width: 259px;
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="border: 1pt solid #6666FF; width: 60%; height: 424px; font-family: Verdana; border-collapse: collapse; background-color: #ffffff;" align="center">
            <tr>
                <td align="center" colspan="3" class="style9">Login Form</td>
            </tr>
            <tr>
                <td class="style7" align="right">Username:</td>
                <td class="style7" align="center">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
                <td class="style7" align="left">
                    <asp:RequiredFieldValidator ID="RequiredUser" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style7" align="right">Password:</td>
                <td class="style7" align="center">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style7" align="left">
                    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" class="style7">&nbsp;</td>
                <td class="style7" align="center">
                    <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
                </td>
                <td align="center" class="style7">
                    <asp:CustomValidator ID="userAuthentication" runat="server" ErrorMessage="Username or Password is Invalid" ForeColor="Red" OnServerValidate="userAuthentication_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

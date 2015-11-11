<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/MasterPage/loginPage1.Master" Inherits="FoodApp.Login" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login Page</title>
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <table style="border: 1pt solid #6666FF; width: 60%; height: 424px; font-family: Verdana; border-collapse: collapse; background-color: #ffffff;" >
            <tr>
                <td colspan="3" class="style9">Login Form</td>
            </tr>
            <tr>
                <td class="style7" >Username:</td>
                <td class="style7" >
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
                <td class="style7" >
                    <asp:RequiredFieldValidator ID="RequiredUser" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style7" >Password:</td>
                <td class="style7" >
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style7" >
                    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td  class="style7">&nbsp;</td>
                <td class="style7">
                    <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
                </td>
                <td  class="style7">
                    <asp:CustomValidator ID="userAuthentication" runat="server" ErrorMessage="Username or Password is Invalid" ForeColor="Red" OnServerValidate="userAuthentication_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
        </table>
</asp:Content>


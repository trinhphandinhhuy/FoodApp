<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/MasterPage/loginPage1.Master" Inherits="FoodApp.Login" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login Page</title>
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
    <div class="form-group">
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" CssClass="form-control btn btn-register"/>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <a href="Registration.aspx" class="form-control btn btn-info" role="button">Register an account now</a>
            </div>
        </div>
    </div>
    <asp:RequiredFieldValidator ID="RequiredUser" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="userAuthentication" runat="server" ErrorMessage="Username or Password is Invalid" ForeColor="Red" OnServerValidate="userAuthentication_ServerValidate"></asp:CustomValidator>
</asp:Content>


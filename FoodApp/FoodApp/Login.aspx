<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/MasterPage/loginPage1.Master" Inherits="FoodApp.Login" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
    
        <div class="row">
            <div class="col s12 m8 l8">
                <div class="slider">
                    <ul class="slides">
                      <li>
                        <img src="http://www.freefoodphotos.com/imagelibrary/meat/slides/bbq_meat_tray.jpg" />
                        <div class="caption left-align">
                          <h4>Sausages, rissoles and steak</h4>
                        </div>
                      </li>
                      <li>
                        <img src="http://www.freefoodphotos.com/imagelibrary/bread/slides/buttered_rolls.jpg" />
                        <div class="caption center-align">
                          <h4>Fresh buttered hot cross bun</h4>
                        </div>
                      </li>
                      <li>
                        <img src="http://www.freefoodphotos.com/imagelibrary/seafood/slides/salmon_crispbread.jpg" />
                        <div class="caption right-align">
                          <h4>Snack of salmon on crispbread</h4>
                        </div>
                      </li>
                    </ul>
                  </div>
            </div>
            <div class="col s12 m4 l4">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="txtPassword"  runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>         
                <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" CssClass="form-control btn btn-info" />
                <a href="Registration.aspx" class="form-control btn btn-info" role="button"> Register now </a>
            </div>
        </div>
    <asp:RequiredFieldValidator ID="RequiredUser" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="userAuthentication" runat="server" ErrorMessage="Username or Password is Invalid" ForeColor="Red" OnServerValidate="userAuthentication_ServerValidate" Display="None"></asp:CustomValidator>
</asp:Content>


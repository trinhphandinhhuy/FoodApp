<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FoodApp.Registration" MasterPageFile="~/MasterPage/loginPage1.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Registration </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger"/>
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
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
                <asp:Button ID="btnSubmit" runat="server" Text="Register Now" OnClick="btnSubmit_Click" CssClass="form-control btn btn-register"/>
                 <a href="Login.aspx" class="form-control btn btn-info" role="button"> Login </a>
            </div>
            </div>

    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Username Required" ForeColor="#FF3300" ControlToValidate="txtUserName" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email Required" ForeColor="#FF3300" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="rxvEmail" runat="server" ErrorMessage="Invalid E-mail Address" ControlToValidate="txtEmail" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ErrorMessage="Password Required" ForeColor="#FF3300" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rfvCnfrmPwd" runat="server" ErrorMessage="Confirm Password Required" ForeColor="#FF3300" ControlToValidate="txtConfirmPwd" Display="None"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="cvCnfmPwd" runat="server" ErrorMessage="Password and Confirm Password didn't matched" ForeColor="#FF3300" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPwd" Display="None"></asp:CompareValidator>
    <asp:Label ID="lblMsg" runat="server" ForeColor="#CC3300"></asp:Label>
</asp:Content>



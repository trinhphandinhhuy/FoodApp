<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FoodApp.Registration" MasterPageFile="~/MasterPage/loginPage1.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Registration </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger"/>
    <div class="container">
        <div class="row">
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
        </div>
     
            <div class="row">
                <div class="col-sm-6 col-sm-offset-3">
                    <asp:Button ID="btnSubmit" runat="server" Text="Register Now" OnClick="btnSubmit_Click" CssClass="form-control btn btn-register"/>
                </div>
            </div>
        
            <div class="row">
                <div class="col-sm-6 col-sm-offset-3">
                    <a href="Login.aspx" class="form-control btn btn-info" role="button"> Login </a>
                </div>
            </div>
  
    </div>
    <asp:RequiredFieldValidator ID="RfvUserName" runat="server" ErrorMessage="Username Required" ForeColor="#FF3300" ControlToValidate="txtUserName" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ErrorMessage="Email Required" ForeColor="#FF3300" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RxvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid E-mail Address" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RfvPwd" runat="server" ErrorMessage="Password Required" ForeColor="#FF3300" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvCnfrmPwd" runat="server" ErrorMessage="Confirm Password Required" ForeColor="#FF3300" ControlToValidate="txtConfirmPwd" Display="None"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CvCnfmPwd" runat="server" ErrorMessage="Password and Confirm Password didn't matched" ForeColor="#FF3300" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPwd" Display="None"></asp:CompareValidator>
    <asp:Label ID="lblMsg" runat="server" ForeColor="#CC3300"></asp:Label>
</asp:Content>



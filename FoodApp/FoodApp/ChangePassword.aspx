<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MainLayout.Master" CodeBehind="ChangePassword.aspx.cs" Inherits="FoodApp.ChangePassword" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container" style="min-height:64vh">
        <div class="section"><h3 class="center grey-text">CHANGE PASSWORD</h3></div>
         <div class="section">
         <div class="col-md-6 col-md-offset-3">
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    Old Password:<br />
    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
    New Password:<br />
    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
    Confirm Password:<br />
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
    <br />
             <div class="section center">
    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" CssClass="btn btn-register form-control" /><br />
    </div>
        </div>
        </div>
         <asp:RequiredFieldValidator ID="RequiredOldPassword" runat="server" ErrorMessage="Please enter old password" ForeColor="Red" ControlToValidate="txtOldPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredNewPassword" runat="server" ErrorMessage="Please enter new password" ForeColor="Red" ControlToValidate="txtNewPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredConfirmPassword" runat="server" ErrorMessage="Please confirm new password" ForeColor="Red" ControlToValidate="txtConfirmPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="ComparePassword" runat="server" ErrorMessage="Password and Confirm Password did not matched" ForeColor="Red" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" Display="None"></asp:CompareValidator>
    <asp:CustomValidator ID="CheckOldPassword" runat="server" ErrorMessage="Old Password is Invalid" ForeColor="Red" ControlToValidate="txtOldPassword" OnServerValidate="CheckOldPassword_ServerValidate" Display="None"></asp:CustomValidator>
        </div>
   
</asp:Content>

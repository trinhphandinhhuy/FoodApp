<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MPUserManagement.master" CodeBehind="AdminAddUser.aspx.cs" Inherits="FoodApp.AdminAddUser" %>


 <asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
     <div class="container">
         <div class="col m6 offset-m3">
             <div class="section"></div>
              <div class="section">
             <h4 class="center"> ADD NEW USER</h4>
                  </div>
             <div class="section">
         
         Username:<br />
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox><br />
        Email Address:<br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox><br />
        Password:<br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
        Confirm Password:<br />
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
        <br />
                 <div class="section center">
        <asp:Button ID="btnAdd" runat="server" Text="Add New User" OnClick="btnAdd_Click" CssClass="btn btn-register form-control" />
            </div>
                 </div>
            
   
    
     <asp:RequiredFieldValidator ID="RequiredUsername" runat="server" ErrorMessage="Please enter an username" ForeColor="Red" ControlToValidate="txtUsername" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ErrorMessage="Please enter an email address" ForeColor="Red" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ErrorMessage="Please enter password" ForeColor="Red" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredConfirmPassword" runat="server" ErrorMessage="Please confirm password" ForeColor="Red" ControlToValidate="txtConfirmPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionForEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid E-mail Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
    <asp:CompareValidator ID="ComparePassword" runat="server" ErrorMessage="Password and Confirm Password did not matched" ForeColor="Red" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="None"></asp:CompareValidator>
              </div>

         </div>
</asp:Content>

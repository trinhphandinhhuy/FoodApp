<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/DashBoard.Master" CodeBehind="ChangePassword.aspx.cs" Inherits="FoodApp.ChangePassword" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="accountInfo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ImageButton ID="Recipes" runat="server" ImageUrl="~/img/recipe.png" CssClass="navIcon" OnClick="Recipes_Click" /> 
    <asp:ImageButton ID="Ingredients" runat="server" ImageUrl="~/img/ingredients.png" CssClass="navIcon" OnClick="Ingredients_Click" />  
    <asp:ImageButton ID="MyList" runat="server" ImageUrl="~/img/personal.png" CssClass="navIcon" OnClick="User_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="AdminFunction" runat="server">
         <asp:Button ID="btnAddNewUser" runat="server" Text="Add New User" CssClass="btn btn-info" Width="100%" OnClick="btnAddNewUser_Click" />
        <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User" CssClass="btn btn-info" Width="100%" OnClick="btnDeleteUser_Click" />
    </asp:Panel>
    <asp:Button ID="btnEditUsernameAndEmail" runat="server" Text="Edit Username and Email" CssClass="btn btn-info" Width="100%" OnClick="btnEditUsernameAndEmail_Click" />
    <asp:Button ID="btnPassword" runat="server" Text="Change Password" CssClass="btn btn-info" Width="100%" OnClick="btnPassword_Click" />
    <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="100%" Cssclass="btn btn-danger" OnClick="btnLogout_Click"/>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    Old Password:<br />
    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
    New Password:<br />
    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
    Confirm Password:<br />
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
    <br />
    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" CssClass="btn" /><br />
    <asp:RequiredFieldValidator ID="RequiredOldPassword" runat="server" ErrorMessage="Please enter old password" ForeColor="Red" ControlToValidate="txtOldPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredNewPassword" runat="server" ErrorMessage="Please enter new password" ForeColor="Red" ControlToValidate="txtNewPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredConfirmPassword" runat="server" ErrorMessage="Please confirm new password" ForeColor="Red" ControlToValidate="txtConfirmPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="ComparePassword" runat="server" ErrorMessage="Password and Confirm Password did not matched" ForeColor="Red" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" Display="None"></asp:CompareValidator>
    <asp:CustomValidator ID="CheckOldPassword" runat="server" ErrorMessage="Old Password is Invalid" ForeColor="Red" ControlToValidate="txtOldPassword" OnServerValidate="CheckOldPassword_ServerValidate" Display="None"></asp:CustomValidator>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/DashBoard.Master" CodeBehind="ChangeUsernameAndEmail.aspx.cs" Inherits="FoodApp.UserAccount" EnableSessionState="True" %>
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
    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="btn btn-info" Width="100%" OnClick="btnChangePassword_Click" />
    <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="100%" Cssclass="btn btn-danger" OnClick="btnLogout_Click"/>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" /><br />
    Username:<br />
    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox><br />
    Email:<br />
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox><br />
    <br />
    <asp:Button ID="btnChangeUsernameAndEmailAddress" runat="server" Text="Save Change(s)" OnClick="btnChangeUsernameAndEmailAddress_Click" CssClass="btn btn-register form-control" /><br />
    <asp:RequiredFieldValidator ID="RequiredUsername" runat="server" ErrorMessage="Please enter an username" ForeColor="Red" ControlToValidate="txtUsername" Display="None"></asp:RequiredFieldValidator><br />
    <asp:RequiredFieldValidator ID="RequiredEmailAddress" runat="server" ErrorMessage="Please enter an email address" ForeColor="Red" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator><br />
    <asp:RegularExpressionValidator ID="RegularExpressionEmailAddress" runat="server" ErrorMessage="Invalid E-mail Address" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator><br />
    
</asp:Content>

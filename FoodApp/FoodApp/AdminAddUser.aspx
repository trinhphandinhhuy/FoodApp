﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/DashBoard.Master" CodeBehind="AdminAddUser.aspx.cs" Inherits="FoodApp.AdminAddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="accountInfo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ImageButton ID="Recipes" runat="server" ImageUrl="~/img/recipe.png" CssClass="navIcon" /> 
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
</asp:Content>
 <asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    Username:<br />
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
    Email Address:<br />
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
    Password:<br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
    Confirm Password:<br />
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox><br />
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add New User" OnClick="btnAdd_Click" />
    <asp:RequiredFieldValidator ID="RequiredUsername" runat="server" ErrorMessage="Please enter an username" ForeColor="Red" ControlToValidate="txtUsername" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ErrorMessage="Please enter an email address" ForeColor="Red" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ErrorMessage="Please enter password" ForeColor="Red" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredConfirmPassword" runat="server" ErrorMessage="Please confirm password" ForeColor="Red" ControlToValidate="txtConfirmPassword" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionForEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid E-mail Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
    <asp:CompareValidator ID="ComparePassword" runat="server" ErrorMessage="Password and Confirm Password did not matched" ForeColor="Red" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="None"></asp:CompareValidator>
</asp:Content>
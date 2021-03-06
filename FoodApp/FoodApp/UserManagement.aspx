﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/DashBoard.Master" CodeBehind="UserManagement.aspx.cs" Inherits="FoodApp.UserManagement" %>
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
</asp:Content>

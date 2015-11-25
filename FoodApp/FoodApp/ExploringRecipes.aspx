<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/DashBoard.master" CodeBehind="ExploringRecipes.aspx.cs" Inherits="FoodApp.ExploringRecipes"  EnableSessionState="True"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title> Exploring Recipes </title>
    <style>

    </style>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/recipe.png" CssClass="navIcon" OnClick ="Recipe_Click" /> 
    <asp:ImageButton ID="Ingredients" runat="server" ImageUrl="~/img/ingredients.png" CssClass="navIcon" OnClick="Ingredients_Click" />  
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/personal.png" CssClass="navIcon" OnClick ="User_Click" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnAddRecipe" runat="server" Text="Add Recipe" CssClass="btn btn-info" Width="100%" OnClick="btnAddRecipe_Click" />
    <asp:Button ID="btnManageOwnRecipes" runat="server" Text="Manage Own Recipes" CssClass="btn btn-info" Width="100%" OnClick="btnManageOwnRecipes_Click" />
    <asp:Button ID="btnManageUserRecipes" runat="server" Text="Manage User Recipes" CssClass="btn btn-info" Width="100%" OnClick="btnManageUserRecipes_Click" />
    <asp:Button ID="btnExploreRecipes" runat="server" Text="Explore Recipes" CssClass="btn btn-info" Width="100%" OnClick="btnExploreRecipes_Click" />
    <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="100%" Cssclass="btn btn-danger" OnClick="btnLogout_Click"/>
</asp:Content>
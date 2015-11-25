<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DashBoard.Master" AutoEventWireup="true" CodeBehind="RecipeManagement.aspx.cs" Inherits="FoodApp.RecipeManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="accountInfo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     <asp:ImageButton ID="Recipes" runat="server" ImageUrl="~/img/recipe.png" CssClass="navIcon" OnClick="Recipes_Click" /> 
    <asp:ImageButton ID="Ingredients" runat="server" ImageUrl="~/img/ingredients.png" CssClass="navIcon" OnClick="Ingredients_Click" />  
    <asp:ImageButton ID="MyList" runat="server" ImageUrl="~/img/personal.png" CssClass="navIcon" OnClick="MyList_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnAddRecipe" runat="server" Text="Add Recipe" CssClass="btn btn-info" Width="100%" OnClick="btnAddRecipe_Click" />
    <asp:Button ID="btnManageOwnRecipes" runat="server" Text="Manage Own Recipes" CssClass="btn btn-info" Width="100%" OnClick="btnManageOwnRecipes_Click" />
    <asp:Button ID="btnManageUserRecipes" runat="server" Text="Manage User Recipes" CssClass="btn btn-info" Width="100%" OnClick="btnManageUserRecipes_Click" />
    <asp:Button ID="btnExploreRecipes" runat="server" Text="Explore Recipes" CssClass="btn btn-info" Width="100%" OnClick="btnExploreRecipes_Click" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

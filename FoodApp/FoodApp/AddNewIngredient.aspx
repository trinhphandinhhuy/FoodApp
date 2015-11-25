<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DashBoard.Master" AutoEventWireup="true" CodeBehind="AddNewIngredient.aspx.cs" Inherits="FoodApp.AddNewIngredient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="accountInfo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ImageButton ID="Recipes" runat="server" ImageUrl="~/img/recipe.png" CssClass="navIcon" /> 
    <asp:ImageButton ID="Ingredients" runat="server" ImageUrl="~/img/ingredients.png" CssClass="navIcon" OnClick="Ingredients_Click" />  
    <asp:ImageButton ID="MyList" runat="server" ImageUrl="~/img/personal.png" CssClass="navIcon" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnAddIngredient" runat="server" Text="Add Ingredient" CssClass="btn btn-info" Width="100%" OnClick="btnAddIngredient_Click" />
    <asp:Button ID="btnListAllIngredient" runat="server" Text="List All Ingredient" CssClass="btn btn-info" Width="100%" OnClick="btnListAllIngredient_Click" />
    <asp:Button ID="btnSearchIngredient" runat="server" Text="Search Ingredient" CssClass="btn btn-info" Width="100%" OnClick="btnSearchIngredient_Click" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        Food Name:<br />
        <asp:TextBox ID="txtFoodName" runat="server" placeholder="Enter Ingredient Name"></asp:TextBox><br />
        Food Category:<br />
        <asp:DropDownList ID="ddlFoodType" runat="server"></asp:DropDownList><br />
        Unit Type:<br />
        <asp:DropDownList ID="ddlUnitType" runat="server"></asp:DropDownList><br />
        <br />
        <asp:Button ID="btnAddFoodItem" runat="server" Text="Add Food Item" OnClick="btnAddFoodItem_Click" />
        <asp:RequiredFieldValidator ID="RequiredFoodName" runat="server" ErrorMessage="Ingredient name is required" ForeColor="Red" ControlToValidate="txtFoodName" Display="None"></asp:RequiredFieldValidator>
</asp:Content>

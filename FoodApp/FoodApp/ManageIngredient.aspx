<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DashBoard.Master" AutoEventWireup="true" CodeBehind="ManageIngredient.aspx.cs" Inherits="FoodApp.ManageIngredient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="accountInfo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnAddIngredient" runat="server" Text="Add Ingredient" CssClass="btn btn-info" Width="100%" OnClick="btnAddIngredient_Click" />
    <asp:Button ID="btnListAllIngredient" runat="server" Text="List All Ingredient" CssClass="btn btn-info" Width="100%" OnClick="btnListAllIngredient_Click" />
    <asp:Button ID="btnSearchIngredient" runat="server" Text="Search Ingredient" CssClass="btn btn-info" Width="100%" OnClick="btnSearchIngredient_Click" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

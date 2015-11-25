<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage/DashBoard.Master" CodeBehind="Dashboard.aspx.cs" Inherits="FoodApp.SuccessLogIn" EnableSessionState="True" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title> Main Page </title>
    <style>

    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ImageButton ID="Recipes" runat="server" ImageUrl="~/img/recipe.png" CssClass="navIcon" /> 
    <asp:ImageButton ID="Ingredients" runat="server" ImageUrl="~/img/ingredients.png" CssClass="navIcon" OnClick="Ingredients_Click" />  
    <asp:ImageButton ID="User" runat="server" ImageUrl="~/img/personal.png" CssClass="navIcon" OnClick="User_Click" />
</asp:Content>
    

 <asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <h1>  Welcome back <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>,</h1>
     <p>  &nbsp;</p>
     <p>  &nbsp;</p>
 </asp:Content>   
       
<asp:Content ContentPlaceHolderID="accountInfo" runat="server">
    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" Cssclass="btn btn-danger"/>
 </asp:Content>
    

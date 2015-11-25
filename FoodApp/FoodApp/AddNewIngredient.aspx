<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DashBoard.Master" AutoEventWireup="true" CodeBehind="AddNewIngredient.aspx.cs" Inherits="FoodApp.AddNewIngredient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="accountInfo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

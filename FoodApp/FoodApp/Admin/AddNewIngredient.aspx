<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPIngreManagement.master" AutoEventWireup="true" CodeBehind="AddNewIngredient.aspx.cs" Inherits="FoodApp.AddNewIngredient" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <div class="container">
         <div class="section"><h4 class="center">ADD NEW INGREDIENT</h4></div>
         <div class="section">
        <div class="row">
         <div class="col s12 m6 l6 centered">
        Food Name:<br />
        <asp:TextBox ID="txtFoodName" runat="server" placeholder="Enter Ingredient Name" CssClass="form-control"></asp:TextBox><br />
        Food Category:<br />
        <asp:DropDownList ID="ddlFoodType" runat="server" CssClass="form-control"></asp:DropDownList><br />
        Unit Type:<br />
        <asp:DropDownList ID="ddlUnitType" runat="server" CssClass="form-control"></asp:DropDownList><br />
        <br />
        <asp:Button ID="btnAddFoodItem" runat="server" Text="Add Food Item" OnClick="btnAddFoodItem_Click" CssClass="btn btn-register form-control" />
        </div>
            </div>
            </div>
        </div>
         <asp:RequiredFieldValidator ID="RequiredFoodName" runat="server" ErrorMessage="Ingredient name is required" ForeColor="Red" ControlToValidate="txtFoodName" Display="None"></asp:RequiredFieldValidator>
</asp:Content>


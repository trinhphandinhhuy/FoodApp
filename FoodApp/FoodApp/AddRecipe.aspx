﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRecipe.aspx.cs" Inherits="FoodApp.AddRecipe" MasterPageFile="~/MasterPage/MainLayout.Master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add recipe</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="grey-text center-on-small-only">ADD YOUR RECIPE</h3>
    <asp:ValidationSummary ID="VsRecipe" runat="server" CssClass="alert alert-danger"/>
    <div class="row">
    <div class="col-md-6 col-md-offset-3">
    <div class="form-group">
        <asp:TextBox ID="txtRecipeName" runat="server" CssClass="form-control" placeholder="Recipe name"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Mealtype</label>
        <asp:DropDownList ID="DlRecipeType" runat="server" CssClass="browser-default form-control" DataSourceID="MealTypeData" DataTextField="Name" DataValueField="MealTypeID"></asp:DropDownList>

        <asp:SqlDataSource ID="MealTypeData" runat="server" ConnectionString="" ProviderName="System.Data.OleDb" SelectCommand="SELECT [MealTypeID], [Name] FROM [MealType]"></asp:SqlDataSource>
    <br />
    </div>
    <div class="input-field col s6 l6">
        <i class="material-icons prefix">query_builder</i>
        <asp:TextBox ID="txtCookingTime" runat="server" CssClass="input-field icon_prefix" placeholder="Cooking time"></asp:TextBox>
    </div>
        
    <div class="input-field col s6 l6">
        <i class="material-icons prefix">assignment_ind</i>
        <asp:TextBox ID="txtPortion" runat="server"  CssClass="input-field icon_prefix " placeholder="Portions"></asp:TextBox>
    </div>
 <br />
    <br />
    <div class="form-group">
        <label>Directions</label>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="input-field grey lighten-3" placeholder="Write instruction how to cook this meal" BorderColor="#CCCCCC" Height="150px"></asp:TextBox>
    </div>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <h5>Add Ingredients</h5>
    <div class="col-lg-6">
        <div class="form-group">
        <asp:DropDownList ID="DlIngredients" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="FoodStuffDS" DataTextField="Name" DataValueField="FoodItemID"></asp:DropDownList>
        <asp:SqlDataSource ID="FoodStuffDS" runat="server"  ConnectionString="" ProviderName="System.Data.OleDb" SelectCommand="SELECT [FoodItemID], [Name] FROM [FoodItem]"></asp:SqlDataSource>
    &nbsp;</div>
    <div class="form-group">
        <asp:TextBox ID="txtAmount" runat="server"  CssClass="form-control" placeholder="Amount"></asp:TextBox>
    </div>
    <asp:Button ID="AddIngButton" runat="server" Text="Add Ingredients" OnClick="AddIngButton_Click" />
    <br />
    <br />
        </div>
        <div class="col-lg-6">
    <asp:GridView ID="IngredientRecipeDB"  AutoGenerateColumns="true"  runat="server"></asp:GridView>
        </div>
    </asp:PlaceHolder>
    
    <div class="form-group">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" CssClass="form-control btn btn-register"/>
            </div>
        </div>
    </div>
    </div>
    <asp:RequiredFieldValidator ID="RfvRecipeName" runat="server" ErrorMessage="Recipe name Required" ForeColor="#FF3300" ControlToValidate="txtRecipeName" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvCookingTime" runat="server" ErrorMessage="Cooking time Required" ForeColor="#FF3300" ControlToValidate="txtCookingTime" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvPortion" runat="server" ErrorMessage="Portions Required" ForeColor="#FF3300" ControlToValidate="txtPortion" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvDescription" runat="server" ErrorMessage="Description Required" ForeColor="#FF3300" ControlToValidate="txtDescription" Display="None"></asp:RequiredFieldValidator>
    <asp:Label ID="lblMsg" runat="server" ForeColor="#CC3300"></asp:Label>
        </div></div>
</asp:Content>





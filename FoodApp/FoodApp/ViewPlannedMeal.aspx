﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ViewPlannedMeal.aspx.cs" Inherits="FoodApp.ViewPlannedMeal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container">
            <h3 class="grey-text center">Planned Meal For <asp:Label ID="lblCreatedDate" runat="server"></asp:Label></h3>
            <div class="divider"></div>
            <br />
            <div class="section center">
                <asp:Label ID="lblCheck" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="section">
                <b>Portion: <asp:Label ID="lblPortion" runat="server"></asp:Label></b>
                <asp:DropDownList ID="ddlPortion" runat="server"></asp:DropDownList>
                <asp:Button ID="btnChangePortion" runat="server" Text="Change Portion" OnClick="btnChangePortion_Click" CssClass="form-control btn btn-info" />
                <h5>RECIPE</h5>
                <asp:Table runat="server" ID="tbRecipe" Width="100%" CssClass="striped highlight"></asp:Table>
                <asp:DropDownList ID="ddlRecipe" runat="server"></asp:DropDownList>
                <asp:Button ID="btnAddNewRecipe" runat="server" Text="Add New Recipe To Planned Meal" OnClick="btnAddNewRecipe_Click" CssClass="form-control btn btn-info" />
                <asp:DropDownList ID="ddlChosenRecipe" runat="server"></asp:DropDownList>
                <asp:Button ID="btnRemoveRecipe" runat="server" Text="Remove Recipe From Planned Meal" OnClick="btnRemoveRecipe_Click" CssClass="form-control btn btn-info" />
            </div>
            <div class="section">
                <asp:Button ID="btnCheckStorage" runat="server" Text="Check Storage" OnClick="btnCheckStorage_Click" CssClass="form-control btn btn-info" />
                <asp:Button ID="btnCook" runat="server" Text="Cook" OnClick="btnCook_Click" CssClass="form-control btn btn-info" />
            </div>
        </div>
    </div>
    <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
</asp:Content>
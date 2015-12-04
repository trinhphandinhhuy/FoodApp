﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManageUserRecipes.aspx.cs" Inherits="FoodApp.AdminManageUserRecipes" MasterPageFile="~/MasterPage/MPRecipeManagement.master" %>




<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container center">
    <asp:GridView ID="RecipeTable" runat="server" OnRowDeleting="RecipeTable_RowDeleting" OnRowDataBound="RecipeTable_RowDataBound">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManageUserRecipes.aspx.cs" Inherits="FoodApp.AdminManageUserRecipes" MasterPageFile="~/MasterPage/MPRecipeManagement.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container center">
        <div class="section">
            <h4 class="center">MANAGE USER RECIPE</h4>
        </div>
         <div class="section">
            <asp:GridView ID="RecipeTable" runat="server" OnRowDeleting="RecipeTable_RowDeleting" OnRowDataBound="RecipeTable_RowDataBound" CssClass="striped highlight">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>



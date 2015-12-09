<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManageUserRecipes.aspx.cs" Inherits="FoodApp.AdminManageUserRecipes" MasterPageFile="~/MasterPage/MPRecipeManagement.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container center">
        <div class="section">
            <h3 class="center grey-text">MANAGE USER RECIPE</h3>
        </div>
         <div class="section">
            <asp:GridView ID="RecipeTable" runat="server" OnRowDeleting="RecipeTable_RowDeleting" OnRowDataBound="RecipeTable_RowDataBound" Width="100%" CssClass="striped highlight">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="btn" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>



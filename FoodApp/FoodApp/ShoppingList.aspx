<%@ Page Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ShoppingList.aspx.cs" Inherits="FoodApp.ShoppingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="grey-text center">SHOPPING LIST </h3><br />
    <asp:ListBox ID="lbRecipe" runat="server" Visible="false"></asp:ListBox>
    <asp:ListBox ID="lbRecipePortion" runat="server" Visible="false"></asp:ListBox>
    <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
    <div class="container">
        <div class="row">
            <asp:Panel ID="Panel1" runat="server" CssClass="col s12 m12 l12 center">
                Ingredients & amount you need for the meal: 
                <asp:Table ID="tbShoppingList" runat="server" CssClass="striped highlight"></asp:Table>
                <asp:Button ID="btnAddShoppingList" runat="server" Text="Add Shopping List" CssClass="form-control btn btn-info" OnClick="btnAddShoppingList_Click" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
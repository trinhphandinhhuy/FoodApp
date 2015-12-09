<%@ Page Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ShoppingList.aspx.cs" Inherits="FoodApp.ShoppingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h3 class="grey-text center"> EDIT SHOPPING LIST </h3><br />
        <asp:ListBox ID="lbRecipe" runat="server" Visible="false"></asp:ListBox>
        <asp:ListBox ID="lbRecipePortion" runat="server" Visible="false"></asp:ListBox>
        <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
        <div class="container">
            <div class="row">
        <asp:Panel ID="Panel1" runat="server" CssClass="col s12 m12 l4">
            Ingredients & amount you need for the meal: 
            <asp:Table ID="tbShoppingList" runat="server" CssClass="striped highlight"></asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" CssClass="col s12 m12 l4 center">
            <br />
            <br />
            <i class="large material-icons">trending_flat</i>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" CssClass="col s12 m12 l4">
            Real amount for each ingredient:
            <asp:Table ID="tbRealShoppingList" runat="server" CssClass="striped highlight"></asp:Table>
        </asp:Panel>
             </div>
        <asp:Button ID="btnComfirm" CssClass="btn" runat="server" Text="Confirm Shopping List" OnClick="btnComfirm_Click" />
        </div>
        <asp:Table ID="tbUpdateDB" runat="server">
        </asp:Table>
</asp:Content>
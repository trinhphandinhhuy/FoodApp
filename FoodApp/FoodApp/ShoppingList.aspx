<%@ Page Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ShoppingList.aspx.cs" Inherits="FoodApp.ShoppingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="grey-text center">Ingredients & amount you need for the meal: </h3><br />
    <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
    <div class="container">
        <div class="row">         
            <asp:Panel ID="Panel1" runat="server" CssClass="">   
                <div class="col s12 m8 l8 center">           
                    <asp:Table ID="tbShoppingList" runat="server" CssClass="striped highlight center"></asp:Table><br />
                    <asp:Button ID="btnAddShoppingList" runat="server" Text="Add Shopping List" CssClass="form-control btn btn-info" OnClick="btnAddShoppingList_Click" />
                 </div>   
             </asp:Panel>
        </div>
    </div>
</asp:Content>
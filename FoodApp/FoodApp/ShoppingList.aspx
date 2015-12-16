<%@ Page Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ShoppingList.aspx.cs" Inherits="FoodApp.ShoppingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="grey-text center">Ingredients & amount you need for the meal: </h3><br />
    <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
    <div class="container">
        <div class="row">         
              
                <div class="col s12 m8 l8 offset-m2 offset-l2">           
                    <asp:Table ID="tbShoppingList" runat="server" CssClass="striped highlight form-control"></asp:Table><br />
                    <asp:Button ID="btnAddShoppingList" runat="server" Text="Add Shopping List" CssClass="form-control btn btn-info" OnClick="btnAddShoppingList_Click" />
                 </div>   
             
        </div>
    </div>
</asp:Content>
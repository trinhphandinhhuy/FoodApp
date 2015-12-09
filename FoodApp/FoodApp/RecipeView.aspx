<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPRecipeManagement.master" AutoEventWireup="true" CodeBehind="RecipeView.aspx.cs" Inherits="FoodApp.RecipeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Image ID="RecipeImage" CssClass="responsive-img" runat="server" />
        <div class="container">
            <h4>
                <asp:Label ID="RecipeName" runat="server" Text="Cupcake"></asp:Label></h4>
            <div class="divider"></div>
            <br />
            <div class="chip">
                Created by:
                <asp:Label ID="recipeAuthor" runat="server" Text="coco"></asp:Label>
            </div>
            <div class="chip">
                <asp:Label ID="MealType" runat="server" Text="Soup"></asp:Label><br />
            </div>
            <div class="section">
                <div class="col l6">
                    <b>Portions:</b>
                    <asp:Label ID="portions" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col l6">
                    <b>Cookingtime:</b>
                    <asp:Label ID="cookingtime" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="section">
                <asp:Table runat="server" ID="tbFoodItem" Width="100%" CssClass="striped highlight">

                </asp:Table>
            </div>
            <div class="section">
                <h5>DIRECTION</h5>
                <asp:Label ID="descriptions" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPRecipeManagement.master" AutoEventWireup="true" CodeBehind="RecipeView.aspx.cs" Inherits="FoodApp.RecipeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container">
            <h3 class="grey-text center"><asp:Label ID="RecipeName" runat="server" Text="Cupcake"></asp:Label></h3>
            <div class="divider"></div>
            <br />
            <div class="col l12 center">
            <asp:Image ID="RecipeImage" CssClass="responsive-img materialboxed" runat="server" Width="100%" />
                </div>
            <div class="section center">
            <div class="chip">
                Created by:
                <asp:Label ID="recipeAuthor" runat="server" Text="coco"></asp:Label>
            </div>
            <div class="chip">
                <asp:Label ID="MealType" runat="server" Text="Soup"></asp:Label><br />
            </div>

                </div>
            <div class="section">
                <div class="col l6">
                    <i class="tiny material-icons">perm_identity</i><b>Portions:</b>
                    <asp:Label ID="portions" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col l6">
                    <i class="tiny material-icons">av_timer</i><b>Cookingtime:</b>
                    <asp:Label ID="cookingtime" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="section">
                <h5>INGREDIENTS</h5>
                <asp:Table runat="server" ID="tbFoodItem" Width="100%" CssClass="striped highlight"></asp:Table>
            </div>
            <div class="section">
                <h5>DIRECTION</h5>
                <asp:Label ID="descriptions" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="section">
                <asp:Button ID="btnAddRecipeToOwn" runat="server" Text="Add Recipe To My Own Recipe" OnClick="btnAddRecipeToOwn_Click" CssClass="form-control btn btn-register" />
            </div>
        </div>
    </div>
</asp:Content>

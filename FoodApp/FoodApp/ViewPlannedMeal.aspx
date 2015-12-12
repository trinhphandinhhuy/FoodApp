<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ViewPlannedMeal.aspx.cs" Inherits="FoodApp.ViewPlannedMeal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container">
            <h3 class="grey-text center">Planned Meal For <asp:Label ID="lblCreatedDate" runat="server"></asp:Label></h3>
            <div class="divider"></div>
            <br />
            <div class="section">
                <div class="col l6">
                    <b>Portion: <asp:Label ID="lblPortion" runat="server"></asp:Label></b>
                    <asp:DropDownList ID="ddlPortion" runat="server"></asp:DropDownList>
                    <asp:Button ID="btnChangePortion" runat="server" Text="Change Portion" OnClick="btnChangePortion_Click" CssClass="form-control btn btn-info" />
                </div>
            </div>
            <div class="section">
                <h5>RECIPE</h5>
                <asp:Table runat="server" ID="tbRecipe" Width="100%" CssClass="striped highlight"></asp:Table>
            </div>
            <div class="section">
                <asp:DropDownList ID="ddlRecipe" runat="server"></asp:DropDownList>
                <asp:Button ID="btnAddNewRecipe" runat="server" Text="Add New Recipe To Planned Meal" OnClick="btnAddNewRecipe_Click" CssClass="form-control btn btn-info" />
            </div>
            <div class="section">
                <asp:DropDownList ID="ddlChosenRecipe" runat="server"></asp:DropDownList>
                <asp:Button ID="btnRemoveRecipe" runat="server" Text="Remove Recipe From Planned Meal" OnClick="btnRemoveRecipe_Click" CssClass="form-control btn btn-info" />
            </div>
            <div class="section">
                <asp:Button ID="btnCheckStorage" runat="server" Text="Check Storage" OnClick="btnCheckStorage_Click" CssClass="form-control btn btn-info" />
                <asp:Label ID="lblCheckStorage" runat="server"></asp:Label>
            </div>
            <div class="section">
                <asp:Button ID="btnCook" runat="server" Text="Cook" OnClick="btnCook_Click" CssClass="form-control btn btn-info" />
                <asp:Label ID="lblDone" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <asp:ListBox ID="lbRecipePortion" runat="server" Visible="false"></asp:ListBox>
    <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
</asp:Content>
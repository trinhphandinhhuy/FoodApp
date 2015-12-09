<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ViewPlannedMeal.aspx.cs" Inherits="FoodApp.ViewPlannedMeal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container">
            <h3 class="grey-text center">Planned Meal No. <asp:Label ID="lblPlannedMealID" runat="server"></asp:Label></h3>
            <div class="divider"></div>
            <br />
            <div class="section">
                <div class="col l6">
                    <b>Created Date:</b>
                    <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                </div>
                <div class="col l6">
                    <b>Portion:</b>
                    <asp:Label ID="lblPortion" runat="server"></asp:Label>
                </div>
            </div>
            <div class="section">
                <h5>RECIPE</h5>
                <asp:Table runat="server" ID="tbRecipe" Width="100%" CssClass="striped highlight"></asp:Table>
            </div>
        </div>
    </div>
</asp:Content>

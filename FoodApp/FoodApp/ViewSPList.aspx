<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ViewSPList.aspx.cs" Inherits="FoodApp.ViewSPList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container">
            <h3 class="grey-text center">Shopping List No. <asp:Label ID="lblShoppingListID" runat="server"></asp:Label></h3>
            <div class="divider"></div>
            <br />
            <div class="section">
                <div class="col l6">
                    <b>Created Date:</b>
                    <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                </div>
            </div>
            <div class="section">
                <h5>FOOD ITEMS</h5>
                <asp:Table runat="server" ID="tbFoodItem" Width="100%" CssClass="striped highlight"></asp:Table>
            </div>
        </div>
    </div>
</asp:Content>

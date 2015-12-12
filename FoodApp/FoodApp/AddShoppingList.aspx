<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddShoppingList.aspx.cs" Inherits="FoodApp.AddShoppingList" MasterPageFile="~/MasterPage/MPPlanedMeal.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="grey-text center-on-small-only">Add Shopping List</h3>
        <asp:Label ID="lblCheck" runat="server"></asp:Label>
        <asp:Label ID="lblAmount" runat="server" ForeColor="Red"></asp:Label><br />
        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <asp:DropDownList ID="ddlFoodItem" runat="server"></asp:DropDownList>
        <asp:TextBox ID="txtAmount" runat="server" CssClass="input-field icon_prefix " placeholder="Amount"></asp:TextBox>
        <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
        <asp:Button ID="btnAddFoodItemToShoppingList" runat="server" Text="Add Food Item to Shopping List" OnClick="btnAddFoodItemToShoppingList_Click" class="form-control btn btn-info" />
        <br />
        <asp:Table ID="tbFoodItem" runat="server" Width="100%" CssClass="striped highlight"></asp:Table>
        <br />
        <asp:Button ID="btnConfirmShoppingList" runat="server" Text="Confirm Shopping List" OnClick="btnConfirmShoppingList_Click" class="form-control btn btn-info" />
    </div>
</asp:Content>

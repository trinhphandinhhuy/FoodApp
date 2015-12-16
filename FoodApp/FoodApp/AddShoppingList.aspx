<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddShoppingList.aspx.cs" Inherits="FoodApp.AddShoppingList" MasterPageFile="~/MasterPage/MPPlanedMeal.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="grey-text center">ADD SHOPPING LIST</h3>
        <asp:Label ID="lblCheck" runat="server"></asp:Label>
        <asp:Label ID="lblAmount" runat="server" ForeColor="Red"></asp:Label><br />
        <div class="row">
            <div class="col s12 m4 l4">
                Select Date:<br />
                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col s12 m4 l4">
                Select Ingredients:
                <asp:DropDownList ID="ddlFoodItem" runat="server"></asp:DropDownList>
                Enter real amount:
                <asp:TextBox ID="txtAmount" runat="server" CssClass="input-field icon_prefix " placeholder="Amount"></asp:TextBox>
                <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
                <asp:Button ID="btnAddFoodItemToShoppingList" runat="server" Text="Add Ingredient" OnClick="btnAddFoodItemToShoppingList_Click" class="form-control btn btn-info" />
             </div><br />
            <div class="col s12 m4 l4">
                <asp:Table ID="tbFoodItem" runat="server" Width="100%" CssClass="striped highlight"></asp:Table>
             </div>           
        </div>
        <asp:Button ID="btnConfirmShoppingList" runat="server" Text="Confirm Shopping List" OnClick="btnConfirmShoppingList_Click" class="form-control btn btn-info" />
    </div>
</asp:Content>

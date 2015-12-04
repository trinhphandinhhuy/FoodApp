<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanMeal.aspx.cs" Inherits="FoodApp.PlanMeal" EnableSessionState="True" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plan Meal</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="ddlRecipe" runat="server"></asp:DropDownList>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="btnAddRecipeToPlannedMeal" runat="server" Text="Add Recipe To Planned Meal" OnClick="btnAddRecipeToPlannedMeal_Click" /><br /><br />
            <asp:Button ID="btnRemoveChosenRecipe" runat="server" Text="Remove Chosen Recipe" OnClick="btnRemoveChosenRecipe_Click" /><br /><br />
        </asp:Panel>
        <asp:ListBox ID="lbChosenRecipe" runat="server" Rows="5"></asp:ListBox><br /><br />
        <asp:DropDownList ID="ddlPortion" runat="server"></asp:DropDownList><br /><br />
        <asp:Button ID="btnConfirmPlannedMeal" runat="server" Text="Confirm" OnClick="btnConfirmPlannedMeal_Click" /><br /><br />
    </form>
</body>
</html>
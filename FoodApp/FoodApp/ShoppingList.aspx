<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingList.aspx.cs" Inherits="FoodApp.ShoppingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping List</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListBox ID="lbRecipe" runat="server" Visible="false"></asp:ListBox>
        <asp:ListBox ID="lbRecipePortion" runat="server" Visible="false"></asp:ListBox>
        <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
        <asp:Table ID="tbShoppingList" runat="server"></asp:Table>
    </form>
</body>
</html>

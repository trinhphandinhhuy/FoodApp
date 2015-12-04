<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingList.aspx.cs" Inherits="FoodApp.ShoppingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListBox ID="lbRecipe" runat="server"></asp:ListBox><br /><br />
        <asp:ListBox ID="lbRecipePortion" runat="server"></asp:ListBox><br /><br />
        <asp:Label ID="lblPortion" runat="server"></asp:Label><br /><br />
        <asp:ListBox ID="lbFoodItemID" runat="server"></asp:ListBox><br /><br />
        <asp:ListBox ID="lbFoodItem" runat="server"></asp:ListBox><br /><br />
        <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />
        <asp:Label ID="lblCheck" runat="server"></asp:Label>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListAllIngredient.aspx.cs" Inherits="FoodApp.ListAllIngredient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnListAllIngredient" runat="server" Text="List All Ingredient" CssClass="btn btn-info" OnClick="btnListAllIngredient_Click" />
        <br />
        <br />
        <asp:Table ID="tblListAllIngredient" runat="server" CssClass="table table-striped">
        </asp:Table>
    
    </div>
    </form>
</body>
</html>

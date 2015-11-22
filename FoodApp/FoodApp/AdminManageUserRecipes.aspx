<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManageUserRecipes.aspx.cs" Inherits="FoodApp.AdminManageUserRecipes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:GridView ID="RecipeTable" runat="server" OnRowDeleting ="RecipeTable_RowDeleting" OnRowDataBound = "RecipeTable_RowDataBound">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
            </Columns>
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>

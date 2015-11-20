<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchIngredient.aspx.cs" Inherits="FoodApp.SearchIngredient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Search by name<br />
        <asp:TextBox ID="txtBoxSearchName" runat="server"></asp:TextBox>
        <br />
        or Category<br />
        <asp:DropDownList ID="ddlCategory" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnSearchIngredient" runat="server" OnClick="btnSearchIngredient_Click" Text="Search" />
        <br />
        <br />
        <asp:Table ID="tblSearchIngredient" runat="server">
        </asp:Table>
    
    </div>
    </form>
</body>
</html>

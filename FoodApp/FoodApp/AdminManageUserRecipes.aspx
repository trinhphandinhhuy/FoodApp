<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManageUserRecipes.aspx.cs" Inherits="FoodApp.AdminManageUserRecipes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:GridView ID="RecipeTable" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="RecipeID,UserDataID" DataSourceID="SqlDataSource1" Width="782px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="RecipeTable_RowDataBound">
            <Columns>
                <asp:CommandField ButtonType= "Link" ShowDeleteButton="True" />
                <asp:BoundField DataField="RecipeID" HeaderText="RecipeID" InsertVisible="False" ReadOnly="True" SortExpression="RecipeID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Portion" HeaderText="Portion" SortExpression="Portion" />
                <asp:BoundField DataField="CookingTime" HeaderText="CookingTime" SortExpression="CookingTime" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="MealTypeID" HeaderText="MealTypeID" SortExpression="MealTypeID" />
                <asp:BoundField DataField="UserDataID" HeaderText="UserDataID" ReadOnly="True" SortExpression="UserDataID" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DatabaseforAppConnectionString2 %>"
            DeleteCommand="DELETE FROM [Recipe] WHERE [RecipeID] = ? AND [UserDataID] = ?" 
            SelectCommand="SELECT * FROM [Recipe] WHERE ([UserDataID] &lt;&gt; ?)" 
            ProviderName="<%$ ConnectionStrings:DatabaseforAppConnectionString2.ProviderName %>" >
            
            <DeleteParameters>
                <asp:Parameter Name="RecipeID" Type="Int32" />
                <asp:Parameter Name="UserDataID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="7" Name="UserDataID" Type="Int32" />
            </SelectParameters>
            
        </asp:SqlDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ShoppingListHistory.aspx.cs" Inherits="FoodApp.ShoppingListHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <h3 class="grey-text center"> SHOPPING LIST HISTORY </h3><br />
        
                <div class="row">
                    <div class="col s12 m4 l4">
                        Select day:
                      <asp:Calendar id="datefilterShoppingList" runat="server" TitleStyle-BackColor="#4DB6AC" TitleStyle-ForeColor="White" OnDayRender="datefilterShoppingList_DayRender" OnSelectionChanged="datefilterShoppingList_SelectionChanged">
                 
                      </asp:Calendar>
                    </div>
                    <div class="col s12 m8 l8">
                        <asp:DataList ID="ShoppingList" runat="server">
                            <ItemTemplate>
                                <div class="card">
                                    <div class="card-title">
                                        <a href="ViewSPList.aspx?ShoppingListID=<%#Eval("ShoppingListID")%>"><span class="teal-text">Shopping List On <%#Eval("CreatedDate").ToString().Split(' ')[0]%></span></a>
                                </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            
    </div>
</asp:Content>

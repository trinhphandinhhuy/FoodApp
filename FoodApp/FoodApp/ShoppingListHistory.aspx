<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ShoppingListHistory.aspx.cs" Inherits="FoodApp.ShoppingListHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:DataList ID="ShoppingList" runat="server">
            <ItemTemplate>
                <div class="row">
                    <di class="col s12 m8 l8">
                        <div class="card">
                            <div class="card-title">
                                <a href="ViewSPList.aspx?ShoppingListID=<%#Eval("ShoppingListID")%>"><span class="teal-text">Shopping List On <%#Eval("CreatedDate").ToString().Split(' ')[0]%></span></a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>

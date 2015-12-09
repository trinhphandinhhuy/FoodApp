<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ShoppingListHistory.aspx.cs" Inherits="FoodApp.ShoppingListHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:DataList ID="ShoppingList" runat="server">
            <ItemTemplate>
                <div class="row">
                <div class="col s12 m8 l8">
                    <div class="card">
                        <div class="card-title">
                    
                            <span class="teal-text">Shopping List number <%#Eval("ShoppingListID")%></span>
                        </div>
                        <div class="card-content">
                            <p>
                               Created Date: <%#Eval("CreatedDate")%>
                            </p>
                        </div>
                        <div class="card-action">
                            <a href="ViewSPList.aspx">View this list</a>
                        </div>
                    </div>

                </div>
                </div>

            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>

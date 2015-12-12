<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="PlannedMealHistory.aspx.cs" Inherits="FoodApp.PlannedMealHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col s12 m3 l3"></div>
            <div class="col s12 m8 l8">
                <asp:DataList ID="PlannedMeal" runat="server">
                    <ItemTemplate>        
                        <div class="card">
                            <div class="card-title">
                                <a href="ViewPlannedMeal.aspx?PlannedMealID=<%#Eval("PlannedMealID")%>"><span class="teal-text">Planned Meal For <%#Eval("CreatedDate")%></span></a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>

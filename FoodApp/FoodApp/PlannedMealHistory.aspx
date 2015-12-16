<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="PlannedMealHistory.aspx.cs" Inherits="FoodApp.PlannedMealHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <h3 class="grey-text center"> PLANNED MEAL HISTORY </h3><br />
        <div class="row">
            <div class="col s12 m4 l4">
                Select day:
              <asp:Calendar id="datefilterPlanMeal" runat="server" OnDayRender="datefilterPlanMeal_DayRender" OnSelectionChanged="datefilterPlanMeal_SelectionChanged" TitleStyle-BackColor="#4DB6AC" TitleStyle-ForeColor="White">
                 
              </asp:Calendar>
            </div>
            <div class="col s12 m8 l8">
                <asp:DataList ID="PlannedMeal" runat="server">
                    <ItemTemplate>        
                        <div class="card">
                            <div class="card-title">
                                <a href="ViewPlannedMeal.aspx?PlannedMealID=<%#Eval("PlannedMealID")%>"><span class="teal-text">Planned Meal For <%#Eval("CreatedDate").ToString().Split(' ')[0]%></span></a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
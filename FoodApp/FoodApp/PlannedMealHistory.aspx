<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="PlannedMealHistory.aspx.cs" Inherits="FoodApp.PlannedMealHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <h3 class="grey-text center"> PLANNED MEAL HISTORY </h3><br />
        <div class="row">
            <div class="col s12 m4 l4">
                 <div class="text-lighten-4 center"><h5>Select day</h5></div>
              <asp:Calendar id="datefilterPlanMeal" runat="server" OnDayRender="datefilterPlanMeal_DayRender" OnSelectionChanged="datefilterPlanMeal_SelectionChanged" TitleStyle-BackColor="#4DB6AC" TitleStyle-ForeColor="White">
                 
              </asp:Calendar>
            </div>
            <div class="col s12 m8 l8">
                <div class="collection">
                <asp:DataList ID="PlannedMeal" runat="server">
                    <ItemTemplate>       
                        
                                <a href="ViewPlannedMeal.aspx?PlannedMealID=<%#Eval("PlannedMealID")%>"  class="collection-item"><i class="material-icons">grade</i><span class="teal-text">Planned Meal For <%#Eval("CreatedDate").ToString().Split(' ')[0]%></span></a>
                       
                    </ItemTemplate>
                </asp:DataList>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
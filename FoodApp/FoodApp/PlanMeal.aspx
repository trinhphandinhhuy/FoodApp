<%@ Page Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="PlanMeal.aspx.cs" Inherits="FoodApp.PlanMeal" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="grey-text center"> ADD PLANNED MEAL </h3><br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container">
                    <div class="row">
                    <asp:Panel ID="Panel2" runat="server" CssClass="col s12 m12 l4">
                        Recipes:
                        <asp:DropDownList ID="ddlRecipe" runat="server"></asp:DropDownList>
                    </asp:Panel>
                
                    <asp:Panel ID="Panel1" runat="server" CssClass="col s12 m12 l4">
                    <asp:Button ID="btnAddRecipeToPlannedMeal" Width="100%" runat="server" Text="Add Recipe(s)" OnClick="btnAddRecipeToPlannedMeal_Click" CssClass="form-control btn btn-register" /><br /><br />
                    <asp:Button ID="btnRemoveChosenRecipe" Width="100%" runat="server" Text="Remove Chosen Recipe" OnClick="btnRemoveChosenRecipe_Click" CssClass="form-control btn btn-register" /><br /><br />
                    Portion: <asp:DropDownList ID="ddlPortion" runat="server"></asp:DropDownList>
                    </asp:Panel>
                    
                    <asp:Panel ID="Panel3" runat="server" CssClass="col s12 m12 l4">
                        Added Recipes:
                        <asp:ListBox ID="lbChosenRecipe" runat="server" Rows="5"></asp:ListBox><br /><br />
                    </asp:Panel>
                
                
                
                        <asp:Label ID="lblCheckChosenRecipe" runat="server"></asp:Label>
                    </div></div>
                    </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnAddRecipeToPlannedMeal" />
                <asp:PostBackTrigger ControlID="btnRemoveChosenRecipe" />
            </Triggers>
        </asp:UpdatePanel>
    <div class="row">
        <div class="col l4 offset-l4">
    <asp:Button ID="btnConfirmPlannedMeal" runat="server" Text="Confirm" OnClick="btnConfirmPlannedMeal_Click" CssClass="form-control btn centered"/><br /><br />
        </div>
        </div>
</asp:Content>
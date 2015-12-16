<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPPlanedMeal.master" AutoEventWireup="true" CodeBehind="ViewPlannedMeal.aspx.cs" Inherits="FoodApp.ViewPlannedMeal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
            <h3 class="grey-text center">Planned Meal For <asp:Label ID="lblCreatedDate" runat="server"></asp:Label></h3>
            <div class="divider"></div>
            <br />
            <div class="section center">
                <asp:Label ID="lblCheck" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="row">
            <div class="section col s12 m4 l4">
                <b>Portion: <asp:Label ID="lblPortion" runat="server"></asp:Label></b>
                <h5>RECIPE</h5>
                <asp:Table runat="server" ID="tbRecipe" Width="100%" CssClass="striped highlight"></asp:Table>
                <br />
            </div>
            <div class="section col s12 m8 l8">
                <div class="col s12 m12 l12">
                    <asp:DropDownList ID="ddlPortion" runat="server" CssClass="col s12 m4 l4"></asp:DropDownList>
                    <div class="col s12 m4 l4">
                        <asp:Button ID="btnChangePortion" runat="server" Text="Change Portion" OnClick="btnChangePortion_Click" CssClass="form-control btn btn-info" />
                    </div>
                 </div>

                    <div class="col s12 m6 l6">
                    <asp:DropDownList ID="ddlRecipe" runat="server"></asp:DropDownList>
                    <asp:Button ID="btnAddNewRecipe" runat="server" Text="Add New Recipe" OnClick="btnAddNewRecipe_Click" CssClass="form-control btn btn-info" />
                    
                </div>
                <div class="col s12 m6 l6">
                    <asp:DropDownList ID="ddlChosenRecipe" runat="server"></asp:DropDownList>
                    <asp:Button ID="btnRemoveRecipe" runat="server" Text="Remove Recipe" OnClick="btnRemoveRecipe_Click" CssClass="form-control btn btn-info" />
                </div>
                <br />
                
                </div>

             </div>
        
                <div class="center">
                    <asp:Button ID="btnCheckStorage" runat="server" Text="Check Storage" OnClick="btnCheckStorage_Click" CssClass="form-control btn btn-info" />
                    <asp:Button ID="btnCook" runat="server" Text="Cook" OnClick="btnCook_Click" CssClass="form-control btn btn-info" />
                </div>
    </div>
    <asp:ListBox ID="lbFoodItemID" runat="server" Visible="false"></asp:ListBox>
</asp:Content>
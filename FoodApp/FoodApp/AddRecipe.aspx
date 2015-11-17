<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRecipe.aspx.cs" Inherits="FoodApp.AddRecipe" MasterPageFile="~/MasterPage/DashBoard.Master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add recipe</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ValidationSummary ID="VsRecipe" runat="server" CssClass="alert alert-danger"/>
    <div class="form-group">
        <asp:TextBox ID="txtRecipeName" runat="server" CssClass="form-control" placeholder="Recipe name"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtCookingTime" runat="server" CssClass="form-control" placeholder="Cooking time"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtPortion" runat="server"  CssClass="form-control" placeholder="Portions"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Descriptions"></asp:TextBox>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" CssClass="form-control btn btn-register"/>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <a href="Dashboard.aspx" class="form-control btn btn-info" role="button">Comback to dashboard</a>
            </div>
        </div>
    </div>
    <asp:RequiredFieldValidator ID="RfvRecipeName" runat="server" ErrorMessage="Recipe name Required" ForeColor="#FF3300" ControlToValidate="txtRecipeName" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvCookingTime" runat="server" ErrorMessage="Cooking time Required" ForeColor="#FF3300" ControlToValidate="txtCookingTime" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvPortion" runat="server" ErrorMessage="Portions Required" ForeColor="#FF3300" ControlToValidate="txtPortion" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvDescription" runat="server" ErrorMessage="Description Required" ForeColor="#FF3300" ControlToValidate="txtDiscription" Display="None"></asp:RequiredFieldValidator>
    <asp:Label ID="lblMsg" runat="server" ForeColor="#CC3300"></asp:Label>
</asp:Content>



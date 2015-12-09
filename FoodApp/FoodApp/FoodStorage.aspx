<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPIngreManagement.master" AutoEventWireup="true" CodeBehind="FoodStorage.aspx.cs" Inherits="FoodApp.FoodStorage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">

        <div class="row">
            <h3 class="center grey-text shades-text">FOOD STORAGE</h3>
            <div class="col s12 m4 l4">
                Search by name<br />
                <asp:TextBox ID="txtBoxSearchName" runat="server" CssClass="form-control"></asp:TextBox>
                in Category: 
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
            </asp:DropDownList>
                <asp:Button ID="btnSearchIngredient" runat="server" OnClick="btnSearchIngredient_Click" Text="Search" CssClass="btn btn-register form-control" />
                <br />
                <br />
            </div>
            <div class="col s12 m8 l8 grey lighten-4">
                <asp:GridView ID="FoodTable" runat="server" AutoGenerateColumns="true" Width="100%" CssClass="striped highlight"></asp:GridView>
            </div>
        </div>
         
    </div>
</asp:Content>

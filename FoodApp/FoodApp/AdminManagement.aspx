<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManagement.aspx.cs" Inherits="FoodApp.AdminAccount" MasterPageFile="~/MasterPage/MPUserManagement.master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h4 class="grey-text center">USER MANAGEMENT</h4>
        <div class="section">
            <asp:GridView ID="UserDataTable" CssClass="striped highlight" runat="server" Width="100%"></asp:GridView><br /><br />
        </div>
    </div>
</asp:Content>
  

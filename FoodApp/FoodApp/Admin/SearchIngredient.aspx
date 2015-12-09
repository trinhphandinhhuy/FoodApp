﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MPIngreManagement.master" CodeBehind="SearchIngredient.aspx.cs" Inherits="FoodApp.SearchIngredient" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="min-height:57vh">
         <div class="section"><h3 class="center grey-text">SEARCH INGREDIENTS</h3></div>
         <div class="section">
        <div class="row">
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
        
        
        <div class="col s12 m8 l8">
            <asp:GridView ID="FoodTable" runat="server" AutoGenerateColumns="false" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" OnRowDataBound="FoodTable_RowDataBound" OnRowDeleting="FoodTable_RowDeleting" OnRowEditing="FoodTable_RowEditing" OnRowUpdating="FoodTable_RowUpdating" OnRowCancelingEdit="FoodTable_RowCancelingEdit" Width="100%" CssClass="striped highlight">
                <Columns>
                    <asp:BoundField DataField="FoodItemID" HeaderText="ID" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFoodName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUpdateFoodName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit">
                        <ItemTemplate>
                            <asp:Label ID="lblUnitType" runat="server" Text='<%# Bind("UnitType") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlUpdateUnitType" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Food Type">
                        <ItemTemplate>
                            <asp:Label ID="lblFoodType" runat="server" Text='<%# Bind("FoodTypeID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlUpdateFoodType" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
            </div>
            </div>
    </div>
</asp:Content>



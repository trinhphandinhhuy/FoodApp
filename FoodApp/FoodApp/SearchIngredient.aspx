﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/DashBoard.Master" CodeBehind="SearchIngredient.aspx.cs" Inherits="FoodApp.SearchIngredient" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ImageButton ID="Recipes" runat="server" ImageUrl="~/img/recipe.png" CssClass="navIcon" OnClick="Recipes_Click" /> 
    <asp:ImageButton ID="Ingredients" runat="server" ImageUrl="~/img/ingredients.png" CssClass="navIcon" OnClick="Ingredients_Click" />  
    <asp:ImageButton ID="MyList" runat="server" ImageUrl="~/img/personal.png" CssClass="navIcon" OnClick="MyList_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnAddIngredient" runat="server" Text="Add Ingredient" CssClass="btn btn-info" Width="100%" OnClick="btnAddIngredient_Click" />
    <asp:Button ID="btnListAllIngredient" runat="server" Text="List All Ingredient" CssClass="btn btn-info" Width="100%" OnClick="btnListAllIngredient_Click" />
    <asp:Button ID="Button1" runat="server" Text="Search Ingredient" CssClass="btn btn-info" Width="100%" OnClick="btnSearchIngredient1_Click" />
    <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="100%" Cssclass="btn btn-danger" OnClick="btnLogout_Click"/>
</asp:Content>

    <asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <div class="row">
       <div class="col-md-6 col-md-offset-3">   
        Search by name<br />
        <asp:TextBox ID="txtBoxSearchName" runat="server" CssClass="form-control"></asp:TextBox> in Category: 
        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
        </asp:DropDownList>
        <asp:Button ID="btnSearchIngredient" runat="server" OnClick="btnSearchIngredient_Click" Text="Search" CssClass="btn btn-register form-control" />
        <br />
        <br />
        </div>
        <div class="col-md-12 col-lg-12">  
        <asp:GridView ID="FoodTable" runat="server" AutoGenerateColumns="false" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" OnRowDataBound="FoodTable_RowDataBound" OnRowDeleting="FoodTable_RowDeleting" OnRowEditing="FoodTable_RowEditing" OnRowUpdating="FoodTable_RowUpdating" OnRowCancelingEdit="FoodTable_RowCancelingEdit" Width="100%">
            <Columns>
                <asp:BoundField DataField="FoodItemID" HeaderText="Food Item ID" ReadOnly="true" />
                <asp:TemplateField HeaderText="Food Name">
                    <ItemTemplate>
                        <asp:Label ID="lblFoodName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUpdateFoodName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Type">
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
    </asp:Content> 
   


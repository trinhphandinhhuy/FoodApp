﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MPRecipeManagement.master" CodeBehind="ExploringRecipes.aspx.cs" Inherits="FoodApp.ExploringRecipes" EnableSessionState="True" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" >
        <asp:Repeater ID="Recipe" runat="server">
            <ItemTemplate>
                <div class="col l4 s12 m6 " >
                    <div class="card">
                        <div class="card-image" style="height:300px;">
                            <img class="responsive-img" src="<%#Eval("ImageURL")%>" />
                            <span class="card-title teal-text"><%#Eval("Name")%></span>
                        </div>
                        <div class="card-content">
                            <p>Recipe by: <%#Eval("Username")%></p>
                        </div>
                        <div class="card-action">
                            <a href="RecipeView.aspx">Viewmore</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>


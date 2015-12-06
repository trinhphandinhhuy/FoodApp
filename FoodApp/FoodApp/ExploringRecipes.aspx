<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MPRecipeManagement.master" CodeBehind="ExploringRecipes.aspx.cs" Inherits="FoodApp.ExploringRecipes" EnableSessionState="True" %>




<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:DataList ID="RecipeList" runat="server">
            <ItemTemplate>
                <div class="col l3">
                    <div class="card">
                        <div class="card-image">
                            <img src="<%#Eval("ImageURL")%>" height="200" width="200" />
                            <span class="card-title teal-text"><%#Eval("Name")%></span>
                        </div>
                        <div class="card-content">
                            <p>
                               Recipe by: <%#Eval("Username")%>
                            </p>
                        </div>
                        <div class="card-action">
                            <a href="RecipeView.aspx">Viewmore</a>
                        </div>
                    </div>

                </div>


            </ItemTemplate>
        </asp:DataList>
    </div>


</asp:Content>


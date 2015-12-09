<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MPRecipeManagement.master" CodeBehind="ExploringRecipes.aspx.cs" Inherits="FoodApp.ExploringRecipes" EnableSessionState="True" %>




<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row  ">
        <asp:Repeater ID="Recipe" runat="server" DataSourceID="SqlDataSource1">


            <ItemTemplate>

                <div class="col l4 s12 m6 ">
                    <div class="card">


                        <div class="card-image" style="height: 300px;">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ImageURL")%>' CssClass="responsive-img" />
                            <span class="card-title teal-text">
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="RecipeView.aspx" OnClick="LinkButton1_Click">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Name")%>'></asp:Label></asp:LinkButton></span>
                        </div>
                        <div class="card-content">
                            <p>
                                Recipe by:<asp:Label ID="Label1" runat="server" Text='<%#Eval("Username")%>'></asp:Label>
                            </p>
                        </div>
                        <div class="card-action">
                            <a href="RecipeView.aspx">Viewmore</a>
                        </div>
                    </div>
                </div>


            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnnectExplore %>" ProviderName="<%$ ConnectionStrings:cnnectExplore.ProviderName %>" SelectCommand="SELECT Recipe.Name, Recipe.ImageURL, UserData.Username FROM (Recipe INNER JOIN UserData ON Recipe.UserDataID = UserData.UserDataID)"></asp:SqlDataSource>

    </div>



</asp:Content>


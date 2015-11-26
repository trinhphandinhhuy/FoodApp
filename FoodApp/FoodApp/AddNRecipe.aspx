<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainLayout.Master" AutoEventWireup="true" CodeBehind="AddNRecipe.aspx.cs" Inherits="FoodApp.AddNRecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="index-banner grey lighten-2">
        <div class="section no-pad-bot container">
            <h4>ADD RECIPE</h4>
            <div class="col s12">
                <div class="col s8 m5 l3 center">
                  
                    <asp:FileUpload ID="FileUpload1" Visible="true"  runat="server" CssClass="active" />
                
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
                     <br />
               <div class="col s8 m5 l3 center">
                <asp:Image ID="Image1" CssClass="responsive-img" runat="server" />
                   </div>
                <br />
                <asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
               
               
                <asp:TextBox CssClass="input-field" placeholder="Tittle" ID="txtRecipe" runat="server"></asp:TextBox>
            </div>
                </div>
        </div>

    </div>
    <div class="container">
        <br />
        Description
        <asp:TextBox CssClass="input-field" placeholder="Tell us about your recipe, where it comefrom, why do you like it" ID="txtDescription" runat="server"></asp:TextBox>
        Meal type
        
        <asp:DropDownList ID="DlRecipeType" runat="server" DataSourceID="MealTypeData" DataTextField="Name" DataValueField="MealTypeID"></asp:DropDownList>

        <asp:SqlDataSource ID="MealTypeData" runat="server" ConnectionString="" ProviderName="System.Data.OleDb" SelectCommand="SELECT [MealTypeID], [Name] FROM [MealType]" OnSelecting="MealTypeData_Selecting"></asp:SqlDataSource>

  
  
        <asp:TextBox ID="txtCookingTime" runat="server" CssClass="form-control" placeholder="Cooking time"></asp:TextBox>
   
    
        <asp:TextBox ID="txtPortion" runat="server"  CssClass="form-control" placeholder="Portions"></asp:TextBox>
   
    
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Descriptions"></asp:TextBox>
   
    
        <h2>ADD INGREDIENTS</h2>
        <div class="col-lg-6">
        <asp:DropDownList ID="DlIngredients" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="FoodStuffDS" DataTextField="Name" DataValueField="FoodItemID"></asp:DropDownList>
        <asp:SqlDataSource ID="FoodStuffDS" runat="server"  ConnectionString="" ProviderName="System.Data.OleDb" SelectCommand="SELECT [FoodItemID], [Name] FROM [FoodItem]"></asp:SqlDataSource>
        &nbsp;
    
        <asp:TextBox ID="txtAmount" runat="server"  CssClass="form-control" placeholder="Amount"></asp:TextBox>
    
        <asp:Button ID="AddIngButton" runat="server" Text="Add Ingredients" />
        <br />
        <br />
        </div>
        <div class="col-lg-6">
    <asp:GridView ID="IngredientRecipeDB"  AutoGenerateColumns="true"  runat="server"></asp:GridView>
        </div>
        <div class="col-sm-6 col-sm-offset-3">
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm"  CssClass="form-control btn btn-register"/>
        </div>
        </div>
  
    
    
        

</asp:Content>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRecipe.aspx.cs" Inherits="FoodApp.EditRecipe" MasterPageFile="~/MasterPage/MPRecipeManagement.master" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="grey-text center-on-small-only"> EDIT YOUR RECIPE </h3>
        <asp:ValidationSummary ID="VsRecipe" runat="server" CssClass="alert alert-danger" />
        <div class="form-group">
            <div class="row">
                <div class="col-sm-6 col-sm-offset-3">
                     <br />  <br />  <br />
                    <asp:Button ID="Button2" runat="server" Text="Back to My Recipes" OnClick="btnBack_Click" CssClass="form-control btn btn-register" />
                    <br />  <br />
                </div>

            </div>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtRecipeName" runat="server" CssClass="form-control" placeholder="RECIPE NAME"></asp:TextBox>
        </div>

        <div class="upload-link container">
            <div id="wrapper">
                <input id="fileUpload" type="file" /><br />
                <div id="image-holder"></div>
            </div>

        </div>

        <div class="form-group">
            <asp:Label ID="LblMealType" runat="server" Text=" "></asp:Label>
            <asp:DropDownList ID="DlRecipeType" runat="server" CssClass="browser-default form-control" DataSourceID="MealTypeData" DataTextField="Name" DataValueField="MealTypeID" OnSelectedIndexChanged="MealType_SelectedIndexChanged"></asp:DropDownList>

            <asp:SqlDataSource ID="MealTypeData" runat="server" ConnectionString="" ProviderName="System.Data.OleDb" SelectCommand="SELECT [MealTypeID], [Name] FROM [MealType]"></asp:SqlDataSource>
            <br />
        </div>

        <div class="input-field col s6 l6">
            <i class="material-icons prefix">query_builder</i>
            <asp:TextBox ID="txtCookingTime" runat="server" CssClass="input-field icon_prefix" placeholder="Cooking time (minutes)"></asp:TextBox>
        </div>

        <div class="input-field col s6 l6">
            <i class="material-icons prefix">assignment_ind</i>
            <asp:TextBox ID="txtPortion" runat="server" CssClass="input-field icon_prefix " placeholder="Portions"></asp:TextBox>
        </div>
        <br />
        <br />

        <div class="form-group">
            <label> Directions </label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="input-field grey lighten-3" placeholder="Write instruction how to cook this meal" BorderColor="#CCCCCC" Height="150px"></asp:TextBox>
        </div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <br />
            <h5> Add Ingredients </h5>
           
            <div class="col-lg-6">
                <asp:GridView ID="IngredientRecipeDB" AutoGenerateColumns="false" 
                    runat="server" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowDeleting="IngredientRecipeDB_RowDeleting" OnRowEditing="IngredientRecipeDB_RowEditing"
                    OnRowDataBound="IngredientRecipeDB_RowDataBound"  OnRowUpdating="IngredientRecipeDB_RowUpdating" OnRowCancelingEdit="IngredientRecipeDB_RowCancelingEdit">
                    <Columns>

                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:Label ID="lblIngName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlUpdateIngName" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:Label ID="lblIngAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtUpdateIngAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:Label ID="lblUnitType" runat="server" Text='<%# Bind("UnitType") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                </Columns>
                </asp:GridView>
                <br />
                <br />
            </div>

            <div class="col-lg-6">
                <div class="form-group">
                    <asp:DropDownList ID="DlIngredients" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="FoodStuffDS" DataTextField="Name" DataValueField="FoodItemID"></asp:DropDownList>
                    <asp:SqlDataSource ID="FoodStuffDS" runat="server" ConnectionString="" ProviderName="System.Data.OleDb" SelectCommand="SELECT [FoodItemID], [Name] FROM [FoodItem]"></asp:SqlDataSource>
                    &nbsp;
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder="Amount"></asp:TextBox>
                </div>
                 <br />
                <asp:Button ID="AddIngButton" runat="server" Text="Add Ingredients" OnClick="AddIngButton_Click" />
                <br /><br /><br />
            </div>
            
        </asp:PlaceHolder>

        <div class="form-group">
            <div class="row">
                <div class="col-sm-6 col-sm-offset-3">
                     <br />
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" CssClass="form-control btn btn-register" />
                    <br />
                </div>

            </div>
        </div>
    </div>
    <asp:RequiredFieldValidator ID="RfvRecipeName" runat="server" ErrorMessage="Recipe name Required" ForeColor="#FF3300" ControlToValidate="txtRecipeName" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvCookingTime" runat="server" ErrorMessage="Cooking time Required" ForeColor="#FF3300" ControlToValidate="txtCookingTime" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvPortion" runat="server" ErrorMessage="Portions Required" ForeColor="#FF3300" ControlToValidate="txtPortion" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvDescription" runat="server" ErrorMessage="Description Required" ForeColor="#FF3300" ControlToValidate="txtDescription" Display="None"></asp:RequiredFieldValidator>
  
      <asp:Label ID="lblMsg" runat="server" ForeColor="#CC3300"></asp:Label>
<script>//*
    $("#fileUpload").on('change', function () {

        if (typeof (FileReader) != "undefined") {

            var image_holder = $("#image-holder");
            image_holder.empty();

            var reader = new FileReader();
            reader.onload = function (e) {
                $("<img />", {
                    "src": e.target.result,
                    "class": "thumb-image"
                }).appendTo(image_holder);

            }
            image_holder.show();
            reader.readAsDataURL($(this)[0].files[0]);
        } else {
            alert("This browser does not support FileReader.");
        }
    });
    //*</script>

</asp:Content>






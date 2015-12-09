﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRecipe.aspx.cs" Inherits="FoodApp.AddRecipe" MasterPageFile="~/MasterPage/MPRecipeManagement.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="grey-text center-on-small-only">ADD YOUR RECIPE</h3>
        <asp:ValidationSummary ID="VsRecipe" runat="server" CssClass="alert alert-danger" />
    </div>
    <div class="container">
        <div class="form-group">
            <asp:TextBox ID="txtRecipeName" runat="server" CssClass="form-control" placeholder="RECIPE NAME"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Mealtype</label>
            <asp:DropDownList ID="DlRecipeType" runat="server" CssClass="browser-default form-control" DataSourceID="MealTypeData" DataTextField="Name" DataValueField="MealTypeID"></asp:DropDownList>
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
        <br /><br />
        <div class="form-group">
            <label>Directions</label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="input-field grey lighten-3" placeholder="Write instruction how to cook this meal" BorderColor="#CCCCCC" Height="150px"></asp:TextBox>
        </div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <h5>Add Ingredients</h5>
            <div class="col l6">
                <div class="form-group">
                    <asp:DropDownList ID="DlIngredients" CssClass="form-control" runat="server" DataSourceID="FoodStuffDS" DataTextField="Name" DataValueField="FoodItemID"></asp:DropDownList>
                    <asp:SqlDataSource ID="FoodStuffDS" runat="server" ConnectionString="" ProviderName="System.Data.OleDb" SelectCommand="SELECT [FoodItemID], [Name] FROM [FoodItem]"></asp:SqlDataSource>
                    &nbsp;
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtAmount" runat="server" placeholder="Amount"></asp:TextBox>
                </div>
                <asp:Button ID="AddIngButton" runat="server" Text="Add Ingredients" OnClick="AddIngButton_Click" />
                <asp:ListBox ID="lbChosenFoodItemID" runat="server" Visible="false"></asp:ListBox>
                <asp:Table ID="tbChosenFoodItem" runat="server" BorderWidth="1" BorderColor="Black" BorderStyle="Solid"></asp:Table>
            </div>
        </asp:PlaceHolder>
    </div>
    <div class="container">
        <div class="upload-link container">
            <div id="wrapper">
                <asp:FileUpload ID="fileUpload" class="fileUpload" runat="server" /><br />
                <div id="image-holder" class="col s12 l9 center"></div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="form-group">
            <div class="col s6 offset-s3">
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" CssClass="form-control btn btn-register" />
            </div>
        </div>
    </div>
    <asp:RequiredFieldValidator ID="RfvRecipeName" runat="server" ErrorMessage="Recipe name Required" ForeColor="#FF3300" ControlToValidate="txtRecipeName" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvCookingTime" runat="server" ErrorMessage="Cooking time Required" ForeColor="#FF3300" ControlToValidate="txtCookingTime" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvPortion" runat="server" ErrorMessage="Portions Required" ForeColor="#FF3300" ControlToValidate="txtPortion" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RfvDescription" runat="server" ErrorMessage="Description Required" ForeColor="#FF3300" ControlToValidate="txtDescription" Display="None"></asp:RequiredFieldValidator>
    <asp:Label ID="lblMsg" runat="server" ForeColor="#CC3300"></asp:Label>
    <script>//*
        $(document).ready(function () {
            $(".fileUpload").change(function () {

                //Get count of selected files
                var countFiles = $(this)[0].files.length;

                var imgPath = $(this)[0].value;
                var extn = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
                var image_holder = $("#image-holder");
                image_holder.empty();

                if (extn == "gif" || extn == "png" || extn == "jpg" || extn == "jpeg") {
                    if (typeof (FileReader) != "undefined") {

                        //loop for each file selected for uploaded.
                        for (var i = 0; i < countFiles; i++) {

                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $("<img />", {
                                    "src": e.target.result,
                                    "class": "thumb-image"
                                }).appendTo(image_holder);
                            }

                            image_holder.show();
                            reader.readAsDataURL($(this)[0].files[i]);
                        }

                    } else {
                        alert("This browser does not support FileReader.");
                    }
                } else {
                    alert("Pls select only images");
                }
            });
        });
        //*</script>
</asp:Content>






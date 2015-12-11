<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MainLayout.Master" CodeBehind="ChangeUsernameAndEmail.aspx.cs" Inherits="FoodApp.UserAccount" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="min-height:64vh" >
        <div class="section">
            <h3 class="center grey-text">EDIT PROFILE</h3>
        </div>
        <div class="section">
            <div class="col-md-6 col-md-offset-3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" /><br />
                Username:<br />
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox><br />
                Email:<br />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox><br />
                <br />
                <div class="section center">
                    <asp:Button ID="btnChangeUsernameAndEmailAddress" runat="server" Text="Save Change(s)" OnClick="btnChangeUsernameAndEmailAddress_Click" CssClass="btn btn-register form-control" /><br />
                    <asp:RequiredFieldValidator ID="RequiredUsername" runat="server" ErrorMessage="Please enter an username" ForeColor="Red" ControlToValidate="txtUsername" Display="None"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="RequiredEmailAddress" runat="server" ErrorMessage="Please enter an email address" ForeColor="Red" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionEmailAddress" runat="server" ErrorMessage="Invalid E-mail Address" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator><br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

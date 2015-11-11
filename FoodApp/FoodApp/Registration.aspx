<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" MasterPageFile="~/MasterPage/loginPage1.Master" Inherits="FoodApp.Registration" %>


    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Registration </title>
    <style type="text/css">
        .style4
        {
            width: 212px;
        }
        .style7
        {
            width: 212px;
            height: 31px;
        }
        .style9
        {
            height: 26px;
        }
        .style11
        {
            width: 259px;
        }
        .style12
        {
            width: 259px;
            height: 31px;
        }

        td
        {
            text-align: center;
        }

    </style>
    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
        <table style="border: 1pt solid #6666FF; width: 60%; height: 424px; font-family: Verdana;
            border-collapse: collapse; background-color: #ffffff;" >
            <tr>
                <td colspan="3" class="style9">
                    <asp:Label ID="lblHeader" runat="server" Text="Registration Form" Font-Bold="True"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style11" >
                    <asp:Label ID="lblUserName" runat="server" Text="Username :"></asp:Label>
                </td>
                <td class="style11" >
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td class="style4" >
                    <asp:RequiredFieldValidator ID="RfvUserName" runat="server" ErrorMessage="* Required"
                        ForeColor="#FF3300" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="lblEmail" runat="server" Text="E-Mail :"></asp:Label>
                </td>
                <td class="style11" >
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td class="style4">
                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ErrorMessage="* Required"
                        ForeColor="#FF3300" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RxvEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Invalid E-mail" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td class="style11" >
                    <asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
                </td>
                <td class="style11" >
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style4" >
                    <asp:RequiredFieldValidator ID="RfvPwd" runat="server" ErrorMessage="* Required"
                        ForeColor="#FF3300" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="style11">
                    <asp:Label ID="lblConfirmPwd" runat="server" Text="Confirm Pasword :"></asp:Label>
                </td>
                <td class="style11" >
                    <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style4" >
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RfvCnfrmPwd" runat="server" ErrorMessage="* Required"
                        ForeColor="#FF3300" ControlToValidate="txtConfirmPwd"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CvCnfmPwd" runat="server" ErrorMessage="Password and Confirm Password didnt matched"
                        ForeColor="#FF3300" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPwd"></asp:CompareValidator>
                </td>
            </tr>
           
            <tr>
            <td class="style12">
                &nbsp;
                <asp:Label ID="lblMsg" runat="server" ForeColor="#CC3300"></asp:Label>
            </td>
            <td class="style12">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;
                <asp:Button ID="btnClear" runat="server" CausesValidation="False" OnClick="btnClear_Click"
                    Text="Clear" />
            </td>
            <td class="style7">
            </td>
            </tr>
        </table>

    </asp:Content>


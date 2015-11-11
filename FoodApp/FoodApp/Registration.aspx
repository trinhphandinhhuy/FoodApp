<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FoodApp.Registration" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        .auto-style1 {
            width: 752px;
        }
        .auto-style2 {
            width: 259px;
            height: 56px;
        }
        .auto-style3 {
            width: 212px;
            height: 56px;
        }
        .auto-style4 {
            width: 259px;
            height: 32px;
        }
        .auto-style5 {
            width: 212px;
            height: 32px;
        }
        .auto-style8 {
            width: 259px;
            height: 46px;
        }
        .auto-style9 {
            width: 212px;
            height: 46px;
        }
        .auto-style10 {
            width: 259px;
            height: 13px;
        }
        .auto-style11 {
            width: 212px;
            height: 13px;
        }
        .auto-style12 {
            width: 259px;
            height: 63px;
        }
        .auto-style13 {
            width: 212px;
            height: 63px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
        <table style="border: 1pt solid #6666FF; width: 60%; height: 424px; font-family: Verdana;
            border-collapse: collapse; background-color: #ffffff;" align="center">
            <tr>
                <td align="center" colspan="3" class="style9">
                    <strong>Registration</strong></td>
            </tr>

            <tr>
                <td class="auto-style8" align="right">
                    <asp:Label ID="lblUserName" runat="server" Text="Username :"></asp:Label>
                </td>
                <td class="auto-style8" align="left">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style9" align="left">
                    <asp:RequiredFieldValidator ID="RfvUserName" runat="server" ErrorMessage="* Required"
                        ForeColor="#FF3300" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="right">
                    <asp:Label ID="lblEmail" runat="server" Text="E-Mail :"></asp:Label>
                </td>
                <td class="auto-style2" align="left">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style3" align="left">
                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ErrorMessage="* Required"
                        ForeColor="#FF3300" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RxvEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Invalid E-mail" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" align="right">
                    <asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
                </td>
                <td class="auto-style4" align="left">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style5" align="left">
                    <asp:RequiredFieldValidator ID="RfvPwd" runat="server" ErrorMessage="* Required"
                        ForeColor="#FF3300" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" align="right">
                    <asp:Label ID="lblConfirmPwd" runat="server" Text="Confirm Pasword :"></asp:Label>
                </td>
                <td class="auto-style12" align="left">
                    <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style13" align="left">
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RfvCnfrmPwd" runat="server" ErrorMessage="* Required"
                        ForeColor="#FF3300" ControlToValidate="txtConfirmPwd"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CvCnfmPwd" runat="server" ErrorMessage="Password and Confirm Password didnt matched"
                        ForeColor="#FF3300" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPwd"></asp:CompareValidator>
                </td>
            </tr>
           
        
            <td align="center" class="auto-style10">
                &nbsp;
                <asp:Label ID="lblMsg" runat="server" ForeColor="#CC3300"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" CausesValidation="False" OnClick="btnClear_Click"
                    Text="Clear" Width="69px" />
            &nbsp;&nbsp;&nbsp;
            </td>
            <td align="center" class="auto-style11">
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>


<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.master" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="Member_ChangePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>تغییر رمز</title>
    <style type="text/css">
        .auto-style1
        {
            text-align: center;
        }
        .auto-style2
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>تغییر رمز</h2>

        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;" class="auto-style2">رمز فعلی :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="CurrentPass" runat="server" Width="196px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">رمز جدید:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="NewPass" runat="server" Width="196px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">تکرار رمز جدید:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="RNewPass" runat="server" Width="196px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;height: 30px;" class="auto-style2"></td>
                <td style="height: 30px;" class="auto-style1">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="بروز رسانی" />
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Files/HotelView.css" type="text/css" media="all" rel="stylesheet" />
    <style type="text/css">
        .auto-style8
        {
            width: 97px;
        }
        .auto-style9
        {
            width: 97px;
            height: 61px;
        }
        .auto-style10
        {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="h2Tag">ورود</h2>
    <br />
    <div id="ErrorMSG" runat="server" class="LoginError" visible="false"></div>
    <table style="font-family:'BYekan'">
        <tr>
            <td class="auto-style9">
                نام کاربری
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="UserName" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                کلمه عبور
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Password" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">

            </td>
            <td class="auto-style10">
                <asp:Button ID="BTN" runat="server" Text="ورود" CssClass="SabtPost" OnClick="BTN_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">

            </td>
            <td class="auto-style10">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


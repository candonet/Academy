<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserRegister.aspx.cs" Inherits="UserRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Files/HotelView.css" rel="stylesheet" type="text/css" />
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
    <title>ثبت نام کاربران</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="h2Tag">ثبت نام کاربران</h2>
    <br />
    <div id="ErrorMSG" runat="server" class="LoginError" visible="false"></div>
    <table style="font-family:'BYekan'" id="RegisterTable" runat="server">
        <tr>
            <td class="auto-style9">
                نام 
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Nam" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" placeholder="نام"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                نام خانوادگی
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Famil" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" placeholder="نام خانوادگی"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                ایمیل
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Email" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" placeholder="youremail@example.com" Font-Names="Times News Roman"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                نام کاربری
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Username" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" Font-Names="Times News Roman"></asp:TextBox>
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
                تکرار کلمه عبور
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="RePassword" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                آواتار
            </td>
            <td class="auto-style10">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                
            </td>
            <td class="auto-style10">
                <asp:CheckBox ID="CheckBox1" runat="server"  CssClass="Pishnehad" Text="مقررات و قوانین سایت را خوانده‌ام و با آن موافق هستم"/><br />
                <asp:CheckBox ID="CheckBox2" runat="server"  CssClass="Pishnehad" Text="عضویت در خبرنامه رایگان"/>
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


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Config" %>

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
    <title>ویرایش اطلاعات</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="h2Tag">ویرایش اطلاعات</h2>
    <br />
    <br />
    <div id="ErrorMSG2" runat="server" class="LoginError" visible="false"></div>
    <table style="font-family:'BYekan'">
        <tr>
            <td class="auto-style9">
                نام 
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Nam" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                نام خانوادگی
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Famil" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                ایمیل
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Email" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" placeholder="yourmail@example.com"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                آواتار
            </td>
            <td class="auto-style10">
                <asp:FileUpload ID="FileUpload1" runat="server" />عکس با سایز 100 پیکسل
            </td>
        </tr>
        <tr>
            <td class="auto-style8">

            </td>
            <td class="auto-style10">
                <asp:Button ID="Button1" runat="server" Text="بروزرسانی" CssClass="SabtPost" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <h2 class="h2Tag">تغییر رمز</h2>
    <div id="ErrorMSG1" runat="server" class="LoginError" visible="false"></div>
    <table style="font-family:'BYekan'">
        <tr>
            <td class="auto-style9">
                کلمه عبور فعلی
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="CurrentPass" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                کلمه عبورجدید
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Password" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                تکرار کلمه عبورجدید
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="Repass" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">

            </td>
            <td class="auto-style10">
                <asp:Button ID="BTN" runat="server" Text="بروزرسانی" CssClass="SabtPost" OnClick="BTN_Click"/>
            </td>
        </tr>
    </table>
    
</asp:Content>


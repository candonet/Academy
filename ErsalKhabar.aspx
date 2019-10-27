<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ErsalKhabar.aspx.cs" Inherits="ErsalKhabar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>ارسال خبر</title>
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
        .auto-style11
        {
            height: 50px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="h2Tag">ارسال خبر</h2>
    <br />
    <div id="LoginDiv" runat="server">
        <div id="ErrorMSG" runat="server" class="LoginError"> برای ارسال خبر شما باید به حساب کاربری خود متصل باشید</div>
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
    </div>
    <div id="SendNews" runat="server" visible="false">
        <div id="ErrorMSG2" runat="server" class="LoginError" visible="false"> لطفا مقادیر را درست وارد کنید</div>
        <table style="font-family:'BYekan'">
            <tr>
                <td class="auto-style9">
                    نام خبر
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    دسته بندی خبر
                </td>
                <td class="auto-style11">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="250px" Font-Names="BYekan" Font-Size="Medium" Height="30px">
                        <asp:ListItem>هما سعادت</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="vertical-align:top">
                    متن خبر
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="350px" Height="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    عکس خبر
                </td>
                <td class="auto-style11">
                    <asp:FileUpload ID="FileUpload1" runat="server" /><span style="font-size:9.5px;font-family:'Tahoma'"> حجم عکس تا 100 کیلوبایت</span>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">

                </td>
                <td class="auto-style10" style="text-align:center">
                 <img id="myimg" runat="server" /><br />
                 <asp:TextBox ID="txtCaptcha" runat="server" CssClass="TextBoxInput" Font-Names="Tahoma" Width="200px"></asp:TextBox><asp:Label ID="lblMessage" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">

                </td>
                <td class="auto-style11">
                    <asp:Button ID="Button2" runat="server" Text="ارسال خبر" CssClass="SabtPost" OnClick="Button2_Click1" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                 &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    
                </td>
            </tr>
        </table>
    </div>
    <div id="PostSuccess" runat="server" visible="false">
        <div class="NewsSuccess">خبر شما پس از تایید ادمین به نمایش خواهد در آمد.</div>
    </div>
</asp:Content>


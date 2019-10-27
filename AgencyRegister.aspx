<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AgencyRegister.aspx.cs" Inherits="AgencyRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style8
        {
            width: 151px;
        }
        .auto-style9
        {
            width: 151px;
            height: 40px;
        }
        .auto-style10
        {
            height: 40px;
        }
        .TextBoxInput
        {}
    </style>
    <title>ثبت نام آژانس های مسافرتی</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="h2Tag">ثبت نام آژانس های مسافرتی</h2>
    <br />
    <div id="ErrorMSG" runat="server" class="LoginError" visible="false"></div>
    <table style="font-family:'BYekan'" id="RegisterTable" runat="server">
        <tr>
            <td class="auto-style9">
                نام 
                آژانس</td>
            <td class="auto-style10">
                <asp:TextBox ID="Nam" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                نام انگلیسی آژانس</td>
            <td class="auto-style10">
                <asp:TextBox ID="namEng" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" Font-Names="Tahoma"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                شماره مجوز گرئشگری آژانس</td>
            <td class="auto-style10">
                <asp:TextBox ID="shomareMJ" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" Font-Names="Times News Roman"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                نام مدیر
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="namMod" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                تلفن مستقیم مدیر عامل</td>
            <td class="auto-style10">
                <asp:TextBox ID="TelMod" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                ایمیل</td>
            <td class="auto-style10">
                <asp:TextBox ID="email" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"  placeholder="youremail@example.com" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                ID یاهو</td>
            <td class="auto-style10">
                <asp:TextBox ID="YahooID" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                تلفن </td>
            <td class="auto-style10">
                <asp:TextBox ID="tel" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                فکس</td>
            <td class="auto-style10">
                <asp:TextBox ID="FaQs" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                تلفن همراه</td>
            <td class="auto-style10">
                <asp:TextBox ID="Mobile" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                وب سایت</td>
            <td class="auto-style10">
                <asp:TextBox ID="Aweb" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"  Font-Names="Tahoma"></asp:TextBox><span style="font-family:Tahoma;font-size:x-small;direction:rtl"> بدون //:http</span>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                استان</td>
            <td class="auto-style10">
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="BYekan" Height="27px" Width="202px">
                                                <asp:ListItem>آذربایجان شرقی</asp:ListItem>
                                                <asp:ListItem>آذربایجان غربی</asp:ListItem>
                                                <asp:ListItem>اردبیل</asp:ListItem>
                                                <asp:ListItem>اصفهان</asp:ListItem>
                                                <asp:ListItem>البرز</asp:ListItem>
                                                <asp:ListItem>ایلام</asp:ListItem>
                                                <asp:ListItem>بوشهر</asp:ListItem>
                                                <asp:ListItem>تهران</asp:ListItem>
                                                <asp:ListItem>چهارمحال و بختیاری</asp:ListItem>
                                                <asp:ListItem>خراسان جنوبی</asp:ListItem>
                                                <asp:ListItem>خراسان رضوی</asp:ListItem>
                                                <asp:ListItem>خراسان شمالی</asp:ListItem>
                                                <asp:ListItem>خوزستان</asp:ListItem>
                                                <asp:ListItem>زنجان</asp:ListItem>
                                                <asp:ListItem>سمنان</asp:ListItem>
                                                <asp:ListItem>سیستان و بلوچستان</asp:ListItem>
                                                <asp:ListItem>فارس</asp:ListItem>
                                                <asp:ListItem>قزوین</asp:ListItem>
                                                <asp:ListItem>قم</asp:ListItem>
                                                <asp:ListItem>کردستان</asp:ListItem>
                                                <asp:ListItem>کرمان</asp:ListItem>
                                                <asp:ListItem>کرمانشاه</asp:ListItem>
                                                <asp:ListItem>کهگیلویه و بویراحمد</asp:ListItem>
                                                <asp:ListItem>گلستان</asp:ListItem>
                                                <asp:ListItem>گیلان</asp:ListItem>
                                                <asp:ListItem>لرستان</asp:ListItem>
                                                <asp:ListItem>مازندران</asp:ListItem>
                                                <asp:ListItem>مرکزی</asp:ListItem>
                                                <asp:ListItem>هرمزگان</asp:ListItem>
                                                <asp:ListItem>همدان</asp:ListItem>
                                                <asp:ListItem>یزد</asp:ListItem>
                                                <asp:ListItem>خارج از ایران</asp:ListItem>
                                            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                شهر</td>
            <td class="auto-style10">
                <asp:TextBox ID="shahr" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                آدرس محل کار</td>
            <td class="auto-style10">
                <asp:TextBox ID="adresMahal" runat="server" CssClass="TextBoxInput" Height="80px" Width="250px" TextMode="MultiLine" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                خدمات آژانس</td>
            <td class="auto-style10">
                <asp:TextBox ID="khademat" runat="server" CssClass="TextBoxInput" Height="80px" Width="250px" TextMode="MultiLine" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                نام رابط</td>
            <td class="auto-style10">
                <asp:TextBox ID="RefName" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                شماره تماس رابط </td>
            <td class="auto-style10">
                <asp:TextBox ID="RefTel" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                نام کاربری</td>
            <td class="auto-style10">
                <asp:TextBox ID="Username" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" Font-Names="Tahoma" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                کلمه عبور</td>
            <td class="auto-style10">
                <asp:TextBox ID="Password" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" TextMode="Password" Font-Names="Tahoma" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                تکرار کلمه عبور</td>
            <td class="auto-style10">
                <asp:TextBox ID="Repass" runat="server" CssClass="TextBoxInput" Height="30px" Width="250px" TextMode="Password" Font-Names="Tahoma" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                تصویر مجوز "بند ب" 
            </td>
            <td class="auto-style10">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                لوگو
            </td>
            <td class="auto-style10">
                <asp:FileUpload ID="FileUpload2" runat="server" /><span style="font-size:xx-small">حد مجاز 50 کیلوبایت</span>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                
            </td>
            <td class="auto-style10">
                <asp:CheckBox ID="CheckBox1" runat="server"  CssClass="Pishnehad" Text="مقررات و قوانین سایت را خوانده‌ام و با آن موافق هستم"/><br />
                
            </td>
        </tr>
        <tr>
            <td class="auto-style8">

            </td>
            <td class="auto-style10">
                <asp:Button ID="BTN" runat="server" Text="ثبت نام" CssClass="SabtPost" OnClick="BTN_Click" />
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


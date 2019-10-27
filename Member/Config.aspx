<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.master" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Member_Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت مشخصات</title>
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
    <form id="Form1" runat="server" enctype="multipart/form-data">
        <h2>ویرایش اطلاعات</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;" class="auto-style2">نام :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">نام انگلیسی:</td>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="EnglishName"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">سایت :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><span style="font-size:x-small;direction:rtl"> بدون //:http</span>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">ایمیل :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">تلفن :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">فاکس :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">شماره مجوز :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">نام مدیر :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">شماره تماس مدیر :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">آیدی یاهو :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">شماره موبایل :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">استان :</td>
                <td class="auto-style1">
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
                <td style="width: 99px;" class="auto-style2">شهر :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">آدرس محل کار :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox13" runat="server" Height="148px" TextMode="MultiLine" Width="273px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">خدمات آژانس :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox14" runat="server" Height="148px" TextMode="MultiLine" Width="273px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">تصویر بند 'ب' :</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">لوگو :</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">تعداد پرسنل :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">آدرس نقشه گوگل :</td>
                <td class="auto-style1">
                    مختصات X:<asp:TextBox ID="TextBox16" runat="server" Width="39px"></asp:TextBox>
                &nbsp;مختصات Y:<asp:TextBox ID="TextBox17" runat="server" Width="39px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;" class="auto-style2">درباره آژانس :</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox18" runat="server" Height="148px" TextMode="MultiLine" Width="273px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;height: 30px;" class="auto-style2"></td>
                <td style="height: 30px;" class="auto-style1">
                    <asp:Button ID="Button2" runat="server" Text="بروز رسانی" OnClick="Button2_Click" style="height: 29px" />
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


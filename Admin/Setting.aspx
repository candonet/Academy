<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="Admin_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>تنظیمات سایت</title>
    <style type="text/css">
        .auto-style6
        {
            text-align: left;
            vertical-align:top;
        }
        .auto-style7
        {
            width: 99px;
            height: 22px;
        }
        .auto-style8
        {
            height: 22px;
        }
    </style>
    <script src="image/jscolor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
    <h2>مدیریت سایت</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">عنوان سایت</td>
                <td class="auto-style8">
                    <asp:TextBox ID="SiteTitle" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">کلمات کلیدی:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="SiteK" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="width: 99px;text-align: left;">وضعیت سایت:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>فعال</asp:ListItem>
                        <asp:ListItem>غیرفعال</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">نمایش اخبار:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DropDownList4" runat="server">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style7">لوگو سایت:</td>
                <td class="auto-style8">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    (300×100)</td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">سرعت اسلاید:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox3" runat="server" Width="60px"></asp:TextBox> <span style="font-size:x-small"> براساس میلی ثانیه</span>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">رنگ هیدر:</td>
                <td class="auto-style8">
                    <button class="jscolor {valueElement:'ContentPlaceHolder1_TextBox2', onFineChange:'setTextColor(this)'}">
		                انتخاب رنگ
	                </button>

                    <asp:TextBox ID="TextBox2" runat="server" Width="60px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">حافظه سایت:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox4" runat="server" Width="60px"></asp:TextBox><span style="font-size:x-small">مگابایت</span>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">توضیحات وبسایت</td>
                <td class="auto-style8">
                    <asp:TextBox ID="SiteDesc" runat="server" Width="196px" Height="40px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="height: 30px;" class="auto-style8">
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="ثبت"/>
                    &nbsp;&nbsp;<asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="مدیریت اسلاید ها" />
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
	<h2>مدیریت اسلاید اصلی</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">اسلاید :</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Tahoma" Height="25px" Width="157px">
                    </asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" OnClick="Button1_Click1" Text="انتخاب" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">اسلاید انتخاب شده:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="CurrentSlide" runat="server" Width="196px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">آدرس عکس :</td>
                <td class="auto-style8">
                    <asp:TextBox ID="ImageURL" runat="server" Width="196px"></asp:TextBox>
                    (880×300)<br />
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">URL :</td>
                <td class="auto-style9">
                    <asp:TextBox ID="URL" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">متن عکس:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextSlide" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="height: 30px;" class="auto-style8">
                    <asp:Button ID="MenuInsert" runat="server" OnClick="Button1_Click" Text="ثبت"/>
                    &nbsp;<asp:Button ID="MenuInsert2" runat="server" OnClick="MenuInsert2_Click" Text="ویرایش" Enabled="False"/>
                    &nbsp;<asp:Button ID="MenuInsert3" runat="server" OnClick="MenuInsert3_Click" Text="حذف" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟');"/>
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
	
        <h2>مدیریت اسلاید افقی</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">اسلاید :</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Tahoma" Height="25px" Width="157px">
                    </asp:DropDownList>
                    <asp:Button ID="Button3" runat="server" Text="انتخاب" OnClick="Button3_Click1" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">اسلاید انتخاب شده:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="CurrentSlide0" runat="server" Width="196px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">آدرس عکس :</td>
                <td class="auto-style8">
                    <asp:TextBox ID="ImageURL0" runat="server" Width="196px"></asp:TextBox>
                    <br />
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style6">URL :</td>
                <td class="auto-style9">
                    <asp:TextBox ID="URL0" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">اسم عکس:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextSlide0" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">متن عکس:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="CommentSlide" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">کلمات کلیدی:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="Keyword" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="height: 30px;" class="auto-style8">
                    <asp:Button ID="MenuInsert4" runat="server" OnClick="MenuInsert4_Click" Text="ثبت"/>
                    &nbsp;<asp:Button ID="MenuInsert5" runat="server" OnClick="MenuInsert5_Click" Text="ویرایش" Enabled="False"/>
                    &nbsp;<asp:Button ID="MenuInsert6" runat="server" OnClick="MenuInsert6_Click" Text="حذف" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟');"/>
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <h2>درباره ما</h2>
        <table style="width: 400px;">
            <tr>
                <td class="auto-style6">درباره سایت:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBox1" runat="server" Width="275px" Height="142px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="height: 30px;" class="auto-style8">
                    <asp:Button ID="Button5" runat="server" Text="بروز رسانی" OnClick="Button5_Click"/>
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        </form>
</asp:Content>


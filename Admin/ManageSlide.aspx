<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageSlide.aspx.cs" Inherits="Admin_ManageSlide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت اسلاید ها</title>
    <style>
        .HeaderList
        {
            font-family:'BYekan';
            font-size:13.5px;
            font-weight:normal;
            background-color:#7186ff;
            color:white;
            padding-right:5px;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>مدیریت اسلاید ها</h2>
        <table style="width:400px;border-collapse:collapse;font-family:'BYekan';font-weight:100">
            <tr>
                <td style="width:100px" class="HeaderList">

                </td>
                <td class="HeaderList">
                    اسلاید اصلی
                </td>
                <td class="HeaderList">
                    اسلاید افقی
                </td>
            </tr>
            <tr>
                <td>
                    صفحه اصلی
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    ورود کاربران
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    ویرایش مشخصات
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList5" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList6" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    جستجو
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList7" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList8" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    ارسال خبر
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList9" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList10" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    درباره ما
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList11" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList12" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    ثبت نام کاربران
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList13" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList14" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    ثبت نام آژانس ها
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList15" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList16" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    دسته تورها
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList17" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList18" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    نمایش تور
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList19" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList20" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    دسته هتل ها
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList21" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList22" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    نمایش هتل ها
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList23" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList24" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    دسته اخبار
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList25" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList26" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    نمایش خبر
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList27" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList28" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    دسته جاذبه ها
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList29" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList30" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    نمایش جاذبه
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList31" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList32" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    نمایش صفحه
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList33" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList34" runat="server" Width="80px">
                        <asp:ListItem>نمایش</asp:ListItem>
                        <asp:ListItem>مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="بروز رسانی" OnClick="Button1_Click" />
        <br />
        <br />
    </form>
</asp:Content>


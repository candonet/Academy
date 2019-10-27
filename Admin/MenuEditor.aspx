<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MenuEditor.aspx.cs" Inherits="Admin_MenuEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت منو ها</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="image/chosen.jquery.js"></script>
    <link rel="stylesheet" href="image/bootstrap-chosen.css" />
    <script>
        $(function () {
            $('#<%=DropDownList1.ClientID%>').chosen();
            $('#<%=DropDownList2.ClientID%>').chosen();
            $('#<%=DropDownList3.ClientID%>').chosen();
            $('#<%=DropDownList4.ClientID%>').chosen();
            $('#<%=DropDownList5.ClientID%>').chosen();
            $('#<%=DropDownList6.ClientID%>').chosen();
            $('#<%=DropDownList7.ClientID%>').chosen();
            $('#<%=DropDownList8.ClientID%>').chosen();
            $('#<%=DropDownList9.ClientID%>').chosen();
            $('#<%=DropDownList10.ClientID%>').chosen();
            $('#<%=DropDownList11.ClientID%>').chosen();
            $('#<%=DropDownList12.ClientID%>').chosen();
            $('#<%=DropDownList13.ClientID%>').chosen();
            $('#<%=MenuList.ClientID%>').chosen();
            $('#<%=MenuList2.ClientID%>').chosen();
            $('#<%=MenuList3.ClientID%>').chosen();
            $('#<%=MenuList4.ClientID%>').chosen();
        });
    </script>
    <style type="text/css">
        .auto-style6
        {
            width: 99px;
            text-align: left;
            height: 26px;
        }
        .auto-style7
        {
            text-align: center;
            height: 26px;
        }
        input, select, textarea
        {
            vertical-align: middle;
            font-family: Tahoma;
            border: 1px #bbb solid;
            font-size: 11px;
            padding: 5px;
            background-color: white;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
            border-bottom-left-radius: 5px;
        }
        .SortDone
        {
            color:green;
        }
        .SortFailed
        {
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
    <h2>مدیریت منوی  سایت</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">منوی مادر :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="MenuList" runat="server" Font-Names="Tahoma" Height="100%" Width="196px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">دسته بندی :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>نا مشخص</asp:ListItem>
                        <asp:ListItem>تور</asp:ListItem>
                        <asp:ListItem>هتل</asp:ListItem>
                        <asp:ListItem>جاذبه های گردشگری</asp:ListItem>
                        <asp:ListItem>اخبار</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="sl1" runat="server">
                <td style="width: 99px;text-align: left;">دسته بندی تور :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList5" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="sl2" runat="server">
                <td style="width: 99px;text-align: left;">&nbsp;نام کشور:</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="sl3" runat="server">
                <td style="width: 99px;text-align: left;">نام شهر:</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="sl4" runat="server">
                <td style="width: 99px;text-align: left;">نام ناحیه :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList4" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="sl5" runat="server">
                <td style="width: 99px;text-align: left;">دسته بندی :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList6" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">نام منو :</td>
                <td class="auto-style7">
                    <asp:TextBox ID="NewName" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">آدرس صفحه :</td>
                <td style="text-align: center;">
                    <asp:TextBox ID="MenuURL" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="width: 99px;text-align: left;">پروفایل منو :</td>
                <td style="text-align: center;">
                    <asp:TextBox ID="MenuProfile1" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">توضیحات منو :</td>
                <td style="text-align: center;">
                    <asp:TextBox ID="MenuDescription" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="text-align: center;height: 30px;">
                    <asp:Button ID="MenuInsert" runat="server" OnClick="Button1_Click" Text="ثبت"/>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td style="text-align: center">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
	
        <h2>ویرایش منو ها</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">منو :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="MenuList2" runat="server" Font-Names="Tahoma" Height="100%" Width="157px" OnSelectedIndexChanged="MenuList2_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="انتخاب" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">منوی انتخاب شده:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="CurrentMenu" runat="server" Width="196px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">منوی مادر :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="MenuList3" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">دسته بندی :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList7" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Enabled="False">
                        <asp:ListItem>نا مشخص</asp:ListItem>
                        <asp:ListItem>تور</asp:ListItem>
                        <asp:ListItem>هتل</asp:ListItem>
                        <asp:ListItem>جاذبه های گردشگری</asp:ListItem>
                        <asp:ListItem>اخبار</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="dl1" runat="server">
                <td style="width: 99px;text-align: left;">دسته بندی تور :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList8" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="dl2" runat="server">
                <td style="width: 99px;text-align: left;">&nbsp;نام کشور:</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList9" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="dl3" runat="server">
                <td style="width: 99px;text-align: left;">نام شهر:</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList10" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DropDownList10_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="dl4" runat="server">
                <td style="width: 99px;text-align: left;">نام ناحیه :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList11" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="dl5" runat="server">
                <td style="width: 99px;text-align: left;">دسته بندی :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="DropDownList12" runat="server" Font-Names="Tahoma" Height="100%" Width="196px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">نام منوی جدید :</td>
                <td class="auto-style7">
                    <asp:TextBox ID="NewName2" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 99px;text-align: left;">آدرس صفحه :</td>
                <td style="text-align: center;">
                    <asp:TextBox ID="MenuURL2" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">پروفایل منو :</td>
                <td style="text-align: center;">
                    <asp:TextBox ID="MenuProfile2" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">توضیحات منو :</td>
                <td style="text-align: center;">
                    <asp:TextBox ID="Tozihat2" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">وضعیت منو :</td>
                <td style="text-align: center;">
                    <asp:DropDownList ID="DropDownList13" runat="server" Width="100px">
                        <asp:ListItem Value="true">نمایش</asp:ListItem>
                        <asp:ListItem Value="false">مخفی</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="text-align: center;height: 30px;">
                    <asp:Button ID="MenuInsert2" runat="server" OnClick="MenuInsert2_Click" Text="ویرایش" OnClientClick="return confirm('آیا شما مطمئن به ویرایش هستید؟'); "/>
                    &nbsp;<asp:Button ID="MenuInsert3" runat="server" OnClick="MenuInsert3_Click" Text="حذف"  OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "/>
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td style="text-align: center">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <h2>ویرایش ترتیب منو ها</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">منو :</td>
                <td style="text-align: center">
                    <asp:DropDownList ID="MenuList4" runat="server" Font-Names="Tahoma" Height="100%" Width="157px" OnSelectedIndexChanged="MenuList2_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" Text="انتخاب" OnClick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;"></td>
                <td style="text-align: center">
                    <asp:ListBox ID="ListBox1" runat="server" Height="95px" Width="196px"></asp:ListBox><br />
                    <input type="button" value="بالا" id="Up" onclick="MoveUpDown(this.id);" /><input type="button" value="پایین" id="Down" onclick="MoveUpDown(this.id);"  />
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="text-align: center;height: 30px;">
                    <input type="button" id="Button4" value="بروزرسانی" " onclick="Sortmenu()"/>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td style="text-align: center">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <script>
            function MoveUpDown(n) {
                var $op = $('#<%=ListBox1.ClientID%> option:selected'),
                        $this = $("#" + n);
                if ($op.length) {
                    ($this.attr('id') == 'Up') ?
                        $op.first().prev().before($op) :
                        $op.last().next().after($op);
                }
            }
            function ShowError()
            { $('#ErrorMessage').stop(); $('#ErrorMessage').fadeOut(1); $('#ErrorMessage').fadeIn(500); }
            function Sortmenu() {
                var wholeValues = "";
                $("#<%=ListBox1.ClientID%> option").each(function () {
                    var res = this.value.split("-");
                    wholeValues += res[0] + "-";
                });
                var PostData = '{Request: "' + wholeValues + '" }';
                $.ajax({
                    type: "POST",
                    url: "MenuEditor.aspx/SortMenu",
                    data: PostData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response);
                    }
                });
            }
            function OnSuccess(response) {
                if (response.d == "1") {
                    $("#<%=Label3.ClientID%>").html('عملیات با موفقیت انجام شد');
                    $("#<%=Label3.ClientID%>").attr('class', 'SortDone');
                }
                else {
                    $("#<%=Label3.ClientID%>").html('خطا در اتصال به سرور - لطفا دوباره تلاش کنید');
                    $("#<%=Label3.ClientID%>").attr('class', 'SortFailed');
                }
            }
        </script>
        </form>
</asp:Content>


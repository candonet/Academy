<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="AddCCA.aspx.cs" Inherits="Admin_AddCCA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <title>مدیریت ناحیه</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="image/chosen.jquery.js"></script>
    <link rel="stylesheet" href="image/bootstrap-chosen.css" />
    <script>
        $(function () {
            $('#ContentPlaceHolder1_DropDownList1').chosen();
            $('#ContentPlaceHolder1_DropDownList2').chosen();
            $('#ContentPlaceHolder1_DropDownList3').chosen();
            $('#ContentPlaceHolder1_DropDownList4').chosen();
            $('#ContentPlaceHolder1_DropDownList5').chosen();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>مدیریت کشور ها</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">نام کشور :</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Tahoma" Height="100%" Width="157px">
                    </asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" OnClick="Button1_Click1" Text="انتخاب" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">کشور انتخاب شده:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="CurrentCountry" runat="server" Width="196px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">نام کشور :</td>
                <td class="auto-style8">
                    <asp:TextBox ID="CountryName" runat="server" Width="196px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="height: 30px;" class="auto-style8">
                    <asp:Button ID="MenuInsert" runat="server" OnClick="Button1_Click" Text="ثبت"/>
                    &nbsp;<asp:Button ID="MenuInsert2" runat="server" Text="ویرایش" Enabled="False" OnClick="MenuInsert2_Click"/>
                    &nbsp;<asp:Button ID="MenuInsert3" runat="server" Text="حذف" OnClick="MenuInsert3_Click"/>
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
	
	<h2>مدیریت شهرها</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">نام شهر :</td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Tahoma" Height="100%" Width="157px">
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="انتخاب" OnClick="Button1_Click2" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">شهر انتخاب شده:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="CurrentCity" runat="server" Width="196px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">نام کشور :</td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Tahoma" Height="100%" Width="207px">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">نام شهر :</td>
                <td class="auto-style10">
                    <asp:TextBox ID="CityName" runat="server" Width="196px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td class="auto-style12">
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="ثبت"/>
                    &nbsp;<asp:Button ID="Button4" runat="server" Text="ویرایش" Enabled="False" OnClick="Button4_Click1"/>
                    &nbsp;<asp:Button ID="Button5" runat="server" Text="حذف" OnClick="Button5_Click" />
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
		<h2>مدیریت ناحیه ها</h2>
        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">نام ناحیه :</td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList4" runat="server" Font-Names="Tahoma" Height="100%" Width="157px">
                    </asp:DropDownList>
                    <asp:Button ID="Button6" runat="server" Text="انتخاب" OnClick="Button6_Click"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">ناحیه انتخاب شده:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="CurrentArea" runat="server" Width="196px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">نام شهر :</td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList5" runat="server" Font-Names="Tahoma" Height="100%" Width="207px">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">نام ناحیه :</td>
                <td class="auto-style10">
                    <asp:TextBox ID="AreaName" runat="server" Width="196px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td class="auto-style12">
                    <asp:Button ID="Button7" runat="server"  Text="ثبت" OnClick="Button7_Click"/>
                    &nbsp;<asp:Button ID="Button8" runat="server" Text="ویرایش" Enabled="False" OnClick="Button8_Click" />
                    &nbsp;<asp:Button ID="Button9" runat="server" Text="حذف" OnClick="Button9_Click" />
                    </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>


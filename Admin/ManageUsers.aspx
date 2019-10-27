<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Admin_ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت کاربران</title>
    <style type="text/css">
        .auto-style6
        {
            text-align: left;
        }
        .auto-style8
        {
            height: 22px;
        }
        .TaedNashode
        {
            font-size:13.5px;
            font-family:"BYekan";
            color:red;
            
        }
        .TaedShode
        {
            font-size:13.5px;
            font-family:"BYekan";
            color:green;
        }
        .LabelS
        {
            font-size:12.5px;
            font-family:"BYekan";
        }
        .auto-style9
        {
            width: 99px;
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>مدیریت کاربران</h2>
        <table style="width:600px">
            <tr>
                <td valign="top">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "></asp:Button>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Update" Text="بررسی" OnClientClick="return confirm('آیا شما مطمئن به بررسی هستید؟'); "></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="username" HeaderText="نام کاربری" SortExpression="username" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="status" HeaderText="وضعیت" SortExpression="status" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" SelectCommand="SELECT [Members].[ID],[Members].[username],[Members].[status] FROM [Members],[GroupMember] WHERE GroupMember.UserID = Members.ID AND GroupMember.GroupID = 2 ORDER BY [ID] DESC"></asp:SqlDataSource>
                </td>
                <td valign="top">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 99px;text-align: left;">شماره سیستمی :</td>
                            <td class="auto-style8">
                                <asp:Label ID="Label1" runat="server" Text="####" Font-Bold="False" CssClass="LabelS"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="auto-style9">نام کاربری :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="TextBox5" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="auto-style9">کلمه عبور جدید :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="Password" runat="server" Width="120px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">نام  :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="TextBox1" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">نام خانوادگی :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="TextBox4" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">ایمیل :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="TextBox2" runat="server" Width="120px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">تاریخ عضویت :</td>
                            <td class="auto-style8">
                                <asp:Label ID="Label2" runat="server" Text="0000/00/00" Font-Bold="False" CssClass="LabelS"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">تاریخ آخرین ورود :</td>
                            <td class="auto-style8">
                                <asp:Label ID="Label3" runat="server" Text="0000/00/00" Font-Bold="False" CssClass="LabelS"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">عضویت خبرنامه :</td>
                            <td class="auto-style9">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>بله</asp:ListItem>
                                    <asp:ListItem>خیر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">وضعیت :</td>
                            <td class="auto-style9">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>فعال</asp:ListItem>
                                    <asp:ListItem>غیر فعال</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;height: 30px;"></td>
                            <td style="height: 30px;" class="auto-style8">
                                &nbsp;&nbsp;<asp:Button ID="Button6" runat="server" Enabled="False" OnClick="Button6_Click" Text="ویرایش" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">&nbsp;</td>
                            <td class="auto-style8">
                                <asp:Label ID="Label4" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    
                </td>
            </tr>
        </table>
    </form>
</asp:Content>


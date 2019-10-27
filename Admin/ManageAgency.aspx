<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageAgency.aspx.cs" Inherits="Admin_ManageAgency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت آژانس ها</title>
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
        <h2>مدیریت آژانس</h2>
        <table style="width:880px">
            <tr>
                <td style="vertical-align:top;width:280px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="400px">
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
                            <asp:BoundField DataField="STS" HeaderText="" SortExpression="STS" >
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" SelectCommand="SELECT [Members].[ID],[Members].[username],[Members].[status],AgencyDetail.STS FROM [AgencyDetail],[Members],[GroupMember] WHERE GroupMember.UserID = Members.ID AND GroupMember.GroupID = 3  AND [AgencyDetail].UserID = Members.ID ORDER BY [ID] DESC"></asp:SqlDataSource>
                </td>
                <td valign="top">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 99px;text-align: left;">شماره سیستمی :</td>
                            <td class="auto-style8">
                                <asp:Label ID="Label1" runat="server" Text="0" Font-Bold="False" CssClass="LabelS"></asp:Label>
                                <asp:Label ID="Label5" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="auto-style9">نام کاربری :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="UserTXT" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="auto-style9">کلمه عبور جدید :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="PasswordTXT" runat="server" Width="120px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">نام  :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="NAM" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">تلفن :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="TEL" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">فکس :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="FAQ" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">ایمیل :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="Email" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">نام رابط :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="RefName" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">شماره تماس رابط :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="RefTel" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">تعداد پرسنل :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="TedadP" runat="server" Width="120px"></asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TedadP" runat="server" ForeColor="Red" ErrorMessage="فقط باید عدد وارد کنید" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">مختصات نقشه :</td>
                            <td class="auto-style8">
                                X:<asp:TextBox ID="LocationX" runat="server" Width="60px" MaxLength="7"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="LocationX" runat="server" ForeColor="Red" ErrorMessage="مقداراشتباه" ValidationExpression="\d{2}.\d{4}"></asp:RegularExpressionValidator><br />
                                Y:<asp:TextBox ID="LocationY" runat="server" Width="60px" MaxLength="7"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="LocationY" runat="server" ForeColor="Red" ErrorMessage="مقداراشتباه" ValidationExpression="\d{2}.\d{4}"></asp:RegularExpressionValidator>
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
                            <td class="auto-style6">تصویر بند"ب" :</td>
                            <td class="auto-style9">
                                <asp:HyperLink ID="HyperLink1" runat="server" style="text-decoration:none;font-family:'BYekan'" Target="_blank"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">تعریف هتل :</td>
                            <td class="auto-style9">
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                    <asp:ListItem>بله</asp:ListItem>
                                    <asp:ListItem>خیر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">تعریف تور :</td>
                            <td class="auto-style9">
                                <asp:DropDownList ID="DropDownList5" runat="server">
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
                            <td class="auto-style6">وضعیت تایید:</td>
                            <td class="auto-style9">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>تایید شده</asp:ListItem>
                                    <asp:ListItem>تایید نشده</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;height: 30px;"></td>
                            <td style="height: 30px;" class="auto-style8">
                                &nbsp;&nbsp;<asp:Button ID="Button6" runat="server" Enabled="False" Text="ویرایش" OnClick="Button6_Click" />
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
                <td style="vertical-align:top;width:220px">
                    <h2>مدیریت مجوز ها</h2>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                            <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" Visible="False" />
                            <asp:BoundField DataField="meqdar" HeaderText="مجوز" SortExpression="meqdar">
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
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="159px">
                        <asp:ListItem>بند الف</asp:ListItem>
                        <asp:ListItem>بند ب</asp:ListItem>
                        <asp:ListItem>بند پ</asp:ListItem>
                        <asp:ListItem>بند ج</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="درج" />
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [Mojavez] WHERE [ID] = @original_ID" InsertCommand="INSERT INTO [Mojavez] ([UserID], [meqdar]) VALUES (@UserID, @meqdar)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Mojavez] WHERE ([UserID] = @UserID)" UpdateCommand="UPDATE [Mojavez] SET [UserID] = @UserID, [meqdar] = @meqdar WHERE [ID] = @original_ID AND (([UserID] = @original_UserID) OR ([UserID] IS NULL AND @original_UserID IS NULL)) AND (([meqdar] = @original_meqdar) OR ([meqdar] IS NULL AND @original_meqdar IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_UserID" Type="Int64" />
                            <asp:Parameter Name="original_meqdar" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="UserID" Type="Int64" />
                            <asp:Parameter Name="meqdar" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Label5" Name="UserID" PropertyName="Text" Type="Int64" DefaultValue="0" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="UserID" Type="Int64" />
                            <asp:Parameter Name="meqdar" Type="String" />
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_UserID" Type="Int64" />
                            <asp:Parameter Name="original_meqdar" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>


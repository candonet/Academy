<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageNews.aspx.cs" Inherits="Admin_ManageNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت اخبار</title>
    <style>
        .MyTD
        {
            vertical-align:top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>مدیریت اخبار</h2>
        <table style="width:700px;">
            <tr>
                <td class="MyTD" style="width:450px">
                    <h2>لیست اخبار</h2>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" Width="450px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف"  OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:HyperLinkField HeaderText="ویرایش" DataTextField="ID" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Admin/AddNews.aspx?NewsID={0}"  DataTextFormatString="/Admin/AddJazebe.aspx?NewsID={0}" >
                            <HeaderStyle Width="170px" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="Esm" HeaderText="کاربر" SortExpression="Esm" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [News] WHERE [ID] = @original_ID AND (([Title] = @original_Title) OR ([Title] IS NULL AND @original_Title IS NULL))" InsertCommand="INSERT INTO [News] ([Title]) VALUES (@Title)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [Title],(SELECT username FROM Members WHERE ID = UserID) as Esm FROM [News]" UpdateCommand="UPDATE [News] SET [Title] = @Title WHERE [ID] = @original_ID AND (([Title] = @original_Title) OR ([Title] IS NULL AND @original_Title IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_Title" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Title" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Title" Type="String" />
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_Title" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>

                    <br />
                    <asp:Button ID="Button2" runat="server" Text="درج خبر جدید" OnClick="Button2_Click" Width="90px" />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="اخبار تایید نشده" Width="90px" />
                </td>
                <td class="MyTD">
                    <h2>دسته بندی اخبار</h2>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" EditText="ویرایش" ShowEditButton="True" ItemStyle-CssClass="MyBTN1"></asp:CommandField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف"  OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CatName" HeaderText="نام دسته" SortExpression="CatName" />
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
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="نام دسته :"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="درج" />
                    <br />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [NewsCat] WHERE [ID] = @original_ID AND (([CatName] = @original_CatName) OR ([CatName] IS NULL AND @original_CatName IS NULL))" InsertCommand="INSERT INTO [NewsCat] ([CatName]) VALUES (@CatName)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [NewsCat]" UpdateCommand="UPDATE [NewsCat] SET [CatName] = @CatName WHERE [ID] = @original_ID AND (([CatName] = @original_CatName) OR ([CatName] IS NULL AND @original_CatName IS NULL))" OnSelecting="SqlDataSource2_Selecting">
                        <DeleteParameters>
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_CatName" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CatName" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="CatName" Type="String" />
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_CatName" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <br />
                </td>
            </tr>
        </table>
        
    </form>
</asp:Content>


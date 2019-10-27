<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageUncheckedNews.aspx.cs" Inherits="Admin_ManageUncheckedNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت اخبار تایید نشده</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>مدیریت اخبار تایید نشده</h2>
         
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" Width="500px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف"  OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:HyperLinkField HeaderText="ویرایش" DataTextField="ID" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Admin/AddNews.aspx?NewsID={0}"  DataTextFormatString="/Admin/AddJazebe.aspx?NewsID={0}" >
                            <HeaderStyle Width="200px" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [News] WHERE [ID] = @original_ID AND (([Title] = @original_Title) OR ([Title] IS NULL AND @original_Title IS NULL))" InsertCommand="INSERT INTO [News] ([Title]) VALUES (@Title)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [Title],(SELECT username From Members WHERE ID = UserID) as Esm FROM [News] where STS is null or STS = 0" UpdateCommand="UPDATE [News] SET [Title] = @Title WHERE [ID] = @original_ID AND (([Title] = @original_Title) OR ([Title] IS NULL AND @original_Title IS NULL))">
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

    </form>
</asp:Content>


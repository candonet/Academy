<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageItems.aspx.cs" Inherits="Admin_ManageItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>امکانات هتل</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form" runat="server">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="300px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" CancelText="لغو" DeleteText="حذف" EditText="ویرایش" ShowDeleteButton="True" ShowEditButton="True" UpdateText="بروزرسانی" />
                <asp:BoundField DataField="Nam" SortExpression="Nam" />
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

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [InfoHotel] WHERE [ID] = @original_ID AND (([Nam] = @original_Nam) OR ([Nam] IS NULL AND @original_Nam IS NULL))" InsertCommand="INSERT INTO [InfoHotel] ([Nam]) VALUES (@Nam)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [InfoHotel]" UpdateCommand="UPDATE [InfoHotel] SET [Nam] = @Nam WHERE [ID] = @original_ID AND (([Nam] = @original_Nam) OR ([Nam] IS NULL AND @original_Nam IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int64" />
                <asp:Parameter Name="original_Nam" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Nam" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nam" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int64" />
                <asp:Parameter Name="original_Nam" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </form>
</asp:Content>


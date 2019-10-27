<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Admin.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="supportticket.aspx.cs" Inherits="Admin_supportticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت تیکت ها</title>
        <style>
        .Entezar
        {
            color:red;
        }
        .Pasokh
        {
            color:green;
        }
        .Baste
        {
            color:gray;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <h2>تاریخچه تیکت شما</h2>
        <div style="font-family:'BYekan'">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" Width="500px" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="Tarikh" HeaderText="آخرین بروز رسانی" ReadOnly="True" SortExpression="Tarikh" />
                    <asp:BoundField DataField="Title" HeaderText="موضوع" SortExpression="Title" />
                    <asp:BoundField DataField="Esm" HeaderText="نام کاربر" SortExpression="Esm" />
                    <asp:BoundField DataField="sts1" HeaderText="وضعیت" SortExpression="sts1" >
                    <ItemStyle CssClass="Entezar"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="ID" HeaderText="شماره تیکت" InsertVisible="False" ReadOnly="True" SortExpression="ID">
                    <ItemStyle Width="70px" HorizontalAlign="Center"/>
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" SelectCommand="SELECT (SELECT TOP (1) ReplyDate FROM TicketComment WHERE (TicketID = Ticket.ID) order by ID desc) AS Tarikh, Title, sts1, ID,(select Username From Members Where ID = UserID) as Esm FROM Ticket order  by Tarikh desc">
        </asp:SqlDataSource>
        </div>
    </form>
</asp:Content>


<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageADS.aspx.cs" Inherits="Admin_ManageADS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت تبلیغات</title>
    <link rel="stylesheet" href="../Files/js-persian-cal.css" type="text/css" />
    <script type="text/javascript" src="../Js/js-persian-cal.min.js" ></script>
    <style type="text/css">
        .auto-style6
        {
            text-align: left;
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
    </style>
    <script>
        function showme() {
            alert(document.getElementById('extra1').value);
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>تبلیغات</h2>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="500px" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "></asp:Button>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Update" Text="بررسی" OnClientClick="return confirm('آیا شما مطمئن به بررسی هستید؟'); "></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AdsName" HeaderText="نام تبلیغ" SortExpression="AdsName">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EndDate" HeaderText="وضعیت نمایش" SortExpression="EndDate">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EndDate" HeaderText="تاریخ اتمام" SortExpression="EndDate">
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [Ads] WHERE [ID] = @original_ID " InsertCommand="INSERT INTO [Ads] ([ImageADR]) VALUES (@ImageADR)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Ads]" UpdateCommand="UPDATE [Ads] SET [ImageADR] = @ImageADR WHERE [ID] = @original_ID AND (([ImageADR] = @original_ImageADR) OR ([ImageADR] IS NULL AND @original_ImageADR IS NULL))" OnUpdating="SqlDataSource1_Updating">
                        <DeleteParameters>
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_ImageADR" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ImageADR" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ImageADR" Type="String" />
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_ImageADR" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
        <table style="width: 490px;">
            <tr>
                <td style="width: 99px;text-align: left;">نام تبلیغ :</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox5" runat="server" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">آدرس عکس :</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox2" runat="server" Width="120px"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style6">URL :</td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBox3" runat="server" Width="196px">#</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">تاریخ شروع :</td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBox1" runat="server" Width="55px" style="padding:3px;margin:0"></asp:TextBox>
                    <script type="text/javascript">
                        var objCal5 = new AMIB.persianCalendar('ContentPlaceHolder1_TextBox1', {
                            extraInputID: 'extra1',
                            extraInputFormat: 'YYYY/MM/DD yyyy/mm/dd',
                        }
                        );
	                </script>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">تاریخ پایان :</td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBox4" runat="server" Width="55px" style="padding:3px;margin:0"></asp:TextBox>
                    <script type="text/javascript">
                        var objCal5 = new AMIB.persianCalendar('ContentPlaceHolder1_TextBox4', {
                            extraInputID: 'extra1',
                            extraInputFormat: 'YYYY/MM/DD yyyy/mm/dd',
                        }
                        );
	                </script>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">کلمات کلیدی:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox6" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="height: 30px;" class="auto-style8">
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="ثبت"/>
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

    </form>
</asp:Content>


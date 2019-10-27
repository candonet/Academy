<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="AddHotel.aspx.cs" Inherits="Admin_AddHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="image/chosen.jquery.js"></script>
    <link rel="stylesheet" href="image/bootstrap-chosen.css" />
    <script>
        $(function () {
            $('#ContentPlaceHolder1_DropDownList6').chosen();
            $('#ContentPlaceHolder1_DropDownList2').chosen();
            $('#ContentPlaceHolder1_DropDownList1').chosen();
            $('#ContentPlaceHolder1_DropDownList3').chosen();
            $('#ContentPlaceHolder1_DropDownList4').chosen();
        });
    </script>
    <title>مدیریت هتل ها</title>
    <style type="text/css">
        .HeaderDataList
        {
             font-family:"BYekan";
        }
        .tdEmpty
        {
            padding-left:5px;
            padding-right:5px;
        }
        .tdEmpty:hover
        {
            -moz-transition:all 200ms linear 0s;
			-webkit-transition:all 200ms linear 0s;
			-o-transition:all 200ms linear 0s;
			-ms-transition:all 200ms linear 0s;
            background-color: #E6E6E6;
            color: black;
        }
        .auto-style1
        {
            text-align: left;
            vertical-align:top;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server" enctype="multipart/form-data">
        
        <h2>مدیریت هتل</h2>
        <table style="width:800px">
            <tr>
                <td style="vertical-align:top;width:290px">
                    <table style="width:100%">
                        <tr>
                            <td>
                                کشور<asp:DropDownList ID="DropDownList2" runat="server" Width="170px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>
                                شهر<asp:DropDownList ID="DropDownList6" runat="server" Width="170px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left">
                                <asp:TextBox ID="SearchHotel" runat="server" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                            </td>
                            <td style="text-align:right">
                                <asp:Button ID="Button8" runat="server" Text="جستجو" OnClick="Button8_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" Width="100%" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound1">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "></asp:Button>
                                    <asp:Button ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="بررسی" OnClientClick="return confirm('آیا شما مطمئن به بررسی این سطر هستید؟'); "></asp:Button>
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Title" HeaderText="نام هتل" SortExpression="Title" >
                            <HeaderStyle CssClass="HeaderDataList" />
                            <ItemStyle CssClass="tdEmpty" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Active" HeaderText="وضعیت" SortExpression="Active" >
                            <HeaderStyle CssClass="HeaderDataList" />
                            <ItemStyle CssClass="tdEmpty" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </td>
                <td>

                    <table style="width: 400px;">
                        <tr>
                            <td style="width: 99px;" class="auto-style1">نام هتل :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="HotelName" runat="server" Width="196px" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">نام پروفایل هتل :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="HotelProfile" runat="server" Width="196px" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">آدرس آیکون هتل:</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="TextBox3" runat="server" Width="196px" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                                <br />
                                <asp:FileUpload ID="FileUpload2" runat="server" />
                                (110x170)</td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">&nbsp;تعداد ستاره هتل:</td>
                            <td class="auto-style8">
                                <asp:DropDownList ID="DropDownList5" runat="server" Font-Names="Tahoma" Height="100%" Width="207px">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">توضیحات :</td>
                            <td class="auto-style9">
                                <asp:TextBox ID="Tozihat" runat="server" Width="196px" Height="104px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">درباره هتل :</td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox1" runat="server" Width="196px" Height="104px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">نام کشور :</td>
                            <td class="auto-style8">
                                <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Tahoma" Height="100%" Width="207px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">نام شهر :</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Tahoma" Height="100%" Width="207px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">نام ناحیه :</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList4" runat="server" Font-Names="Tahoma" Height="100%" Width="207px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">کلمات کلیدی :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="KeyWord" runat="server" Width="196px" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;height: 30px;" class="auto-style1">&nbsp;</td>
                            <td style="height: 30px;text-align:right" class="auto-style8">
                                <div style="text-align:center;width:220px">
                                    <asp:Button ID="MenuInsert" runat="server" OnClick="Button1_Click" Text="درج جدید"/>
                                    &nbsp;<asp:Button ID="MenuInsert2" runat="server" Text="ویرایش" Enabled="False" OnClick="MenuInsert2_Click"/>
                                    &nbsp;<asp:Button ID="Button2" runat="server" Enabled="False" OnClick="Button2_Click" Text="لغو بررسی" />
                                    <br />
                                    <asp:Button ID="Button6" runat="server" Text="تایید" Width="50px" Enabled="False" OnClick="Button6_Click" />
                                    &nbsp;<asp:Button ID="Button7" runat="server" Text="تعلیق" Width="50px" Enabled="False" OnClick="Button7_Click" />
                                </div>
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">&nbsp;</td>
                            <td class="auto-style8">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
        <h2></h2>
        <table style="width:800px"  id="TakmiLTable" runat="server">
            <tr>
                <td style="vertical-align:top">

                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" Width="250px" OnRowDeleting="GridView2_RowDeleting" OnRowUpdating="GridView2_RowUpdating">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "></asp:Button>
                                </ItemTemplate>
                                <HeaderStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="NN" HeaderText="مشخصات هتل" SortExpression="Nam" >
                            <HeaderStyle CssClass="HeaderDataList" />
                            <ItemStyle CssClass="tdEmpty" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                    <br />
                    <table style="width:250px">
                        <tr>
                            <td>
                                امکانات :</td>
                            <td>
                                
                                <asp:DropDownList ID="DropDownList10" runat="server" Font-Names="Tahoma" Height="100%" Width="150px">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                </asp:DropDownList>
                                
                            </td>
                            <td>

                                <asp:Button ID="Button4" runat="server" Text="اضافه" OnClick="Button4_Click" />

                            </td>
                        </tr>
                        <tr style="border:1px solid black">
                            <td>
                               مشخصه جدید        
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" Width="150px" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="اضافه" OnClick="Button3_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [HotelDetail] WHERE [ID] = @original_ID AND (([Nam] = @original_Nam) OR ([Nam] IS NULL AND @original_Nam IS NULL)) AND (([HotelID] = @original_HotelID) OR ([HotelID] IS NULL AND @original_HotelID IS NULL))" InsertCommand="INSERT INTO [HotelDetail] ([Nam], [HotelID]) VALUES (@Nam, @HotelID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [HotelDetail].[ID], [HotelDetail].[Nam], [HotelDetail].[HotelID],InfoHotel.Nam as NN FROM [HotelDetail],InfoHotel WHERE ([HotelID] = @HotelID) AND InfoHotel.ID=HotelDetail.Nam" UpdateCommand="UPDATE [HotelDetail] SET [Nam] = @Nam, [HotelID] = @HotelID WHERE [ID] = @original_ID AND (([Nam] = @original_Nam) OR ([Nam] IS NULL AND @original_Nam IS NULL)) AND (([HotelID] = @original_HotelID) OR ([HotelID] IS NULL AND @original_HotelID IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_Nam" Type="Int64" />
                            <asp:Parameter Name="original_HotelID" Type="Int64" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Nam" Type="Int64" />
                            <asp:Parameter Name="HotelID" Type="Int64" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="HotelID" SessionField="HotelID" Type="Int64" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Nam" Type="Int64" />
                            <asp:SessionParameter Name="HotelID" SessionField="HotelID" Type="Int64" />
                            <asp:Parameter Name="original_ID" Type="Int64" />
                            <asp:Parameter Name="original_Nam" Type="Int64" />
                            <asp:Parameter Name="original_HotelID" Type="Int64" />
                        </UpdateParameters>
                    </asp:SqlDataSource>

                </td>
                <td style="vertical-align:top">
                    <table style="width: 400px;">
                        <tr>
                            <td style="width: 99px;" class="auto-style1">تعداد اتاق :</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="txt1" runat="server" Width="196px" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">تلفن:</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="txt2" runat="server" Width="196px" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">سایت:</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="txt3" runat="server" Width="196px" onkeydown = "return (event.keyCode!=13);"></asp:TextBox><span style="font-size:x-small;direction:rtl"> بدون //:http</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">وضعیت سایت:</td>
                            <td class="auto-style8">
                                <asp:DropDownList ID="DropDownList7" runat="server" Width="90px">
                                    <asp:ListItem>فعال</asp:ListItem>
                                    <asp:ListItem>فیلتر شده</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">آدرس :</td>
                            <td class="auto-style9">
                                <asp:TextBox ID="txt4" runat="server" Width="196px" Height="104px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;height: 30px;" class="auto-style1">&nbsp;</td>
                            <td style="height: 30px;" class="auto-style8">
                                &nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="ثبت" Width="50px" />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 99px;" class="auto-style1">&nbsp;</td>
                            <td class="auto-style8">
                                <asp:Label ID="Label7" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
            </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [Hotel] WHERE [ID] = @original_ID AND (([Title] = @original_Title) OR ([Title] IS NULL AND @original_Title IS NULL))" InsertCommand="INSERT INTO [Hotel] ([Title]) VALUES (@Title)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [Title],[Active] FROM [Hotel]" UpdateCommand="UPDATE [Hotel] SET [Title] = @Title WHERE [ID] = @original_ID AND (([Title] = @original_Title) OR ([Title] IS NULL AND @original_Title IS NULL))">
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
	<h2 id="HeaderImages" runat="server">تصاویر هتل</h2>
        <table style="width:550px" runat="server" id="ImageTable">
            <tr>
                <td>
                    <table style="width:80%">
                        <tr>
                            <td style="width:50%">
                                کلملات کلیدی<asp:TextBox ID="KeyW1" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:50%">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:50%">
                                کلملات کلیدی<asp:TextBox ID="KeyW2" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:50%">
                                <asp:FileUpload ID="FileUpload3" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:50%">
                                کلملات کلیدی<asp:TextBox ID="KeyW3" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:50%">
                                <asp:FileUpload ID="FileUpload4" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:50%">
                                کلملات کلیدی<asp:TextBox ID="KeyW4" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:50%">
                                <asp:FileUpload ID="FileUpload5" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:50%">
                                کلملات کلیدی<asp:TextBox ID="KeyW5" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:50%">
                                <asp:FileUpload ID="FileUpload6" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="آپلود عکس" OnClick="Button1_Click1" />
                    <br />
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                    <asp:DataList ID="DataList1" runat="server" OnDeleteCommand="DataList1_DeleteCommand" RepeatColumns="5">
                        <ItemTemplate>
                            <table style="height:100px;width:100px">
                                <tr>
                                    <td align="center" valign="top">
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ImageAddress","~/IMG/{0}") %>' style="width:100px;height:100px" Target="_blank">
                                <asp:Image ID="Image1" runat="server" style="width:100px;height:100px" ImageUrl='<%# Eval("ImageAddress","~/IMG/th/{0}") %>'/>
                            </asp:HyperLink>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("ImageAddress") %>' Visible="false"></asp:Label>
                                        <asp:Button ID="DeleteBTN" runat="server" CommandName="delete" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); " Text="حذف عکس" />
                                    </td>
                                </tr>
                            </table>
                <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:DataList ID="DataList2" runat="server" RepeatColumns="20" OnDeleteCommand="DataList2_DeleteCommand">
                    <ItemTemplate>
                    
                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("PageNumb") %>' CommandName="delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:DataList>
                    <br />

                    <asp:Label ID="Label5" runat="server"></asp:Label>

                </td>
            </tr>
        </table>
    </form>
</asp:Content>


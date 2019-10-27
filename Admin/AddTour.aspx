<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="AddTour.aspx.cs" Inherits="Admin_AddTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="../Files/js-persian-cal.css" type="text/css" />
    <script type="text/javascript" src="../Js/js-persian-cal.min.js" ></script>
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
            $('#<%=DropDownList14.ClientID%>').chosen();
            $('#<%=DropDownList15.ClientID%>').chosen();
            $('#<%=DropDownList16.ClientID%>').chosen();
            $('#<%=DropDownList17.ClientID%>').chosen();
            $('#<%=DropDownList18.ClientID%>').chosen();
            $('#<%=DropDownList19.ClientID%>').chosen();
            $('#<%=DropDownList20.ClientID%>').chosen();
            $('#<%=DropDownList21.ClientID%>').chosen();
            $('#<%=DropDownList22.ClientID%>').chosen();
            $('#<%=DropDownList23.ClientID%>').chosen();
            $('#<%=DropDownList24.ClientID%>').chosen();
            $('#<%=DropDownList25.ClientID%>').chosen();
            $('#<%=DropDownList26.ClientID%>').chosen();
            $('#<%=DropDownList27.ClientID%>').chosen();
            $('#<%=DropDownList28.ClientID%>').chosen();
            $('#<%=DropDownList29.ClientID%>').chosen();
            $('#<%=DropDownList30.ClientID%>').chosen();
            $('#<%=DropDownList31.ClientID%>').chosen();
            $('#<%=DropDownList32.ClientID%>').chosen();
            $('#<%=DropDownList33.ClientID%>').chosen();
            $('#<%=DropDownList34.ClientID%>').chosen();
            $('#<%=DropDownList35.ClientID%>').chosen();
            $('#<%=DropDownList36.ClientID%>').chosen();
        });
    </script>
    <script type="text/ecmascript">
        function Exchange(inputItem) {
            //var d = document;
            //var val = d.getElementById(inputItem).value;
            //val = val.replace(",", "");
            //while (/(\d+)(\d{3})/.test(val.toString())) {
            //    val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
            //}
            //d.getElementById(inputItem).value = val;
        }

    </script>
    <title>مدیریت تور ها</title>
    <style type="text/css">
        .auto-style6
        {
            width: 99px;
            text-align: left;
            height: 26px;
        }
       
            .auto-style10
            {
                text-align: right;
                width: 291px;
            }
            .auto-style11
            {
                text-align: right;
                height: 26px;
                width: 291px;
            }
            .auto-style12
            {
                text-align: right;
                height: 30px;
                width: 291px;
            }
        .TDTXT
        {
            vertical-align:top;
            width: 99px;
            text-align: left;
        }
        .auto-style13
        {
            width: 166px;
        }
        .auto-style14
        {
            width: 166px;
            text-align: left;
            height: 26px;
        }
        .auto-style15
        {
            vertical-align: top;
            width: 166px;
            text-align: left;
        }
        .auto-style16
        {
            height: 30px;
            width: 166px;
        }
        .HeaderDataList
        {
             font-family:"BYekan";
        }
        .tdEmpty
        {
            margin:0;
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
        .auto-style17
        {
            vertical-align: central;
            width: 49px;
            text-align: left;
            height: 24px;
        }
        .auto-style18
        {
            width: 427px;
        }
        .HeaderDataList
        {
             font-size:14.5px;
             font-family:"BYekan";
             font-weight:normal;
        }
        .tdEmpty
        {
            
            font-size:13.5px;
            font-family:"BYekan";
            padding-left:5px;
            padding-right:5px;
        }
        .auto-style20
        {
            width: 136px;
        }
        .auto-style21
        {
            vertical-align: top;
            width: 136px;
            text-align: left;
        }
        .auto-style22
        {
            height: 30px;
            width: 136px;
        }
        .auto-style23
        {
            text-align: right;
            width: 263px;
        }
        .auto-style24
        {
            text-align: right;
            height: 30px;
            width: 263px;
        }
        .TaedNashode
        {
            font-size:13.5px;
            font-family:"BYekan";
            color:red;
            
        }
        .TaedShode
        {
            font-size: 13.5px;
            font-family: "BYekan";
            color: green;
        }
        .auto-style25
        {
            text-align: right;
            width: 67px;
        }
        .auto-style27
        {
            vertical-align: central;
            width: 67px;
            text-align: left;
            height: 24px;
        }
        .auto-style28
        {
            vertical-align: central;
            text-align: right;
            width: 346px;
            height: 24px;
        }
        .auto-style29
        {
            text-align: right;
            width: 69px;
            height: 24px;
        }
        .auto-style30
        {
            text-align: right;
            width: 72px;
            height: 24px;
        }
    </style>
    <script type="text/javascript">
        function MoveToN(n) {
            window.scrollTo(0, n);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">

        <h2>مدیریت تور</h2>
        <div style="width:550px">
        <table style="width:100%">
            <tr>
                <td>
                    آژانس<asp:DropDownList ID="DropDownList8" runat="server" Width="120px" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    نوع تور<asp:DropDownList ID="DropDownList12" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    کشور<asp:DropDownList ID="DropDownList13" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList13_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    شهر<asp:DropDownList ID="DropDownList14" runat="server" Width="120px" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"  Width="850px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnRowUpdating="GridView3_RowUpdating" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" OnPageIndexChanged="GridView3_PageIndexChanged" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowDataBound="GridView3_RowDataBound" >
            <Columns>
                <asp:BoundField HeaderText="" DataField="ID" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField HeaderText="نام تور" DataField="Nam" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField HeaderText="آژانس" DataField="Agency" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" HorizontalAlign="Center" />
                </asp:BoundField>
                 <asp:BoundField HeaderText="نوع تور" DataField="Kind" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" HorizontalAlign="Center" />
                </asp:BoundField>
                 <asp:BoundField HeaderText="مدت اقامت" DataField="modat" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="تاریخ اتمام" DataField="tarikh2" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" HorizontalAlign="Center" />
                </asp:BoundField>
                 <asp:BoundField HeaderText="وضعیت" DataField="tarikh2" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Update" Text="بررسی"></asp:Button>
                    </ItemTemplate>
                    <HeaderStyle Width="50px" />
                </asp:TemplateField>
            </Columns>
            
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
            
            </asp:GridView>

        </div>
        <table>
            <tr>
                <td>
                    <table style="width: 400px;">
                        <tr style="display:none">
                            <td style="width: 99px;text-align: left;">نام تور ::</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Tahoma" Height="100%" Width="157px">
                                </asp:DropDownList>
                                <asp:Button ID="Button1" runat="server" Text="انتخاب" OnClick="Button1_Click2" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">نام آژانس :</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList15" runat="server" Font-Names="Tahoma" Height="100%" Width="207px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td class="auto-style6">تور انتخاب شده :</td>
                            <td class="auto-style11">
                                <asp:TextBox ID="CurrentCity" runat="server" Width="196px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">عنوان تور :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="TextBox1" runat="server" Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">دسته بندی :</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList5" runat="server" Font-Names="Tahoma" Height="100%" Width="207px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">نام کشور :</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Tahoma" Height="100%" Width="207px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">نام شهر :</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Tahoma" Height="100%" Width="207px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">نام ناحیه :</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList4" runat="server" Font-Names="Tahoma" Height="100%" Width="207px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">مبدا :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="CityName" runat="server" Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">مدت تور :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="TextBox8" runat="server" Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">نوع سفر:</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="TextBox2" runat="server" Width="196px" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">آفر:</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList10" runat="server" Font-Names="BYekan" Height="100%" Width="60px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Size="Small">
                                    <asp:ListItem>بله</asp:ListItem>
                                    <asp:ListItem>خیر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">لوکس:</td>
                            <td class="auto-style10">
                                <asp:DropDownList ID="DropDownList11" runat="server" Font-Names="BYekan" Height="100%" Width="60px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Size="Small">
                                    <asp:ListItem>بله</asp:ListItem>
                                    <asp:ListItem>خیر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">تاریخ شروع :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="TextBox3" runat="server" Width="60px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                                <script type="text/javascript">
                                    var objCal5 = new AMIB.persianCalendar('ContentPlaceHolder1_TextBox3', {
                                        extraInputID: 'extra1',
                                        extraInputFormat: 'YYYY/MM/DD yyyy/mm/dd',
                                    }
                                    );
	                            </script>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">تاریخ پایان :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="TextBox7" runat="server" Width="60px"></asp:TextBox>
                                <script type="text/javascript">
                                    var objCal5 = new AMIB.persianCalendar('ContentPlaceHolder1_TextBox7', {
                                        extraInputID: 'extra1',
                                        extraInputFormat: 'YYYY/MM/DD yyyy/mm/dd',
                                    }
                                    );
	                            </script>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="width: 99px;text-align: left;height: 30px;"></td>
                            <td class="auto-style12">
                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="درج جدید"/>
                                &nbsp;<asp:Button ID="Button4" runat="server" Text="ویرایش" Enabled="False" OnClick="Button4_Click1"/>
                                &nbsp;<asp:Button ID="Button5" runat="server" Text="حذف" OnClick="Button5_Click" Enabled="False" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "/>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 99px;text-align: left;">&nbsp;</td>
                            <td class="auto-style10">
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align:top" class="auto-style18">
                    <table>
                        <tr>
                            <td class="TDTXT">مدارک لازم :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="TextBox4" runat="server" Width="196px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TDTXT">خدمات آژانس :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="TextBox5" runat="server" Width="196px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TDTXT">توضیحات :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="TextBox6" runat="server" Width="196px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TDTXT">کلمات کلیدی :</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="KeyWord" runat="server" Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div   runat="server" id="AdsTable">
        <h2>تبلیغات</h2>
            <table>
                <tr>
                    <td class="auto-style27">انتخاب عکس:</td>
                    <td class="auto-style28">
                        <asp:TextBox ID="TextBox9" runat="server" Height="11px" Width="90px"></asp:TextBox>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td class="auto-style17">وضعیت:</td>
                    <td class="auto-style29">
                        <asp:DropDownList ID="DropDownList7" runat="server">
                            <asp:ListItem>مخفی</asp:ListItem>
                            <asp:ListItem>نمایش</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style30">
                        <asp:Button ID="Button2" runat="server" Text="ثبت " Width="68px" OnClick="Button2_Click" Height="25px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style25">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <h2 id="distnationTitle" runat="server">مقصد</h2>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" Width="1000px" OnRowDeleting="GridView2_RowDeleting" OnRowUpdating="GridView2_RowUpdating">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "></asp:Button>
                        <asp:Button ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="بررسی" OnClientClick="return confirm('آیا شما مطمئن به بررسی این سطر هستید؟'); "></asp:Button>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:BoundField DataField="nam" HeaderText="نام" SortExpression="nam" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                    </asp:BoundField>
                <asp:BoundField DataField="modat" HeaderText="مدت" SortExpression="modat" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                    </asp:BoundField>
                <asp:BoundField DataField="tozihat" HeaderText="توضیحات" SortExpression="tozihat" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" Width="500px" />
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [beTB] WHERE [ID] = @original_ID AND (([nam] = @original_nam) OR ([nam] IS NULL AND @original_nam IS NULL)) AND (([modat] = @original_modat) OR ([modat] IS NULL AND @original_modat IS NULL)) AND (([tozihat] = @original_tozihat) OR ([tozihat] IS NULL AND @original_tozihat IS NULL))" InsertCommand="INSERT INTO [beTB] ([nam], [modat], [tozihat]) VALUES (@nam, @modat, @tozihat)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [nam], [modat], [tozihat] FROM [beTB] WHERE ([TourID] = @TourID)" UpdateCommand="UPDATE [beTB] SET [nam] = @nam, [modat] = @modat, [tozihat] = @tozihat WHERE [ID] = @original_ID AND (([nam] = @original_nam) OR ([nam] IS NULL AND @original_nam IS NULL)) AND (([modat] = @original_modat) OR ([modat] IS NULL AND @original_modat IS NULL)) AND (([tozihat] = @original_tozihat) OR ([tozihat] IS NULL AND @original_tozihat IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int64" />
                <asp:Parameter Name="original_nam" Type="String" />
                <asp:Parameter Name="original_modat" Type="String" />
                <asp:Parameter Name="original_tozihat" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="nam" Type="String" />
                <asp:Parameter Name="modat" Type="String" />
                <asp:Parameter Name="tozihat" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="TourID" SessionField="TourID" Type="Int64" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="nam" Type="String" />
                <asp:Parameter Name="modat" Type="String" />
                <asp:Parameter Name="tozihat" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int64" />
                <asp:Parameter Name="original_nam" Type="String" />
                <asp:Parameter Name="original_modat" Type="String" />
                <asp:Parameter Name="original_tozihat" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>

        <table style="width: 400px;" runat="server" id="TableBe">
            <tr>
                <td style="text-align: left;" class="auto-style13">نام مقصد :</td>
                <td class="auto-style10">
                    <asp:TextBox ID="Distn" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">مدت اقامت :</td>
                <td class="auto-style11">
                    <asp:TextBox ID="modateq" runat="server" Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">توضیحات :</td>
                <td class="auto-style10">
                    <asp:TextBox ID="Tozzih" runat="server" Width="196px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style16"></td>
                <td class="auto-style12">
                    <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="درج جدید"/>
                    &nbsp;<asp:Button ID="Button10" runat="server" Text="ویرایش" Enabled="False" OnClick="Button10_Click"/>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style13">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
     <h2 id="HotelTitle" runat="server">هتل ها</h2>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1000px" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="حذف" OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "></asp:Button>
                        <asp:Button ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="بررسی" OnClientClick="return confirm('آیا شما مطمئن به بررسی این سطر هستید؟'); "></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="esm1" HeaderText="هتل" SortExpression="esm1"  >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                </asp:BoundField>
                <asp:BoundField DataField="esm2" HeaderText="هتل" SortExpression="esm2"  >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                </asp:BoundField>
                <asp:BoundField DataField="esm3" HeaderText="هتل" SortExpression="esm3"  >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                </asp:BoundField>
                <asp:BoundField DataField="esm4" HeaderText="هتل" SortExpression="esm4"  >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                </asp:BoundField>
                <asp:BoundField DataField="esm5" HeaderText="هتل" SortExpression="esm5"  >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                </asp:BoundField>
                <asp:BoundField DataField="Emt" HeaderText="امتیاز" SortExpression="Emt" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                </asp:BoundField>
                <asp:BoundField DataField="Setare" HeaderText="درجه" SortExpression="Setare" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                </asp:BoundField>
                <asp:BoundField DataField="HotelKhademat" HeaderText="خدمات" SortExpression="HotelKhademat" >
                <HeaderStyle CssClass="HeaderDataList" />
                <ItemStyle CssClass="tdEmpty" />
                </asp:BoundField>
                <asp:BoundField DataField="qeimat1" HeaderText="قیمت ۲ تخته (هر نفر)" SortExpression="qeimat1">
                <ItemStyle HorizontalAlign="Center" CssClass="tdEmpty" />
                <HeaderStyle CssClass="HeaderDataList" />
                </asp:BoundField>
                <asp:BoundField DataField="qeimat2" HeaderText="قیمت ۱ تخته (هر نفر)" SortExpression="qeimat2" >
                <ItemStyle HorizontalAlign="Center" CssClass="tdEmpty" />
                    <HeaderStyle CssClass="HeaderDataList" />
                </asp:BoundField>
                <asp:BoundField DataField="qeimat3" HeaderText="کودک با تخت ۶ تا ۱۲ سال" SortExpression="qeimat3" >
                <ItemStyle HorizontalAlign="Center" CssClass="tdEmpty"/>
                    <HeaderStyle CssClass="HeaderDataList" />
                </asp:BoundField>
                <asp:BoundField DataField="qeimat4" HeaderText="کودک بدون تخت ۲ تا ۶ سال" SortExpression="qeimat4" >
                <ItemStyle HorizontalAlign="Center" CssClass="tdEmpty"/>
                    <HeaderStyle CssClass="HeaderDataList" />
                </asp:BoundField>
                <asp:BoundField DataField="tozihat" HeaderText="توضيحات" SortExpression="tozihat" >
                    <ItemStyle CssClass="tdEmpty" />
                <HeaderStyle CssClass="HeaderDataList" />
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

        <table style="width: 750px;" runat="server" id="TableHotel">
            <tr >
                <td id="sl1" runat="server" style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td id="sl4" runat="server" class="auto-style23">
                    <asp:DropDownList ID="DropDownList6" runat="server" Font-Names="Tahoma" Height="100%" Width="150px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="Button11" runat="server" Text="هتل وجود ندارد" OnClick="Button11_Click" Width="85px" />
                </td>
                <td>

                    <asp:Button ID="Button13" runat="server" Text="اضافه کردن هتل ترکیبی" OnClick="Button13_Click" />
                    <span style="font-size:x-small"> برای تور های ترکیبی</span>
                </td>
            </tr>
            <tr id="sl2" runat="server">
                <td style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="HotelName" runat="server" Width="107px"></asp:TextBox>
                    <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="انتخاب از لیست" Width="85px" />
                </td>
                <td>

                </td>
            </tr>
            <tr id="sl3" runat="server">
                <td style="text-align: left;" class="auto-style20">تعداد ستاره :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList9" runat="server" Font-Names="Tahoma" Height="100%" Width="48px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style20">خدمات :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList16" runat="server" Font-Names="Tahoma" Height="100%" Width="70px">
                        <asp:ListItem>B.B</asp:ListItem>
                        <asp:ListItem>F.B</asp:ListItem>
                        <asp:ListItem>H.B</asp:ListItem>
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>U.All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln11" runat="server">
                <td style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList21" runat="server" Font-Names="Tahoma" Height="100%" Width="150px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="Button6" runat="server" Text="هتل وجود ندارد" Width="85px" OnClick="Button6_Click" />
                </td>
                <td>
                    کشور : <asp:DropDownList ID="DropDownList33" runat="server" Width="167px" OnSelectedIndexChanged="DropDownList33_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr id="sln12" runat="server">
                <td style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="HotelName2" runat="server" Width="107px"></asp:TextBox>
                    <asp:Button ID="Button15" runat="server" Text="انتخاب از لیست" Width="85px" OnClick="Button15_Click" />
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln13" runat="server">
                <td style="text-align: left;" class="auto-style20">تعداد ستاره :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList22" runat="server" Font-Names="Tahoma" Height="100%" Width="48px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln14" runat="server">
                <td style="text-align: left;" class="auto-style20">خدمات :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList23" runat="server" Font-Names="Tahoma" Height="100%" Width="70px">
                        <asp:ListItem>B.B</asp:ListItem>
                        <asp:ListItem>F.B</asp:ListItem>
                        <asp:ListItem>H.B</asp:ListItem>
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>U.All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln21" runat="server">
                <td style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList24" runat="server" Font-Names="Tahoma" Height="100%" Width="150px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="Button16" runat="server" Text="هتل وجود ندارد" Width="85px" OnClick="Button16_Click" />
                </td>
                <td>
                    کشور : <asp:DropDownList ID="DropDownList34" runat="server" Width="167px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList34_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr id="sln22" runat="server">
                <td style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="HotelName3" runat="server" Width="107px"></asp:TextBox>
                    <asp:Button ID="Button18" runat="server" Text="انتخاب از لیست" Width="85px" OnClick="Button18_Click" />
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln23" runat="server">
                <td style="text-align: left;" class="auto-style20">تعداد ستاره :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList25" runat="server" Font-Names="Tahoma" Height="100%" Width="48px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln24" runat="server">
                <td style="text-align: left;" class="auto-style20">خدمات :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList26" runat="server" Font-Names="Tahoma" Height="100%" Width="70px">
                        <asp:ListItem>B.B</asp:ListItem>
                        <asp:ListItem>F.B</asp:ListItem>
                        <asp:ListItem>H.B</asp:ListItem>
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>U.All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln31" runat="server">
                <td style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList27" runat="server" Font-Names="Tahoma" Height="100%" Width="150px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="Button19" runat="server" Text="هتل وجود ندارد" Width="85px" OnClick="Button19_Click" />
                </td>
                <td>
                    کشور : <asp:DropDownList ID="DropDownList35" runat="server" Width="167px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList35_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr id="sln32" runat="server">
                <td style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="HotelName4" runat="server" Width="107px"></asp:TextBox>
                    <asp:Button ID="Button21" runat="server" Text="انتخاب از لیست" Width="85px" OnClick="Button21_Click" />
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln33" runat="server">
                <td style="text-align: left;" class="auto-style20">تعداد ستاره :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList28" runat="server" Font-Names="Tahoma" Height="100%" Width="48px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln34" runat="server">
                <td style="text-align: left;" class="auto-style20">خدمات :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList29" runat="server" Font-Names="Tahoma" Height="100%" Width="70px">
                        <asp:ListItem>B.B</asp:ListItem>
                        <asp:ListItem>F.B</asp:ListItem>
                        <asp:ListItem>H.B</asp:ListItem>
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>U.All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln41" runat="server">
                <td style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList30" runat="server" Font-Names="Tahoma" Height="100%" Width="150px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="Button22" runat="server" Text="هتل وجود ندارد" Width="85px" OnClick="Button22_Click" />
                </td>
                <td>
                    کشور : <asp:DropDownList ID="DropDownList36" runat="server" Width="167px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList36_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr id="sln42" runat="server">
                <td style="text-align: left;" class="auto-style20">نام هتل :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="HotelName5" runat="server" Width="107px"></asp:TextBox>
                    <asp:Button ID="Button24" runat="server" Text="انتخاب از لیست" Width="85px" OnClick="Button24_Click" />
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln43" runat="server">
                <td style="text-align: left;" class="auto-style20">تعداد ستاره :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList31" runat="server" Font-Names="Tahoma" Height="100%" Width="48px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr id="sln44" runat="server">
                <td style="text-align: left;" class="auto-style20">خدمات :</td>
                <td class="auto-style23">
                    <asp:DropDownList ID="DropDownList32" runat="server" Font-Names="Tahoma" Height="100%" Width="70px">
                        <asp:ListItem>B.B</asp:ListItem>
                        <asp:ListItem>F.B</asp:ListItem>
                        <asp:ListItem>H.B</asp:ListItem>
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>U.All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style20">قيمت 2 تخته (هر نفر) :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="Qeimat1" runat="server" Width="196px"  onkeyup="Exchange(this.id)"></asp:TextBox>
                </td>
                <td>

                    قیمت اضافه:<asp:TextBox ID="Qeimat1P" runat="server" onkeyup="Exchange(this.id)"></asp:TextBox>

                    <asp:DropDownList ID="DropDownList17" runat="server" Width="60px">
                        <asp:ListItem>یورو</asp:ListItem>
                        <asp:ListItem>دلار</asp:ListItem>
                        <asp:ListItem>پوند</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style20">قیمت ۱ تخته (هر نفر) :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="Qeimat2" runat="server" Width="196px"  onkeyup="Exchange(this.id)"></asp:TextBox>
                </td>
                <td>

                    قیمت اضافه:<asp:TextBox ID="Qeimat2P" runat="server" onkeyup="Exchange(this.id)"></asp:TextBox>

                    <asp:DropDownList ID="DropDownList18" runat="server" Width="60px">
                        <asp:ListItem>یورو</asp:ListItem>
                        <asp:ListItem>دلار</asp:ListItem>
                        <asp:ListItem>پوند</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style20">کودک با تخت ۶ تا ۱۲ سال :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="Qeimat3" runat="server" Width="196px" OnTextChanged="TextBox2_TextChanged" onkeyup="Exchange(this.id)"></asp:TextBox>
                </td>
                <td>

                    قیمت اضافه:<asp:TextBox ID="Qeimat3P" runat="server" onkeyup="Exchange(this.id)"></asp:TextBox>

                    <asp:DropDownList ID="DropDownList19" runat="server" Width="60px">
                        <asp:ListItem>یورو</asp:ListItem>
                        <asp:ListItem>دلار</asp:ListItem>
                        <asp:ListItem>پوند</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style20">کودک بدون تخت ۲ تا ۶ سال :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="Qeimat4" runat="server" Width="196px" onkeyup="Exchange(this.id)"></asp:TextBox>
                </td>
                <td>
                    قیمت اضافه:<asp:TextBox ID="Qeimat4P" runat="server" onkeyup="Exchange(this.id)"></asp:TextBox>

                    <asp:DropDownList ID="DropDownList20" runat="server" Width="60px">
                        <asp:ListItem>یورو</asp:ListItem>
                        <asp:ListItem>دلار</asp:ListItem>
                        <asp:ListItem>پوند</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style21">توضیحات :</td>
                <td class="auto-style23">
                    <asp:TextBox ID="Tozihat" runat="server" Width="196px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style22"></td>
                <td class="auto-style24">
                    <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="ثبت"/>
                    &nbsp;<asp:Button ID="Button8" runat="server" Text="ویرایش" Enabled="False" OnClick="Button8_Click"/>
                    &nbsp;</td>
                <td>

                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style20">&nbsp;</td>
                <td class="auto-style23">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
                <td>

                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" DeleteCommand="DELETE FROM [TourHotel] WHERE [ID] = @original_ID " InsertCommand="INSERT INTO [TourHotel] ([HotelID], [qeimat1], [qeimat2], [qeimat3], [qeimat4], [tozihat], [TourID]) VALUES (@HotelID, @emtiaz, @daraje, @qeimat1, @qeimat2, @qeimat3, @qeimat4, @tozihat, @TourID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT TourHotel.HotelKhademat,
	TourHotel.ID,
	(select COALESCE(CAST(CAST(((ROUND(AVG(CAST(Keifiat AS FLOAT)), 1) 
		+ ROUND(AVG(CAST(Tamizi AS FLOAT)), 1)+ROUND(AVG(CAST(Amalkard AS FLOAT)), 1)
		+ ROUND(AVG(CAST(Tafrihat AS FLOAT)), 1)+ROUND(AVG(CAST(Mantaqe AS FLOAT)), 1)
		+ ROUND(AVG(CAST(Arzesh AS FLOAT)), 1))/6) as numeric(36,2))AS nvarchar(30)),N'امتیازی ثبت نشده') from HotelComment where HotelComment.HotelID=TourHotel.HotelID) as Emt,
		COALESCE((select Setare from Hotel where Hotel.ID = TourHotel.HotelID),TourHotel.HotelStar) as Setare,
		TourHotel.qeimat1,
		TourHotel.qeimat2,
		TourHotel.qeimat3,
		TourHotel.qeimat4,
		TourHotel.tozihat,
		TourHotel.TourID,
		COALESCE((select HotelProfile from Hotel where Hotel.ID = TourHotel.HotelID),TourHotel.HotelName) as esm1,
		COALESCE((select HotelProfile from Hotel where Hotel.ID = TourHotel.HotelID2),TourHotel.HotelName2) as esm2,
		COALESCE((select HotelProfile from Hotel where Hotel.ID = TourHotel.HotelID3),TourHotel.HotelName3) as esm3,
		COALESCE((select HotelProfile from Hotel where Hotel.ID = TourHotel.HotelID4),TourHotel.HotelName4) as esm4,
		COALESCE((select HotelProfile from Hotel where Hotel.ID = TourHotel.HotelID5),TourHotel.HotelName5) as esm5
	FROM [TourHotel] WHERE ([TourID] = @TourID)" UpdateCommand="UPDATE [TourHotel] SET [HotelID] = @HotelID, [emtiaz] = @emtiaz, [daraje] = @daraje, [qeimat1] = @qeimat1, [qeimat2] = @qeimat2, [qeimat3] = @qeimat3, [qeimat4] = @qeimat4, [tozihat] = @tozihat, [TourID] = @TourID WHERE [ID] = @original_ID AND (([HotelID] = @original_HotelID) OR ([HotelID] IS NULL AND @original_HotelID IS NULL)) AND (([emtiaz] = @original_emtiaz) OR ([emtiaz] IS NULL AND @original_emtiaz IS NULL)) AND (([daraje] = @original_daraje) OR ([daraje] IS NULL AND @original_daraje IS NULL)) AND (([qeimat1] = @original_qeimat1) OR ([qeimat1] IS NULL AND @original_qeimat1 IS NULL)) AND (([qeimat2] = @original_qeimat2) OR ([qeimat2] IS NULL AND @original_qeimat2 IS NULL)) AND (([qeimat3] = @original_qeimat3) OR ([qeimat3] IS NULL AND @original_qeimat3 IS NULL)) AND (([qeimat4] = @original_qeimat4) OR ([qeimat4] IS NULL AND @original_qeimat4 IS NULL)) AND (([tozihat] = @original_tozihat) OR ([tozihat] IS NULL AND @original_tozihat IS NULL)) AND [TourID] = @original_TourID">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int64" />
                <asp:Parameter Name="original_HotelID" Type="Int64" />
                <asp:Parameter Name="original_emtiaz" Type="String" />
                <asp:Parameter Name="original_daraje" Type="String" />
                <asp:Parameter Name="original_qeimat1" Type="String" />
                <asp:Parameter Name="original_qeimat2" Type="String" />
                <asp:Parameter Name="original_qeimat3" Type="String" />
                <asp:Parameter Name="original_qeimat4" Type="String" />
                <asp:Parameter Name="original_tozihat" Type="String" />
                <asp:Parameter Name="original_TourID" Type="Int64" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="HotelID" Type="Int64" />
                <asp:Parameter Name="emtiaz" Type="String" />
                <asp:Parameter Name="daraje" Type="String" />
                <asp:Parameter Name="qeimat1" Type="String" />
                <asp:Parameter Name="qeimat2" Type="String" />
                <asp:Parameter Name="qeimat3" Type="String" />
                <asp:Parameter Name="qeimat4" Type="String" />
                <asp:Parameter Name="tozihat" Type="String" />
                <asp:Parameter Name="TourID" Type="Int64" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="TourID" SessionField="TourID" Type="Int64" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="HotelID" Type="Int64" />
                <asp:Parameter Name="emtiaz" Type="String" />
                <asp:Parameter Name="daraje" Type="String" />
                <asp:Parameter Name="qeimat1" Type="String" />
                <asp:Parameter Name="qeimat2" Type="String" />
                <asp:Parameter Name="qeimat3" Type="String" />
                <asp:Parameter Name="qeimat4" Type="String" />
                <asp:Parameter Name="tozihat" Type="String" />
                <asp:Parameter Name="TourID" Type="Int64" />
                <asp:Parameter Name="original_ID" Type="Int64" />
                <asp:Parameter Name="original_HotelID" Type="Int64" />
                <asp:Parameter Name="original_emtiaz" Type="String" />
                <asp:Parameter Name="original_daraje" Type="String" />
                <asp:Parameter Name="original_qeimat1" Type="String" />
                <asp:Parameter Name="original_qeimat2" Type="String" />
                <asp:Parameter Name="original_qeimat3" Type="String" />
                <asp:Parameter Name="original_qeimat4" Type="String" />
                <asp:Parameter Name="original_tozihat" Type="String" />
                <asp:Parameter Name="original_TourID" Type="Int64" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</asp:Content>


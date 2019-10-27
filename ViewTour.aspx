<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="ViewTour.aspx.cs" Inherits="ViewTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" lang="javascript">
        function SlideShowStart(timeinter) {
            $(document).ready(function () {
                $('.box_skitter_large').skitter({
                    theme: 'clean',
                    numbers_align: 'right',
                    dots: true,
                    interval: timeinter,
                    preview: true
                });
                setInterval(ChangeSlide , timeinter);
            });
        }
        function ChangeSlide() {
            $('#NextBTN').click();
        }
  </script>
    <link rel="stylesheet" href="/Files/Tour.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br />
    <div id="page11" runat="server" style=" border-bottom-right-radius:8px;border-bottom-left-radius:8px;border-top-right-radius:8px;border-top-left-radius:8px;"><!--/ used for SlideShow--> 
        <div id="content" runat ="server">

        </div>
    </div><!--/ End of SlideShow--> 
    
    <center>
        <table style="width:1180px">
            <tr>
                <td style="width:170px;vertical-align:top">
                    <table dir="rtl" style="width:100%;">
                        <tr>
                            <td class="TitleLeftBar">

                                 تبلیغات
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:center;padding-top:10px;">
                                <center>
                                    <asp:DataList ID="DataList2" runat="server">
                                        <ItemTemplate>
                                            <center>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("URL") %>' Target="_blank" >
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageADR") %>' AlternateText='<%# Eval("KeyW") %>'></asp:Image>
                                                </asp:HyperLink>
                                            </center>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </center>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:1000px;">
                    <table id="tblMaster" dir="ltr" style="width:1000px;border-collapse:collapse;">
                         <tr>
                             <td valign="top">
                                <table class="GrayTable" dir="rtl" style="margin-left:5px;">
                                    <tr>
                                        <td align="right" style="font-size:13px">
                                            <table style="width:100%;padding:10px">
                                                <tr>
                                                    <td class="TitleBar" runat="server" id="TitleTour">
                                    
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="BodyTour" runat="server">
                                                        <table style="width:100%;height:35px;border:0px solid #808080;padding:0px;">
                                                            <tr>
                                                                <td>
                                                                    <table style="width:100%">
                                                                        <tr>
                                                                            <td>

                                                                                        <table class="auto-style1" style="width:100%;text-align:center;border:1px solid #808080" >
                                                                                            <tr>
                                                                                                <td class="auto-style2 MainHeader" >
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td>

                                                                                                                <asp:Label ID="Label7" runat="server" CssClass="LabelHeader"></asp:Label>

                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>

                                                                                            </tr>
                                                                                            <tr >
                                                                                                <td class="auto-style3" >
                                                                                                    <table style="width:100%" >
                                                                                                        <tr >
                                                                                                            <td style="width:50%;height:50px;">
                                                                                                                <asp:Label ID="Label4" runat="server" CssClass="LabelValues" Text=''></asp:Label>
                                                                                                            </td>
                                                                                                            <td style="width:50%;height:50px;">
                                                                                                                <asp:Label ID="Label3" runat="server" Text='' CssClass="LabelValues"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width:50%;height:50px;">
                                                                                                                <asp:Label ID="Label6" runat="server" CssClass="LabelValues" Text=''></asp:Label>
                                                                                                            </td>
                                                                                                            <td style="width:50%;height:50px;" >
                                                                                                                <asp:Label ID="Label5" runat="server" CssClass="LabelValues" Text=''></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                            
                                                                                        </table>

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table style="width:100%">
                                                                        <tr>
                                                                            <td>

                                                                                <table style="width:100%">
                                                                        <tr>
                                                                            <td>

                                                                                <table class="auto-style1" style="width:100%;text-align:center;border:1px solid #808080">
                                                                                    <tr>
                                                                                        <td class="auto-style2  MainHeader">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label8" runat="server" CssClass="LabelHeader"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="auto-style3">
                                                                                            <table style="width:100%">
                                                                                                <tr>
                                                                                                    <td style="width:50%;height:50px;">
                                                                                                        <asp:Label ID="Label9" runat="server" CssClass="LabelValues" Text=""></asp:Label>
                                                                                                    </td>
                                                                                                    <td style="width:50%;height:50px;">
                                                                                                        <asp:Label ID="Label10" runat="server" CssClass="LabelValues" Text=""></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width:50%;height:50px;">
                                                                                                        <asp:Label ID="Label11" runat="server" CssClass="LabelValues" Text=""></asp:Label>
                                                                                                    </td>
                                                                                                    <td style="width:50%;height:50px;">
                                                                                                        <asp:Label ID="Label12" runat="server" CssClass="LabelValues" Text=""></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <table class="auto-style1" style="width:100%;text-align:center;border:1px solid #808080" >
                                                                                            <tr>
                                                                                                <td class="auto-style2 MainHeader" >
                                                                                                    <center>
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td>

                                                                                                                <asp:Label ID="Label13" runat="server" CssClass="LabelHeader">به مقصد </asp:Label>

                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                        </center>
                                                                                                </td>

                                                                                            </tr>
                                                                                            <tr >
                                                                                                <td class="auto-style3">
                                                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                                                                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="nam" HeaderText="نام" SortExpression="nam">
                                                                                                            <ControlStyle Width="50px" />
                                                                                                            <HeaderStyle CssClass="GridHeader" Height="30px" />
                                                                                                            <ItemStyle Width="15%" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="modat" HeaderText="مدت" SortExpression="modat" >
                                                                                                            <HeaderStyle CssClass="GridHeader" />
                                                                                                            <ItemStyle Width="15%" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="tozihat" HeaderText="توضیحات" SortExpression="tozihat" >
                                                                                                            <HeaderStyle CssClass="GridHeader" />
                                                                                                            <ItemStyle CssClass="LabelItems" Height="35px" />
                                                                                                            </asp:BoundField>
                                                                                                        </Columns>
                                                                                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                                                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                                                                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                                                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                                                                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                                                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                                                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                                                                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                                                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                                                                                    </asp:GridView>
                                                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" SelectCommand="SELECT [nam], [modat], [tozihat] FROM [beTB] WHERE ([TourID] = @TourID)">
                                                                                                    </asp:SqlDataSource>
                                                                                                </td>
                                                                                            </tr>
                                                                            
                                                                                        </table>
                                                                                        <br />
                                                                                        <table class="auto-style1" style="width:100%;text-align:center;border:1px solid #808080" >
                                                                                            <tr>
                                                                                                <td class="auto-style2  MainHeader" >
                                                                                                    <center>
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td>

                                                                                                                <asp:Label ID="Label1" runat="server" CssClass="LabelHeader">هتل ها </asp:Label>

                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                        </center>
                                                                                                </td>

                                                                                            </tr>
                                                                                            <tr >
                                                                                                <td class="auto-style3">
                                                                                                    <asp:GridView ID="GridView2" runat="server"  AllowSorting="false" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" GridLines="Vertical" Width="100%" OnRowDataBound="GridView2_RowDataBound" OnSorting="GridView2_Sorting">
                                                                                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="esm" HeaderText="نام هتل">
                                                                                                            <HeaderStyle Height="35px" CssClass="GridHeader" Font-Size="13.5px" Font-Bold="false"/>
                                                                                                                <ItemStyle CssClass="LabelItems" Height="35px" HorizontalAlign="Center" Width="150px" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="Emt" HeaderText="امتیاز هتل" >
                                                                                                            <HeaderStyle  Height="35px" CssClass="GridHeader" Font-Size="13.5px" Font-Bold="false"/>
                                                                                                                <ItemStyle CssClass="LabelItems" Height="35px" width="80px"/>
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="Setare" HeaderText="درجه هتل" >
                                                                                                                <HeaderStyle Height="35px" CssClass="GridHeader" HorizontalAlign="Center" Width="100px" Font-Size="13.5px" Font-Bold="false"/>
                                                                                                                <ItemStyle CssClass="stars" Height="35px" HorizontalAlign="Center" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="KHDM" HeaderText="خدمات" >
                                                                                                                <HeaderStyle Height="35px" CssClass="GridHeader" HorizontalAlign="Center" Font-Size="13.5px" Font-Bold="false"/>
                                                                                                                <ItemStyle CssClass="LabelItems" Height="35px" HorizontalAlign="Center" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="qeimat1" HeaderText="قیمت ۲ تخته (هر نفر)" >
                                                                                                            <HeaderStyle Height="35px" CssClass="GridHeader" Font-Size="13.5px" Font-Bold="false"/>
                                                                                                                <ItemStyle CssClass="LabelItems" Height="35px" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="qeimat2" HeaderText="قیمت ۱ تخته (هر نفر)" >
                                                                                                            <HeaderStyle Height="35px" CssClass="GridHeader" Font-Size="13.5px" Font-Bold="false"/>
                                                                                                                <ItemStyle CssClass="LabelItems" Height="35px" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="qeimat3" HeaderText="کودک با تخت ۶ تا ۱۲ سال" >
                                                                                                            <HeaderStyle Height="35px" CssClass="GridHeader" Font-Size="13.5px" Font-Bold="false"/>
                                                                                                                <ItemStyle CssClass="LabelItems" Height="35px" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="qeimat4" HeaderText="کودک بدون تخت ۲ تا ۶ سال" >
                                                                                                            <HeaderStyle Height="35px" CssClass="GridHeader" Font-Size="13.5px" Font-Bold="false"/>
                                                                                                                <ItemStyle CssClass="LabelItems" Height="35px" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="tozihat" HeaderText="توضيحات" >
                                                                                                            <HeaderStyle Height="35px" CssClass="GridHeader" Font-Size="13.5px" Font-Bold="false"/>
                                                                                                                <ItemStyle CssClass="LabelItems" Height="35px" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:TemplateField HeaderText="HotelID" Visible="False">
                                                                                                                <EditItemTemplate>
                                                                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("HotelID") %>'></asp:TextBox>
                                                                                                                </EditItemTemplate>
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="HotelName1" runat="server" Text='<%# Bind("HtlPrfl") %>'></asp:Label>
                                                                                                                    <asp:Label ID="HotelName2" runat="server" Text='<%# Bind("HtlPrfl2") %>'></asp:Label>
                                                                                                                    <asp:Label ID="HotelName3" runat="server" Text='<%# Bind("HtlPrfl3") %>'></asp:Label>
                                                                                                                    <asp:Label ID="HotelName4" runat="server" Text='<%# Bind("HtlPrfl4") %>'></asp:Label>
                                                                                                                    <asp:Label ID="HotelName5" runat="server" Text='<%# Bind("HtlPrfl5") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Esm2" runat="server" Text='<%# Bind("esm2") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Esm3" runat="server" Text='<%# Bind("esm3") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Esm4" runat="server" Text='<%# Bind("esm4") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Esm5" runat="server" Text='<%# Bind("esm5") %>'></asp:Label>
                                                                                                                    <asp:Label ID="KHDM2" runat="server" Text='<%# Bind("KHDM2") %>'></asp:Label>
                                                                                                                    <asp:Label ID="KHDM3" runat="server" Text='<%# Bind("KHDM3") %>'></asp:Label>
                                                                                                                    <asp:Label ID="KHDM4" runat="server" Text='<%# Bind("KHDM4") %>'></asp:Label>
                                                                                                                    <asp:Label ID="KHDM5" runat="server" Text='<%# Bind("KHDM5") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Emt2" runat="server" Text='<%# Bind("Emt2") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Emt3" runat="server" Text='<%# Bind("Emt3") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Emt4" runat="server" Text='<%# Bind("Emt4") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Emt5" runat="server" Text='<%# Bind("Emt5") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Setare2" runat="server" Text='<%# Bind("Setare2") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Setare3" runat="server" Text='<%# Bind("Setare3") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Setare4" runat="server" Text='<%# Bind("Setare4") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Setare5" runat="server" Text='<%# Bind("Setare5") %>'></asp:Label>
                                                                                                                    <asp:Label ID="q1" runat="server" Text='<%# Bind("Qeimat1P") %>'></asp:Label>
                                                                                                                    <asp:Label ID="q2" runat="server" Text='<%# Bind("Qeimat2P") %>'></asp:Label>
                                                                                                                    <asp:Label ID="q3" runat="server" Text='<%# Bind("Qeimat3P") %>'></asp:Label>
                                                                                                                    <asp:Label ID="q4" runat="server" Text='<%# Bind("Qeimat4P") %>'></asp:Label>
                                                                                                                    <asp:Label ID="q1p" runat="server" Text='<%# Bind("Qeimat1Pv") %>'></asp:Label>
                                                                                                                    <asp:Label ID="q2p" runat="server" Text='<%# Bind("Qeimat2Pv") %>'></asp:Label>
                                                                                                                    <asp:Label ID="q3p" runat="server" Text='<%# Bind("Qeimat3Pv") %>'></asp:Label>
                                                                                                                    <asp:Label ID="q4p" runat="server" Text='<%# Bind("Qeimat4Pv") %>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                                                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                                                                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                                                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                                                                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                                                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                                                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                                                                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                                                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                                                                                    </asp:GridView>
                                                                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" SelectCommand="SELECT (Select HotelProfile FROM Hotel WHERE ID = TourHotel.HotelID) as HtlPrfl,TourHotel.Qeimat1P,TourHotel.Qeimat2P,TourHotel.Qeimat3P,TourHotel.Qeimat4P,TourHotel.Qeimat1Pv,TourHotel.Qeimat2Pv,TourHotel.Qeimat3Pv,TourHotel.Qeimat4Pv,COALESCE(TourHotel.HotelKhademat,'درج نشده') as KHDM,TourHotel.HotelID, TourHotel.ID,(select COALESCE(CAST(CAST(((ROUND(AVG(CAST(Keifiat AS FLOAT)), 1) + ROUND(AVG(CAST(Tamizi AS FLOAT)), 1)+ROUND(AVG(CAST(Amalkard AS FLOAT)), 1)+ROUND(AVG(CAST(Tafrihat AS FLOAT)), 1)+ROUND(AVG(CAST(Mantaqe AS FLOAT)), 1)+ROUND(AVG(CAST(Arzesh AS FLOAT)), 1))/6) as numeric(36,2))AS nvarchar(30)),N'امتیازی ثبت نشده') from HotelComment where HotelComment.HotelID=TourHotel.HotelID) as Emt,COALESCE((select Setare from Hotel where Hotel.ID = TourHotel.HotelID),TourHotel.HotelStar) as Setare,TourHotel.qeimat1,TourHotel.qeimat2,TourHotel.qeimat3,TourHotel.qeimat4,TourHotel.tozihat,TourHotel.TourID,COALESCE((select Title from Hotel where Hotel.ID = TourHotel.HotelID),TourHotel.HotelName) as esm FROM [TourHotel] WHERE ([TourID] = @TourID) Order By Qeimat1 desc">
                                                                                                    </asp:SqlDataSource>
                                                                                                </td>
                                                                                            </tr>
                                                                            
                                                                                        </table>
                                                                                        <br />
                                                                                <table class="auto-style1" style="width:100%;text-align:center;border:1px solid #808080">
                                                                                    <tr>
                                                                                        <td class="auto-style2 MainHeader">
                                                                                            <center>
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td class="LabelHeader">
                                                                                                        اطلاعات تور
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                                </center>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="auto-style3">
                                                                                            <table style="width:100%;border-collapse: collapse;border:1px solid #C0C0C0" border="1">
                                                                                                <tr>
                                                                                                    <td class="RightInfoBox">
                                                                                                        از
                                                                                                        </td>
                                                                                                    <td class="LeftInfoBox">
                                                                                                        <asp:Label ID="lb1" runat="server" CssClass="LabelValues"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="RightInfoBox">
                                                                                                        نوع سفر</td>
                                                                                                    <td class="LeftInfoBox">
                                                                                                        <asp:Label ID="lb2" runat="server" CssClass="LabelValues"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="RightInfoBox">
                                                                                                        تاریخ</td>
                                                                                                    <td class="LeftInfoBox">
                                                                                                        <asp:Label ID="lb3" runat="server" CssClass="LabelValues"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="RightInfoBox">
                                                                                                        مدارک لازم</td>
                                                                                                    <td class="LeftInfoBox">
                                                                                                        <asp:Label ID="lb4" runat="server" CssClass="LabelValues"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="RightInfoBox">
                                                                                                        خدمات آژانس</td>
                                                                                                    <td class="LeftInfoBox">
                                                                                                        <asp:Label ID="lb5" runat="server" CssClass="LabelValues"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="RightInfoBox">
                                                                                                        توضیحات</td>
                                                                                                    <td class="LeftInfoBox">
                                                                                                        <asp:Label ID="lb6" runat="server" CssClass="LabelValues"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>

                                                                        

                                                    </td>
                                                </tr>
                                            </table>
                            
                                        </td>
                                    </tr>
                                </table>
                             </td>
                         </tr>
                         </table>
                    <center>
                        <br /><br />
    <div id ="HorSlide" runat="server">
        <div id="w" runat="server">
    
        </div><!-- @end #w -->
    
        <nav class="slidernav divNav">
            <div id="navbtns" class="clearfix divNav">
                <a href="#" id="NextBTN" class="previous divNav"></a>
            </div>
        </nav>
        <script type="text/javascript">
            $(function () {
                $('.crsl-items').carousel({
                    visible: 4,
                    itemMinWidth: 180,
                    itemEqualHeight: 370,
                    itemMargin: 9,
                });

                $("a[href=#]").on('click', function (e) {
                    e.preventDefault();
                });
            });
        </script>
    </div>
    <br />
        <div class="CommentDiv" id="CommentSection" runat="server">
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <div class="UserComment" style="direction:rtl">
		                <table style="width:100%">
			                <tr style="font-family:'Tahoma';font-size:11.5px;">
				                <td class="UserSender">
					                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Nam") %>'></asp:Label>
				                </td>
				                <td style="width:50%;padding:5px;text-align:left">
					                 <asp:Label ID="Label14" runat="server" Text='<%# Eval("Vaqt") %>'></asp:Label>
				                </td>
			                </tr>
		                </table>	
		                <div class="UserText">
                            <asp:Label ID="Label15" runat="server" Text='<%# Eval("MSG") %>'></asp:Label>
		                </div>
	                </div>
                </ItemTemplate>
            </asp:ListView>
            <br />
	        <div style="font-size:14.5px;margin-bottom:10px;font-family:'BYekan'">ارسال نظر</div>
	        <div style="font-family:'Tahoma';font-size:11.5px">نام شما</div>
	        <asp:TextBox ID="TextBox2" runat="server" CssClass="myInput"></asp:TextBox>
            <br />
	        <div style="font-family:'Tahoma';font-size:11.5px">ایمیل</div>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="myInput" placeholder="youremail@example.com" ></asp:TextBox>
	        <br />
	        <div style="font-family:'Tahoma';font-size:11.5px">وب سایت</div>
	        <asp:TextBox ID="TextBox4" runat="server" CssClass="myInput"></asp:TextBox>
            <br />
	        <div style="font-family:'Tahoma';font-size:11.5px">نظر شما</div>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="myInput" TextMode="MultiLine" Width="500px" Height="200px" style="text-align:right" ></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="ثبت نظر" CssClass="CommentBTN" OnClick="Button1_Click"></asp:Button>
        </div>
                    </center>
                </td>
                
            </tr>
        </table>
         
     </center>
    
</asp:Content>


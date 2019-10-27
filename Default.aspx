<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="test" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Js/fm.scrollator.jquery.js" type="text/javascript"></script>
    <link rel="stylesheet" href="Files/fm.scrollator.jquery.css" />
    <style type="text/css">
        .LabelHeader
        {
            font-family:"BYekan";
            height:40px;
            background-color:#65b7f3;
            color:white;
            text-align:center;
        }
        .ItemList
        {
            cursor:pointer !important;
            -moz-transition:all 500ms linear 0s;
			-webkit-transition:all 500ms linear 0s;
			-o-transition:all 500ms linear 0s;
			-ms-transition:all 500ms linear 0s;
            font-family:"BYekan";
            height:40px;
            text-align:center;
        }
        .ScrollBox
        {
            height: 650px;
            display:inline-block;
            overflow-y:scroll;
            width:100%;
            direction:ltr;
        }
        .MMM
        {
            display:none;
        }
    </style>
    <script>
        $(function () {
            var $scrollable_div1 = $('#Sc1');
            $scrollable_div1.scrollator();
            var $scrollable_div2 = $('#Sc2');
            $scrollable_div2.scrollator();
        });
	</script>
    <script type="text/javascript">
        
    </script>
    <script type="text/javascript">
        function ClickTour() {
            if (!$("#ContentPlaceHolder1_tb1").hasClass('MMM')) {
                changeID('tab1');
                return;
            }
            if (!$("#ContentPlaceHolder1_tb2").hasClass('MMM')) {
                changeID('tab2');
                return;
            }
            if (!$("#ContentPlaceHolder1_tb3").hasClass('MMM')) {
                changeID('tab3');
                return;
            }
            if (!$("#ContentPlaceHolder1_tb4").hasClass('MMM')) {
                changeID('tab4');
                return;
            }
            if (!$("#ContentPlaceHolder1_tb5").hasClass('MMM')) {
                changeID('tab5');
                return;
            }
        }
        function changeID(n) {
            document.getElementById("tab1").className = "";
            document.getElementById("tab2").className = "";
            document.getElementById("tab3").className = "";
            document.getElementById("tab4").className = "";
            document.getElementById("tab5").className = "";
            document.getElementById(n).className = "current";
            $("#ContentPlaceHolder1_Norooz").stop();
            $("#ContentPlaceHolder1_Dakheli").stop();
            $("#ContentPlaceHolder1_Khareji").stop();
            $("#ContentPlaceHolder1_Lahzei").stop();
            $("#ContentPlaceHolder1_OfferDar").stop();
            $("#ContentPlaceHolder1_Norooz").slideUp(500);
            $("#ContentPlaceHolder1_Dakheli").slideUp(500);
            $("#ContentPlaceHolder1_Khareji").slideUp(500);
            $("#ContentPlaceHolder1_Lahzei").slideUp(500);
            $("#ContentPlaceHolder1_OfferDar").slideUp(500);
            if (n == "tab1") $("#ContentPlaceHolder1_Norooz").slideDown(500);
            else if (n == "tab2") $("#ContentPlaceHolder1_Dakheli").slideDown(500);
            else if (n == "tab3") $("#ContentPlaceHolder1_Khareji").slideDown(500);
            else if (n == "tab4") $("#ContentPlaceHolder1_Lahzei").slideDown(500);
            else if (n == "tab5") $("#ContentPlaceHolder1_OfferDar").slideDown(500);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%" class="GrayTable">
	<tr>
		<td>
	        <div id="example-two">
    		<ul class="nav">
                <li id="tb1" runat="server" ><a href="#" id="tab1" onclick="changeID(this.id)" class="current" style="background-color:#42c641">تور نوروزی</a></li>
                <li id="tb2" runat="server" ><a href="#" id="tab2" onclick="changeID(this.id)" >تور داخلی</a></li>
                <li id="tb3" runat="server" ><a href="#" id="tab3" onclick="changeID(this.id)" >تور خارجی</a></li>
                <li id="tb4" runat="server" ><a href="#" id="tab4" onclick="changeID(this.id)" style="background-color:#ffa709">تور لوکس</a></li>
                <li id="tb5" runat="server" ><a href="#" id="tab5" onclick="changeID(this.id)" style="background-color:#ff6464">تور آفر دار</a></li>
            </ul>
                <p style="width:100%">
                <div id="Norooz" runat="server">
                    <asp:GridView ID="GridView5" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="GridView5_RowDataBound" Width="100%" OnSelectedIndexChanged="GridView5_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:HyperLink runat="server" ID="HyperLink1"
                                    NavigateUrl='<%# Eval("TourProfile","/Tours/{0}") %>'>
                                    
                                </asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <script>
                        $('#ContentPlaceHolder1_GridView5 tr').click(function () {
                            window.location = $(this).find('a').attr('href');
                        }).hover(function () {
                            $(this).toggleClass('hover');
                        });
                    </script>
                </div>
                <div id="Dakheli" style="display:none;" runat="server">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound1" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:HyperLink runat="server" ID="HyperLink1"
                                    NavigateUrl='<%# Eval("TourProfile","/Tours/{0}") %>'>
                                    
                                </asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <script>
                        $('#ContentPlaceHolder1_GridView1 tr').click(function () {
                            window.location = $(this).find('a').attr('href');
                        }).hover(function () {
                            $(this).toggleClass('hover');
                        });
                    </script>
                </div>
                <div id="Khareji" style="display:none;" runat="server">
                    <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="GridView2_RowDataBound" Width="100%" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:HyperLink runat="server" ID="HyperLink1"
                                    NavigateUrl='<%# Eval("TourProfile","/Tours/{0}") %>'>
                                    
                                </asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <script>
                        $('#ContentPlaceHolder1_GridView2 tr').click(function () {
                            window.location = $(this).find('a').attr('href');
                        }).hover(function () {
                            $(this).toggleClass('hover');
                        });
                    </script>
                </div>
                <div id="Lahzei" style="display:none;" runat="server">
                    <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="GridView3_RowDataBound" Width="100%" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:HyperLink runat="server" ID="HyperLink1"
                                    NavigateUrl='<%# Eval("TourProfile","/Tours/{0}") %>'>
                                    
                                </asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns><FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <script>
                        $('#ContentPlaceHolder1_GridView3 tr').click(function () {
                            window.location = $(this).find('a').attr('href');
                        }).hover(function () {
                            $(this).toggleClass('hover');
                        });
                    </script>    
                </div>
                <div id="OfferDar" style="display:none;" runat="server">
                    <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="GridView4_RowDataBound" Width="100%" OnSelectedIndexChanged="GridView4_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:HyperLink runat="server" ID="HyperLink1"
                                    NavigateUrl='<%# Eval("TourProfile","/Tours/{0}") %>'>
                                    
                                </asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <script>
                        $('#ContentPlaceHolder1_GridView4 tr').click(function () {
                            window.location = $(this).find('a').attr('href');
                        }).hover(function () {
                            $(this).toggleClass('hover');
                        });
                    </script> 
                </div>
                </p>
		    </div> <!-- END Organic Tabs (Example One) -->
		</td>
	</tr>
</table>
<br />

<table>
    <tr>
        <td style="vertical-align:top">
            <table style="width:450px" class="GrayTable">
                <tr>
                    <td class="TitleLeftBar" runat="server" id="TitleTour">
                                اخبار                   
                    </td>
                </tr>
                <tr>
                    <td id="BodyTour" runat="server">
                        <div class="ScrollBox" id="Sc1">
                        <asp:ListView ID="ListView1" runat="server">
                            <ItemTemplate>
                                <table class="NewsBox">
                                    <tr>
                                        <td>
                                            <div style="width:100px;text-align:center;">
                                                <asp:Image ID="Image1" runat="server"  ImageUrl='<%# Eval("PicA") %>' style="max-height:100px;max-width:100px;" CssClass="ImgL"/>
                                            </div>
                                        </td>
                                        <td style="height: 94px;width:100%;padding-right:10px">
                                            <table style="height: 94px;width: 100%;">
                                                <tr >
                                                    <td style="height: 31px;">
                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("NewsProfile","~/News/{0}") %>' Text='<%# Eval("Title") %>' class="NewsLinks"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" style="width:100%">
                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("TinyMatn","{0} ... ") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:ListView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:center">
                            <a href="/خبرها" style="font-family:'BYekan';text-decoration:none;color:blue" >آرشیو...</a>
                        </td>
                    </tr>
                
            </table>
        </td>
        <td style="vertical-align:top">
            <table style="width:450px" class="GrayTable">
                <tr>
                    <td class="TitleLeftBar" runat="server" id="Td1" >
                             جاذبه های گردشگری                   
                    </td>
                </tr>
                <tr>
                    <td id="Td2" runat="server" >
                        <div class="ScrollBox" id="Sc2">
                        <asp:ListView ID="ListView2" runat="server">
                            <ItemTemplate>
                                <table class="NewsBox">
                                    <tr>
                                        <td>
                                            <div style="width:100px;text-align:center;">
                                                <asp:Image ID="Image1" runat="server"  ImageUrl='<%# Eval("PicA") %>' style="max-height:100px;max-width:100px;" CssClass="ImgL"/>
                                            </div>
                                        </td>
                                        <td style="height: 94px;width:100%;padding-right:10px">
                                            <table style="height: 94px;width: 100%;">
                                                <tr >
                                                    <td style="height: 31px;">
                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("JazebeProfile","~/Jazebe/{0}") %>' Text='<%# Eval("Title") %>'  class="NewsLinks"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" style="width:100%">
                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("TinyMatn","{0} ... ") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:ListView>
                        </div>
                    </td>
                    
                    
                </tr>
                <tr>
                    <td style="text-align:center">
                        <a href="/جاذبه-ها" style="font-family:'BYekan';text-decoration:none;color:blue;" >آرشیو...</a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
    <div id="HorSlide2" runat="server">
    <center>
        <div id="w2" runat="server" style="direction:ltr">
    
        </div><!-- @end #w -->
    </center>
        <nav class="slidernav divNav" style="direction:ltr">
            <div id="navbtns" class="clearfix divNav">
            <a href="#" id="NextBTN2" class="previous divNav"></a>
                                        
            </div>
        </nav>
</div>
    <h1 style="visibility:hidden">تور نوروز</h1>
</asp:Content>


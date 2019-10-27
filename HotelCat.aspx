<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HotelCat.aspx.cs" Inherits="HotelCat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Files/HotelCat.css" type="text/css" media="all" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%" class="GrayTable">
        <tr>
            <td class="TitleLeftBar" runat="server" id="TitleTour">
                هتل ها
            </td>
        </tr>
        <tr>
            <td id="BodyTour" runat="server">
               <table class="TableStyle">
                    <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
        <ItemTemplate>
                            <tr>
                                <td class="MainTd">
			                    <table style="width:100%">
				                    <tr>
					                    <td class="TableImage" style="width:150px;">
                                            <asp:HyperLink ID="HyperLink2" style="text-decoration:none" NavigateUrl='<%# Eval("HotelProfile","~/Hotels/{0}") %>' runat="server"><asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("IconImage") %>'/></asp:HyperLink>
                                            
                                            
					                    </td>
					                    <td class="TableCells">
						                    <p class="HotelName">
                                                <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Title") %>' CssClass="HotelLink" NavigateUrl='<%# Eval("HotelProfile","~/Hotels/{0}") %>' runat="server"></asp:HyperLink></p>
						                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Setare") %>'></asp:Label>
						                    <br>
						                    <div class="Taed"><asp:Label ID="Label3" runat="server" Text='<%# Eval("Taeedi") %>'></asp:Label>
                                            </div>
					                    </td>
					                    
                                        <td class="TableCells" style="width:150px;">
						                    
					                    </td>
				                    </tr>
			                    </table>
			                    <p class="AboutHotel">  
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Tozihat") %>'></asp:Label>
                                </p>
		                    </td>
	                    </tr>
                        </ItemTemplate>
    </asp:ListView>
    
	           </table><span style="font-family:'BYekan'">صفحه </span>
                <asp:DataPager ID="DataPager1" PagedControlID="ListView1" runat="server" QueryStringField="pg"  OnPreRender="DataPager1_PreRender" PageSize="10" />
            </td>
        </tr>
    </table>
   
</asp:Content>


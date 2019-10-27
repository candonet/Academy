<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AgencyCat.aspx.cs" Inherits="AgencyCat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>لیست آژانس ها</title>
    <link href="Files/HotelCat.css" type="text/css" media="all" rel="stylesheet" />
    <style>
        .innnerTB
        {
            border-collapse: collapse;
            width: 100%;
            font-size: 13.5px;
        }
        .innnerTB tr td
        {
            padding: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%" class="GrayTable">
        <tr>
            <td class="TitleLeftBar" runat="server" id="TitleTour">
                آژانس ها
            </td>
        </tr>
        <tr>
            <td id="BodyTour" runat="server">
                <div style="font-family:'BYekan'">
                <asp:ListView ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound1">
                    <ItemTemplate>
                        <table width=700px style="border-collapse: collapse;border-bottom:solid 1px #bbb">
	                        <tr>
		                        <td style="width:200px;text-align:center;vertical-align:central;padding-top:20px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("namEng","~/Agency/logo/{0}.jpg") %>' style="max-height:120px;max-width:120px"/>
		                        </td>
		                        <td>
			                        <br/>
			                        <p class="HotelName">
                                        <asp:HyperLink ID="HyperLink1" Text='<%# Eval("nam") %>' CssClass="HotelLink" NavigateUrl='<%# Eval("namEng","~/Agency/{0}") %>' runat="server"></asp:HyperLink>
			                        </p>
			                        <br/>
			                        <table  class="innnerTB">
				                        <tr>
					                        <td style="width:110px">
						                        تعداد تور : 
					                        </td>
					                        <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Tedad") %>'></asp:Label>
					                        </td>
				                        </tr>
				                        <tr>
					                        <td>
						                        تاریخ عضویت : 
					                        </td>
					                        <td>
						                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("JoinDate") %>'></asp:Label>
					                        </td>
				                        </tr>
				                        <tr>
					                        <td>
						                        شهر:
					                        </td>
					                        <td>
						                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("shahr") %>'></asp:Label>
					                        </td>
				                        </tr>
				                        <tr>
					                        <td>
						                        آدرس محل کار :
					                        </td>
					                        <td>
						                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("adresMahal") %>'></asp:Label>
					                        </td>
				                        </tr>
				                        <tr>
					                        <td>
						                        تلفن : 
					                        </td>
					                        <td>
						                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("tel") %>'></asp:Label>
					                        </td>
				                        </tr>
			                        </table>
		                        </td>
	                        </tr>
                        </table>
                    </ItemTemplate>
                </asp:ListView>
                    <span style="font-family:'BYekan'">صفحه </span>
                <asp:DataPager ID="DataPager1" PagedControlID="DataList1" runat="server" QueryStringField="pg"  OnPreRender="DataPager1_PreRender" PageSize="10" />
                    </div>
            </td>
        </tr>
    </table>
</asp:Content>


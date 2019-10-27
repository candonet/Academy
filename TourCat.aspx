<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="TourCat.aspx.cs" Inherits="test"  enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%" class="GrayTable">
    <tr>
        <td class="TitleLeftBar" runat="server" id="TitleTour">
                                        
            &nbsp;</td>
    </tr>
    <tr>
        <td id="BodyTour" runat="server">
            <table style="font-family:'BYekan';font-size:14.5px;width:100%">
                <tr>
                    <td>
                        از<br />
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" Font-Names="BYekan" Font-Size="Small" Width="200px" Height="30px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        آژانس<br />
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" Font-Names="BYekan" Font-Size="Small" Width="200px" Height="30px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        مدت اقامت<br />
                        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" Font-Names="BYekan" Font-Size="Small" Width="200px" Height="30px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound1" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
 
        </td>
    </tr>
    </table>
</asp:Content>


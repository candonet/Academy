<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewNews.aspx.cs" Inherits="ViewNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .DSource
        {
            padding:5px;
		    padding-right:40px;
		    background-image:url('../images/Dsource.png');
		    background-repeat:no-repeat;
            background-size:32px 32px;
		    background-position:right;
		    display:inline-block;
		    height:32px;
            margin:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%" class="GrayTable">
        <tr>
            <td class="TitleLeftBar" runat="server" id="TitleTour">
            </td>
        </tr>
        <tr>
            <td id="BodyTour" runat="server" style="padding:15px">
                <div style="text-align:center">
                    <asp:Label ID="SubT" runat="server" style="font-family:'BYekan';" Font-Bold="false" Font-Size="Medium"></asp:Label>
                    <asp:Image ID="Image1" runat="server" style="max-width:512px;max-height:384px" /><br /><br />
                </div>
                <asp:Label ID="Label1" runat="server" style="font-family:'BYekan';" Font-Bold="false" Font-Size="Medium"></asp:Label><br />
                <span class="DSource">
                    <span style="top:10px;position:relative">
                        <asp:Label ID="DSource" runat="server" style="font-family:'BYekan';" Font-Bold="false" Font-Size="Medium"></asp:Label>
                    </span>
                </span>
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPage.aspx.cs" Inherits="ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%" class="GrayTable">
        <tr>
            <td class="TitleLeftBar" runat="server" id="TitleTour">
                                    
            </td>
        </tr>
        <tr>
            <td id="BodyTour" runat="server" style="padding:15px;">
                <asp:Label ID="Label1" runat="server" Text="متاسفانه صفحه مورد نظر یافت نشد" style="font-family:'BYekan';font-size:13.5px"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewJazebe.aspx.cs" Inherits="ViewJazebe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            height: 33px;
            padding:15px;
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
            <td id="BodyTour" runat="server" class="auto-style1">
                <div style="text-align:center">
                    <asp:Image ID="Image1" runat="server"  style="max-width:512px;max-height:384px" /><br /><br />
                </div>
                <asp:Label ID="Label1" runat="server" Text="" style="font-family:'BYekan';" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.master" AutoEventWireup="true" CodeFile="Submitticket.aspx.cs" Inherits="Member_Submitticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>ارسال تیکت</title>
    <style>
        .auto-style1
        {
            width: 49px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>ارسال تیکت به پشتیبانی</h2>
        <table style="width: 600px;">
            <tr>
                <td style="text-align: left;" class="auto-style1"></td>
                <td class="auto-style10">
                    <div class="ERRORmsg" runat="server" id="ErrorMSG" visible="false"></div>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style1">موضوع :</td>
                <td class="auto-style10">
                    <asp:TextBox ID="ticketsubject" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;vertical-align:top" class="auto-style1">پیام :</td>
                <td class="auto-style10">
                    <asp:TextBox ID="ticketmsg" runat="server" Width="100%" Height="252px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="auto-style1"></td>
                <td style="text-align:center">
                    <asp:Button ID="Button1" runat="server" Text="ارسال" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>


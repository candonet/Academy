<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Files/HotelView.css" type="text/css" media="all" rel="stylesheet" />
    <style>
        .MyLinks
        {
            font-family:'BYekan';
            font-size:12.5px;
        }
    </style>
    <title>نتایج جستجو</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="h2Tag">جستجو</h2>
    <div style="padding:10px" id="BodyTXT" runat="server">
        <asp:Label ID="Label1" runat="server" Text="" style="font-family:'BYekan';font-size:14.5px;"></asp:Label>
        <span style="font-family:'BYekan';font-size:14.5px;" id="Head1" runat="server">لیست هتل های مرتبط :</span>
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <div style="padding-right:10px">
                    <asp:HyperLink CssClass="MyLinks" ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("HotelProfile","~/Hotels/{0}") %>' Text='<%# Eval("Title") %>' style="text-decoration:none;color:#5e88fc;font-size:14px"></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <span style="font-family:'BYekan';font-size:14.5px;" id="Head2" runat="server">لیست تور های مرتبط :</span>
        <asp:ListView ID="ListView2" runat="server">
            <ItemTemplate>
                <div style="padding-right:10px">
                    <asp:HyperLink CssClass="MyLinks" ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("TourProfile","~/Tours/{0}") %>' Text='<%# Eval("Nam") %>' style="text-decoration:none;color:#5e88fc;font-size:14px"></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <span style="font-family:'BYekan';font-size:14.5px;" id="Head3" runat="server">لیست اخبار مرتبط :</span>
        <asp:ListView ID="ListView3" runat="server">
            <ItemTemplate>
                <div style="padding-right:10px">
                    <asp:HyperLink CssClass="MyLinks" ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("NewsProfile","~/News/{0}") %>' Text='<%# Eval("Title") %>' style="text-decoration:none;color:#5e88fc;font-size:14px"></asp:HyperLink>
                </div>
            </ItemTemplate>           
        </asp:ListView>
        <br />
        <span style="font-family:'BYekan';font-size:14.5px;" id="Head4" runat="server">لیست جاذبه های مرتبط :</span>
        <asp:ListView ID="ListView4" runat="server">
            <ItemTemplate>
                <div style="padding-right:10px">
                    <asp:HyperLink CssClass="MyLinks" ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("JazebeProfile","~/Jazebe/{0}") %>' Text='<%# Eval("Title") %>' style="text-decoration:none;color:#5e88fc;font-size:14px"></asp:HyperLink>
                </div>
            </ItemTemplate>           
        </asp:ListView>
    </div>
    
</asp:Content>


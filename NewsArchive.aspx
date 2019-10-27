<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewsArchive.aspx.cs" Inherits="NewsArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%" class="GrayTable">
        <tr>
            <td class="TitleLeftBar" runat="server" id="TitleTour">
                     آرشیو اخبار                   
            </td>
        </tr>
        <tr>
            <td id="BodyTour" runat="server">
                <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
            <table class="NewsBox2">
                <tr>
                    <td style="height: 50px;">
                        <asp:Image ID="Image1" runat="server"  ImageUrl='<%# Eval("PicA") %>' style="max-height:100px;max-width:100px;" CssClass="ImgL"/>
                    </td>
                    <td style="height: 94px;width:100%;padding-right:10px;">
                        <table style="height: 94px;width: 100%;">
                            <tr >
                                <td style="height: 31px;">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("NewsProfile","~/News/{0}") %>' Text='<%# Eval("Title") %>' style="text-decoration:none;color:#5e88fc;font-size:14px"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="width:100%">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("TinyMatn") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                                
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView><span style="font-family:'BYekan';">صفحه </span>
                
    <asp:DataPager ID="DataPager1" PagedControlID="ListView1" runat="server" QueryStringField="pg"  OnPreRender="DataPager1_PreRender" PageSize="10" />
                
            </td>
            
        </tr>
    </table>
   
    
</asp:Content>


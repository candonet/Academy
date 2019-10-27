<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageImages.aspx.cs" Inherits="Admin_ManageImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت تصاویر</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>آپلود فایل و عکس</h2>

        <table style="width: 400px;">
            <tr>
                <td style="width: 99px;text-align: left;">انتخاب فایل :</td>
                <td style="text-align: center">
                    <asp:FileUpload ID="FileUpload1" runat="server" style="margin-right: 0px" />
                </td>
            </tr>
            
            <tr>
                <td style="width: 99px;text-align: left;height: 30px;"></td>
                <td style="text-align: center;height: 30px;">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="آپلود" />
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 99px;text-align: left;">&nbsp;</td>
                <td style="text-align: center">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <h2>لیست تمام فایل ها</h2>
    <div style="text-align:right">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" OnDeleteCommand="DataList1_DeleteCommand">
            <ItemTemplate>
                <table style="height:100px;width:100px" >
                    <tr>
                        <td align="center" valign="top">
                        
                            <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" style="width:100px;height:100px" NavigateUrl='<%# Eval("AksA","~/IMG/{0}") %>'  >
                                <asp:Image ID="Image1" runat="server" style="width:100px;height:100px" ImageUrl='<%# Eval("AksA","~/IMG/th/{0}") %>'/>
                            </asp:HyperLink>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("AksA") %>' Visible="false"></asp:Label>
                            <asp:Button ID="DeleteBTN" runat="server" Text="حذف عکس" CommandName="delete"  OnClientClick="return confirm('آیا شما مطمئن به حذف هستید؟'); "/>
                        </td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
        </asp:DataList>

            <h2> صفحه : 
                <asp:DataList ID="DataList2" runat="server" RepeatColumns="20" OnSelectedIndexChanged="DataList2_SelectedIndexChanged" OnDeleteCommand="DataList2_DeleteCommand">
                    <ItemTemplate>
                    
                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("PageNumb") %>' CommandName="delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:DataList>
                </h2>
<br />
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    </div>
    </form>
</asp:Content>


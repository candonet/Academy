<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="AddPage.aspx.cs" Inherits="Admin_AddPage" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت صفحه</title>
    
    <script type="text/javascript" src="Files/ckeditor.js"></script>
	<script src="Files/sample.js"></script>
	<link rel="stylesheet" href="Files/samples.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server" id="Form1" >
    <h2>مدیریت صفحات</h2>
        <p>موضوع صفحه :  
            <asp:TextBox ID="SubJ" runat="server" Width="259px"></asp:TextBox>
        </p>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:TextBox ID="editor" runat="server" TextMode="MultiLine"></asp:TextBox>

                </td>
            </tr>
        </table>
        <p>کلمات کلیدی :  
            <asp:TextBox ID="Keyword" runat="server" Width="259px"></asp:TextBox>
        </p>
        <p> 
            <asp:Button ID="Button1" runat="server" Text="ثبت اطلاعات" OnClick="Button1_Click" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <script>
            initSample();
        </script>
    </form>
</asp:Content>


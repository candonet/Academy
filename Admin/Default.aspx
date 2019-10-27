<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>پنل مدیریت</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>پنل مدیریت</h2>
        <p>با سلام 
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ></asp:Label>
            </p>
	    <p> به پنل مدیریت خوش آمدید</p>
	    <p>لطفا گزینه مورد نظر را از قسمت راست یا چپ انتخاب کنید</p>
    </form>
</asp:Content>


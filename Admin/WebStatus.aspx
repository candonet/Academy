<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="WebStatus.aspx.cs" Inherits="WebStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>وضعیت سایت</title>
    <script class="include" type="text/javascript" src="image/jquery.min.js"></script>
	<script class="include" type="text/javascript" src="image/d3.min.js"></script>
	<script class="include" type="text/javascript" src="image/d3pie.min.js"></script>
    <script class="include" type="text/javascript" src="image/myCodes.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <h2>وضعیت حافظه</h2>
        <div id="pie"></div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</asp:Content>


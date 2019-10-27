<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AddJazebe.aspx.cs" Inherits="Admin_AddJazebe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت جاذبه</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="image/chosen.jquery.js"></script>
    <link rel="stylesheet" href="image/bootstrap-chosen.css" />
    <script>
        $(function () {
            $('#ContentPlaceHolder1_DropDownList1').chosen();
            $('#ContentPlaceHolder1_DropDownList2').chosen();
            $('#ContentPlaceHolder1_DropDownList3').chosen();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <br />
        <table style="width: 700px;">
            <tr>
                <td>
                    <p>موضوع  :  
                        <asp:TextBox ID="SubJ" runat="server" Width="485px"></asp:TextBox>
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width:570px">
                        <tr>
                            <td>
                                 کشور <asp:DropDownList ID="DropDownList1" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>
                               شهر <asp:DropDownList ID="DropDownList2" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>
                                ناحیه <asp:DropDownList ID="DropDownList3" runat="server" Width="150px" AutoPostBack="True"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="230px" TextMode="MultiLine" Width="555px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    آدرس عکس :
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
        </table>
        <p>کلمات کلیدی :  
            <asp:TextBox ID="Keyword" runat="server" Width="259px"></asp:TextBox>
        </p>
        <p> 
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ثبت اطلاعات" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        </form>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="AddNews.aspx.cs" Inherits="Admin_AddNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت اخبار</title>
    <script type="text/javascript">
        $(document).ready(function () { $("#input").cleditor(); });
        function ShowText(n) {
            document.getElementById('input').innerHTML = n;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
    <h2>مدیریت صفحات</h2>
        <p>موضوع خبر :  
            <asp:TextBox ID="SubJ" runat="server" Width="485px"></asp:TextBox>
        </p>
        <p> تیتر خبر :  
            <asp:TextBox ID="Sub2" runat="server" Width="485px"></asp:TextBox>
        </p>
        <p>دسته بندی :
            <asp:DropDownList ID="DropDownList1" runat="server" Width="210px">
            </asp:DropDownList>
        </p>
        <table style="width: 700px;">
            <tr>
                <td>

                    <asp:TextBox ID="TextBox1" runat="server" Height="230px" TextMode="MultiLine" Width="555px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                    آدرس عکس :
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="$('#ContentPlaceHolder1_TextBox2').val('/IMG/' + this.value);" />

                </td>

            </tr>
        </table>
        <p>کلمات کلیدی :  
            <asp:TextBox ID="Keyword" runat="server" Width="259px"></asp:TextBox>
        </p>
        <p>منبع خبر :  
            <asp:TextBox ID="DSource" runat="server" Width="259px"></asp:TextBox>
        </p>
        <p>وضعیت نمایش :&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" Width="104px">
                <asp:ListItem>نمایش</asp:ListItem>
                <asp:ListItem>عدم نمایش</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p> 
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ثبت اطلاعات" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        </form>
</asp:Content>


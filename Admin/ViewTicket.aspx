<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ViewTicket.aspx.cs" Inherits="Admin_ViewTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>نمایش تیکت</title>
    <style>
        .ttt
        {

            color:#bfd9f8
        }
        .CommentHeader
        {
            font-size: 12.5px;
        }
        .Memb
        {
            background-color: #ededed;
            padding: 10px;
        }
        .Staff
        {
            background-color: #abf8b5;
            padding: 10px;
        }
    </style>
    <script type="text/javascript">
        var n = 0;
        function changeID() {
            if (n == 0) {
                $("#ItemPlus").html('-');
                $("#HideComment").stop();
                $("#HideComment").slideUp(500);
                $("#HideComment").slideDown(500);
                n = 1;
            }
            else {
                $("#ItemPlus").html('+');
                $("#HideComment").stop();
                $("#HideComment").slideDown(500);
                $("#HideComment").slideUp(500);
                n = 0;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <form id="Form1" runat="server">
    <h2>مشاهده تیکت <asp:Label ID="Label1" runat="server" Text="#" Font-Names="Tahoma"></asp:Label><br /> <asp:Button ID="Button2" runat="server" Text="بستن تیکت" OnClick="Button2_Click" OnClientClick="return confirm('آیا شما مطمئن به بستن این تیکت هستید؟');" /></h2>
    <div id="ErrorMSG" runat="server" class="ERRORmsg" visible="false">

    </div>
    <div style="font-family:'BYekan'" id="MainReport" runat="server">
        <table width="600px" style="border-collapse: collapse;border-radius:5px;"  >
		<tr>
			<td style="background-color:#bfd9f8;border-radius:5px;">
				<table style="border-collapse: collapse;width:100%">
					<tr>
						<td class="CommentHeader" id="ItemPlus" style="cursor:pointer;padding:10px" onclick="changeID()">
							+
						</td>
						<td style="text-align:left;padding-left:10px;cursor:pointer;padding:10px" class="CommentHeader"  onclick="changeID()">
							پاسخ
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td style="height:120px;padding:5px;vertical-align:top;text-align:center;display:none" id="HideComment" class="CommentHeader">
                <asp:TextBox ID="MSG" runat="server" Width="550px" Height="100%" TextMode="MultiLine"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Text="ارسال پاسخ" OnClick="Button1_Click" />
			</td>
		</tr>
	</table>
        <br />
        <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound" Width="600px">
            <ItemTemplate>
                <table width=600px style="border-collapse: collapse;border:solid 1px #e1e1e1"  border=1>
		            <tr>
			            <td class="Memb" id="HeaderColor" runat="server">
				            <table style="border-collapse: collapse;width:100%">
					            <tr>
						            <td class="CommentHeader">
                                        <asp:Label ID="lbldate" runat="server" Text='<%# Eval("ReplyDate") %>'></asp:Label>
						            </td>
						            <td style="text-align:left;padding-left:10px;" class="CommentHeader">
							            <asp:Label ID="lblname" runat="server" Text='<%# Eval("Esm") %>' Font-Bold="true"></asp:Label>
						            </td>
					            </tr>
				            </table>
			            </td>
		            </tr>
		            <tr>
			            <td style="height:70px;padding:5px;vertical-align:top" class="CommentHeader">
			                <asp:Label ID="lblmsg" runat="server" Text='<%# Eval("MSG") %>'></asp:Label>
			            </td>
		            </tr>
	            </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
        </form>
</asp:Content>


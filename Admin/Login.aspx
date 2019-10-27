<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>پنل ورود به سامانه</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <script type="text/javascript" src="../Js/jquery.js"></script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    if ($('#Label1').html() == "") $('#MainTable').fadeIn(1000); else $('#MainTable').fadeIn(1);
        //});
        function ShowError()
        { $('#ErrorMessage').stop(); $('#ErrorMessage').fadeOut(1); $('#ErrorMessage').fadeIn(500); }
        function Login() {
            var PostData = '{Request: "' + $("#TextBox1")[0].value + ':' + $("#TextBox2")[0].value + ':' + $("#CaptchaCode")[0].value + '" }';
            $.ajax({
                type: "POST",
                url: "Login.aspx/CheckUserName",
                data: PostData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response);
                }
            });
        }
        function OnSuccess(response) {
            if (response.d != "1") {
                ShowError();
                $("#Label1").html(response.d);
            }
            else
                document.getElementById('Button1').click();
        }
        function runScript(e) {
            if (e.keyCode == 13) {
                Login();
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function GetCaptcha() {
            var PostData = '{Request: "get" }';
            $.ajax({
                type: "POST",
                url: "Login.aspx/CreateCaptchaImage2",
                data: PostData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess2,
                failure: function (response) {
                    alert(response);
                }
            });
        }
        function OnSuccess2(response) {
            if (response.d != "data:image/gif;base64") {
                $("#myimg").attr("src", response.d);
            }
            else
                document.getElementById('myresult').innerHTML = response.d;
        }
    </script>
    <style type="text/css">
        .style2
        {
            width: 153px;
        }
        .style5
        {
            text-align: center;
        }

        .auto-style1
        {
            text-align: center;
            height: 29px;
        }
        .auto-style2
        {
            height: 29px;
        }

    </style>
</head>
<body >
    <form id="form1" runat="server" >
    <div>
    <br /><br /><br /><br /><br /><br /><br />
                <table class="login" align=center id="MainTable" style="width:500px">
            <tr>
                <td style="text-align: center">
                    <p></p>
                    <p style="font-weight:bold;font-size:small;color:#827676">ورود به بخش مدیریت</p>
                    
                    <table class=ErrorMsg id="ErrorMessage">
                    <tr>
                        <td >
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                        </td>
                        <td style="background:url(../images/notice-alert.png) 50% 0 no-repeat;width:29px;height:29px">
                        </td>
                    </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>

        <table class="style1">
            <tr>
                <td class="style2">
                    <div id="lock"></div>
                </td>
                <td><p style="font-size:x-small">برای ورود به بخش مدیریت نام کاربری و رمز خود را وارد کنید</p>
                    <table class="InPutTable">
                        <tr>
                            <td class="style5">
                                نام کاربری :</td>
                            <td>
                                <input type="text" id="TextBox1" value="" runat="server" onkeypress="return runScript(event)" style="width:200px" />
                                 
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                کلمه عبور :</td>
                            <td class="auto-style2">
                                <input type="password" id="TextBox2" value="" runat="server" onkeypress="return runScript(event)" style="width:200px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                تصویر امنیتی :
                            </td>
                            <td>
                                <div style="background-image: url('refresh.png');width:16px;height:16px;display:inline-block;cursor:pointer" onclick="GetCaptcha()"></div>
                                <img id="myimg" runat="server" /> 
                                <input type="text" id="CaptchaCode" value="" runat="server" onkeypress="return runScript(event)" style="width:100px;margin-top:-15px" />

                            </td>
                        </tr>
                        <tr><td>
          </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td>
                                <input type="button" id="button" value="ورود" onclick="Login()" />
                                <asp:Button ID="Button1" Text="CHECK" runat="server"  style="display:none" OnClick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
                </td>
            </tr>
        </table>
    
    </div>
    <br />
    </form>
        
    <%--<p align=center style="text-shadow:0 1px 1px #040404;height:50px;color:white;font-size:small"> </p>--%>
        
        </body>
</html>

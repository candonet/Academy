<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewHotel.aspx.cs" Inherits="ViewHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" lang="javascript" src="/Files/HotelSlide.js"></script>
    <link rel="stylesheet" type="text/css" href="/Files/HotelView.css" />
    <link rel="stylesheet" href="/Files/js-persian-cal.css" />
	<script type="text/javascript" src="/Js/js-persian-cal.min.js"></script>
    <style type="text/css">
        .auto-style8
        {
            width: 145px;
        }
        .MyCol
        {
            padding:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%" class="GrayTable">
        <tr>
            <td class="TitleLeftBar" runat="server" id="TitleTour">
                                        
             </td>
        </tr>
        <tr>
            <td id="BodyTour" runat="server">
                
                <table class="auto-style1" style="width:100%;text-align:center;border:1px solid #808080" >
                    <tr>
                        <td class="TableHeaders" >
                            <table style="width:100%">
                                <tr>
                                    <td style="text-align:right">
                                        <asp:Label ID="Label1" runat="server" CssClass="LabelHeader" style="font-size:15.5px"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" CssClass="LabelHeader"></asp:Label>
                                    </td>
                                    <td style="text-align:left;padding-left:10px;">
                                        <asp:Label ID="Label7" runat="server" CssClass="LabelHeader" Text="Label" Font-Size="15.5px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr >
                        <td class="auto-style3" style="text-align:center;direction:ltr">
                            <center>
                            <table style="width:95%;margin-bottom:10px">
                                <tr>
                                    <td>
                                        <div style="text-align:left;direction:ltr">
                                            <div class="ImageViewDiv">
                                                <asp:Image ID="img2" runat="server" />
                                                <asp:Image ID="img1" runat="server" />
                                            </div>
                                            <asp:DataList ID="DataList1" runat="server" RepeatColumns="8">
                                                <ItemTemplate>
                                                    <div class="tinyImage">
                                                        <asp:Image ID="Image1" runat="server" class="tinyImage" ImageUrl='<%# Eval("ImageAddress","/IMG/{0}") %>'/>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                    </td>
                                    <td style="width:380px;direction:rtl;vertical-align:top;text-align:right;">
                                        <asp:Label ID="Label4" runat="server" Text="Label" style="font-size:13.5px;font-weight:normal"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            </center>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td style="vertical-align:top">
                            <table class="auto-style1" style="width:300px;text-align:center;border:1px solid #808080" >
                                <tr>
                                    <td class="TableHeaders" >
                                        <table>
                                            <tr>
                                                <td class="LabelHeader">
                                                    اطلاعات تکمیلی
                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                </tr>
                                <tr >
                                    <td class="auto-style5" >
                                        <table style="border-collapse: collapse;border:1px solid #C0C0C0;width:100%">
                                            <tr>
                                                <td style="border:1px solid #C0C0C0;padding:5px;" class="auto-style6">
                                                    تعداد اتاق
                                                </td>
                                                <td style="border:1px solid #C0C0C0;padding:5px;" class="auto-style7">
                                                    <asp:Label ID="lblRoom" runat="server" Text="درج نشده"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:1px solid #C0C0C0;padding:5px;">
                                                    آدرس
                                                </td>
                                                <td style="border:1px solid #C0C0C0;padding:5px;">
                                                    <asp:Label ID="lblAddress" runat="server" Text="درج نشده"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:1px solid #C0C0C0;padding:5px;">
                                                    تلفن
                                                </td>
                                                <td style="border:1px solid #C0C0C0;padding:5px;direction:ltr">
                                                    <asp:Label ID="lbltel" runat="server" Text="درج نشده"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:1px solid #C0C0C0;padding:5px;">
                                                    وب سایت
                                                </td>
                                                <td style="border:1px solid #C0C0C0;padding:5px;">
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" >درج نشده</asp:HyperLink>
                                                    
                                                </td>
                                            </tr>


                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="vertical-align:top">
                            <table class="auto-style1" style="width:590px; text-align:center;border:1px solid #808080;height:100%" >
                                <tr>
                                    <td  class="TableHeaders" >
                                        <table>
                                            <tr>
                                                <td class="LabelHeader">
                                                    مشخصات هتل
                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                </tr>
                                <tr >
                                    <td class="auto-style5" style="padding:10px;">
                            
                                        <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="4" Width="100%" >
                                            <ItemTemplate>
                                                <div class="HotelInfo">
                                                    <asp:Label ID="NamLabel" runat="server" Text='<%# Eval("Nam") %>' />
                                                </div>
                                                <br />
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConString %>" SelectCommand="SELECT InfoHotel.[Nam] FROM [HotelDetail],InfoHotel WHERE  InfoHotel.ID = HotelDetail.Nam">
                                        </asp:SqlDataSource>
                            
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table class="auto-style1" style="width:100%;text-align:center;border:1px solid #808080" >
                    <tr>
                        <td class="TableHeaders" >
                            <table style="width:100%">
                                <tr>
                                    <td class="LabelHeader" style="text-align:right">
                                        امتیاز و نقد و بررسی کاربران 
                                    </td>
                                    <td class="LabelHeader" style="text-align:left;padding-left:10px">
                                        <div class="FirstPost" onclick="OpenLogin()">نقد کنید </div>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr >
                        <td class="auto-style4" >
                            <table width=100% style="border-collapse: collapse;" >
	                            <tr>
		                            <td>
			                            <table width=100%  style="border-collapse: collapse;" id="MainTable">
				                            <tr>
					                            <td class="FirstColSelected" onclick="GotoPath(1)" id="tag1" runat="server">
						                            مشاهده همه (<asp:Label ID="lb1" runat="server" Text="0"></asp:Label>)
					                            </td>
					                            <td class="SecondCol">
					                            کیفیت و تنوع غذا
					                            </td>
					                            <td Class="ThrdCol">
					                            <div class="BGDiv">
						                            <div class="InsideDiv" id="ProgressBar1">
						                            </div>
					                            </div>
					                            </td>
					                            <td class="FourCol" id="value1">
                                                    0
					                            </td>
				                            </tr>
				                            <tr>
					                            <td class="FirstCol" onclick="GotoPath(2)" id="tag2" runat="server">
					                            تفریحی(خانوادگی)(<asp:Label ID="lb2" runat="server" Text="0"></asp:Label>)
					                            </td>
					                            <td class="SecondCol">
					                            تمیزی و زیبایی هتل و اتاق ها
					                            </td>
					                            <td Class="ThrdCol">
					                            <div class="BGDiv">
						                            <div class="InsideDiv" id="ProgressBar2">
						                            </div>
					                            </div>
					                            </td>
					                            <td class="FourCol" id="value2">
					                            0
					                            </td>
				                            </tr>
				                            <tr>
					                            <td class="FirstCol" onclick="GotoPath(3)" id="tag3" runat="server">
					                            تفریحی(زوج) (<asp:Label ID="lb3" runat="server" Text="0"></asp:Label>)
					                            </td>
					                            <td class="SecondCol">
					                            عملکرد کارکنان
					                            </td>
					                            <td Class="ThrdCol">
					                            <div class="BGDiv">
						                            <div class="InsideDiv" id="ProgressBar3">
						                            </div>
					                            </div>
					                            </td>
					                            <td class="FourCol" id="value3">
					                            0
					                            </td>
				                            </tr>
				                            <tr>
					                            <td class="FirstCol" onclick="GotoPath(4)" id="tag4" runat="server">
					                            تفریحی(مجردی)&nbsp;(<asp:Label ID="lb4" runat="server" Text="0"></asp:Label>)
					                            </td>
					                            <td class="SecondCol">
					                            تفریحات و امکانات هتل
					                            </td>
					                            <td Class="ThrdCol">
					                            <div class="BGDiv">
						                            <div class="InsideDiv" id="ProgressBar4">
						                            </div>
					                            </div>
					                            </td>
					                            <td class="FourCol" id="value4">
					                            0
					                            </td>
				                            </tr>
				                            <tr>
					                            <td class="FirstCol" onclick="GotoPath(5)" id="tag5" runat="server">
					                            کاری(تجاری) (<asp:Label ID="lb5" runat="server" Text="0"></asp:Label>)
					                            </td>
					                            <td class="SecondCol">
					                            منطقه و دسترسی
					                            </td>
					                            <td Class="ThrdCol">
					                            <div class="BGDiv">
						                            <div class="InsideDiv" id="ProgressBar5">
						                            </div>
					                            </div>
					                            </td>
					                            <td class="FourCol" id="value5">
					                            0
					                            </td>
				                            </tr>
				                            <tr>
					                            <td class="FirstCol" onclick="GotoPath(6)" id="tag6" runat="server">
					                            غیره (<asp:Label ID="lb6" runat="server" Text="0"></asp:Label>)
					                            </td>
					                            <td class="SecondCol">
					                            ارزش قیمت به نسبت خدمات
					                            </td>
					                            <td Class="ThrdCol">
					                            <div class="BGDiv">
						                            <div class="InsideDiv" id="ProgressBar6">
						                            </div>
					                            </div>
					                            </td>
					                            <td class="FourCol" id="value6">
					                            0
					                            </td>
				                            </tr>
			                            </table>
		                            </td>
		                            <td style="width:130px;background-color:#C0C0C0;">
			                            <center>
				                            <table style="background-color:white;border-collapse: collapse;width:120px">
					                            <tr>
						                            <td style="font-size:11.5px;text-align:center;border:solid 1px #C0C0C0;height:40px">
							                            <asp:Label ID="RANK" runat="server" Text="امتیاز کاربران"></asp:Label>
						                            </td>
					                            </tr>
					                            <tr>
						                            <td style="font-size:11.5px;text-align:center;border:solid 1px #C0C0C0;height:50px">
							                             <div id="emtiaz">0 از 10 </div>
							                             <center>
							                             <div style="direction:rtl;height:16px;width:96px;position:relative;">
								                            <div class="InsideDiv" id="ProgressBarEmtiaz" style="z-index:0">
									                            <div class="LastProG">
									                            </div>
								                            </div>
							                            </div>
							                            </center>
						                            </td>
					                            </tr>
					                            <tr>
						                            <td style="font-size:11.5px;text-align:center;border:solid 1px #C0C0C0;height:40px">
							                            تعداد نقد بررسی ها :<asp:Label ID="CountSP" runat="server" Text="0"></asp:Label>
						                            </td>	
					                            </tr>
				                            </table>
			                            </center>
		                            </td>
	                            </tr>
                            </table>
                            
                         </td>
                    </tr>
                </table>
                <div class="HideTableParent" id="LoginTable" runat="server" >
                    <table class="HideTables" >
                        <tr>
                            <td  class="TableHeaders" >
                                <table>
                                    <tr>
                                        <td class="LabelHeader">
                                            ثبت نقد و بررسی
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                        <tr >
                            <td class="auto-style4"  >
                                <div class="warning">
                                     برای ثبت نقد و بررسی باید در سیستم عضو شوید یا با نام کاربری خود وارد شوید . 
                                    </div>
                                    <hr />
                                    <table width=100%>
	                                    <tr>
		                                    <td class="auto-style8">نام کاربری
		                                    </td>
		                                    <td>
                                                <asp:TextBox ID="UserNameLogin" runat="server" CssClass="TextBoxInput" Height="27px"></asp:TextBox>
		                                        <asp:Label ID="Label9" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
		                                    </td>
	                                    </tr>
	                                    <tr>
		                                    <td class="auto-style8">کلمه عبور
		                                    </td>
		                                    <td><asp:TextBox ID="PasswordLogin" runat="server" CssClass="TextBoxInput" Height="27px" TextMode="Password"></asp:TextBox>
		                                        <asp:Label ID="Label6" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
		                                    </td>
	                                    </tr>
	                                    <tr>
		                                    <td class="auto-style8">
		                                    </td>
		                                    <td>
		                                        <asp:Label ID="ErrorMSG" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
		                                    </td>
	                                    </tr>
	                                    <tr>
		                                    <td class="auto-style8">
		                                    </td>
		                                    <td>
                                                <asp:Button ID="Button3" runat="server" Text="ثبت و تایید" CssClass="SabtPost" OnClick="Button3_Click"/>
		                                    </td>
	                                    </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </div>
                <div class="HideTableParent" id="SendComment" runat="server">
                <table class="HideTables">
                    <tr>
                        <td class="TableHeaders" >
                            <table>
                                <tr>
                                    <td class="LabelHeader">
                                        ثبت نقد و بررسی
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr >
                        <td class="auto-style4"  >
                            <div class="warning">
                                کاربر گرامی! لطفاً دقت داشته باشید: نقد و بررسی های شما می‌بایست حاوی اطلاعاتی نظیر نقاط قوت و ضعف و تجربه شخصی شما از استفاده از خدمات این آژانس باشد. همچنین حداقل تعداد کاراکتر مطلوب می بایست بیش از 800 کاراکتر باشد. آپلود واچر هتل ( یا هر مدرک دیگری که استفاده از خدمات این آژانس توسط شما را ثابت نماید) اجباریست و امکان ثبت نقد وبررسی بدون آپلود مجوز/واچر وجود ندارد. 
                                </div>
                                <hr />
                                <table width=100%>
	                                <tr>
		                                <td class="auto-style8">نوع سفر
		                                </td>
		                                <td>&nbsp;<asp:DropDownList ID="DropDownList14" runat="server" Font-Names="BYekan" Height="27px" Width="202px">
                                            <asp:ListItem Value="تفریحی(خانوادگی)"></asp:ListItem>
                                            <asp:ListItem Value="تفریحی(زوج)"></asp:ListItem>
                                            <asp:ListItem Value="تفریحی(مجردی)"></asp:ListItem>
                                            <asp:ListItem Value="کاری(تجاری)"></asp:ListItem>
                                            <asp:ListItem Value="غیره"></asp:ListItem>
                                            </asp:DropDownList>

		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">نام و نام خانوادگی
		                                </td>
		                                <td>&nbsp;<asp:TextBox ID="esmFamil" runat="server" CssClass="TextBoxInput" Height="27px"></asp:TextBox>
		                                    <asp:Label ID="ver1" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">ایمیل
		                                </td>
		                                <td>&nbsp;<asp:TextBox ID="emeil" runat="server" CssClass="TextBoxInput" Height="27px"></asp:TextBox>
		                                    <asp:Label ID="ver2" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">استان
		                                </td>
		                                <td>
                                            &nbsp;
		                                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="BYekan" Height="27px" Width="202px">
                                                <asp:ListItem>آذربایجان شرقی</asp:ListItem>
                                                <asp:ListItem>آذربایجان غربی</asp:ListItem>
                                                <asp:ListItem>اردبیل</asp:ListItem>
                                                <asp:ListItem>اصفهان</asp:ListItem>
                                                <asp:ListItem>البرز</asp:ListItem>
                                                <asp:ListItem>ایلام</asp:ListItem>
                                                <asp:ListItem>بوشهر</asp:ListItem>
                                                <asp:ListItem>تهران</asp:ListItem>
                                                <asp:ListItem>چهارمحال و بختیاری</asp:ListItem>
                                                <asp:ListItem>خراسان جنوبی</asp:ListItem>
                                                <asp:ListItem>خراسان رضوی</asp:ListItem>
                                                <asp:ListItem>خراسان شمالی</asp:ListItem>
                                                <asp:ListItem>خوزستان</asp:ListItem>
                                                <asp:ListItem>زنجان</asp:ListItem>
                                                <asp:ListItem>سمنان</asp:ListItem>
                                                <asp:ListItem>سیستان و بلوچستان</asp:ListItem>
                                                <asp:ListItem>فارس</asp:ListItem>
                                                <asp:ListItem>قزوین</asp:ListItem>
                                                <asp:ListItem>قم</asp:ListItem>
                                                <asp:ListItem>کردستان</asp:ListItem>
                                                <asp:ListItem>کرمان</asp:ListItem>
                                                <asp:ListItem>کرمانشاه</asp:ListItem>
                                                <asp:ListItem>کهگیلویه و بویراحمد</asp:ListItem>
                                                <asp:ListItem>گلستان</asp:ListItem>
                                                <asp:ListItem>گیلان</asp:ListItem>
                                                <asp:ListItem>لرستان</asp:ListItem>
                                                <asp:ListItem>مازندران</asp:ListItem>
                                                <asp:ListItem>مرکزی</asp:ListItem>
                                                <asp:ListItem>هرمزگان</asp:ListItem>
                                                <asp:ListItem>همدان</asp:ListItem>
                                                <asp:ListItem>یزد</asp:ListItem>
                                                <asp:ListItem>خارج از ایران</asp:ListItem>
                                            </asp:DropDownList>

		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">سال تولد
		                                </td>
		                                <td>
		                                    &nbsp;
		                                    <asp:DropDownList ID="DropDownList11" runat="server" Font-Names="BYekan" Width="48px" Height="27px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                                <asp:ListItem>13</asp:ListItem>
                                                <asp:ListItem>14</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem Value="16"></asp:ListItem>
                                                <asp:ListItem Value="17"></asp:ListItem>
                                                <asp:ListItem>18</asp:ListItem>
                                                <asp:ListItem Value="19"></asp:ListItem>
                                                <asp:ListItem Value="20"></asp:ListItem>
                                                <asp:ListItem Value="21"></asp:ListItem>
                                                <asp:ListItem Value="22"></asp:ListItem>
                                                <asp:ListItem Value="23"></asp:ListItem>
                                                <asp:ListItem Value="24"></asp:ListItem>
                                                <asp:ListItem Value="25"></asp:ListItem>
                                                <asp:ListItem Value="26"></asp:ListItem>
                                                <asp:ListItem Value="27"></asp:ListItem>
                                                <asp:ListItem Value="28"></asp:ListItem>
                                                <asp:ListItem>29</asp:ListItem>
                                                <asp:ListItem Value="30"></asp:ListItem>
                                                <asp:ListItem Value="31"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownList12" runat="server" Font-Names="BYekan" Height="27px">
                                                <asp:ListItem>فروردین</asp:ListItem>
                                                <asp:ListItem>اردیبهشت</asp:ListItem>
                                                <asp:ListItem>خرداد</asp:ListItem>
                                                <asp:ListItem>تیر</asp:ListItem>
                                                <asp:ListItem>مرداد</asp:ListItem>
                                                <asp:ListItem Value="شهریور"></asp:ListItem>
                                                <asp:ListItem>مهر</asp:ListItem>
                                                <asp:ListItem>آبان</asp:ListItem>
                                                <asp:ListItem>آذر</asp:ListItem>
                                                <asp:ListItem>دی</asp:ListItem>
                                                <asp:ListItem>بهمن</asp:ListItem>
                                                <asp:ListItem>اسفند</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownList13" runat="server" Font-Names="BYekan" Height="27px">
                                                <asp:ListItem>1380</asp:ListItem>
                                                <asp:ListItem>1379</asp:ListItem>
                                                <asp:ListItem>1378</asp:ListItem>
                                                <asp:ListItem>1377</asp:ListItem>
                                                <asp:ListItem>1376</asp:ListItem>
                                                <asp:ListItem>1375</asp:ListItem>
                                                <asp:ListItem Value="1374"></asp:ListItem>
                                                <asp:ListItem Value="1373"></asp:ListItem>
                                                <asp:ListItem Value="1372"></asp:ListItem>
                                                <asp:ListItem Value="1371"></asp:ListItem>
                                                <asp:ListItem Value="1370"></asp:ListItem>
                                                <asp:ListItem Value="1369"></asp:ListItem>
                                                <asp:ListItem Value="1368"></asp:ListItem>
                                                <asp:ListItem>1367</asp:ListItem>
                                                <asp:ListItem>1366</asp:ListItem>
                                                <asp:ListItem>1365</asp:ListItem>
                                                <asp:ListItem>1364</asp:ListItem>
                                                <asp:ListItem>1363</asp:ListItem>
                                                <asp:ListItem>1362</asp:ListItem>
                                                <asp:ListItem>1361</asp:ListItem>
                                                <asp:ListItem>1360</asp:ListItem>
                                                <asp:ListItem>1359</asp:ListItem>
                                                <asp:ListItem>1358</asp:ListItem>
                                                <asp:ListItem>1357</asp:ListItem>
                                                <asp:ListItem>1356</asp:ListItem>
                                                <asp:ListItem>1355</asp:ListItem>
                                            </asp:DropDownList>
		                                
		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">شغل
		                                </td>
		                                <td>&nbsp;<asp:TextBox ID="shoql" runat="server" CssClass="TextBoxInput" Height="27px"></asp:TextBox>
		                                    <asp:Label ID="ver3" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">تاریخ مسافرت
		                                </td>
		                                <td>
		                                &nbsp;
		                                    <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="BYekan" Width="48px" Height="27px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                                <asp:ListItem>13</asp:ListItem>
                                                <asp:ListItem>14</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem Value="16"></asp:ListItem>
                                                <asp:ListItem Value="17"></asp:ListItem>
                                                <asp:ListItem>18</asp:ListItem>
                                                <asp:ListItem Value="19"></asp:ListItem>
                                                <asp:ListItem Value="20"></asp:ListItem>
                                                <asp:ListItem Value="21"></asp:ListItem>
                                                <asp:ListItem Value="22"></asp:ListItem>
                                                <asp:ListItem Value="23"></asp:ListItem>
                                                <asp:ListItem Value="24"></asp:ListItem>
                                                <asp:ListItem Value="25"></asp:ListItem>
                                                <asp:ListItem Value="26"></asp:ListItem>
                                                <asp:ListItem Value="27"></asp:ListItem>
                                                <asp:ListItem Value="28"></asp:ListItem>
                                                <asp:ListItem>29</asp:ListItem>
                                                <asp:ListItem Value="30"></asp:ListItem>
                                                <asp:ListItem Value="31"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="BYekan" Height="27px">
                                                <asp:ListItem>فروردین</asp:ListItem>
                                                <asp:ListItem>اردیبهشت</asp:ListItem>
                                                <asp:ListItem>خرداد</asp:ListItem>
                                                <asp:ListItem>تیر</asp:ListItem>
                                                <asp:ListItem>مرداد</asp:ListItem>
                                                <asp:ListItem Value="شهریور"></asp:ListItem>
                                                <asp:ListItem>مهر</asp:ListItem>
                                                <asp:ListItem>آبان</asp:ListItem>
                                                <asp:ListItem>آذر</asp:ListItem>
                                                <asp:ListItem>دی</asp:ListItem>
                                                <asp:ListItem>بهمن</asp:ListItem>
                                                <asp:ListItem>اسفند</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownList4" runat="server" Font-Names="BYekan" Height="27px">
                                                <asp:ListItem>1394</asp:ListItem>
                                                <asp:ListItem>1393</asp:ListItem>
                                                <asp:ListItem>1392</asp:ListItem>
                                                <asp:ListItem>1391</asp:ListItem>
                                                <asp:ListItem>1390</asp:ListItem>
                                                <asp:ListItem>1389</asp:ListItem>
                                                <asp:ListItem Value="1388"></asp:ListItem>
                                                <asp:ListItem Value="1387"></asp:ListItem>
                                                <asp:ListItem Value="1386"></asp:ListItem>
                                                <asp:ListItem Value="1385"></asp:ListItem>
                                                <asp:ListItem Value="1384"></asp:ListItem>
                                                <asp:ListItem Value="1383"></asp:ListItem>
                                                <asp:ListItem Value="1382"></asp:ListItem>
                                                <asp:ListItem>1381</asp:ListItem>
                                                <asp:ListItem>1380</asp:ListItem>
                                                <asp:ListItem Value="1379"></asp:ListItem>
                                            </asp:DropDownList>
		                                
		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">عنوان
		                                </td>
		                                <td>&nbsp;<asp:TextBox ID="onvan" runat="server" CssClass="TextBoxInput" Height="27px"></asp:TextBox>
		                                    <asp:Label ID="ver4" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">دیدگاه
		                                </td>
		                                <td>&nbsp;<asp:TextBox ID="didgah" runat="server" CssClass="TextBoxInput" Height="60px" TextMode="MultiLine"></asp:TextBox>
		                                    <asp:Label ID="ver5" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
		                                </td>
	                                </tr>
                                    <tr>
		                                <td class="auto-style8">آپلود واچر
		                                </td>
		                                <td>&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
		                                    <asp:Label ID="ver6" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">
		                                </td>
		                                <td><asp:CheckBox ID="CheckBox1" runat="server" CssClass="Pishnehad" Text=" اقامت در این هتل را به دیگران توصیه میکنم " />
		                                </td>
	                                </tr>
                                </table>
                                <hr />
                                <table width=100%>
	                                <tr>
		                                <td class="auto-style8">کیفیت و تنوع غذا
		                                </td>
		                                <td>

		                                    <asp:DropDownList ID="DropDownList5" runat="server" Font-Names="BYekan" Height="27px" Width="202px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem Selected="True">5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>

		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">تمیزی و زیبایی هتل و اتاق ها
		                                </td>
		                                <td>

		                                    <asp:DropDownList ID="DropDownList6" runat="server" Font-Names="BYekan" Height="27px" Width="202px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem Selected="True">5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>

		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">عملکرد کارکنان
		                                </td>
		                                <td>

		                                    <asp:DropDownList ID="DropDownList7" runat="server" Font-Names="BYekan" Height="27px" Width="202px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem Selected="True">5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>

		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">تفریحات و امکانات هتل
		                                </td>
		                                <td>

		                                    <asp:DropDownList ID="DropDownList8" runat="server" Font-Names="BYekan" Height="27px" Width="202px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem Selected="True">5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>

		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">منطقه و دسترسی
		                                </td>
		                                <td>
		                                
		                                    <asp:DropDownList ID="DropDownList9" runat="server" Font-Names="BYekan" Height="27px" Width="202px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem Selected="True">5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>

		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">ارزش قیمت به نسبت خدمات
		                                </td>
		                                <td>

		                                    <asp:DropDownList ID="DropDownList10" runat="server" Font-Names="BYekan" Height="27px" Width="202px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem Selected="True">5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>

		                                </td>
	                                </tr>
	                                <tr>
		                                <td class="auto-style8">
		                                </td>
		                                <td>
                                            <asp:Button ID="Button1" runat="server" Text="ثبت و تایید" CssClass="SabtPost" OnClick="Button1_Click1" OnClientClick="return checkValid()"/>
		                                </td>
	                                </tr>
                                </table>   
                            </td>
                    </tr>
                </table>
                </div>
                <br />

                <table class="auto-style1" style="width:100%;text-align:center;border:1px solid #808080" runat="server" visible="false" id="CommentTable">
                    <tr>
                        <td class="TableHeaders" >
                            <table>
                                <tr>
                                    <td class="LabelHeader">
                                        نظرات
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr >
                        <td class="auto-style4" >
                            <asp:DataList ID="DataList3" runat="server" Width="100%" OnItemDataBound="DataList3_ItemDataBound">
                                <ItemTemplate>
                                    <table style="width:100%;border-collapse: collapse;border:solid 1px gray;">
	                                    <tr>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Aydi") %>' style="display:none"></asp:Label>
		                                    <td style="width:130px;vertical-align:top;text-align:center;background-color:#C0C0C0;">
                                                <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("AksAvatar") %>'  style="height:150px;width:120px;"/>
			                                    <div style="width:125px;font-size:13.5px;"><asp:Label ID="NLlbl" runat="server" Text='<%# Eval("NamLast") %>'></asp:Label><br />
			                                    تعداد نقد و بررسی: <div>
                                                     <asp:Label ID="Tnaqd" runat="server" Text='<%# Eval("Bomba3") %>'></asp:Label> </div>
			                                    امتیاز مثبت:  <div> <asp:Label ID="TMosbat" runat="server" Text='<%# Eval("Bomba1") %>'></asp:Label> </div>
			                                    امتیاز منفی:  <div> <asp:Label ID="TManfi" runat="server" Text='<%# Eval("Bomba2") %>'></asp:Label> </div>
			                                    </div>
		                                    </td>
		                                    <td style="background-color:white">
		                                    <div id="Vote" style="position: absolute; direction:rtl">
		                                    <div class="VoteBox" style="background-color: gray;" runat="server" id="VoteeM"><%# Eval("emMos") %></div>
                                            <div class="VoteBox" style="background-color: #56b256;cursor:pointer;" onclick="VoteAjax(this.id)"  runat="server" id="VoteM">+</div>
                                &nbsp;&nbsp;<div class="VoteBox" style="background-color: #f34c4c;cursor:pointer;font-family:'serif';padding-top:3px;top:13px;padding-left:8px;padding-right:8px;" onclick="VoteAjax(this.id)" runat="server" id="VoteP">-</div>
                                            <div class="VoteBox" style="background-color: gray;" runat="server" id="VoteeP"><%# Eval("emMan") %></div>
		                                    <div class="VoteMSG" id="VoteMSG" runat="server"></div>
		                                    </div>
			                                    <table>
				                                    <tr>
					                                    <td>
					                                    <div class="HotelName"> <asp:Label ID="CommentTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label> </div><br/>
					                                    <div class="HotelText"><asp:Label ID="TarikhComment" runat="server" Text='<%# Eval("PostDate") %>'></asp:Label></div>
					                                    <asp:Label ID="TaeedCH" runat="server" Text='<%# Eval("Advice") %>'></asp:Label><br><br><br>
					
					                                    <div id="tinyText" class="TinyTXT" runat="server"><asp:Label ID="TinyTextAS" runat="server" Text='<%# Eval("TozihatKot","{0} ...") %>'></asp:Label></div>
					                                    <div id="BigText" class="BigText" runat="server"><asp:Label ID="BigTextAS" runat="server" Text='<%# Eval("Tozihat") %>'></asp:Label>
                                                        </div>
					                                    <br/>
					                                    <div class="FooterTXT">
						                                     نوع سفر :  <p class="safarKind" >  <asp:Label ID="KindS" runat="server" Text='<%# Eval("KIND") %>'></asp:Label></p>&nbsp;&nbsp;تاریخ سفر: <p class="TarikhSafar">  <asp:Label ID="TarikhSFR" runat="server" Text='<%# Eval("TarikhM") %>'></asp:Label></p><div class="MoreInfo" id="MoreInfo" onClick="SlideUPDOWN(this.id);" runat="server">بیشتر</div>
					                                    </div>
					                                    </td>
				                                    </tr>
			                                    </table>
		                                    </td>
	                                    </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>  
                        </td>
                    </tr>
                </table>
                <br />
                <table class="auto-style1" style="width:100%;text-align:center;border:1px solid #808080" >
                    <tr>
                        <td class="TableHeaders" >
                            <table>
                                <tr>
                                    <td class="LabelHeader">
                                        درباره هتل
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr >
                        <td class="auto-style4" >
                            
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                            
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


var myVar;
var ImageIndex = 0;
var publicValid = 0;
var ImageName = new Array();
ImageName[0] = "#ContentPlaceHolder1_img1";
ImageName[1] = "#ContentPlaceHolder1_img2";
$("#my_image").attr("src", "second.jpg");

function ShowThisImage(inputImage) {
    clearTimeout(myVar);
    if (ImageIndex == 0) {
        $(ImageName[1]).css('z-index', "100");
        $(ImageName[0]).css('z-index', "101");
        $(ImageName[1]).attr("src", inputImage);
        $(ImageName[1]).css('opacity', 1);
    }
    else if (ImageIndex == 1) {
        $(ImageName[0]).css('z-index', "100");
        $(ImageName[1]).css('z-index', "101");
        $(ImageName[0]).attr("src", inputImage);
        $(ImageName[0]).css('opacity', 1);
    }
    myVar = setInterval(HideImage, 1);
}

function HideImage() {

    var n = $(ImageName[ImageIndex]).css('opacity');
    if (n == 0.1) {
        clearTimeout(myVar);
        n = 0;
        $(ImageName[ImageIndex]).css('opacity', n);
        if (ImageIndex == 1) {
            ImageIndex = 0;
        }
        else {
            ImageIndex = 1;
        }
    }
    else {
        n -= 0.01;
        $(ImageName[ImageIndex]).css('opacity', n);
    }
}
function SetEmtiaz(n) {
    document.getElementById('emtiaz').innerHTML = n + " از 10";
    document.getElementById('ProgressBarEmtiaz').style.width = n * 10 + "%";
}
function SetPro(n, Index) {
    document.getElementById('value' + Index).innerHTML = n;
    document.getElementById('ProgressBar' + Index).style.width = n * 10 + "%";
}
$(document).ready(function () {
    $(".tinyImage").click(function () { ShowThisImage($(this).attr("src")); })
});
function checkValid() {
    var n = 0;
    if (document.getElementById("ContentPlaceHolder1_esmFamil").value == "") {
        $("#ContentPlaceHolder1_ver1").html('فیلد "نام و نام خانوادگی" خالی است');
        n = 1;
    }
    else {
        $("#ContentPlaceHolder1_ver1").html("");
    }
    var emailvalid = 0;
    if (document.getElementById("ContentPlaceHolder1_emeil").value == "") {
        $("#ContentPlaceHolder1_ver2").html('فیلد "ایمیل" خالی است');
        n = 1;
        emailvalid = 1;
    }
    else {
        $("#ContentPlaceHolder1_ver2").html("");
    }
    if (emailvalid == 0) {

        if (document.getElementById("ContentPlaceHolder1_emeil").value.indexOf('@') == -1) {
            $("#ContentPlaceHolder1_ver2").html('"' + document.getElementById("ContentPlaceHolder1_emeil").value + '" در فیلد "ایمیل" آدرس ایمیل معتبر نیست');
            n = 1;
        }
        else {
            $("#ContentPlaceHolder1_ver2").html("");
        }
    }
    if (document.getElementById("ContentPlaceHolder1_shoql").value == "") {
        $("#ContentPlaceHolder1_ver3").html('فیلد "شغل" خالی است');
        n = 1;
    }
    else {
        $("#ContentPlaceHolder1_ver3").html("");
    }
    if (document.getElementById("ContentPlaceHolder1_onvan").value == "") {
        $("#ContentPlaceHolder1_ver4").html('فیلد "عنوان" خالی است');
        n = 1;
    }
    else {
        $("#ContentPlaceHolder1_ver4").html("");
    }
    if (document.getElementById("ContentPlaceHolder1_didgah").value == "") {
        $("#ContentPlaceHolder1_ver5").html('فیلد "توضیحات" خالی است');
        n = 1;
    }
    else {
        $("#ContentPlaceHolder1_ver5").html("");
    }
    if (n == 0) return true;
    else if (n == 1) return false;

}
function GotoTag(n) {
    var PageURL = $(location).attr('href');
    var PP = PageURL.indexOf('&Type=');
    var NN = PageURL.indexOf('&Type=' + n);
    if (NN < 0) {
        if (PP > 0) {
            PageURL = PageURL.substr(0, PP) + "&Type=" + n;
        }
        else PageURL += "&Type=" + n;
        window.location = PageURL;
    }
}
function GotoPath(n) {

    var PageURL = $(location).attr('href');
    var res = PageURL.split('/');
    if (res[5] != n) {
        window.location = res[0] + "/" + res[1] + "/" + res[2] + "/" + res[3] + "/" + res[4] + "/" + n;
    }
}

function OpenLogin() {
    if (publicValid == 0) {
        $("#ContentPlaceHolder1_SendComment").stop();
        $("#ContentPlaceHolder1_SendComment").slideDown(500);
        $("#ContentPlaceHolder1_LoginTable").stop();
        $("#ContentPlaceHolder1_LoginTable").slideDown(500);
        publicValid = 1;
    }
    else {
        $("#ContentPlaceHolder1_SendComment").stop();
        $("#ContentPlaceHolder1_SendComment").slideUp(500);
        $("#ContentPlaceHolder1_LoginTable").stop();
        $("#ContentPlaceHolder1_LoginTable").slideUp(500);
        publicValid = 0;
    }

}
function SlideUPDOWN(n) {
    var thatNumber = n.substr(39, n.length - 38);
    var PoN = "#ContentPlaceHolder1_DataList3_MoreInfo_" + thatNumber;
    if ($(PoN).html() == "بیشتر") {
        $("#ContentPlaceHolder1_DataList3_tinyText_" + thatNumber).stop();
        $("#ContentPlaceHolder1_DataList3_tinyText_" + thatNumber).slideUp(500);
        $("#ContentPlaceHolder1_DataList3_BigText_" + thatNumber).stop();
        $("#ContentPlaceHolder1_DataList3_BigText_" + thatNumber).slideDown(500);
        $(PoN).html('کمتر');
    }
    else {
        $("#ContentPlaceHolder1_DataList3_BigText_" + thatNumber).stop();
        $("#ContentPlaceHolder1_DataList3_BigText_" + thatNumber).slideUp(500);
        $("#ContentPlaceHolder1_DataList3_tinyText_" + thatNumber).stop();
        $("#ContentPlaceHolder1_DataList3_tinyText_" + thatNumber).slideDown(500);
        $(PoN).html('بیشتر');
    }
}



function VoteAjax(n) {
    var thatNumber = n.substr(36, n.length - 35);
    var opr = n.substr(34, 1);
    var PostID = $("#ContentPlaceHolder1_DataList3_Label5_" + thatNumber).html();
    var PostData = '{Requesto: "' + PostID + ':' + opr + ':' + thatNumber + '" }';
    $.ajax({
        type: "POST",
        url: "/ViewHotel.aspx/VoteToUser",
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
    var Data = response.d.split('-');
    $("#ContentPlaceHolder1_DataList3_VoteMSG_" + Data[1]).html(Data[0]);
    if (Data.length == 3) {
        if (Data[2] == "P") {
            var CurrentN = parseInt($("#ContentPlaceHolder1_DataList3_VoteeM_" + Data[1]).html());
            CurrentN++;
            $("#ContentPlaceHolder1_DataList3_VoteeM_" + Data[1]).html(CurrentN);
        }
        else if (Data[2] == "M") {
            var CurrentN = parseInt($("#ContentPlaceHolder1_DataList3_VoteeP_" + Data[1]).html());
            CurrentN++;
            $("#ContentPlaceHolder1_DataList3_VoteeP_" + Data[1]).html(CurrentN);
        }
    }
}

function VoteAjax2(n) {
    var thatNumber = n.substr(36, n.length - 35);
    var opr = n.substr(34, 1);
    var PageURL = $(location).attr('href');
    var NNN = PageURL + "/VoteToUser";
    var PostID = $("#ContentPlaceHolder1_DataList3_Label5_" + thatNumber).html();
    
    var PostData = '{Requesto: "' + PostID + ':' + opr + ':' + thatNumber + '" }';
    $.ajax({
        type: "POST",
        url: "/ViewAgency.aspx/VoteToUser",
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
    var Data = response.d.split('-');
    $("#ContentPlaceHolder1_DataList3_VoteMSG_" + Data[1]).html(Data[0]);
    if (Data.length == 3) {
        if (Data[2] == "P") {
            var CurrentN = parseInt($("#ContentPlaceHolder1_DataList3_VoteeM_" + Data[1]).html());
            CurrentN++;
            $("#ContentPlaceHolder1_DataList3_VoteeM_" + Data[1]).html(CurrentN);
        }
        else if (Data[2] == "M") {
            var CurrentN = parseInt($("#ContentPlaceHolder1_DataList3_VoteeP_" + Data[1]).html());
            CurrentN++;
            $("#ContentPlaceHolder1_DataList3_VoteeP_" + Data[1]).html(CurrentN);
        }
    }
}
function CheckForBegin(n) {
    var d = document;
    var e = d.getElementById(n);
    if (n == "name") {
        if (e.value == "نام و نام خانوادگی")
            e.value = "";
    }
    else if (n == "email") {
        if (e.value == "ایمیل")
            e.value = "";
    }
    else if (n == "subj") {
        if (e.value == "عنوان")
            e.value = "";
    }
}
function ForBlur(n) {
    var d = document;
    var e = d.getElementById(n);
    if (n == "name") {
        if (e.value == "")
            e.value = "نام و نام خانوادگی";

    }
    else if (n == "email") {
        if (e.value == "") {
            e.value = "ایمیل";
            var lbl = d.getElementById('Label2').style.visibility = "hidden";
        }
        else if (CheckEmail(e) == true) {
            var lbl = d.getElementById('Label2').style.visibility = "visible";
        }
        else if (CheckEmail(e) == false) {
            var lbl = d.getElementById('Label2').style.visibility = "hidden";
        }
    }
    else if (n == "subj") {
        if (e.value == "")
            e.value = "عنوان";
    }
}
function CheckEmpty(n) {
    if (n.value.trim() == "")
        return true;
    return false;
}
function CheckEmail(n) {
    if (n.value.indexOf("@") == -1)
        return true;
    return false;
}
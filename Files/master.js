function set_background_color() {
    var BGcolor = "#c8f1fe";
    $("html, body").css("background-color", BGcolor);
    $("html, body").addClass("BB");

}
function MoveT() {
    window.scrollTo(100, 1000);
}
function ChangeLogin(n) {

    if (n == "1") {
        document.getElementById('LoginMenuBTN').innerHTML = "<li><a href='/Login'>ورود کاربران</a></li>";
    }
    else {
        document.getElementById('LoginMenuBTN').innerHTML = "<li><a href='#'>خوش آمدید" + " " + n + "</a><ul  class='sub-menu'><li><a href='/Config'>ویرایش اطلاعات</a></li><li><a href='/?action=logout'>خروج</a></li></ul></li>";
    }
}
function SlideShowStart(timeinter) {
    $(document).ready(function () {
        $('.box_skitter_large').skitter({
            theme: 'clean',
            numbers_align: 'left',
            dots: true,
            interval: timeinter,
            preview: true
        });
        setInterval(ChangeSlide, timeinter);
    });
}
function ChangeSlide() {
    $('#NextBTN').click();
}
function ChangeSlide2() {
    $('#NextBTN2').click();
}
function Slide2SS(timeinter) {
    
        setInterval(ChangeSlide2, timeinter);
}
$(function () {
    $('.crsl-items').carousel({
        visible: 4,
        itemMinWidth: 180,
        itemEqualHeight: 370,
        itemMargin: 9,
    });

    $("a[href=#]").on('click', function (e) {
        e.preventDefault();
    });
});
$(document).ready(function () {
    //判断当教师或者管理员查看题目信息时，对选定题目按钮进行隐藏
    var userState = $("#loginUser").val().trim();
    if (userState == "1" || userState == "0" || userState == "2") {
        $("#btn_ToPaperDtailStu").hide();
    }
    else {
        $("#btn_ToPaperDtailStu").show();
    }
})
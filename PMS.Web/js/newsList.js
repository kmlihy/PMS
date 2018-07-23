//sessionStorage.setItem("userState", $("#userType").text().trim());
$(document).ready(function () {
    $("#userType").hide();
    var userState = $("#userType").text().trim()
    if (userState != "") {
        if (userState == "0") {
            $("#institute").hide();
            $("#Mine").hide();
            $("#school").show();
        }
        else if (userState == "2") {
            $("#institute").show();
            $("#Mine").hide();
            $("#school").show();
        }
        else if (userState == "1") {
            $("#institute").show();
            $("#Mine").show();
            $("#school").show();
        }
        else if (userState == "3") {
            $("#institute").show();
            $("#Mine").show();
            $("#school").show();
        }
    }
    else {
        //document.write('<a href="http://localhost:33192/login.aspx">您还没有登录或登录已超时，请点击跳转到登录界面  </a>');
    }
    //当前教师没有发布公告时的处理
    var teacherNews = $("#Mine-table").html().trim();
    if (teacherNews == "") {
        $("#Mine-list").html("<h4>暂无公告</h4>");
        $("#teacher_all").hide();
    }
    //当前学院没有发布公告时的处理
    var collegeNews = $("#newsListtable").html().trim();
    if (collegeNews == "") {
        $("#institute-list").html("<h4>暂无公告</h4>");
        $("#college_all").hide();
    }
    //当前学校没有发布公告时的处理
    var schoolNews = $("#school-table").html().trim();
    if (schoolNews == "") {
        $("#school-list").html("<h4>暂无公告</h4>");
        $("#school_all").hide();
    }
})
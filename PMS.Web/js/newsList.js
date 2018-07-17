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
})
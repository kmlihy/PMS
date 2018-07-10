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
})
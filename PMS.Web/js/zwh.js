$(function() {
    $("#okMessage").hide();
    $(".body").height($(window).height());
})

// 页面重置
function formReset() {
    $("#form")[0].reset()
}

// 点击切换验证码
function refreshCode() {
    var code = document.getElementById("code");
    code.src = "checkCode.aspx?id=" + Math.random();
}

// 管理员登录界面提示框
function adminMsg() {
    var my_toast_plug_name = "mytoast";
    $[my_toast_plug_name] = function (options) {
        var content;
        if ($("#userName").val() === "") {
            content = "用户名不能为空！";
        } else if ($("#pwd").val() === "") {
            content = "密码不能为空！";
        } else {
            return;
        }
        var jq_toast = $("<div class='my-toast'><div class='my-toast-text'></div></div>");
        var jq_text = jq_toast.find(".my-toast-text");
        jq_text.html(content);
        jq_toast.appendTo($("body")).stop().fadeIn(500).delay(3000).fadeOut(500);
        var w = jq_toast.width() - 10;
        jq_text.width(w);
        var l = -jq_toast.outerWidth() / 2;
        var t = -jq_toast.outerHeight() / 2;
        jq_toast.css({
            "margin-left": l + "px",
            "margin-top": t - 50 + "px"
        });
        var _jq_toast = jq_toast;
        setTimeout(function () {
            _jq_toast.remove();
        }, 2 * 1000);
    };
    $.mytoast({
        type: "notice"
    });
}

// 管理员登录界面判断是否提交表单
function admincheckForm() {
    if ($("#userName").val() !== "" && $("#pwd").val() !== "") {
        return true;
    } else {
        return false;
    }
}

// 学生登录界面提示框
function stuMsg() {
    var my_toast_plug_name = "mytoast";
    $[my_toast_plug_name] = function (options) {
        var content;
        if ($("#userName").val() === "") {
            content = "用户名不能为空！";
        } else if ($("#pwd").val() === "") {
            content = "密码不能为空！";
        } else if ($("#captcha").val() === "") {
            content = "验证码不能为空！";
        } else if ($("#captcha").val().toLowerCase !== "<%=code%>") {
            content = "验证码错误！";
        } else {
            return;
        }
        var jq_toast = $("<div class='my-toast'><div class='my-toast-text'></div></div>");
        var jq_text = jq_toast.find(".my-toast-text");
        jq_text.html(content);
        jq_toast.appendTo($("body")).stop().fadeIn(500).delay(3000).fadeOut(500);
        var w = jq_toast.width() - 10;
        jq_text.width(w);
        var l = -jq_toast.outerWidth() / 2;
        var t = -jq_toast.outerHeight() / 2;
        jq_toast.css({
            "margin-left": l + "px",
            "margin-top": t - 50 + "px"
        });
        var _jq_toast = jq_toast;
        setTimeout(function () {
            _jq_toast.remove();
        }, 2 * 1000);
    };
    $.mytoast({
        type: "notice"
    });
}

// 学生登录界面判断是否提交表单
function stucheckForm() {
    if ($("#userName").val() !== "" && $("#pwd").val() !== "" && $("#captcha").val() !== "") {
        return true;
    } else {
        return false;
    }
}

// 个人中心页面
function edit() {
    var telNum = $.trim($("#telNum").text());
    $("#telNum").text("")
    var txtTelNum = "<input type='text' class='telNum'/>"
    $("#telNum").append(txtTelNum);
    $(".telNum").focus();
    $(".telNum").val(telNum);
    var email = $.trim($("#email").text());
    $("#email").text("")
    var txtEmail = "<input type='text' class='email'/>"
    $("#email").append(txtEmail);
    $(".email").val(email);

    $("#editMessage").hide();
    $("#okMessage").show();
}

function ok() {
    var telNum = $(".telNum").val();
    if (telNum === "") {
        $("#telNum").closest("td").text("");
    } else {
        $("#telNum").closest("td").text(telNum);
    }
    var email = $(".email").val();
    if (email === "") {
        $("#email").closest("td").text("");
    } else {
        $("#email").closest("td").text(email);
    }
    $("#okMessage").hide();
    $("#editMessage").show();
}


function pagingMsg() {
    var my_toast_plug_name = "mytoast";
    $[my_toast_plug_name] = function (options) {
        var content;
        if (parseInt(sessionStorage.getItem("page")) <= 1) {
            content = "前无古人！";
        } else if (parseInt(sessionStorage.getItem("page")) >= parseInt(sessionStorage.getItem("countPage"))) {
            content = "后无来者！";
        } else {
            return;
        }
        var jq_toast = $("<div class='my-toast'><div class='my-toast-text'></div></div>");
        var jq_text = jq_toast.find(".my-toast-text");
        jq_text.html(content);
        jq_toast.appendTo($("body")).stop().fadeIn(500).delay(3000).fadeOut(500);
        var w = jq_toast.width() - 10;
        jq_text.width(w);
        var l = -jq_toast.outerWidth() / 2;
        var t = -jq_toast.outerHeight() / 2;
        jq_toast.css({
            "margin-left": l + "px",
            "margin-top": t - 50 + "px"
        });
        var _jq_toast = jq_toast;
        setTimeout(function () {
            _jq_toast.remove();
        }, 3 * 1000);
    };
    $.mytoast({
        type: "notice"
    });
}

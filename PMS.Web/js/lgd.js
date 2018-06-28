//注册验证
$(document).ready(function () {
    $("#regform").validate({
        errorPlacement: function (error, element) {
            error.appendTo(element.parent().parent());
        },
        rules: {
            usercount: {
                required: true,
                digits: true
            },
            pwd: {
                required: true,
                minlength: 6
            },
            confirmPwd: {
                required: true,
                minlength: 6,
                equalTo: "#pwd"
            },
            username: {
                required: true,
            },
            userEmail: {
                required: true,
                email: true
            },
            usertel: {
                required: true,
                isMobile: true
            },
        },
        messages: {
            usercount: {
                required: "请输入账号",
            },
            pwd: {
                required: "请输入密码",
            },
            confirmPwd: {
                required: "请输入密码",
                equalTo: "两次密码输入不一致"
            },
            username: {
                required: "请输入姓名",
            },
            userEmail: {
                required: "请输入邮箱",
            },
            usertel: {
                required: "请输入电话",
                isMobile: "请输入有效的电话号码"
            },
        }
    });
});
//发布公告
//密码修改

$(document).ready(function () {
    $("#changePwdForm").validate({
        errorPlacement: function (error, element) {
            error.appendTo(element.parent().parent());
        },
        rules: {
            phone: {
                required: true,
                isMobile: true
            },
            newpwd: {
                required: true,
                minlength: 6
            },
            confirmPwd: {
                required: true,
                minlength: 6,
                equalTo: "#newpwd"
            },
        },
        messages: {
            phone: {
                required: "请输入手机号码",
                isMobile: "请输入正确的手机号码"
            },
            newpwd: {
                required: "请输入密码",
                minlength: "密码长度不能小于5个字母"
            },
            confirmPwd: {
                required: "请输入密码",
                minlength: "密码长度不能小于5个字母",
                equalTo: "两次密码输入不一致"
            },
        }
    })
})
//分页界限提示
function adminMsg() {
    alert("123");
    var my_toast_plug_name = "mytoast";
    $[my_toast_plug_name] = function (options) {
        var content;
        if ($("#fristPage").val() == "1") {
            content = "已经是第一页！";
        } else if ($("#fristPage").val() == $("#lastPage").val()) {
            content = "最后一页！";
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
//全选框
var $checkboxAll = $(".js-checkbox-all"),
    $checkbox = $("tbody").find("[type='checkbox']"),
    length = $checkbox.length,
    i = 0;

//启动icheck
$(("[type='checkbox']")).iCheck({
    checkboxClass: 'icheckbox_square-orange',
});

//全选checkbox
$checkboxAll.on("ifClicked", function (event) {
    if (event.target.checked) {
        $checkbox.iCheck('uncheck');
        i = 1;
    } else {
        $checkbox.iCheck('check');
        i = length;
    }
});

//监听计数
$checkbox.on('ifClicked', function (event) {
    event.target.checked ? i-- : i++;
    if (i == length + 1) {
        $checkboxAll.iCheck('check');
    } else {
        $checkboxAll.iCheck('uncheck');
    }
});
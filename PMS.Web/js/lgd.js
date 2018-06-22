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
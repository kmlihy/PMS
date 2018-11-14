// 点击切换验证码
function refreshCode() {
    var code = document.getElementById("code");
    code.src = "checkCode.aspx?id=" + Math.random();
}

$(document).ready(function () {

    //配置
    var config = {
        vx: 4,	//小球x轴速度,正为右，负为左
        vy: 4,	//小球y轴速度
        height: 2,	//小球高宽，其实为正方形，所以不宜太大
        width: 2,
        count: 60,		//点个数
        color: "255, 251, 240", 	//点颜色
        stroke: "255, 251, 240", 		//线条颜色
        dist: 6000, 	//点吸附距离
        e_dist: 20000, 	//鼠标吸附加速距离
        max_conn: 10 	//点到点最大连接数
    }
    CanvasParticle(config);

    $(function () {
        $("#okMessage").hide();
        $("html").height($(window).height());
    })
    //学生，教师登陆页面提交
    $("#btnSubmit").click(function () {
        var pubKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCAnNXR7lHTpPH/97QOxIp+UusK9/RH5elvEPv6ssL37xGo8vQHh7CCsOonUWWVdi1iVegi7fRCkWeUVlta61EuX141+eKnZcdJe81NeUZ1h3N77JbzElbhhi8Wln6U27xpfkskKASLhQ4dS9DqoJQN/YUhBaBpER287Wjf3X6WmQIDAQAB";
        var encrypt = new JSEncrypt();
        encrypt.setPublicKey(pubKey);

        var userName = $("#userName").val();
        var pwd = encrypt.encrypt($("#pwd").val());
        var captcha = $("#captcha").val();
        var type = $("input[name='user']:checked").val();
        $.ajax({
            type: 'Post',
            url: 'login.aspx',
            data: {
                userName: userName,
                pwd: pwd,
                captcha: captcha,
                type: type,
                op: "login"
            },
            dataType: 'text',
            success: function (succ) {
                if (succ === "登录成功") {
                    window.location.href = "/admin/main.aspx";
                } else if (succ == "管理员") {
                    window.wxc.xcConfirm("管理员请前往管理员登陆页面", window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            window.location.href = "admin/login.aspx";
                        }
                    });
                }
                else {
                    window.wxc.xcConfirm("登录失败", window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            window.location.href = "login.aspx";
                        }
                    });
                }
            }
        });
    })
    //管理员登陆页面提交
    $("#btnlogin").click(function () {
        var pubKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCAnNXR7lHTpPH/97QOxIp+UusK9/RH5elvEPv6ssL37xGo8vQHh7CCsOonUWWVdi1iVegi7fRCkWeUVlta61EuX141+eKnZcdJe81NeUZ1h3N77JbzElbhhi8Wln6U27xpfkskKASLhQ4dS9DqoJQN/YUhBaBpER287Wjf3X6WmQIDAQAB";
        var encrypt = new JSEncrypt();
        encrypt.setPublicKey(pubKey);
        var userName = $("#userName").val();
        var pwd = encrypt.encrypt($("#pwd").val());
        $.ajax({
            type: 'Post',
            url: 'login.aspx',
            data: {
                userName: userName,
                pwd: pwd,
                op: 'login'
            },
            datatype: 'text',
            success: function (succ) {
                if (succ === "登录成功") {
                    window.location.href = "/admin/main.aspx";
                } else {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            window.location.href = "/admin/login.aspx";
                        }
                    });
                }
            }
        });
    })
    // 页面重置
    function formReset() {
        $("#form")[0].reset()
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

    function ok(userType) {
        var telNum = $(".telNum").val();
        var email = $(".email").val();
        $.ajax({
            type: 'get',
            url: userType + 'Center.aspx?op=update',
            datatype: 'text',
            data: {
                phone: telNum,
                Email: email,
            },
            success: function (data) {
                alert(data);
            },
            error: function () {

            }
        });
        if (telNum === "") {
            $("#telNum").closest("td").text("");
        } else {
            $("#telNum").closest("td").text(telNum);
        }
        if (email === "") {
            $("#email").closest("td").text("");
        } else {
            $("#email").closest("td").text(email);
        }
        $("#okMessage").hide();
        $("#editMessage").show();
    }
})
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

    //正则表达式
    var txtAccount = /^[0-9]*$/; //数字的正则表达式
    var txtpwd = /^[\x21-\x7E]{6,20}$/;//英文、数字或符号且长度在6-20之间
    var txtEmail = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/; //邮箱的正则表达式
    var txtPwd = /^[0-9a-zA-Z_]{1,}$/; //数字、英文、下划线的正则表达式

    $("#sumbit").click(function () {
        var account = $("#account").val();
        var pwd = $("#newpwd").val();
        var confirmPwd = $("#confirmPwd").val();
        var email = $("#email").val();
        var code = $("#code").val();
        var user = $("input[name='user']:checked").val();
        $('#validateAcoount').text("");
        $('#validateEmail').text("");
        $('#validateCode').text("");
        $('#validatePwd').text("");
        $('#validateConfirmPwd').text("");
        if (account === "") {
            $("#validateAcoount").html("账号不能为空！").css({ "color": "red", "font-size": "14px" });
        } else if (!txtAccount.test(account)) {
            $("#validateAccount").html("账号只能包括数字！").css({ "color": "red", "font-size": "14px" });
        } else if (email === "") {
            $("#validateEmail").html("邮箱不能为空！").css({ "color": "red", "font-size": "14px" });
        } else if (!txtEmail.test(email)) {
            $("#validateEmail").html("邮箱地址不合法").css({ "color": "red", "font-size": "14px" });
        } else if (code === "") {
            $("#validateCode").html("验证码不能为空！").css({ "color": "red", "font-size": "14px" });
        } else if (pwd === "") {
            $("#validatePwd").html("请输入密码！").css({ "color": "red", "font-size": "14px" });
        } else if (!txtpwd.test(pwd)) {
            $("#validateConfirmPwd").html("密码只能由字母、数字、下划线组成且长度为6-20位！").css({ "color": "red", "font-size": "14px" });
        } else if (confirmPwd === "") {
            $("#validateConfirmPwd").html("请输入确认密码！").css({ "color": "red", "font-size": "14px" });
        } else if (confirmPwd !== pwd) {
            $("#validateConfirmPwd").html("两次输入的密码不一致！").css({ "color": "red", "font-size": "14px" });
        } else if (code === "") {
            $("#validateCode").html("验证码不能为空！").css({ "color": "red", "font-size": "14px" });
        }
        else {
            $("#validateCode").html("");
            $.ajax({
                type: 'Post',
                url: 'RetrievePwd.aspx',
                data: {
                    account: account,
                    email: email,
                    code: code,
                    pwd: pwd,
                    user: user,
                    op: "change"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "修改成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                top.location = "../login.aspx";
                            }
                        });
                    } else {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                                //window.location.href = "reg.aspx";
                            }
                        });
                    }
                }
            });
        }
    })

    $("#getcode").click(function () {
        var code = $("#code").val();
        var email = $("#email").val()
        var send = "send";

        var disabled = $("#getcode").attr("disabled");
        if (disabled) {
            return false;
        }
        if (email == "" || email == null) {
            window.wxc.xcConfirm("请填写正确的邮箱", window.wxc.xcConfirm.typeEnum.error);
            return false;
        }
        $.ajax({
            type: 'Post',
            url: 'RetrievePwd.aspx',
            data: {
                email: email,
                op: send
            },
            dataType: 'text',
            success: function (succ) {
                if (succ === "验证码已发送至邮箱") {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            settime();
                        }
                    });
                } else {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                        onOk: function (v) {
                            //window.location.href = "reg.aspx";
                        }
                    });
                }
            }
        });

        var countdown = 5;
        var _generate_code = $("#getcode");
        function settime() {
            if (countdown == 0) {
                _generate_code.attr("disabled", false);
                _generate_code.html("获取验证码");
                countdown = 5;
                return false;
            } else {
                $("#getcode").attr("disabled", true);
                _generate_code.html("重新发送(" + countdown + ")");
                countdown--;
            }
            setTimeout(function () {
                settime();
            }, 1000);
        }
    })
})
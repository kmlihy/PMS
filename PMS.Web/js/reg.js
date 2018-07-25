$(document).ready(function () {
    //$("#regCode").width($("#telNum").width()-92);
    //正则表达式
    var txtAccount = /^[0-9]*$/; //数字的正则表达式
    var txtName = /^[a-zA-Z\u4e00-\u9fa5]+$/; //汉字、英文的正则表达式
    var txtpwd = /^[\x21-\x7E]{6,20}$/;//英文、数字或符号且长度在6-20之间
    var txtEmail = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/; //邮箱的正则表达式
    var TelNum = /^1[3,5,4,7,8]\d{9}$/; //联系电话的正则表达式
    var txtPwd = /^[0-9a-zA-Z_]{1,}$/; //数字、英文、下划线的正则表达式
    var flag = false;
    $("#college").change(function () {
        var collegeId = $("#college").val();
        window.location.href = "reg.aspx?collegeId=" + collegeId + "&op=load";
    });

    $("#btnAdd").click(function () {
        var collegeId = $("#college").val();
        var profession = $("#profession").val();
        var account = $("#account").val();
        var name = $("#name").val();
        var sex = $('input:radio:checked').val();
        var pwd = $("#regPwd").val();
        var confirmPwd = $("#confirmPwd").val();
        var email = $("#email").val();
        var phone = $("#telNum").val();
        //var code = $("#regCode").val();
        //alert(collegeId+":"+profession+":"+account+":"+name+":"+sex+":"+pwd+":"+confirmPwd+":"+email+":"+telNum+":"+code)
        if (collegeId === "") {
            $("#validateColl").html("请选择学院！").css({ "color": "red", "font-size": "14px"});
        } else if (profession === "") {
            $("#validateColl").html("");
            $("#validatePro").html("请选择专业！").css({ "color": "red", "font-size": "14px" });
        } else if (account === "") {
            $("#validatePro").html("");
            $("#validateAcoount").html("账号不能为空！").css({ "color": "red", "font-size": "14px" });
        } else if (!txtAccount.test(account)) {
            $("#validateAccount").html("账号只能包括数字！").css({ "color": "red", "font-size": "14px" });
        } else if (name === "") {
            $("#validateAcoount").html("")
            $("#validateName").html("姓名不能为空！").css({ "color": "red", "font-size": "14px" });
        } else if (!txtName.test(name)) {
            $("#validateName").html("姓名只能包括汉子/英文字符！").css({ "color": "red", "font-size": "14px" });
        } else if (sex === "") {
            $("#validateName").html("")
            $("#validateSex").html("请选择性别！").css({ "color": "red", "font-size": "14px" });
        } else if (pwd === "") {
            $("#validateName").html("")
            $("#validatePwd").html("请输入密码！").css({ "color": "red", "font-size": "14px" });
        } else if (!txtpwd.test(pwd)) {
            $("#validateConfirmPwd").html("密码只能由字母、数字、下划线组成且长度为6-20位！").css({ "color": "red", "font-size": "14px" });
        } else if (confirmPwd === "") {
            $("#validatePwd").html("")
            $("#validateConfirmPwd").html("请输入确认密码！").css({ "color": "red", "font-size": "14px" });
        } else if (confirmPwd !== pwd) {
            $("#validateConfirmPwd").html("两次输入的密码不一致！").css({ "color": "red", "font-size": "14px" });
        } else if (email === "") {
            $("#validateConfirmPwd").html("")
            $("#validateEmail").html("邮箱不能为空！").css({ "color": "red", "font-size": "14px" });
        } else if (!txtEmail.test(email)) {
            $("#validateEmail").html("邮箱地址不合法").css({ "color": "red", "font-size": "14px" });
        } else if (phone === "") {
            $("#validateEmail").html("")
            $("#validateTel").html("联系电话不能为空！").css({ "color": "red", "font-size": "14px" });
        } else if (!TelNum.test(phone)) {
            $("#validateTel").html("联系电话不合法！").css({ "color": "red", "font-size": "14px" });
        }
        //else if (code === "") {
        //    $("#validateCode").html("验证码不能为空！").css({ "color": "red", "font-size": "14px" });
        //}
        //TODO 获取发送的验证码
        //else if (code !== "123") {
        //    $("#validateCode").html("验证码错误！").css("color", "red");
        //}
        else {
            $("#validateCode").html("");
            $.ajax({
                type: 'Post',
                url: 'reg.aspx',
                data: {
                    collegeId: collegeId,
                    profession: profession,
                    account: account,
                    name: name,
                    sex: sex,
                    pwd: pwd,
                    email: email,
                    phone: phone,
                    op: "add"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "注册成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                window.location.href = "login.aspx";
                            }
                        });
                    } else {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                                //window.location.href = "login.aspx";
                            }
                        });
                    }
                }
            });
        }
    })
})
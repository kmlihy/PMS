$(document).ready(function () {
    //jQuery.validate验证
    //$("#changePwdForm").validate({
    //    onfocusout: function (element) { $(element).valid(); },
    //    rules: {
    //        quondampwd: {
    //            required: true,
    //            minlength: 6
    //        },
    //        newpwd: {
    //            required: true,
    //            minlength: 6
    //        },
    //        confirmPwd: {
    //            required: true,
    //            minlength: 6,
    //            equalTo: "#newpwd"
    //        }
    //    },
    //    messages:{
    //        quondampwd: {
    //            required: "请输入密码",
    //            minlength:"密码长度不能小于5个数"
    //        },
    //        newpwd: {
    //            required: "请输入密码",
    //            minlength: "密码长度不能小于5个数"
    //        },
    //        confirmPwd: {
    //            required: "请输入密码",
    //            minlength: "密码长度不能小于5个数",
    //            equalTo:"两次输入的密码不一致"
    //        },
    //    }
    //})

    //validate验证函数
    function validate() {
        return $("#changePwdForm").validate({
            onfocusout: function (element) { $(element).valid(); },
            rules: {
                quondampwd: {
                    required: true,
                    minlength: 6
                },
                newpwd: {
                    required: true,
                    minlength: 6
                },
                confirmPwd: {
                    required: true,
                    minlength: 6,
                    equalTo: "#newpwd"
                }
            },
            messages:{
                quondampwd: {
                    required: "请输入密码",
                    minlength:"密码长度不能小于5个数"
                },
                newpwd: {
                    required: "请输入密码",
                    minlength: "密码长度不能小于5个数"
                },
                confirmPwd: {
                    required: "请输入密码",
                    minlength: "密码长度不能小于5个数",
                    equalTo:"两次输入的密码不一致"
                },
            }
        })
    }
    $(validate()).ready();
    var state = $("#state").val();
    //修改密码功能实现（Ajax传值）
    $("#postPwd").click(function () {
        var pubKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCAnNXR7lHTpPH/97QOxIp+UusK9/RH5elvEPv6ssL37xGo8vQHh7CCsOonUWWVdi1iVegi7fRCkWeUVlta61EuX141+eKnZcdJe81NeUZ1h3N77JbzElbhhi8Wln6U27xpfkskKASLhQ4dS9DqoJQN/YUhBaBpER287Wjf3X6WmQIDAQAB";
        var encrypt = new JSEncrypt();
        encrypt.setPublicKey(pubKey);

        if (validate().form()) {//点击按钮时调用验证函数再次验证
            var oldPwd = $("#quondampwd").val();
            var newPwd = $("#newpwd").val();
            var confirmPwd = $("#confirmPwd").val();
            if (oldPwd != "" && newPwd != "" && confirmPwd != "") {
                $.ajax({
                    type: 'Post',
                    url: 'changePwd.aspx',
                    data: {
                        old: encrypt.encrypt(oldPwd),
                        newP: encrypt.encrypt(newPwd),
                        type: 'change',
                    },
                    dataType: 'text',
                    success: function (succ) {
                        if (succ == "更新成功") {
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                                onOk: function (v) {
                                    //window.close();
                                    //history.back();
                                    if (state == "0" || state == "2") {
                                        top.location = "login.aspx";
                                    }
                                    else if (state == "1" || state == "3") {
                                        top.location = "../login.aspx";
                                    }
                                }
                            });
                        } else if (succ == "更新失败") {
                            //alert("更新失败");
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                                onOk: function () {
                                    window.location = "changePwd.aspx";
                                }
                            });
                        }
                    }
                })
            }
        }
        else{}
    })
    //修改密码功能实现（SessionStorage传值）
    //var oldPwd = $("#quondampwd").val();
    //sessionStorage.setItem("oldPwd", oldPwd);
    //var newPwd = $("#newpwd").val();
    //sessionStorage.setItem("newPwd", newPwd);
    //var confirmPwd = $("#confirmPwd").val();
    //alert(sessionStorage.getItem("oldPwd"));
    //if (newPwd == confirmPwd) {
    //    sessionStorage.setItem("type","change")
    //    jump(sessionStorage.getItem("oldPwd"), sessionStorage.getItem("newPwd"));
    //}
    //else {
    //    alert("两次输入的密码不一样");
    //}
    //function jump(oldpwd, newpwd) {
    //    window.location.href = "changePwd.aspx?oldPwd=" + sessionStorage.getItem("oldPwd") + "&newPwd=" + sessionStorage.getItem("newPwd") + "&type=" + sessionStorage.getItem("type");
    //}
})
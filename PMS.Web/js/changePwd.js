$(document).ready(function () {
    var oldPwd = $("#quondampwd").val(),
        confirmPwd = $("#confirmPwd").val(),
        newPwd = $("#newpwd").val();
    //提交密码
    $("#postPwd").click(function () {
        if (oldPwd == confirmPwd) {
            $.ajax({
                url: "changePwd.aspx",
                data: {
                    oldPwd: oldPwd,
                    newPwd: newPwd,
                    op: "password"
                },
                type: 'Post',
                dataType: 'text',
                success: function (succ) {
                    if (succ == "更新成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                jump(1);
                            }
                        });
                    } else {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                                jump(1);
                            }
                        });
                    }
                }
            })
        }
        else {
            alert("两次输入的密码不一样！");
        }
    })
    function jump(change) {
        window.location.href = "changePwd.aspx?oldPwd=" + oldPwd + "&newPwd=" + newPwd;
    }
})
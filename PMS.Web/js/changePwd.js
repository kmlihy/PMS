$(document).ready(function () {
    $("#postPwd").click(function () {
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
        var oldPwd = $("#quondampwd").val();
        var newPwd = $("#newpwd").val();
        $.ajax({
            type: 'Post',
            url: 'changePwd.aspx',
            data: {
                old: oldPwd,
                newP: newPwd,
                type:'change',
            },
            dataType: 'text',
            success: function (succ) {
            //    if (succ == "更新成功") {
            //        alert("密码修改成功");
            //    } else {
            //        alert("密码修改失败");
                //    }
                if (succ == "更新成功") {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            //window.close();
                            //history.back();
                            //sessionStorage.clear();
                            top.location = "login.aspx";
                        }
                    });
                } else {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                        onOk: function () {
                            window.location = "changePwd.aspx";
                        }
                    });
                }
            }
        })
    })
    //function jump(type) {
    //    var type = "change";
    //    var oldPwd = $("#quondampwd").val();
    //    var newPwd = $("#newpwd").val();
    //    window.location.href = "changePwd.aspx?oldPwd=" + oldPwd + "&newPwd=" + newPwd + "&type=" + type;
    //}
    //function jump(oldpwd, newpwd) {
    //    window.location.href = "changePwd.aspx?oldPwd=" + sessionStorage.getItem("oldPwd") + "&newPwd=" + sessionStorage.getItem("newPwd") + "&type=" + sessionStorage.getItem("type");
    //}
})
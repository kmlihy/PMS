$(document).ready(function () {
    //判断当教师或者管理员查看题目信息时，对选定题目按钮进行隐藏
    var userState = $("#loginUser").val().trim();
    if (userState === "1" || userState === "0" || userState === "2") {
        $("#btn_ToPaperDtailStu").hide();
    }
    else {
        $("#btn_ToPaperDtailStu").show();
    }
    $(".selectTitle").click(function () {
        var txt = "是否确认选定该题目？";
        var titleid = $("#titleId").val();
        var option = {
            title: "提示",
            btn: parseInt("0011", 2),
            onOk: function () {
                $.ajax({
                    type: 'Post',
                    url: 'paperDetail.aspx?titleId=' + titleid + "&op=selectTitle",
                    success: function (succ) {
                        if (succ === "选题成功") {
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                                onOk: function (v) {
                                    window.location.href = "PaperDtailStu.aspx?titleId=" + titleid;
                                }
                            });
                        }
                        else if (succ === "已选题") {
                            window.wxc.xcConfirm("您已经选过题目，不能多次选题!", window.wxc.xcConfirm.typeEnum.error);
                        }
                    }
                });
            }
        }
        window.wxc.xcConfirm(txt, "confirm", option);
    })
})
$("#btnSubmit").click(function () {
    var guide = parseFloat($("#guide").val());
    var cross = parseFloat($("#cross").val());
    var defence = parseFloat($("#defence").val());
    var excellent = parseFloat($("#excellent").val());
    if ((guide + cross + defence) != 100) {
        window.wxc.xcConfirm("总和不能小于或大于100", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (excellent<=0) {
        window.wxc.xcConfirm("优秀论文成绩下限不能低于0", window.wxc.xcConfirm.typeEnum.warning);
    }
    else {
        $.ajax({
            type: 'Post',
            url: 'scoreRatio.aspx',
            data: {
                guide: guide,
                cross: cross,
                defence: defence,
                excellent: excellent,
                op: "submit"
            },
            dataType: 'text',
            success: function (succ) {
                if (succ === "更新成功") {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            window.location.href = "scoreRatio.aspx";
                        }
                    });
                }
                else {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                        onOk: function (v) {
                        }
                    });
                }
            }
        });
    }
    
})
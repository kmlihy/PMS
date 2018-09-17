$("#btnSubmit").click(function () {
    var guide = $("#guide").val();
    var cross = $("#cross").val();
    var defence = $("#defence").val();
    var excellent = $("#excellent").val();
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
            if (succ === "添加成功") {
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
})
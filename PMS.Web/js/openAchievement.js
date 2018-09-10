$(document).ready(function () {
    $("#openBtn").click(function () {
        window.wxc.xcConfirm("确定开放成绩么？", window.wxc.xcConfirm.typeEnum.confirm, {
            onOk: function (v) {
                $.ajax({
                    type: 'Post',
                    url: 'openAchievement.aspx',
                    data: {
                        op: "open"
                    },
                    dataType: 'text',
                    success: function (succ) {
                        if (succ === "开放成功") {
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
      
                            });
                        } else {
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {

                            });
                        }
                    }
                });
            }
        });
    })
})
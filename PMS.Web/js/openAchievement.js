$(document).ready(function () {
    $('input').lc_switch();
    $('body').delegate('.lcs_check', 'lcs-statuschange', function () {
        var status = ($(this).is(':checked')) ? 'checked' : 'unchecked';
        //status 当前的状态，对应状态 on off  'checked' : 'unchecked';
        //autocomplete="off"  默认为关
        // 加上 disabled="disabled"不可再改变状态
        if (status == "checked") {
            $.ajax({
                type: 'Post',
                url: 'openAchievement.aspx',
                data: {
                    op: "open"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "成绩已开放") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {

                        });
                    } else {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {

                        });
                    }
                }
            });
        }
        else {
            $.ajax({
                type: 'Post',
                url: 'openAchievement.aspx',
                data: {
                    op: "close"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "成绩已关闭查询") {
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
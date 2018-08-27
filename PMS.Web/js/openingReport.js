$(document).ready(function () {
    $(btnSubmit).click(function () {
        var meaning = $("#meaning").text();
        var trend = $("#trend").text();
        var content = $("#content").text();
        var plan = $("#plan").text();
        var method = $("#method").text();
        var outline = $("#outline").text();
        var reference = $("#reference").text();
        var guideTeacher = $("#guideTeacher").text();
        var dean = $("#dean").text();
        if (meaning == "") {
            alert("有未填项目");
        }
        if (trend == "") {
            alert("有未填项目");
        }
        if (content == "") {
            alert("有未填项目");
        }
        if (plan == "") {
            alert("有未填项目");
        }
        if (method == "") {
            alert("有未填项目");
        }
        if (outline == "") {
            alert("有未填项目");
        }
        if (reference == "") {
            alert("有未填项目");
        }
        $.ajax({
            type: 'Post',
            url: 'openingReport.aspx',
            data: {
                meaning: meaning,
                trend: trend,
                content: content,
                plan: plan,
                method: method,
                outline: outline,
                reference: reference,
                guideTeacher: guideTeacher,
                dean: dean,
                op: "insert"
            },
            dataType: 'text',
            success: function (succ) {
                if (succ === "提交成功") {
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
    })
})
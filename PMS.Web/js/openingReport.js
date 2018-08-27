$(document).ready(function () {
    $("#btnTeaOpinion").hide();
    $(btnSubmit).click(function () {
        var meaning = $("#meaning").val();
        var trend = $("#trend").val();
        var content = $("#content").val();
        var plan = $("#plan").val();
        var method = $("#method").val();
        var outline = $("#outline").val();
        var reference = $("#reference").val();
        //var guideTeacher = $("#guideTeacher").val();
        //var dean = $("#dean").val();
        if (meaning == "") {
            alert("有未填项目");
        }
        else if (trend == "") {
            alert("有未填项目");
        }
        else if (content == "") {
            alert("有未填项目");
        }
        else if (plan == "") {
            alert("有未填项目");
        }
        else if (method == "") {
            alert("有未填项目");
        }
        else if (outline == "") {
            alert("有未填项目");
        }
        else if (reference == "") {
            alert("有未填项目");
        }
        else {
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
                    //guideTeacher: guideTeacher,
                    //dean: dean,
                    op: "insert"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "提交成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                document.getElementById("meaning").readOnly;
                                document.getElementById("trend").readOnly;
                                document.getElementById("content").readOnly;
                                document.getElementById("plan").readOnly;
                                document.getElementById("method").readOnly;
                                document.getElementById("outline").readOnly;
                                document.getElementById("reference").readOnly;
                                $("#btnTeaOpinion").show();
                                $("#btnSubmit").hide();
                            }
                        });
                    } else {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                            }
                        });
                    }
                }
            })
        }
    })
})
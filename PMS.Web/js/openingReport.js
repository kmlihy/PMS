$(document).ready(function () {
    $("#btnTeaOpinion").hide();
    $("#btnSubmit").click(function () {
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
                    op: "add"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "提交成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                document.getElementById("meaning").readOnly = true;
                                document.getElementById("trend").readOnly = true;
                                document.getElementById("content").readOnly = true;
                                document.getElementById("plan").readOnly = true;
                                document.getElementById("method").readOnly = true;
                                document.getElementById("outline").readOnly = true;
                                document.getElementById("reference").readOnly = true;
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
    $("#btnReviewSubmit").click(function () {
        var teacherOpinion = $("#guideTeacher").val();
        $.ajax({
            type: 'Post',
            url: 'reviewOpeningReport.aspx',
            data:{
                teacherOpinion: teacherOpinion,
                op:"review"
            },
            dataType: 'text',
            success: function (succ) {
                if (succ === "提交成功") {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {

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
    })
})
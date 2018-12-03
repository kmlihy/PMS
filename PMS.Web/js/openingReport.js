$(document).ready(function () {
    //学生提交开题报告
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
            window.wxc.xcConfirm("确定提交吗？", window.wxc.xcConfirm.typeEnum.confirm, {
                onOk: function (v) {
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
                                        window.location.href = "openingReport.aspx";
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
            });
        }
    })
    //教师驳回学生开题报告
    $("#btnOpinion").click(function () {
        window.wxc.xcConfirm("确定驳回吗？", window.wxc.xcConfirm.typeEnum.confirm, {
            onOk: function (v) {
                var teacherOpinion = $("#guideTeacher").val();
                var deanOpinion = $("#dean").val();
                var stuAccount = $("#stuAccount").text().trim();
                $.ajax({
                    type: 'Post',
                    url: 'reviewOpeningReport.aspx?stuAccount=' + stuAccount,
                    data: {
                        teacherOpinion: teacherOpinion,
                        deanOpinion: deanOpinion,
                        op: "no"
                    },
                    dataType: 'text',
                    success: function (succ) {
                        if (succ === "提交成功") {
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                                onOk: function (v) {
                                    window.location.href = "reviewOpeningReport.aspx";
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
        });
    })
    //教师同意学生开题报告
    $("#btnReviewSubmit").click(function () {
        window.wxc.xcConfirm("确定同意吗？", window.wxc.xcConfirm.typeEnum.confirm, {
            onOk: function (v) {
                var teacherOpinion = $("#guideTeacher").val();
                var deanOpinion = $("#dean").val();
                var stuAccount = $("#stuAccount").text().trim();
                $.ajax({
                    type: 'Post',
                    url: 'reviewOpeningReport.aspx?stuAccount=' + stuAccount,
                    data: {
                        teacherOpinion: teacherOpinion,
                        deanOpinion: deanOpinion,
                        op: "yes"
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
            }
        });
        
    })
})
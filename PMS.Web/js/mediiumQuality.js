﻿$(document).ready(function () {
    $("#btnSubmit").click(function () {
        var student = $("#stuSet").val();
        var teacher = $("#teaSet").val();
        var group = $("#groupSet").val();
        if (student != "" && teacher == null) {
            $.ajax({
                type: 'Post',
                url: "mediiumQuality.aspx",
                data: {
                    student: student,
                    op: "student"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "提交成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
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
        } else if (teacher != "" && student == null) {
            $.ajax({
                type: 'Post',
                url: "mediiumQuality.aspx",
                data: {
                    teacher: teacher,
                    op: "teacher"
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
    })
})
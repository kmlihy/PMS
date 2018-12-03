$(document).ready(function () {
    $("#btnSubmit").click(function () {
        window.wxc.xcConfirm("确定提交吗？", window.wxc.xcConfirm.typeEnum.confirm, {
            onOk: function (v) {
                var student = $("#stuSet").val();
                var teacher = $("#teaSet").val();
                var group = $("#groupSet").val();
                if (student != "" && teacher == undefined) {
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
                                        $("#stuSet").readOnly = true;
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
                } else if (teacher != "" && student == undefined) {
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
                                        $("#teaSet").readOnly = true;
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
            }
        });
    })
})
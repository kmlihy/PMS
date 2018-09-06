$("#btnSubmit").click(function () {
    var submit = "submit";
    var txtAreReportContent = $("#txtAreReportContent").val();
    var txtAreReportTime = $("#txtAreReportTime").val();
    var txtAreDefence = $("#txtAreDefence").val();
    var textAreInnovate = $("#textAreInnovate").val();
    var txtAreDefenceScore = $("#txtAreDefenceScore").val();
    if (txtAreDefenceScore == "") {
        window.wxc.xcConfirm("成绩不能为空", window.wxc.xcConfirm.typeEnum.warning);
    } else if (txtAreDefenceScore < 0) {
        window.wxc.xcConfirm("成绩不能小于0", window.wxc.xcConfirm.typeEnum.warning);
    } else if (txtAreDefenceScore > 100) {
        window.wxc.xcConfirm("成绩不能大于100", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (txtAreReportContent == "" || txtAreReportTime == "" || txtAreDefence == "" || textAreInnovate == "") {
        window.wxc.xcConfirm("还有其他未填项", window.wxc.xcConfirm.typeEnum.warning);
    } else {
        $.ajax({
            type: 'Post',
            url: 'replyPanelsOpinion.aspx',
            data: {
                ReportContent: txtAreReportContent,
                ReportTime: txtAreReportTime,
                Defence: txtAreDefence,
                Innovate: textAreInnovate,
                DefenceScore: txtAreDefenceScore,
                op: submit
            },
            dataType: 'text',
            success: function (succ) {
                if (succ === "添加成功") {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            //alert("添加成功");
                        }
                    });
                } else {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                        onOk: function (v) {
                            //alert("添加失败");
                        }
                    });
                }
            }
        });
    }
});
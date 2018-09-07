var tips = $("#scoretips");
var score = $("#defensescore");
$(document).ready(function () {
    tips.hide();
})
$("#defensescore").change(function () {
    if (score.val() == "") {
        
    }
    else if (score.val() > 100) {
        window.wxc.xcConfirm("分数应在0-100内", window.wxc.xcConfirm.typeEnum.warning);
        score.val("  ");
        score.select();
    } else {
        score.hide();
        tips.show();
        tips.text(score.val())
    }
})
function rescore() {
    score.show();
    tips.hide();
    score.val(tips.text());
    score.focus();
}
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
                if (succ === "提交成功") {
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
var tips = $("#scoretips");
var score = $("#defensescore");
$(document).ready(function () {
    tips.hide();
})
$("#defensescore").change(function () {
    if (score.val().trim() == "" || score.val().trim() == "0") {
        window.wxc.xcConfirm("请输入分数", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (score.val().trim() > 100 || score.val().trim() < 1) {
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
$("#scorebtnSubmit").click(function () {
    var score = $("#score").val();
    var investigation = $("#investigation").val();
    var practice = $("#practice").val();
    var solveProblem = $("#solveProblem").val();
    var workAttitude = $("#workAttitude").val();
    var quality = $("#quality").val();
    var innovate = $("#innovate").val();
    var evaluate = $("#evaluate").val();
    var crossTea = $("#crossTea").val();
    if (score == "") {
        window.wxc.xcConfirm("成绩不能为空", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (score < 0) {
        window.wxc.xcConfirm("成绩不能小于0", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (score > 100) {
        window.wxc.xcConfirm("成绩不能大于100", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (investigation == "" || practice == "" || solveProblem == "" || workAttitude == "" || quality == "" || innovate == "") {
        window.wxc.xcConfirm("还有其他未填项", window.wxc.xcConfirm.typeEnum.warning);
    }
    else {
        $.ajax({
            type: 'Post',
            url: 'InstructorsComments.aspx',
            data: {
                score: score,
                investigation: investigation,
                practice: practice,
                solveProblem: solveProblem,
                workAttitude: workAttitude,
                quality: quality,
                evaluate: evaluate,
                innovate: innovate,
                crossTea: crossTea,
                op: "submit"
            },
            dataType: 'text',
            success: function (succ) {
                if (succ == "提交成功") {
                    window.wxc.xcConfirm("添加成功", window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            window.location.href = "downLoadPaper.aspx";
                        }
                    });
                }
                else {
                    window.wxc.xcConfirm("添加失败", window.wxc.xcConfirm.typeEnum.error);
                }
            }
        });
    }
});
$("#btnSubmit").click(function () {
    var op = "submit";
    var score = $("#score").val();
    var investigation = $("#investigation").val();
    var practice = $("#practice").val();
    var solveProblem = $("#solveProblem").val();
    var workAttitude = $("#workAttitude").val();
    var quality = $("#quality").val();
    var innovate = $("#innovate").val();
    var evaluate = $("#evaluate").val();
    if (score == "") {
        window.wxc.xcConfirm("成绩不能为空", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (score < 0){
        window.wxc.xcConfirm("成绩不能小于0", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (score > 100) {
        window.wxc.xcConfirm("成绩不能大于100", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (investigation == "" || practice == "" || solveProblem == "" || workAttitude == "" || quality == "" || innovate=="") {
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
                op: op
            },
            dataType: 'text',
            success: function (succ) {
                if (succ == "提交成功") {
                    window.wxc.xcConfirm("添加成功", window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                           
                        }
                    });
                }
                else {
                    window.wxc.xcConfirm("添加成功", window.wxc.xcConfirm.typeEnum.error, {
                        onOk: function (v) {
                            
                        }
                    });
                }
            }
        });
    }
});
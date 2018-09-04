$("#btnSubmit").click(function () {
    var op = "submit";
    var score = $("#score").val();
    var investigation = $("#investigation").val();
    var practice = $("#practice").val();
    var solveProblem = $("#solveProblem").val();
    var workAttitude = $("#workAttitude").val();
    var quality = $("#quality").val();
    var innovate = $("#innovate").val();

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
            op: op
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
    })
});
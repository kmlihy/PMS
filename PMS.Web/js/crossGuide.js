$(document).ready(function () {
    $("#btnSubmit").css("magin-top", "10px");
    $("#btnSubmit").click(function () {
        var material = $("#tdata").val();
        var quality = $("#tquality").val();
        var workload = $("#tworkload").val(); 
        var innovate = $("#tinnovate").val();
        var score = $("#score").val();
        var evaluate = $("#evaluate").val();
        var assess = data + "|;" + quality + "|;" + workload + "|;" + innovate;
        $.ajax({
            type: 'Post',
            url: 'crossGuide.aspx',
            data: {
                score: score,
                material: material,
                quality: quality,
                workload: workload,
                innovate: innovate,
                evaluate: evaluate,
                op:"add"
            },
            dataType: 'text',
            success: function (succ) {
                if (succ == "提交成功") {
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
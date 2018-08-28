$(document).ready(function () {
    $("#btnSubmit").css("magin-top", "10px");
    $("#btnSubmit").click(function () {
        var data = $("#data").text().trim() + "|," + $("#tdata").val();
        var quality = $("#quality").text().trim() + "|," + $("#tquality").val();
        var workload = $("#workload").text().trim() + "|," + $("#tworkload").val(); 
        var innovate = $("#innovate").text().trim() + "|," + $("#tinnovate").val();
        var score = $("#score").val();
        var evaluate = $("#evaluate").val();
        var assess = data + "|;" + quality + "|;" + workload + "|;" + innovate;
        $.ajax({
            type: 'Post',
            url: 'crossGuide.aspx',
            data: {
                score: score,
                assess: assess,
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
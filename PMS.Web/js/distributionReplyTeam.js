$(document).ready(function () {
    $("#leader").change(function () {
        var leader = $("#leader option:selected").val();
        var member = $("#member option:selected").val();
        var record = $("#record option:selected").val();
        var plan = $("#plan option:selected").val();

        window.location.href = "distributionReplyTeam.aspx?leader=" + leader + "&member=" + member + "&record=" + record + "&op=change1" + "&planId=" + plan;
    });

    $("#member").change(function () {
        var leader = $("#leader option:selected").val();
        var member = $("#member option:selected").val();
        var record = $("#record option:selected").val();
        var plan = $("#plan option:selected").val();

        window.location.href = "distributionReplyTeam.aspx?leader=" + leader + "&member=" + member + "&record=" + record + "&op=change2" + "&planId=" + plan;
    });

    $("#record").change(function () {
        var leader = $("#leader option:selected").val();
        var member = $("#member option:selected").val();
        var record = $("#record option:selected").val();
        var plan = $("#plan option:selected").val();

        window.location.href = "distributionReplyTeam.aspx?leader=" + leader + "&member=" + member + "&record=" + record + "&op=change3" + "&planId=" + plan;
    });
});

$("#confirm").click(function () {
    var leaderId = $("#leader option:selected").val();
    var memberId = $("#member option:selected").val();
    var recordId = $("#record option:selected").val();
    var planId = $("#plan option:selected").val();
    if (leaderId == "" || memberId == "" || recordId == "" || planId == "") {
        window.wxc.xcConfirm("还有未填项", window.wxc.xcConfirm.typeEnum.warning);
    }
    else {
        $.ajax({
            type: 'Post',
            url: 'distributionReplyTeam.aspx',
            data: {
                leaderId: leaderId,
                memberId: memberId,
                recordId: recordId,
                planId: planId,
                submit: "submit"
            },
            dataType: 'text',
            success: function (succ) {
                if (succ === "分配成功") {
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
    }
});

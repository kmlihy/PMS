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
//存储当前页
sessionStorage.setItem("page", $("#page").val());
//存储总页数
sessionStorage.setItem("countPage", $("#countPage").val());

$("#selectcollegeId").change(function () {
    var selectcollegeId = $("#selectcollegeId option:selected").val();
    window.location.href = "distributionReplyTeam.aspx?collegeId=" + selectcollegeId;
});
$("#chooseStuPro").change(function () {
    var selectcollegeId = $("#selectcollegeId option:selected").val();
    var planId = $("#chooseStuPro option:selected").val();
    window.location.href = "distributionReplyTeam.aspx?planId=" + planId + "&collegeId=" + selectcollegeId;
});

//按钮查询
$("#btn-search").click(function () {
    var strWhere = $("#inputsearch").val();
    sessionStorage.setItem("strWhere", strWhere);
    if (sessionStorage.getItem("dropCollegeIdstrWhere") !== null) {
        sessionStorage.removeItem("dropCollegeIdstrWhere");
    }
    if (sessionStorage.getItem("proWhere") !== null) {
        sessionStorage.removeItem("proWhere");
    }
    jump(1);
});
//分页函数
function jump(cur) {
    if (userType === "0") {
        if (sessionStorage.getItem("strWhere") !== null) {
            window.location.href = "distributionReplyStudent.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        } else if ((sessionStorage.getItem("strWhere") === null || sessionStorage.getItem("strWhere") === "") && (sessionStorage.getItem("dropCollegeIdstrWhere") != null && sessionStorage.getItem("proWhere") == null)) {
            window.location.href = "distributionReplyStudent.aspx?currentPage=" + cur + "&collegeId=" + sessionStorage.getItem("dropCollegeIdstrWhere");
        } else if ((sessionStorage.getItem("strWhere") === null || sessionStorage.getItem("strWhere") === "") && (sessionStorage.getItem("dropCollegeIdstrWhere") != null && sessionStorage.getItem("proWhere") != null)) {
            window.location.href = "distributionReplyStudent.aspx?currentPage=" + cur + "&collegeId=" + sessionStorage.getItem("dropCollegeIdstrWhere") + "&proId=" + sessionStorage.getItem("proWhere");
        } else {
            window.location.href = "distributionReplyStudent.aspx?currentPage=" + cur;
        }
    } else if (userType === "2") {
        if (sessionStorage.getItem("strWhere") !== null) {
            window.location.href = "distributionReplyStudent.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        } else if (sessionStorage.getItem("strWhere") === null || sessionStorage.getItem("strWhere") === "") {
            window.location.href = "distributionReplyStudent.aspx?currentPage=" + cur + "&proId=" + sessionStorage.getItem("proWhere");
        } else {
            window.location.href = "distributionReplyStudent.aspx?currentPage=" + cur;
        }
    }
};
//点击分页
$(".jump").click(function () {
    switch ($.trim($(this).html())) {
        case ('<span class="iconfont icon-back"></span>'):
            if (parseInt(sessionStorage.getItem("page")) > 1) {
                jump(parseInt(sessionStorage.getItem("page")) - 1);
                break;
            }
            else {
                jump(1);
                break;
            }
        case ('<span class="iconfont icon-more"></span>'):
            if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {

                jump(parseInt(sessionStorage.getItem("page")) + 1);
                break;
            }
            else {
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
            }
        case ("首页"):
            jump(1);
            break;
        case (sessionStorage.getItem("countPage")):
            jump(parseInt(sessionStorage.getItem("countPage")));
            break;
        case ("尾页"):
            jump(parseInt(sessionStorage.getItem("countPage")));
            break;
    }
});
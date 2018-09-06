//存储当前页
sessionStorage.setItem("page", $("#page").val());
//存储总页数
sessionStorage.setItem("countPage", $("#countPage").val());
//判断用户是分院管理员还是超级管理员(0)
var userType = $("#userType").val();
if (userType == 0) {
    $("#selectStudent").hide();
}
//分院下拉查询
$("#selectcollegeId").change(function () {
    var collegeId = $("#selectcollegeId").find("option:selected").val();
    sessionStorage.setItem("dropCollegeIdstrWhere", collegeId);
    if (sessionStorage.getItem("strWhere") !== null) {
        sessionStorage.removeItem("strWhere");
    }
    if (sessionStorage.getItem("proWhere") !== null) {
        sessionStorage.removeItem("proWhere");
    }
    jump(1);
})
//专业下拉选项查询
$("#chooseStuPro").change(function () {
    var collegeId = $("#chooseStuPro").find("option:selected").val();
    sessionStorage.setItem("proWhere", collegeId);
    if (sessionStorage.getItem("strWhere") !== null) {
        sessionStorage.removeItem("strWhere");
    }
    jump(1);
})
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
//添加学生到答辩小组
$("#btnSubmit").click(function () {
    var obj = document.getElementsByName('checkbox'); //选择所有name="checkbox"的对象，返回数组 
    //取到对象数组后，循环检测它是不是被选中 
    var stuAccount = '';
    for (var i = 0; i < obj.length; i++) {
        if (obj[i].checked) stuAccount += obj[i].value + '?'; //如果选中，将value添加到变量s中 
    }
    $.ajax({
        type: 'Post',
        url: 'distributionReplyStudent.aspx',
        data: {
            stuAccount: stuAccount,
            op: "add"
        },
        dataType: 'text',
        success: function (succ) {
            if (succ === "添加成功") {
                window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                    onOk: function (v) {
                        jump(1);
                    }
                });
            } else {
                window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                    onOk: function (v) {
                        jump(1);
                    }
                });
            }
        }
    });
})
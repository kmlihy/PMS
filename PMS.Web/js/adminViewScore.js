﻿//存储当前页
sessionStorage.setItem("page", $("#page").val());
//存储总页数
sessionStorage.setItem("countPage", $("#countPage").val());
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
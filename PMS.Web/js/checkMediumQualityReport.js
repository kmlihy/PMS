sessionStorage.setItem("page", $("#page").val());
sessionStorage.setItem("countPage", $("#countPage").val());
//查询按钮点击事件

function jump(cur) {
    if (sessionStorage.getItem("strWhere") == null) {
        window.location.href = "checkMediumQualityReport.aspx?currentPage=" + cur;
    }
    if (sessionStorage.getItem("strWhere") != null) {
        window.location.href = "checkMediumQualityReport.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
    }
}
$("#btn-search").click(function () {
    var strWhere = $("#inputsearch").val();
    sessionStorage.setItem("strWhere", strWhere);
    sessionStorage.setItem("type", "textSelect");
    jump(1);
});
$(document).ready(function () {
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
            case ("尾页"):
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
        }
    });
    //jump(1);
})
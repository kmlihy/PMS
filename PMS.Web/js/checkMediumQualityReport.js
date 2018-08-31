sessionStorage.setItem("page", $("#page").val());
sessionStorage.setItem("countPage", $("#countPage").val());
$(document).ready(function () {
    //分页事件
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
    //查询事件
    $("#btn_search").click(function () {
        var strWhere = $("#inputsearch").val();
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
    })
    //地址栏显示信息并传值到后台
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "checkMediumQualityReport.aspx?currentPage=" + cur;
        }
        else {
            window.location.href = "checkMediumQualityReport.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    }
})
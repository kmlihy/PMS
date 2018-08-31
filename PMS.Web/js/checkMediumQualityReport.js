sessionStorage.setItem("page", $("#page").val());
sessionStorage.setItem("countPage", $("#countPage").val());
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
            case (sessionStorage.getItem("countPage")):
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
            case ("尾页"):
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
        }
    });
    function jump(cur) {
        window.location.href = "checkMediumQualityReport.aspx?currentPage=" + cur;
    }
    //jump(1);
})
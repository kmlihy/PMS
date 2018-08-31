$(document).ready(function () {
    //分页参数传递
    var stuAccount = $("#stuAccount").val();
    var page = $("#page").val();
    sessionStorage.setItem("Page", page);
    sessionStorage.setItem("stuAccount", stuAccount);
    //存储总页数
    var countPage = $("#countPage").val();
    sessionStorage.setItem("countPage", countPage);
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
});


function jump(cur) {
    window.location.href = "stuHistoryPaper.aspx?currentPage=" + cur + "&stuAccount=" + sessionStorage.getItem("stuAccount");
};
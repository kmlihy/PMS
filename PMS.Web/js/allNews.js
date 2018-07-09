sessionStorage.setItem("page", $("#page").text().trim());
sessionStorage.setItem("countPage", $("#countPage").text().trim());
sessionStorage.setItem("newsType", $("#newsType").text().trim());
$(document).ready(function () {
    //参数标签隐藏
    $("#page").hide();
    $("#countPage").hide();
    $("#newsType").hide();
    //分页按钮点击事件
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            case ('<span class="iconfont icon-back" style="font-size: 11px;"></span>'):
                if (parseInt(sessionStorage.getItem("page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("page")) - 1);
                    break;
                }
                else {
                    jump(1);
                    break;
                }
            case ('<span class="iconfont icon-more" style="font-size: 11px;"></span>'):
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
        var newsType = $("#newsType").text().trim();
        $.ajax({
            type: 'Post',
            url: 'allNews.aspx',
            data: {
                newsType:newsType,
                newsTypeOp: "type"
            },
            dataType: 'text',
        })
    })
    function jump(cur) {
        window.location.href = "allNews.aspx?roleId=" + sessionStorage.getItem("newsType") + "&currentPage=" + cur;
    }
    //当总页数为1时，首页和尾页按钮隐藏
    if (sessionStorage.getItem("countPage") == "1") {
        $("#last").hide();
        $("#first").hide();
        $("#drop_Page").hide();
    }
})
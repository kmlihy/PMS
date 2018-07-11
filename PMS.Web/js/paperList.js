//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

$(document).ready(function () {
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            case ('<span class="glyphicon glyphicon-chevron-left"></span>'):
                if (parseInt(sessionStorage.getItem("Page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("Page")) - 1);
                    break;
                }
                else {
                    jump(1);
                    break;
                }

            case ('<span class="glyphicon glyphicon-chevron-right"></span>'):
                if (parseInt(sessionStorage.getItem("Page")) < parseInt(sessionStorage.getItem("countPage"))) {
                    jump(parseInt(sessionStorage.getItem("Page")) + 1);
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
    $("#btn-search").click(function () {
        var strWhere = $("#inputsearch").val();
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
    });
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "paperList.aspx?currentPage=" + cur;
        } else {
            window.location.href = "paperList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    };
    if (sessionStorage.getItem("countPage") == "1") {
        $("#first").hide();
        $("#last").hide();
    }
});
$(".selectTitle").click(function () {
    var txt = "是否确认选定该题目？";
    var titleid = $(this).attr("id");
    var option = {
        title: "提示",
        btn: parseInt("0011", 2),
        onOk: function () {
            $.ajax({
                type: 'Post',
                url: 'paperList.aspx?titleId=' + titleid + "&op=selectTitle",
                success: function (succ) {
                    if (succ == "选题成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                window.location.href = "PaperDtailStu.aspx?titleId=" + titleid;
                            }
                        });
                    }
                    else if (succ == "已选题") {
                        window.wxc.xcConfirm("您已经选过题目，不能多次选题!", window.wxc.xcConfirm.typeEnum.error);
                    }
                }
            });
        }
    }
    window.wxc.xcConfirm(txt, "confirm", option);
})
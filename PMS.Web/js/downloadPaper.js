﻿//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

function jump(cur) {
    if (sessionStorage.getItem("strWhere") == null ) {
        window.location.href = "downLoadPaper.aspx?currentPage=" + cur;
    }
    if (sessionStorage.getItem("strWhere") != null) {
        window.location.href = "downLoadPaper.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
    }
};
//查询按钮点击事件
$("#btn-search").click(function () {
    var strWhere = $("#inputsearch").val();
    sessionStorage.setItem("strWhere", strWhere);
    sessionStorage.setItem("type", "textSelect");
    jump(1);
});
$(".btnOpinion").click(function () {
    var account = $(this).parent().parent().find(".stuAccount").text().trim();
    sessionStorage.setItem("account", account);
    $("#myModa1").modal("show");
})
$("#submit").click(function () {
    var opinion = $(".opinion").val();
    $.ajax({
        type: 'Post',
        url: 'downLoadPaper.aspx',
        data: {
            stuAccount: sessionStorage.getItem("account"),
            opinion: opinion,
            op:'add'
        },
        dataType: 'text',
        success: function (succ) {
            if (succ == "提交成功") {
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
$(document).ready(function () {
    //分页参数传递
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
//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

function jump(cur) {
    if (sessionStorage.getItem("strWhere") == null) {
        window.location.href = "checkReportTeacher.aspx?currentPage=" + cur;
    }
    if (sessionStorage.getItem("strWhere") != null) {
        window.location.href = "checkReportTeacher.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
    }
};

//查询按钮点击事件
$("#btn-search").click(function () {
    var strWhere = $("#inputsearch").val();
    sessionStorage.setItem("strWhere", strWhere);
    sessionStorage.setItem("type", "textSelect");
    jump(1);
});

//同意通过
$(".submit").click(function () {
    var stuAccount = $(this).parent().parent().find("#stuAccount").text().trim();
    window.wxc.xcConfirm("确定同意吗？", window.wxc.xcConfirm.typeEnum.confirm, {
        onOk: function (v) {
            $(".submit").hide();
            $(".submitNo").hide();
            $("#no").hide();
            //window.location.href = "checkReportTeacher.aspx?agree=yes&stuAccount=" + stuAccount;
            $.ajax({
                type: 'Post',
                url: 'checkReportTeacher.aspx',
                data: {
                    stuAccount: stuAccount,
                    agree: "yes"
                },
                dataType: 'text',
                success: function (succ) {
                    window.location.href = "checkReportTeacher.aspx";
                }
            });
        }
    });
})

//不同意通过
$(".submitNo").click(function () {
    var stuAccount = $(this).parent().parent().find("#stuAccount").text().trim();
    window.wxc.xcConfirm("确定不同意吗？", window.wxc.xcConfirm.typeEnum.confirm, {
        onOk: function (v) {
            $(".submit").hide();
            $(".submitNo").hide();
            $("#ok").hide();
            //window.location.href = "checkReportTeacher.aspx?agree=no&stuAccount=" + stuAccount;
            $.ajax({
                type: 'Post',
                url: 'checkReportTeacher.aspx',
                data: {
                    stuAccount: stuAccount,
                    agree: "no"
                },
                dataType: 'text',
                success: function (succ) {
                    window.location.href = "checkReportTeacher.aspx";
                }
            });
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
//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

$(document).ready(function () {
    //翻页事件
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            case ('<span class="glyphicon glyphicon-chevron-left"></span>'):
                if (parseInt(sessionStorage.getItem("page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("page")) - 1);
                    break;
                }
                else {
                    jump(1);
                    break;
                }
            case ('<span class="glyphicon glyphicon-chevron-right"></span>'):
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
    //查询按钮事件
    $("#btn-search").click(function () {
        var strWhere = $("#inputsearch").val();
        if (sessionStorage.getItem("op") != null) {
            sessionStorage.removeItem("op");
        }
        sessionStorage.setItem("strWhere", strWhere);
        if (sessionStorage.getItem("dropstrWhere") != null) {
            sessionStorage.removeItem("dropstrWhere");
        }
        if (sessionStorage.getItem("batchWhere") != null) {
            sessionStorage.removeItem("batchWhere");
        }
        jump(1);
    });
    //专业下拉框查询
    $(".selectdrop").change(function () {
        var dropproWhere = $("#selectdrop").find("option:selected").val();
        if (sessionStorage.getItem("op") != null) {
            sessionStorage.removeItem("op");
        }
        sessionStorage.setItem("dropstrWhere", dropproWhere);
        if (sessionStorage.getItem("strWhere") != null) {
            sessionStorage.removeItem("strWhere");
        }
        if (sessionStorage.getItem("batchWhere") != null) {
            sessionStorage.removeItem("batchWhere");
        }
        jump(1);
    })
    //批次下拉查询
    $(".selectdropbatch").change(function () {
        var dropbatchWhere = $("#selectdropbatch").find("option:selected").val();
        if (sessionStorage.getItem("op") != null) {
            sessionStorage.removeItem("op");
        }
        //alert(dropbatchWhere);
        sessionStorage.setItem("batchWhere", dropbatchWhere);
        if (sessionStorage.getItem("strWhere") != null) {
            sessionStorage.removeItem("strWhere");
        }
        jump(1);
    })
    //传查询值到后台
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "selectTopicList.aspx?currentPage=" + cur;
        } else {

            window.location.href = "selectTopicList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&op=" +sessionStorage.getItem("op");
        }
        if (sessionStorage.getItem("strWhere") == null || sessionStorage.getItem("strWhere") == "") {
            window.location.href = "selectTopicList.aspx?currentPage=" + cur + "&dropstrWhere=" + sessionStorage.getItem("dropstrWhere") + "&batchWhere=" + sessionStorage.getItem("batchWhere") + "&op=" + sessionStorage.getItem("op");
        }
    };
    //导出按钮传值
    $("#btn-export").click(function () {
        //alert("导出");
        sessionStorage.setItem("op", "export");
        jump(1);
        //window.location.href = "selectTopicList.aspx?op=export";
    })

    //查看详情弹窗数据填充
    $(".btnSearch").click(function () {
        //查看数据填充
        $("#TeaAccount").text(($(this).parent().parent().find("#teacount").text().trim()));
        $("#StuSex").text(($(this).parent().parent().find("#stusex").text().trim()));
        $("#StuAccount").text(($(this).parent().parent().find("#stuaccount").text().trim()));
        $("#StuTel").text(($(this).parent().parent().find("#phone").text().trim()));
        $("#StuEmail").text(($(this).parent().parent().find("#email").text().trim()));
        $("#RecordId").text(($(this).parent().parent().find("#recordid").text().trim()));
        $("#PlanName").text(($(this).parent().parent().find("#planname").text().trim()));
        $("#Title").text(($(this).parent().parent().find("#title").text().trim()));
        $("#TeaName").text(($(this).parent().parent().find("#teaname").text().trim()));
        $("#StuName").text(($(this).parent().parent().find("#realname").text().trim()));
        $("#ProName").text(($(this).parent().parent().find("#proname").text().trim()));
        $("#CollegeName").text(($(this).parent().parent().find("#collegename").text().trim()));
        $("#RecordTime").text(($(this).parent().parent().find("#recordtime").text().trim()));

    });
    //删除事件
    $(".btnDel").click(function () {
        var recordid = $(this).parent().parent().find("#recordid").text().trim();
        var txt = "是否确认删除？";
        var option = {
            title: "提示",
            btn: parseInt("0011", 2),
            onOk: function () {
                $.ajax({
                    type: 'Post',
                    url: 'selectTopicList.aspx',
                    data: {
                        Recordid: recordid,
                        op: "del"
                    },
                    dataType: 'text',
                    success: function (succ) {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                jump(1);
                            }
                        })
                    }
                })
            }
        }
        window.wxc.xcConfirm(txt, "confirm", option);
    })

});
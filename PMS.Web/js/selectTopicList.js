//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);
//查询按钮事件
$("#btn-search").click(function () {
    var strWhere = $("#inputsearch").val();
    sessionStorage.setItem("strWhere", strWhere);
    if (sessionStorage.getItem("type" == "dropandbtn")) {
        sessionStorage.setItem("type", "");
        //清空下拉查询
        if (sessionStorage.getItem("dropstrWhere") != null) {
            sessionStorage.setItem("dropstrWhere", "");
        }
        sessionStorage.setItem("type", "btn")
        jump(1);
    } else {
        sessionStorage.setItem("type", "");
        sessionStorage.setItem("type", "btn")
        jump(1);
    }
});
//下拉框查询
$(".selectdrop").change(function () {
    var dropstrWhere = $("#selectdrop").find("option:selected").text();
    sessionStorage.setItem("dropstrWhere", dropstrWhere);
    sessionStorage.setItem("type", "");
    sessionStorage.setItem("type", "drop");
    jump(1);
})
function jump(cur) {
    if (sessionStorage.getItem("strWhere") == null && sessionStorage.getItem("dropstrWhere") == null) {
        window.location.href = "selectTopicList.aspx?currentPage=" + cur;
    } else if (sessionStorage.getItem("strWhere") != null && sessionStorage.getItem("dropstrWhere") == null) {
        window.location.href = "selectTopicList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
        sessionStorage.setItem("type", "");
    } else if (sessionStorage.getItem("dropstrWhere") != null && sessionStorage.getItem("strWhere") == null) {
        window.location.href = "selectTopicList.aspx?currentPage=" + cur + "&dropsearch=" + sessionStorage.getItem("dropstrWhere") + "&type=" + sessionStorage.getItem("type");
        sessionStorage.setItem("type", "");
    } else {
        sessionStorage.setItem("type", "dropandbtn");
        window.location.href = "selectTopicList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&dropsearch=" + sessionStorage.getItem("dropstrWhere") + "&type=" + sessionStorage.getItem("type");
        sessionStorage.setItem("type", "");
    }
};
$(document).ready(function () {
    sessionStorage.setItem("type", "");
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

    //传查询值到后台
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "selectTopicList.aspx?currentPage=" + cur;
        } else {
            window.location.href = "selectTopicList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    };
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
        var result = confirm("您确定删除吗？如果该条记录没有关联其他表，将会直接删除！");
        if (result == true) {
            $.ajax({
                type: 'Post',
                url: 'selectTopicList.aspx',
                data: {
                    Recordid: recordid,
                    op: "del"
                },
                dataType: 'text',
                success: function (succ) {
                    alert(succ);
                    jump(1);
                }
            })
        } else { }
    })

});
//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

//下拉框查询
$(".selectdrop").change(function () {
    var strWhere = $("#selectdrop").find("option:selected").text();
    alert(strWhere);
    sessionStorage.setItem("strWhere", strWhere);
    jump(1);
})
function jump(cur) {
    if (sessionStorage.getItem("strWhere") == null) {
        window.location.href = "selectTopicList.aspx?currentPage=" + cur;
    } else {
        window.location.href = "selectTopicList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
    }
};
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
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
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
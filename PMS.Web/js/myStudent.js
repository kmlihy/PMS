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
    jump(1);
});
//输入框的查询条件
function jumpse(cur) {
    if (sessionStorage.getItem("strWhere") == null) {
        window.location.href = "myStudents.aspx?currentPage=" + cur;
    } else {
        window.location.href = "myStudents.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
    }
};
//下拉框查询
$(".selectdrop").change(function () {
    var dropstrWhere = $("#selectdrop").find("option:selected").val();
    sessionStorage.setItem("dropstrWhere", dropstrWhere);
    sessionStorage.setItem("type", "drop");
    jump(1);
})
//跳转方法，传查询值到后台
function jump(cur) {
    //if (sessionStorage.getItem("strWhere") == null && sessionStorage.getItem("dropstrWhere") == null ) {
    //    window.location.href = "myStudents.aspx?currentPage=" + cur;
    //} else if (sessionStorage.getItem("strWhere") != null && sessionStorage.getItem("dropstrWhere") == null) {
    //    window.location.href = "myStudents.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
    //} else if (sessionStorage.getItem("dropstrWhere") != null && sessionStorage.getItem("strWhere") == null) {
    //    window.location.href = "myStudents.aspx?currentPage=" + cur + "&dropsearch=" + sessionStorage.getItem("dropstrWhere") + "&type=" + sessionStorage.getItem("type");
    //} else if (sessionStorage.getItem("dropstrWhere") != null && sessionStorage.getItem("strWhere") != null) {
    //    window.location.href = "myStudents.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&dropsearch=" + sessionStorage.getItem("dropstrWhere") + "&type=" + sessionStorage.getItem("type");
    //}
    
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

    //点击查看详情弹窗加载数据
    $(".btnSearch").click(function () {
        $("#titleRecordId1").text(($(this).parent().parent().find("#titleRecordId").text().trim()));
        $("#realName1").text(($(this).parent().parent().find("#realName").text().trim()));
        $("#sex1").text(($(this).parent().parent().find("#sex").text().trim()));
        $("#phone1").text(($(this).parent().parent().find("#phone").text().trim()));
        $("#proName1").text(($(this).parent().parent().find("#proName").text().trim()));
        $("#title1").text(($(this).parent().parent().find("#title").text().trim()));
        $("#planName1").text(($(this).parent().parent().find("#planName").text().trim()));
        $("#recordtime1").text(($(this).parent().parent().find("#recordtime").text().trim()));
    });
});
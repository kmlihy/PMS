//存储当前页
sessionStorage.setItem("page", $("#page").val());
//存储总页数
sessionStorage.setItem("countPage", $("#countPage").val());
//当总页数为1时，首页与尾页按钮隐藏
if (sessionStorage.getItem("countPage") === "1") {
    $("#first").hide();
    $("#last").hide();
}
//按钮查询
$("#btn-search").click(function () {
    var strWhere = $("#inputsearch").val();
    sessionStorage.setItem("strWhere", strWhere);
    if (sessionStorage.getItem("dropstrWhereplan") !== null) {
        sessionStorage.removeItem("dropstrWhereplan");
    }
    if (sessionStorage.getItem("dropstrWherepro") !== null) {
        sessionStorage.removeItem("dropstrWherepro");
    }
    jump(1);
});
//分页函数
function jump(cur) {
    var strWhere = sessionStorage.getItem("strWhere");
    var type = sessionStorage.getItem("type");
    var proId = sessionStorage.getItem("dropstrWherepro");
    var planId = sessionStorage.getItem("dropstrWhereplan");
    if (strWhere != null) {
        window.location.href = "excellentList.aspx?currentPage=" + cur + "&search=" + strWhere + "&type=" + type + "&op=" + sessionStorage.getItem("op");
    }
    else if (planId != null && proId == null) {
        window.location.href = "excellentList.aspx?currentPage=" + cur + "&dropstrWhereplan=" + planId + "&type=" + type + "&op=" + sessionStorage.getItem("op");
    }
    else if (proId != null && planId == null) {
        window.location.href = "excellentList.aspx?currentPage=" + cur + "&dropstrWherepro=" + proId + "&type=" + type + "&op=" + sessionStorage.getItem("op");
    }
    else if (proId != null && planId != null) {
        window.location.href = "excellentList.aspx?currentPage=" + cur + "&dropstrWherepro=" + proId + "&dropstrWhereplan=" + planId + "&type=" + type + "&op=" + sessionStorage.getItem("op");
    } else {
        window.location.href = "excellentList.aspx?currentPage=" + cur + "&op=" + sessionStorage.getItem("op");
    }
};
//翻页事件
$(".jump").click(function () {
    switch ($.trim($(this).html())) {
        case ('<span class="iconfont icon-back"></span>'):
            if (sessionStorage.getItem("op") != null) {
                sessionStorage.removeItem("op");
            }
            if (parseInt(sessionStorage.getItem("page")) > 1) {
                jump(parseInt(sessionStorage.getItem("page")) - 1);
                break;
            }
            else {
                if (sessionStorage.getItem("op") != null) {
                    sessionStorage.removeItem("op");
                }
                jump(1);
                break;
            }
        case ('<span class="iconfont icon-more"></span>'):
            if (sessionStorage.getItem("op") != null) {
                sessionStorage.removeItem("op");
            }
            if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {
                jump(parseInt(sessionStorage.getItem("page")) + 1);
                break;
            }
            else {
                if (sessionStorage.getItem("op") != null) {
                    sessionStorage.removeItem("op");
                }
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
            }
        case ("首页"):
            if (sessionStorage.getItem("op") != null) {
                sessionStorage.removeItem("op");
            }
            jump(1);
            break;
        case ("尾页"):
            if (sessionStorage.getItem("op") != null) {
                sessionStorage.removeItem("op");
            }
            jump(parseInt(sessionStorage.getItem("countPage")));
            break;
    }
});
//批次下拉框查询
$("#choosePlan").change(function () {
    sessionStorage.removeItem("strWhere");
    //获取排序方式
    var order = $("#order").find("option:selected").val();
    //存储批次下拉框的条件
    var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
    if (dropstrWhereplan != "0") {
        sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
        var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();
        //判断专业是否被选中
        if (dropstrWherepro != "0") {
            //存储专业下拉框的条件
            sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "alldrop");
            jump(1);
        }
        else {
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "plandrop");
            jump(1);
        }
    }
    else {
        sessionStorage.removeItem("dropstrWhereplan");
        var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();
        //判断专业是否被选中
        if (dropstrWherepro != "0") {
            //存储专业下拉框的条件
            sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "prodrop");
            jump(1);
        }
        else {
            sessionStorage.removeItem("dropstrWherepro");
            sessionStorage.removeItem("type");
            jump(1);
        }
    }
});
//专业下拉框查询
$("#chooseStuPro").change(function () {
    sessionStorage.removeItem("strWhere");
    //获取排序方式
    var order = $("#order").find("option:selected").val();
    //获取用户选中的专业下拉框的Id值
    var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();
    if (dropstrWherepro != "0") {
        //把值存储到sessionStorage中并传到后台
        sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
        //获取用户选中批次的id值
        var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
        //判断批次下拉框有没有值
        if (dropstrWhereplan != "0") {
            //存储批次下拉框的条件           
            sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "alldrop");
            jump(1);
        }
        else {
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "prodrop");
            jump(1);
        }
    }
    else {
        sessionStorage.removeItem("dropstrWherepro");
        var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
        //判断批次下拉框有没有值
        if (dropstrWhereplan != "0") {
            //存储批次下拉框的条件           
            sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "plandrop");
            jump(1);
        }
        else {
            sessionStorage.removeItem("dropstrWhereplan");
            sessionStorage.removeItem("type");
            jump(1);
        }
    }
});
//导出按钮传值
$("#btn-export").click(function () {
    //alert("导出");
    sessionStorage.setItem("op", "export");
    jump(1);
    //window.location.href = "selectTopicList.aspx?op=export";
})
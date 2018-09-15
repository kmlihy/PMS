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
    if (type == "up" || type == "plandropUp" || type == "prodropUp" || type == "alldropUp") {
        if (strWhere == null && proId == null && planId == null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur +"&order = up";
        }
        if (strWhere != null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur + "&search=" + strWhere + "&type=" + type + "&order = up";
        }
        if (planId != null && proId == null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur + "&dropstrWhereplan=" + planId + "&type=" + type + "&order = up";
        }
        if (proId != null && planId == null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur + "&dropstrWherepro=" + proId + "&type=" + type + "&order = up";
        }
        if (proId != null && planId != null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur + "&dropstrWherepro=" + proId + "&dropstrWhereplan=" + planId + "&type=" + type + "&order = up";
        }
    }
    else {
        if (strWhere == null && proId == null && planId == null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur;
        }
        if (strWhere != null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur + "&search=" + strWhere + "&type=" + type;
        }
        if (planId != null && proId == null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur + "&dropstrWhereplan=" + planId + "&type=" + type;
        }
        if (proId != null && planId == null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur + "&dropstrWherepro=" + proId + "&type=" + type;
        }
        if (proId != null && planId != null) {
            window.location.href = "adminViewScore.aspx?currentPage=" + cur + "&dropstrWherepro=" + proId + "&dropstrWhereplan=" + planId + "&type=" + type;
        }
    }
};
//点击分页
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
        case (sessionStorage.getItem("countPage")):
            jump(parseInt(sessionStorage.getItem("countPage")));
            break;
        case ("尾页"):
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
        if (order == "0" || order == "down") {
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
        } else {
            //判断专业是否被选中
            if (dropstrWherepro != "0") {
                //存储专业下拉框的条件
                sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "alldropUp");
                jump(1);
            }
            else {
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "plandropUp");
                jump(1);
            }
        }
    }
    else {
        sessionStorage.removeItem("dropstrWhereplan");
        var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();
        if (order == "0" || order == "down") {
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
        } else {
            //判断专业是否被选中
            if (dropstrWherepro != "0") {
                //存储专业下拉框的条件
                sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "prodropUp");
                jump(1);
            }
            else {
                sessionStorage.removeItem("dropstrWherepro");
                sessionStorage.setItem("type","up");
                jump(1);
            }
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
        if (order == "0" || order == "down") {
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
        } else {
            //判断批次下拉框有没有值
            if (dropstrWhereplan != "0") {
                //存储批次下拉框的条件           
                sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "alldropUp");
                jump(1);
            }
            else {
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "prodropUp");
                jump(1);
            }
        }
    }
    else {
        sessionStorage.removeItem("dropstrWherepro");
        var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
        if (order == "0" || order == "down") {
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
        } else {
            //判断批次下拉框有没有值
            if (dropstrWhereplan != "0") {
                //存储批次下拉框的条件           
                sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "plandropUP");
                jump(1);
            }
            else {
                sessionStorage.removeItem("dropstrWhereplan");
                sessionStorage.setItem("type","up");
                jump(1);
            }
        }
    }
});
//排序方式
$("#order").change(function () {
    var order = $("#order").find("option:selected").val();
    //获取用户选中的专业下拉框的Id值
    var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();
    //获取用户选中的批次下拉框的Id值
    var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
    if (dropstrWherepro != "0" && dropstrWhereplan != "0") {
        //把值存储到sessionStorage中并传到后台
        sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
        //存储批次下拉框的条件           
        sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
        if (order == "0" || order == "down") {
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "alldrop");
            jump(1);
        } else {
            sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "alldropUp");
            jump(1);
        }
    }
    else if (dropstrWherepro != "0" && dropstrWhereplan == "0") {
        sessionStorage.removeItem("dropstrWhereplan");
        if (order == "0" || order == "down") {
            sessionStorage.setItem("dropstrWherepro", dropstrWhereplan);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "prodrop");
            jump(1);
        } else {
            sessionStorage.setItem("dropstrWherepro", dropstrWhereplan);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "prodropUP");
            jump(1);
        }
    }
    else if (dropstrWhereplan != "0" && dropstrWherepro == "0") {
        sessionStorage.removeItem("dropstrWherepro");
        if (order == "0" || order == "down") {
            sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "plandrop");
            jump(1);
        } else {
            sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "plandropUP");
            jump(1);
        }
    }
    else if (dropstrWhereplan == "0" && dropstrWherepro == "0") {
        sessionStorage.removeItem("dropstrWhereplan");
        sessionStorage.removeItem("dropstrWherepro");
        if (order == "0" || order == "down") {
            sessionStorage.removeItem("type");
            jump(1);
        } else {
            sessionStorage.setItem("type","up");
            jump(1);
        }
    }
})
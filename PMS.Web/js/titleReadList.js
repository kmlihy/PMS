//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);
$(document).ready(function () {
    $("#panelbody").height(100 + $(".big-box").height());
    //分页参数传递
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            case ('<span class="iconfont icon-back"></span>'):
                if (parseInt(sessionStorage.getItem("Page")) > 1) {
                    sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                    sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                    sessionStorage.setItem("dropstrWhereColl", $("#chooseStuColl").find("option:selected").val());
                    jump(parseInt(sessionStorage.getItem("Page")) - 1);
                    break;
                } else {
                    sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                    sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                    sessionStorage.setItem("dropstrWhereColl", $("#chooseStuColl").find("option:selected").val());
                    jump(1);
                    break;
                }

            case ('<span class="iconfont icon-more"></span>'):
                if (parseInt(sessionStorage.getItem("Page")) < parseInt(sessionStorage.getItem("countPage"))) {
                    sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                    sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                    sessionStorage.setItem("dropstrWhereColl", $("#chooseStuColl").find("option:selected").val());
                    jump(parseInt(sessionStorage.getItem("Page")) + 1);
                    break;
                } else {
                    sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                    sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                    sessionStorage.setItem("dropstrWhereColl", $("#chooseStuColl").find("option:selected").val());
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
                }
            case ("首页"):
                sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                sessionStorage.setItem("dropstrWhereColl", $("#chooseStuColl").find("option:selected").val());
                jump(1);
                break;
            case ("尾页"):
                sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                sessionStorage.setItem("dropstrWhereColl", $("#chooseStuColl").find("option:selected").val());
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
        }
    });
    //分院下拉框查询
    $("#chooseStuColl").change(function () {
        sessionStorage.removeItem("strWhere");
        sessionStorage.removeItem("dropstrWherepro");
        sessionStorage.removeItem("dropstrWhereplan");
        //获取用户选中的专业下拉框的Id值
        var dropstrWhereColl = $("#chooseStuColl").find("option:selected").val();
        if (dropstrWhereColl !== "0") {
            //把值存储到sessionStorage中并传到后台
            sessionStorage.setItem("dropstrWhereColl", dropstrWhereColl);
            sessionStorage.removeItem("type");
            sessionStorage.setItem("type", "Colldrop");
            jump(1);
        } else {
            sessionStorage.removeItem("dropstrWhereColl");
            sessionStorage.removeItem("type");
            jump(1);
        }
    });
    //专业下拉框查询
    $("#chooseStuPro").change(function() {
        sessionStorage.removeItem("strWhere");
        //获取用户选中的专业下拉框的Id值
        var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();
        //sessionStorage.setItem("dropstrWhereColl", null);
        if (dropstrWherepro !== "0") {
            //把值存储到sessionStorage中并传到后台
            sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
            //获取用户选中学院的id值
            var dropstrWhereColl = $("#chooseStuColl").find("option:selected").val();
            //获取用户选中批次的id值
            var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
            if (dropstrWhereColl !== "0") {
                sessionStorage.setItem("dropstrWhereColl", dropstrWhereColl);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "collAndPro");
                jump(1);
            } else if (dropstrWhereplan !== "0" && dropstrWhereColl !== "0") {
                //存储批次下拉框的条件
                sessionStorage.setItem("dropstrWhereColl", dropstrWhereColl);
                sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "allDrop");
                jump(1);
            } else if (dropstrWhereplan !== "0") {
                //存储批次下拉框的条件           
                sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "alldrop");
                jump(1);
            } else {
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "prodrop");
                jump(1);
            }
        } else {
            sessionStorage.removeItem("dropstrWherepro");
            var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
            //判断批次下拉框有没有值
            if (dropstrWhereplan !== "0") {
                //存储批次下拉框的条件           
                sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "plandrop");
                jump(1);
            } else {
                sessionStorage.removeItem("dropstrWhereplan");
                sessionStorage.removeItem("type");
                jump(1);
            }
        }
    });
    //批次下拉框查询
    $("#choosePlan").change(function() {
        sessionStorage.removeItem("strWhere");
        //存储批次下拉框的条件
        var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
        if (dropstrWhereplan !== "0") {
            sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
            var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();
            var dropstrWhereColl = $("#chooseStuColl").find("option:selected").val();
            if (dropstrWherepro !== "0" && dropstrWhereColl !== "0") {
                //存储批次下拉框的条件
                sessionStorage.setItem("dropstrWhereColl", dropstrWhereColl);
                sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "allDrop");
                jump(1);
             }else if (dropstrWherepro !== "0") {
                //存储专业下拉框的条件
                sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "alldrop");
                jump(1);
            }else if (dropstrWhereColl !== "0") {
                sessionStorage.setItem("dropstrWhereColl", dropstrWhereColl);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "collAndPlan");
                jump(1);
            } else {
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "plandrop");
                jump(1);
            }
        } else {
            sessionStorage.removeItem("dropstrWhereplan");
            var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();
            //判断专业是否被选中
            if (dropstrWherepro !== "0") {
                //存储专业下拉框的条件
                sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
                sessionStorage.removeItem("type");
                sessionStorage.setItem("type", "prodrop");
                jump(1);
            } else {
                sessionStorage.removeItem("dropstrWherepro");
                sessionStorage.removeItem("type");
                jump(1);
            }
        }
    });

    function jump(cur) {
        if (sessionStorage.getItem("strWhere") === null && sessionStorage.getItem("dropstrWherepro") === null && sessionStorage.getItem("dropstrWhereplan") === null && sessionStorage.getItem("dropstrWhereColl") === null) {
            window.location.href = "titleReadList.aspx?currentPage=" + cur;
        }
        else if (sessionStorage.getItem("strWhere") !== null) {
            window.location.href = "titleReadList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
        }
        else if (sessionStorage.getItem("dropstrWhereColl") !== null && "dropstrWherepro" === null && sessionStorage.getItem("dropstrWhereplan") === null) {
            window.location.href = "titleReadList.aspx?currentPage=" + cur + "&dropstrWhereColl=" + sessionStorage.getItem("dropstrWhereColl") + "&type=" + sessionStorage.getItem("type");
        }
        else if (sessionStorage.getItem("dropstrWhereColl") !== null && "dropstrWherepro" !== null && sessionStorage.getItem("dropstrWhereplan") === null) {
            window.location.href = "titleReadList.aspx?currentPage=" + cur + "&dropstrWhereColl=" + sessionStorage.getItem("dropstrWhereColl") + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&type=" + sessionStorage.getItem("type");
        }
        else if (sessionStorage.getItem("dropstrWhereColl") !== null && "dropstrWhereplan" !== null && sessionStorage.getItem("dropstrWherepro") === null) {
            window.location.href = "titleReadList.aspx?currentPage=" + cur + "&dropstrWhereColl=" + sessionStorage.getItem("dropstrWhereColl") + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
        }
        else if (sessionStorage.getItem("dropstrWhereColl") !== null && "dropstrWhereplan" !== null && sessionStorage.getItem("dropstrWherepro") !== null) {
            window.location.href = "titleReadList.aspx?currentPage=" + cur + "&dropstrWhereColl=" + sessionStorage.getItem("dropstrWhereColl") + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
        }
        else if (sessionStorage.getItem("dropstrWhereplan") !== null && sessionStorage.getItem("dropstrWherepro") === null) {
            window.location.href = "titleReadList.aspx?currentPage=" + cur + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
        }
        else if (sessionStorage.getItem("dropstrWherepro") !== null && sessionStorage.getItem("dropstrWhereplan") === null) {
            window.location.href = "titleReadList.aspx?currentPage=" + cur + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&type=" + sessionStorage.getItem("type");
        }
        else if (sessionStorage.getItem("dropstrWherepro") !== null && sessionStorage.getItem("dropstrWhereplan") !== null) {
            window.location.href = "titleReadList.aspx?currentPage=" + cur + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
        }
        else {
            window.location.href = "titleReadList.aspx?currentPage=" + cur + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type") + "&search=" + sessionStorage.getItem("strWhere");
        }
    };
    //查询按钮点击事件
    $("#btn-search").click(function() {
        var strWhere = $("#inputsearch").val();
        if (strWhere !== null || strWhere !== "") {
            sessionStorage.setItem("strWhere", strWhere);
            sessionStorage.setItem("type", "textSelect");
            sessionStorage.removeItem("dropstrWhereplan");
            sessionStorage.removeItem("dropstrWherepro");
            $("#inputsearch").val(sessionStorage.getItem("strWhere"));
            jump(1);
        }
        else {
            sessionStorage.removeItem("dropstrWhereplan");
            sessionStorage.removeItem("dropstrWherepro");
            $("#inputsearch").val(sessionStorage.getItem("strWhere"));
            jump(1);
        }
    });
    //点击查看题目详情按钮
    $(".btnSearch").click(function () {
        var titleId = $(this).parent().parent().find("#titleId").val();
        window.location.href = "../paperDetail.aspx?titleId=" + titleId;
    })
    //当总页数为1时，首页与尾页按钮隐藏
    if (sessionStorage.getItem("countPage") === "1") {
        $("#first").hide();
        $("#last").hide();
    }

    //查询详细信息模态框数据绑定
    //$(".btnSearch").click(function () {
    //    var titleId = $(this).parent().parent().find("#titleId").text().trim(),
    //        title = $(this).parent().parent().find("#title").text().trim(),
    //        plan = $(this).parent().parent().find("#planName").text().trim(),
    //        pro = $(this).parent().parent().find("#proName").text().trim(),
    //        author = $(this).parent().parent().find("#teaName").text().trim(),
    //        //selected = $(this).parent().parent().find("#titleNumber").text().trim(),
    //        selected = $(this).parent().parent().find("#nowSelected").text().trim(),
    //        limit = $(this).parent().parent().find("#limit").text().trim(),
    //        createTime = $(this).parent().parent().find("#createTime").text().trim();
    //    $("#searchTitleId").text(titleId);
    //    $("#searchTitle").text(title);
    //    $("#searchPlan").text(plan);
    //    $("#searchPro").text(pro);
    //    $("#searchAuthor").text(author);
    //    $("#searchSelected").text(selected);
    //    $("#searchAll").text(limit);
    //    $("#searchCreateTime").text(createTime);
    //})
});
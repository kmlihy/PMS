//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

//专业下拉框查询
$("#chooseStuPro").change(function () {
    sessionStorage.removeItem("strWhere");
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

//批次下拉框查询
$("#choosePlan").change(function () {
    sessionStorage.removeItem("strWhere");
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

function jump(cur) {
    if (sessionStorage.getItem("strWhere") == null && sessionStorage.getItem("dropstrWherepro") == null && sessionStorage.getItem("dropstrWhereplan") == null) {
        window.location.href = "myStudents.aspx?currentPage=" + cur;
    }
    if (sessionStorage.getItem("strWhere") != null) {
        window.location.href = "myStudents.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
    }
    if (sessionStorage.getItem("dropstrWhereplan") != null && sessionStorage.getItem("dropstrWherepro") == null) {
        window.location.href = "myStudents.aspx?currentPage=" + cur + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
    }
    if (sessionStorage.getItem("dropstrWherepro") != null && sessionStorage.getItem("dropstrWhereplan") == null) {
        window.location.href = "myStudents.aspx?currentPage=" + cur + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&type=" + sessionStorage.getItem("type");
    }
    if (sessionStorage.getItem("dropstrWherepro") != null && sessionStorage.getItem("dropstrWhereplan") != null) {
        window.location.href = "myStudents.aspx?currentPage=" + cur + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
    }
};

//查询按钮点击事件
$("#btn-search").click(function () {
    var strWhere = $("#inputsearch").val();
    sessionStorage.setItem("strWhere", strWhere);
    sessionStorage.setItem("type", "textSelect");
    sessionStorage.removeItem("dropstrWhereplan");
    sessionStorage.removeItem("dropstrWherepro")
    jump(1);
});

$(document).ready(function () {
    //分页参数传递
    $(".jump").click(function () {
        if ($("#search").val() != null) {
            switch ($.trim($(this).html())) {
                case ('<span class="iconfont icon-back"></span>'):
                    if (parseInt(sessionStorage.getItem("Page")) > 1) {
                        sessionStorage.setItem("strWhere", $("#search").val());
                        jump(parseInt(sessionStorage.getItem("Page")) - 1);
                        break;
                    }
                    else {
                        sessionStorage.setItem("strWhere", $("#search").val());
                        jump(1);
                        break;
                    }

                case ('<span class="iconfont icon-more"></span>'):
                    if (parseInt(sessionStorage.getItem("Page")) < parseInt(sessionStorage.getItem("countPage"))) {
                        sessionStorage.setItem("strWhere", $("#search").val());
                        jump(parseInt(sessionStorage.getItem("Page")) + 1);
                        break;
                    }
                    else {
                        sessionStorage.setItem("strWhere", $("#search").val());
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                    }
                case ("首页"):
                    sessionStorage.setItem("strWhere", $("#search").val());
                    jump(1);
                    break;
                case ("尾页"):
                    sessionStorage.setItem("strWhere", $("#search").val());
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
            }
        }
        else {
            switch ($.trim($(this).html())) {
                case ('<span class="iconfont icon-back"></span>'):
                    if (parseInt(sessionStorage.getItem("Page")) > 1) {
                        sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                        sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                        jump(parseInt(sessionStorage.getItem("Page")) - 1);
                        break;
                    }
                    else {
                        sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                        sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                        jump(1);
                        break;
                    }

                case ('<span class="iconfont icon-more"></span>'):
                    if (parseInt(sessionStorage.getItem("Page")) < parseInt(sessionStorage.getItem("countPage"))) {
                        sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                        sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                        jump(parseInt(sessionStorage.getItem("Page")) + 1);
                        break;
                    }
                    else {
                        sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                        sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                    }
                case ("首页"):
                    sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                    sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                    jump(1);
                    break;
                case ("尾页"):
                    sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                    sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
            }
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
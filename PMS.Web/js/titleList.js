//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
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
        window.location.href = "titleList.aspx?currentPage=" + cur;
    }
    if (sessionStorage.getItem("strWhere") != null) {
        window.location.href = "titleList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
    }
    if (sessionStorage.getItem("dropstrWhereplan") != null && sessionStorage.getItem("dropstrWherepro") == null) {
        window.location.href = "titleList.aspx?currentPage=" + cur + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
    }
    if (sessionStorage.getItem("dropstrWherepro") != null && sessionStorage.getItem("dropstrWhereplan") == null) {
        window.location.href = "titleList.aspx?currentPage=" + cur + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&type=" + sessionStorage.getItem("type");
    }
    if (sessionStorage.getItem("dropstrWherepro") != null && sessionStorage.getItem("dropstrWhereplan") != null) {
        window.location.href = "titleList.aspx?currentPage=" + cur + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
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

//点击查看详情按钮
$(".btnSearch").click(function () {
    var titleId = $(this).parent().parent().find("#titleId").text().trim();
    window.location.href = "paperDetail.aspx?titleId=" + titleId;
})

//批量导入
$(".file").on("change", "input[type='file']", function () {
    var filePath = $(this).val();
    if (filePath.indexOf("xls") !== -1 || filePath.indexOf("xlsx") !== -1) {
        $(".fileerrorTip").html("").hide();
        var arr = filePath.split('\\');
        var fileName = arr[arr.length - 1];
        $(".showFileName").html(fileName);
    } else {
        $(".showFileName").html("");
        $(".fileerrorTip").html("您未上传文件，或者您上传文件类型有误！").show();
        return false
    }
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

    //自动隐藏导航栏首页尾页
    if (sessionStorage.getItem("countPage") == "1") {
        $("#first").hide();
        $("#last").hide();
    }

    //添加标题
    $("#btn-Add").click(function () {
        window.location.href = "addPaper.aspx";
    });

    //点击编辑按钮，编辑弹框绑定数据
    $(".btnEdit").click(function () {
        var ediTitleId = $(this).parent().parent().find("#titleId").text().trim();
        $("#ediTitleId").val(ediTitleId);
        var ediTitle = $(this).parent().parent().find("#title").text().trim();
        $("#ediTitle").val(ediTitle);
        var ediPlan = $(this).parent().parent().find("#plaName").text().trim();
        $("#ediPlan").val(ediPlan);
        var ediProf = $(this).parent().parent().find("#proName").text().trim();
        $("#ediProf").val(ediProf);
        var ediTeaName = $(this).parent().parent().find("#teaName").text().trim();
        $("#ediTeaName").val(ediTeaName);
        var ediLimit = $(this).parent().parent().find("#limit").text().trim();
        $("#ediLimit").val(ediLimit);
        var ediCreateTime = $(this).parent().parent().find("#createTime").text().trim();
        $("#ediCreateTime").val(ediCreateTime);
    });

    //点击关闭按钮，清除验证提示信息
    $("#btnClose").click(function () {
        $("#titleIdValidate").html("");
        $("#titleValidate").html("");
        $("#planValidate").html("");
        $("#profValidate").html("");
        $("#teaNameValidate").html("");
        $("#limitValidate").html("");
        $("#createTimeValidate").html("");
    });
    //验证是否提交更改
    $("#btnSave").click(function () {
        var saveTitleId = $("#ediTitleId").val(),
            saveTitle = $("#ediTitle").val(),
            savePlan = $("#ediPlan").val(),
            saveProf = $("#ediProf").val(),
            saveTeaName = $("#ediTeaName").val(),
            saveLimit = $("#ediLimit").val(),
            saveCreateTime = $("#ediCreateTime").val(),
            saveContent = $("#titleContent").val(),
            saveSelected = $("#selected").val();

        //验证用户输入不能为空
        if (saveTitleId == "") {
            $("#titleIdValidate").html("题目编号不能为空！").css("color", "red");
        }
        else if (saveTitle == "") {
            $("#titleValidate").html("题目不能为空，请重新输入！").css("color", "red");
        }
        else if (savePlan == "") {
            $("#planValidate").html("批次不能为空，请重新输入！").css("color", "red");
        }
        else if (saveProf == "") {
            $("#profValidate").html("学院不能为空，请重新输入！").css("color", "red");
        }
        else if (saveTeaName == "") {
            $("#teaNameValidate").html("发布人不能为空，请重新输入！").css("color", "red");
        }
        else if (saveLimit == "") {
            $("#limitValidate").html("人数上限不能为空，请重新输入！").css("color", "red");
        }
        else if (saveCreateTime == "") {
            $("#createTimeValidate").html("创建时间不能为空，请重新输入！").css("color", "red");
        }
        else {
            $.ajax({
                type: 'Post',
                url: 'titleList.aspx',
                data: {
                    saveTitleId: saveTitleId,
                    saveTitle: saveTitle,
                    savePlan: savePlan,
                    saveProf: saveProf,
                    saveTeaName: saveTeaName,
                    saveLimit: saveLimit,
                    saveCreateTime: saveCreateTime,
                    saveContent: saveContent,
                    saveSelected: saveSelected,
                    op: "edit"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ == "更新成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                jump(1);
                                alert("更新成功");
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
        }
    });

    //表单不能被用户编辑
    $("#ediTitleId").attr("disabled", "disabled");
    $("#ediPlan").attr("disabled", "disabled");
    $("#ediProf").attr("disabled", "disabled");
    $("#ediCreateTime").attr("disabled", "disabled");

    //删除标题信息
    $(".btnDel").click(function () {
        var deleteTitleId = $(this).parent().parent().find("#titleId").text().trim();
        alert(deleteTitleId);
        //Confirm弹窗
        var txt = "确定要删除吗？";
        var option = {
            title: "删除警告",
            btn: parseInt("0011", 2),
            onOk: function () {
                $.ajax({
                    type: 'Post',
                    url: 'titleList.aspx',
                    data: {
                        deleteTitleId: deleteTitleId,
                        op: "del"
                    },
                    dataType: 'text',
                    success: function (succ) {
                        if (succ == "删除成功") {
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                                onOk: function (v) {
                                    jump(parseInt(sessionStorage.getItem("Page")));
                                }
                            });
                        } else {
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                                onOk: function (v) {
                                    jump(parseInt(sessionStorage.getItem("Page")));
                                }
                            });
                        }
                    }
                });
            }
        }
        window.wxc.xcConfirm(txt, "warning", option);
    })
});
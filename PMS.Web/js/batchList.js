//时间选择器
$(function () {
    $(".datetimepicker").datepicker({
        dateFormat: 'yy-mm-dd',//显示日期格式
        //英文转中文
        dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
        monthNames: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
    })
})

//存储当前页
sessionStorage.setItem("page", $("#page").val());
//存储总页数
sessionStorage.setItem("countPage", $("#countPage").val());

$(document).ready(function () {
    //分页
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            //点击上一页按钮
            case ('<span class="iconfont icon-back"></span>'):
                if (parseInt(sessionStorage.getItem("page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("page")) - 1);
                    break;
                }
                else {
                    jump(1);
                    break;
                }
                //点击下一页按钮
            case ('<span class="iconfont icon-more"></span>'):
                if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {
                    jump(parseInt(sessionStorage.getItem("page")) + 1);
                    break;
                }
                else {
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
                }
                //点击首页
            case ("首页"):
                jump(1);
                break;
            case (sessionStorage.getItem("countPage")):
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
                //点击尾页
            case ("尾页"):
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
        }
    });
    //点击按钮查询
    $("#btn-search").click(function () {
        var strWhere = $("#inputsearch").val();
        if (strWhere != null || strWhere != "") {
            sessionStorage.setItem("strWhere", strWhere);
            sessionStorage.setItem("type", "btn");
            jump(1);
        }
        else {
            jump(1);
        }
    });
    //下拉框查询
    $("#chooseStuPro").change(function () {
        sessionStorage.removeItem("strWhere");
        var dropstrWhere = $(this).find("option:selected").val();
        sessionStorage.setItem("dropstrWhere", dropstrWhere);
        if (dropstrWhere != "0") {
            sessionStorage.getItem("dropstrWhere");
            sessionStorage.setItem("type", "drop");
            jump(1);
        }
        else {
            sessionStorage.removeItem("dropstrWhere");
            jump(1);
        }
    })
    //地址栏显示信息
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null && sessionStorage.getItem("dropstrWhere") == null) {
            window.location.href = "batchList.aspx?currentPage=" + cur;
        }
        else if (sessionStorage.getItem("strWhere") != null && sessionStorage.getItem("dropstrWhere") == null) {
            window.location.href = "batchList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
        }
        else if (sessionStorage.getItem("strWhere") == null && sessionStorage.getItem("dropstrWhere") != null) {
            window.location.href = "batchList.aspx?currentPage=" + cur + "&dropstrWhere=" + sessionStorage.getItem("dropstrWhere") + "&type=" + sessionStorage.getItem("type");
        }
        else {
            window.location.href = "batchList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&dropstrWhere=" + sessionStorage.getItem("dropstrWhere") + "&type=" + sessionStorage.getItem("type");
        }
    };
    //当总页数为1时，首页与尾页按钮隐藏
    if (sessionStorage.getItem("count") === "1") {
        $("#first").hide();
        $("#last").hide();
    }
    //新增模态框验证
    //var pattern_chin = /[\u4e00-\u9fa5]/g;//汉字的正则表达式
    //var pattern_time = /\d{4}-\d{1,2}-\d{1,2}/; //日期格式
    //批次输入框验证
    //$("#planName").blur(function () {
    //    var planName = $(this).val();
    //    //alert(planName);
    //    if (planName !== "") {
    //        $("#p_name").hide();
    //        var matchResult = planName.match(pattern_chin);
    //        if (matchResult == null) {
    //            $("#p_name").show();
    //            $("#p_name").html("请输入中文").css("color", "red");
    //        }
    //        else {
    //            $("#p_name").hide();
    //        }
    //    }
    //    else {
    //        $("#p_name").html("批次名称不能为空").css("color","red");
    //    }
    //})
    //开始时间输入框验证
    //$("#startTime").blur(function () {
    //    var startTime = $(this).val();
    //    if (startTime == null) {
    //        $("#p_start").hide();
    //    }
    //    else {
    //        $("#p_start").show();
    //        $("#p_start").html("开始时间不能空！").css("color", "red");
    //    }
    //})
    //结束时间框验证
    //$("#endTime").blur(function () {
    //    var endTime = $(this).val();
    //    if (endTime == null) {
    //        $("#p_end").hide();
    //    }
    //    else {
    //        $("#p_end").show();
    //        $("#p_end").html("结束时间不能空！").css("color", "red");
    //    }
    //})
    //添加批次
    //

    //新增模态框验证
    //批次名称验证
    $("#planName").blur(function () {
        name = $(this).val();
        var pattern = /^[a-zA-Z\u4e00-\u9fa5]+$/
        if (!pattern.test(name)) {
            $("#p_name").html("姓名不能含有特殊字符且不能是数字").css("color", "red")
        }
    })
    $("#planName").focus(function () {
        $("#p_name").html("");
    })
    //新增批次
    $("#savePlan").click(function () {
        var planName = $("#planName").val(),
            startTime = $("#startTime").val(),
            endTime = $("#endTime").val(),
            state = $("#state").find("option:selected").val(),
            college = $("#collegeId").find("option:selected").val();
        //if (planName == ""||startTime==""||endTime==""||state==""||college=="") {
        //    alert("不能出现未填项！");
        //}
        //else {
            //ajax传值到后台
            $.ajax({
                type: 'Post',
                url: 'batchList.aspx',
                data: {
                    planName: planName,
                    startTime: startTime,
                    endTime: endTime,
                    state: state,
                    college: college,
                    op: "add"
                },
                dateType: 'text',
                success: function (succ) {
                    if (succ == "添加成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                jump(1);
                            }
                        });
                    }
                    else if (succ == "以上内容不能出现未填项") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                                $("#planName").focus();
                            }
                        });
                    }
                    else {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                                jump(1);
                            }
                        });
                    }
                }
            })
        //}
    })
    //编辑批次
    $(".planEditor").click(function () {
        var editorName = $(this).parent().prev("td").prev("td").prev("td").prev("td").prev("td").text().trim(),
            editorStart = $(this).parent().prev("td").prev("td").prev("td").prev("td").text().trim(),
            editorEnd = $(this).parent().prev("td").prev("td").prev("td").text().trim(),
            editorState = $(this).parent().prev("td").prev("td").find(".stateData").text().trim(),
            editorStateId = $(this).parent().prev("td").prev("td").find(".stateData").get(0).id,
            editorCollege = $(this).parent().prev("td").text().trim(),
            editorPlanId = $(this).parent().parent().children("td").get(1).id;
            var planCollegeId = $(this).parent().parent().children("td").get(6).id;
        $(".editorPlanName").val(editorName);
        $(".editorStartTime").val(editorStart);
        $(".editorEndTime").val(editorEnd);
        $(".editorState").val(editorState);
        $(".editorCollege").val(editorCollege);
        $(".planCollegeId").text(planCollegeId);
        $(".planId").text(editorPlanId);
        $(".editorStateId").text(editorStateId);
    });
    //按钮隐藏
    //下拉框隐藏
    $(".editorStateId").hide();
    $(".planCollegeId").hide();
    $(".planId").hide();
    //编辑按钮
    $(".batchState").hide();
    $(".batchCollege").hide();
    //确定按钮
    $("#btnSure1").hide();
    $("#btnSure2").hide();
    //激活状态编辑按钮
    $("#btnEditor1").click(function () {
        $(".batchState").show();
        $(".editorState").hide();
        $("#btnSure1").show();
        $(this).hide();
    })
    //激活状态确认按钮
    $("#btnSure1").click(function () {
        var state = $(".batchState").find("option:selected").val();
        $(".editorStateId").text(state);
        $(".batchState").hide();
        $(".editorState").val($(".editorStateId").text() == "1" ? "已激活" : "未激活");
        $(".editorState").show();
        $("#btnEditor1").show();
        $(this).hide();
    })
    //学院编辑按钮
    $("#btnEditor2").click(function () {
        $(".batchCollege").show();
        $(".editorCollege").hide();
        $("#btnSure2").show();
        $(this).hide();
    })
    //学院确认按钮
    $("#btnSure2").click(function () {
        var college = $(".selectCollege").find("option:selected").val();
        $(".planCollegeId").text(college);
        var collegeName = $(".selectCollege").find("option:selected").text().trim();
        $(".editorCollege").val(collegeName);
        //按钮隐藏和显示
        $(".batchCollege").hide();
        $(".editorCollege").show();
        $("#btnEditor2").show();
        $(this).hide();
    })
    //提交编辑
    $(".saveEditor").click(function () {
        var editorPlanId = $(".planId").text(),
            editorPlanName = $(".editorPlanName").val(),
            editorStartTime = $(".editorStartTime").val(),
            editorEndTime = $(".editorEndTime").val(),
            editorState = $(".editorStateId").text(),
            planCollegeId = $(".planCollegeId").text();
        //alert("ajax");
        $.ajax({
            type: 'Post',
            url: 'batchList.aspx',
            data: {
                editorPlanId: editorPlanId,
                editorPlanName: editorPlanName,
                editorStartTime: editorStartTime,
                editorEndTime: editorEndTime,
                editorState: editorState,
                planCollegeId: planCollegeId,
                editorOp: "editor"
            },
            dataType: 'text',
            //success: function (succ) {
            //    alert(succ);
            //    jump(parseInt(sessionStorage.getItem("page")));
            //}
            success: function (succ) {
                if (succ == "更新成功") {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            jump(1);
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
        })
    })

    //删除批次
    $(".planDelete").click(function () {
        var deletePlanId = $(this).parent().parent().children("td").get(1).id;
        var result = confirm("您确定删除吗？如果该条记录没有关联其他表，将会直接删除！");
        if (result == true) {
            $.ajax({
                type: 'Post',
                url: 'batchList.aspx',
                data: {
                    deletePlanId: deletePlanId,
                    delOp: "del"
                },
                dataType: 'text',
                //success: function (succ) {
                //    alert(succ);
                //    jump(parseInt(sessionStorage.getItem("page")));
                //}
                success: function (succ) {
                    if (succ == "删除成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                jump(parseInt(sessionStorage.getItem("page")));
                            }
                        });
                    } else {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                                jump(parseInt(sessionStorage.getItem("page")));
                            }
                        });
                    }
                }
            })
        }
    })

    //判断登录的管理员，对批次表格权限进行限制
    var userState = $("#userState").val();
    if (userState == "0") {
        $(".planEditor").hide();
        $(".planDelete").hide();
        $(".planSearch").show();
    }
    else if (userState == "2") {
        $(".planEditor").show();
        $(".planDelete").show();
        $(".planSearch").hide();
    }

    //详细信息模态框数据绑定
    $(".planSearch").click(function () {
        var planId = $(this).parent().parent().find(".planNO").text().trim(),
            planName = $(this).parent().parent().find(".planNO").next().text().trim(),
            startTime = $(this).parent().parent().find(".planNO").next().next().text().trim(),
            endTime = $(this).parent().parent().find(".planNO").next().next().next().text().trim(),
            state = $(this).parent().parent().find(".planNO").next().next().next().next().text().trim(),
            collegeName = $(this).parent().parent().find(".planNO").next().next().next().next().next().text().trim();
        $("#searchPlanId").text(planId);
        $("#searchPlanName").text(planName);
        $("#searchStartTime").text(startTime);
        $("#searchEndTime").text(endTime);
        $("#searchState").text(state);
        $("#searchCol").text(collegeName);
    })
})
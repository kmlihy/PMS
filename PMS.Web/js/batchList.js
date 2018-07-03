//时间选择器
$(function () {
    $(".datetimepicker").datepicker({
        dateFormat: 'yy/mm/dd',//显示日期格式
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
    $("#btn-Del").click(function () {
        alert(sessionStorage.getItem("page") + sessionStorage.getItem("countPage"));
    })
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
    //点击查询
    $("#search").click(function () {
        var strWhere = $("#inputsearch").val();
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
    });
    //地址栏显示信息
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "batchList.aspx?currentPage=" + cur
        }
        else {
            window.location.href = "batchList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    }
    //当总页数为1时，首页与尾页按钮隐藏
    if (sessionStorage.getItem("count") === "1") {
        $("#first").hide();
        $("#last").hide();
    }

    //添加批次
    $("#savePlan").click(function () {
        var planName = $("#planName").val(),
            startTime = $("#startTime").val(),
            endTime = $("#endTime").val(),
            state = $("#state").find("option:selected").val(),
            college = $("#collegeId").find("option:selected").val();
        if (planName == "" || state == "" || startTime == "" || endTime == "" || state == "" || college == "") {
            alert("不能为空")
        }
        else {
            alert("ajax");
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
                    alert(succ);
                    jump(1);
                }
            })
        }
    })
    //编辑批次
    $(".planEditor").click(function () {
        var editorName = $(this).parent().prev("td").prev("td").prev("td").prev("td").prev("td").text().trim(),
            editorStart = $(this).parent().prev("td").prev("td").prev("td").prev("td").text().trim(),
            editorEnd = $(this).parent().prev("td").prev("td").prev("td").text().trim(),
            editorState = $(this).parent().prev("td").prev("td").find(".stateData").text().trim(),
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
    });
    $(".planCollegeId").hide();
    $(".planId").hide();
    $(".saveEditor").click(function () {
        var editorPlanId = $(".planId").text(),
            editorPlanName = $(".editorPlanName").val(),
            editorStartTime = $(".editorStartTime").val(),
            editorEndTime = $(".editorEndTime").val(),
            editorState = $(".editorState").val(),
            planCollegeId = $(".planCollegeId").text();
        alert("ajax");
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
            success: function (succ) {
                alert(succ);
                jump(1);
            }
        })
    })

    //删除批次
    $(".planDelete").click(function () {
        var deletePlanId = $(this).parent().parent().children("td").get(1).id;
        //alert(deletePlanId);
        $.ajax({
            type: 'Post',
            url: 'adminList.aspx',
            data: {
                deletePlanId: deletePlanId,
                op: "dele"
            },
            dataType: 'text',
            success: function (succ) {
                alert(succ);
                jump(parseInt(sessionStorage.getItem("page")));
            }
        })
    })
})
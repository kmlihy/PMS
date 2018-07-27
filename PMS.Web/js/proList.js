//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

$(document).ready(function () {
    //列表导入
    sessionStorage.removeItem("strWhere")
    $(".file").on("change", "input[type='file']", function () {
        var filePath = $(this).val();
        if (filePath.indexOf("xls") != -1 || filePath.indexOf("xlsx") != -1) {
            $(".fileerrorTip").html("").hide();
            var arr = filePath.split('\\');
            var fileName = arr[arr.length - 1];
            $(".showFileName").html(fileName);
        } else {
            $(".showFileName").html("");
            $(".fileerrorTip").html("您未上传文件，或者您上传文件类型有误！").show();
            return false
        }
    })
    //点击下载模板事件
    $("#downfile").click(function () {
        var $eleForm = $("<form method='get'></form>");
        $eleForm.attr("action", "../upload/信息模板下载/专业批量导入模板.xlsx");
        $(document.body).append($eleForm);
        //提交表单，实现下载
        $eleForm.submit();
    })

    //翻页实现
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            case ('<span class="iconfont icon-back"></span>'):
                if (parseInt(sessionStorage.getItem("Page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("Page")) - 1);
                    break;
                }
                else {
                    jump(1);
                    break;
                }

            case ('<span class="iconfont icon-more"></span>'):
                if (parseInt(sessionStorage.getItem("Page")) < parseInt(sessionStorage.getItem("countPage"))) {
                    jump(parseInt(sessionStorage.getItem("Page")) + 1);
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
    //查询按钮点击事件
    $("#btn-search").click(function () {
        var strWhere = $("#inputsearch").val();
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
    });
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "proList.aspx?currentPage=" + cur;
        } else {
            window.location.href = "proList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    };
    if (sessionStorage.getItem("countPage") == "1") {
        $("#first").hide();
        $("#last").hide();
    }
    //专业输入验证
    $("#proName").blur(function () {
        proName = $("#proName").val();
        var pattern = /^[\u4E00-\u9FA5A-Za-z0-9_]+$/;
        if (proName == "") {
            $("#validata").html("专业名称不能为空").css("color", "red");
        } else if (!pattern.test(proName)) {
            $("#validata").html("专业名称不能包含特殊字符").css("color", "red");
        }
    })
    $("#proName").focus(function () {
        $("#validata").text("");
    })
    //添加按钮事件
    $("#btnAdd").click(function () {
        var collegeId = $("#selectcol").find("option:selected").val(),
            proName = $("#proName").val();
        if (collegeId == "-1" || proName == "") {
            alert("含有未填项，请检查！");
        }
        else {
            $.ajax({
                type: 'Post',
                url: 'proList.aspx',
                data: { collegeId: collegeId, proName: proName, op: "add" },
                dataType: 'text',
                success: function (succ) {
                    if (succ == "添加成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                sessionStorage.removeItem("strWhere")
                                jump(1);
                            }
                        });
                    } else if (succ == "添加失败") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                                sessionStorage.removeItem("strWhere")
                                jump(1);
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
            });
        }
    })
    //添加验证
    $("#p_proName").blur(function () {
        proName = $("#p_proName").val();
        var pattern = /^[\u4E00-\u9FA5A-Za-z0-9_]+$/;
        if (proName == "") {
            $("#validate").html("专业名称不能为空").css("color", "red");
        } else if (!pattern.test(proName)) {
            $("#validate").html("专业名称不能包含特殊字符").css("color", "red");
        }
    })
    $("#p_proName").focus(function () {
        $("#validate").text("");
    })
    //专业信息查看
    $(".changebtn").click(function () {
        $("#btnSave").hide();
        $("#btnch").show();
        var proId = $(this).parent().parent().find("#tdproId").text();
        $(".bootstrap-select").hide();
        $("#colname").val($(this).parent().parent().find("#tdcollegeName").text());
        $("#colname").css("max-width", "140px");
        $("#p_proName").val($(this).parent().parent().find("#tdproName").text());
        $("#p_proName").css("max-width", "140px");
        //点击关闭清除ID
        $(".chID").click(function () {
            proId = "";
            $("#colname").show();
            $(".bootstrap-select").hide();
            $("#p_proName").attr("readonly", true);
            $("#validate").text("");
        })
        //编辑按钮点击事件
        $("#btnch").click(function () {
            $(".bootstrap-select").show();
            $("#colname").hide();
            $("#p_proName").attr("readonly", false);
            $("#btnch").hide();
            $("#btnSave").show();
        })
        //保存更改事件
        $("#btnSave").click(function () {
            var proName = $("#p_proName").val(),
              collegeId = $("#collegeSelect").find("option:selected").val();
            if (collegeId == "-1") {
                alert("请选择院系");
            }
            else {
                $.ajax({
                    type: 'Post',
                    url: 'proList.aspx',
                    data: { ProId: proId, ProName: proName, CollegeId: collegeId, op: "change" },
                    dataType: 'text',
                    success: function (succ) {
                        if (succ == "修改成功") {
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
                });
            }
        })
    })
    //删除事件
    $(".btnDel").click(function () {
        var delproId = $(this).parent().parent().find("#tdproId").text().trim();
        var txt = "是否确认删除？";
        var option = {
            title: "提示",
            btn: parseInt("0011", 2),
            onOk: function () {
                $.ajax({
                    type: 'Post',
                    url: 'proList.aspx',
                    data: {
                        DelProId: delproId,
                        op: "del"
                    },
                    dataType: 'text',
                    success: function (succ) {
                        if (succ == "删除成功") {
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
            }
        }
        window.wxc.xcConfirm(txt, "confirm", option);
    })
});
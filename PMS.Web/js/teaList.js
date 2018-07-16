//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);
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
$(document).ready(function () {
    //分页参数传递
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
    //传值到后台事件
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "teaList.aspx?currentPage=" + cur;
        } else {
            window.location.href = "teaList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    };
    if (sessionStorage.getItem("countPage") == "1") {
        $("#first").hide();
        $("#last").hide();
    }
    //添加教师验证
    //账号验证
    $("#teaAccount").blur(function () {
        teaAccount = $("#teaAccount").val();
        var pattern = /[a-zA-Z0-9_]{6,10}/;
        if (!pattern.test(teaAccount)) {
            $("#validateAccount").html("请输入6位以上的字母或数字").css("color", "red")
        }
    })
    $("#teaAccount").focus(function () {
        $("#validateAccount").html("");
    })
    //姓名验证
    $("#teaName").blur(function () {
        teaAccount = $("#teaName").val();
        var pattern = /^[a-zA-Z\u4e00-\u9fa5]+$/
        if (!pattern.test(teaAccount)) {
            $("#validateName").html("姓名不能含有特殊字符且不能是数字").css("color", "red")
        }
    })
    $("#teaName").focus(function () {
        $("#validateName").html("");
    })
    //邮箱验证
    $("#email").blur(function () {
        teaAccount = $("#email").val();
        var pattern = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
        if (!pattern.test(teaAccount)) {
            $("#validateEmal").html("邮箱格式不正确").css("color", "red")
        }
    })
    $("#email").focus(function () {
        $("#validateEmal").html("");
    })
    //电话验证
    $("#tel").blur(function () {
        teaAccount = $("#tel").val();
        var pattern = /^1[34578]\d{9}$/;
        if (!pattern.test(teaAccount)) {
            $("#validateTel").html("请输入正确的手机号码").css("color", "red")
        }
    })
    $("#tel").focus(function () {
        $("#validateTel").html("");
    })
    //关闭清除提示
    $(".addclose").click(function () {
        $("#validateAccount").html("");
        $("#validateTel").html("");
        $("#validateName").html("");
        $("#validateEmal").html("");
    })
    //教师添加函数
    $("#btnAdd").click(function () {
        var collegeId = $("#addselectcol").find("option:selected").val(),
            teaType = $("#addteaType").find("option:selected").val(),
            teaAccount = $("#teaAccount").val(),
            pwd = $("#pwd").val(),
            teaName = $("#teaName").val(),
            sex = $("#sex").find("option:selected").text(),
            email = $("#email").val(),
            tel = $("#tel").val();
        if (collegeId == "" || teaAccount == "" || pwd == "" || teaName == "" || email == "" || tel == "") {
            alert("不能含有空项")
        }
        else {
            $.ajax({
                type: 'Post',
                url: 'teaList.aspx',
                data: {
                    CollegeId: collegeId,
                    TeaType: teaType,
                    TeaAccount: teaAccount,
                    Pwd: pwd,
                    TeaName: teaName,
                    Sex: sex,
                    Email: email,
                    Tel: tel,
                    op: "add"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ == "添加成功") {
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
    //密码框默认隐藏
    $(".cstdteaPwd").hide();
    //编辑验证
    //账号验证
    $("#chteaAccount").blur(function () {
        teaAccount = $("#chteaAccount").val();
        var pattern = /[a-zA-Z0-9_]{6,10}/;
        if (!pattern.test(teaAccount)) {
            $("#chValitateAccount").html("请输入6位以上的字母或数字").css("color", "red")
        }
    })
    $("#chteaAccount").focus(function () {
        $("#chValitateAccount").html("");
    })
    //姓名验证
    $("#chteaName").blur(function () {
        teaAccount = $("#chteaName").val();
        var pattern = /^[a-zA-Z\u4e00-\u9fa5]+$/
        if (!pattern.test(teaAccount)) {
            $("#chValitateteaName").html("姓名不能含有特殊字符且不能是数字").css("color", "red")
        }
    })
    $("#chteaName").focus(function () {
        $("#chValitateteaName").html("");
    })
    //邮箱验证
    $("#chemail").blur(function () {
        teaAccount = $("#chemail").val();
        var pattern = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
        if (!pattern.test(teaAccount)) {
            $("#chValitateteaemail").html("邮箱格式不正确").css("color", "red")
        }
    })
    $("#chemail").focus(function () {
        $("#chValitateteaemail").html("");
    })
    //电话验证
    $("#chtel").blur(function () {
        teaAccount = $("#chtel").val();
        var pattern = /^1[34578]\d{9}$/;
        if (!pattern.test(teaAccount)) {
            $("#chValitateteatel").html("请输入正确的手机号码").css("color", "red")
        }
    })
    $("#chtel").focus(function () {
        $("#chValitateteatel").html("");
    })
    //查看教师信息点击事件
    $(".changebtn").click(function () {
        $(".bootstrap-select").hide();
        $("#tr-pwd").hide();
        $("#chbtn").hide();
        $("#chteaAccount").show();
        $("#chteaName").show();
        $("#chemail").show();
        $("#chtel").show();
        $("#p-collegeName").show();
        $("#p-chteaType").show();
        $("#p-chsex").show();
        //控件不可编辑
        $("#chemail").attr("disabled", "disabled");//改成disabled
        $("#chtel").attr("disabled", "disabled");//改成disabled
        $("#chteaName").attr("disabled", "disabled");//改成disabled
        $("#chteaAccount").attr("disabled", "disabled");//改成disabled


        $("#p-chteaType").text($(this).parent().parent().find("#tdteatype").text());
        $("#p-chsex").text($(this).parent().parent().find("#tdteaSex").text());
        $("#p-collegeName").text($(this).parent().parent().find("#tdteacoll").text());

        //获得基础信息
        $("#chteaAccount").val($(this).parent().parent().find("#tdteaAccount").text().trim());
        $("#chpwd").val($(this).parent().parent().find("#tdteaPwd").text().trim());
        $("#chteaName").val($(this).parent().parent().find("#tdteaName").text().trim());
        $("#chemail").val($(this).parent().parent().find("#tdteaEmail").text().trim());
        $("#chtel").val($(this).parent().parent().find("#tdteaTel").text().trim())
    });
    //关闭按钮事件
    $(".chID").click(function () {
        $(".btnch").show();

        //控件状态改变
        $("#chemail").attr("disabled", "disabled");//改成disabled
        $("#chtel").attr("disabled", "disabled");//改成disabled
        $("#chteaName").attr("disabled", "disabled");//改成disabled
        $("#chteaAccount").attr("disabled", "disabled");//改成disabled
        //清除提示
        $("#chValitateAccount").html("");
        $("#chValitateteaName").html("");
        $("#chValitateteaemail").html("");
        $("#chValitateteatel").html("");
    })
    //编辑按钮点击事件
    $(".btnch").click(function () {
        //点击编辑按钮控件可输入
        $("#chemail").removeAttr("disabled");
        $("#chtel").removeAttr("disabled");
        $("#chteaName").removeAttr("disabled");
        $("#chteaAccount").removeAttr("disabled");
        //隐藏
        $("#p-collegeName").hide();
        $("#p-chteaType").hide();
        $("#p-chsex").hide();
        $("#chbtn").hide();
        $(".btnch").hide();
        //展示保存按钮
        $("#chbtn").show();
        $(".bootstrap-select").show();
        $("#tr-pwd").show();

    })
    //编辑完成保存
    $("#chbtn").click(function () {
        var teaAccount = $(".chteaAccount").val(),
        teaName = $(".chteaName").val(),
        teaEmail = $(".chemail").val(),
        teaPhone = $(".chtel").val(),
        pwd = $(".chpwd").val(),
        collegeId = $("#chselectcol").find("option:selected").val(),
        sex = $("#chsex").find("option:selected").text(),
        teaType = $("#chteaType").find("option:selected").val();
        if (teaEmail == "" || teaPhone == "" || pwd == "" || collegeId == "-1") {
            alert("不能含有未填项");
        }
        else {
            $.ajax({
                type: 'Post',
                url: 'teaList.aspx',
                data: {
                    TeaAccount: teaAccount,
                    TeaName: teaName,
                    TeaEmail: teaEmail,
                    TeaPhone: teaPhone,
                    Pwd: pwd,
                    CollegeId: collegeId,
                    Sex: sex,
                    TeaType: teaType,
                    op: "change"
                },
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
            $(".btnch").show();
        }
    })

    //删除事件
    $(".btnDel").click(function () {
        var teaAccount = $(this).parent().parent().find("#tdteaAccount").text().trim();
        var txt = "是否确认删除？";
        var option = {
            title: "提示",
            btn: parseInt("0011", 2),
            onOk: function () {
                $.ajax({
                    type: 'Post',
                    url: 'teaList.aspx',
                    data: {
                        TeaAccount: teaAccount,
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
    });
    //点击下载模板事件
    $("#downfile").click(function () {
        var $eleForm = $("<form method='get'></form>");
        $eleForm.attr("action", "../upload/信息模板下载/教师批量导入模板.xlsx");
        $(document.body).append($eleForm);
        //提交表单，实现下载
        $eleForm.submit();
    })
});
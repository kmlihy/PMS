﻿//存储当前页
sessionStorage.setItem("page", $("#page").val());
//存储总页数
sessionStorage.setItem("countPage", $("#countPage").val());
//存储查询条件
$(document).ready(function () {
    //删除学生
    $(".deleteStudent").click(function () {
        var stuId = $(this).parent().parent().find(".stuNO").text().trim();
        var result = confirm("您确定删除吗？如果该条记录没有关联其他表，将会直接删除！");
        if (result == true) {
            $.ajax({
                type: 'Post',
                url: 'stuLIst.aspx',
                data: {
                    stuId: stuId,
                    op: "delete"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ == "删除成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                jump(parseInt(sessionStorage.getItem("page")));
                                //    jump(parseInt(sessionStorage.getItem("page")));
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
    //按钮查询
    $("#search").click(function () {
        var strWhere = $("#inputsearch").val();
        sessionStorage.setItem("strWhere", strWhere);
        sessionStorage.setItem("type", "btn");
        jump(1);
    });
    //下拉选项查询
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

    //分页
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
    //判断当前也的pagesize，当为0时，页数向前一页
    
    //地址栏显示信息
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null && sessionStorage.getItem("dropstrWhere") == null) {
            window.location.href = "stuLIst.aspx?currentPage=" + cur;
        }
        else if (sessionStorage.getItem("strWhere") != null && sessionStorage.getItem("dropstrWhere")==null) {
            window.location.href = "stuLIst.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
        }
        else if(sessionStorage.getItem("strWhere")==null&&sessionStorage.getItem("dropstrWhere")!=null){
            window.location.href = "stuLIst.aspx?currentPage=" + cur + "&dropstrWhere=" + sessionStorage.getItem("dropstrWhere") + "&type=" + sessionStorage.getItem("type");
        }
        else {
            window.location.href = "stuLIst.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&dropstrWhere=" + sessionStorage.getItem("dropstrWhere") + "&type=" + sessionStorage.getItem("type");
        }
    };
    //编辑学生
    //获取学生信息到编辑框
    $(".Editor").click(function(){
        var stuNO = $(this).parent().parent().find(".stuNO").text().trim();
        $(".editorStuNO").val(stuNO);//学号框获取学号
        var stuName = $(this).parent().parent().find(".stuName").text().trim();
        $(".editorStuName").val(stuName);//姓名框获取姓名
        var stuSex = $(this).parent().parent().find(".stuSex").text().trim();
        $(".editorStuSex").val(stuSex);//性别框获取性别
        var stuPro = $(this).parent().parent().find(".stuPro").next().text().trim();
        $(".editorPro").val(stuPro);//专业框获取专业
        var stuProId = $(this).parent().parent().find(".stuPro").text().trim();//专业Id
        $(".stuProId").text(stuProId);//专业ID框获取专业ID
        var stuCollege = $(this).parent().parent().find(".stuCollege").next().text().trim();
        $(".editorCollege").val(stuCollege);//学院框获取学院
        var stuColId = $(this).parent().parent().find(".stuCollege").text().trim();//学院ID
        $(".stuCollegeId").text(stuColId);//学院ID框获取学院ID
        var stuPhone = $(this).parent().parent().find(".stuPhone").text().trim();
        $(".editorPhone").val(stuPhone);//电话框获取电话
        var stuEmail = $(this).parent().parent().find(".stuPhone").next().text().trim();
        $(".editorEmail").val(stuEmail);//邮箱框获取邮箱
        var stuPwd = $(this).parent().next().find("input").val();
        $(".editorStuPwd").val(stuPwd);
    });
    //按钮隐藏
    $(".selectCollege").hide();//院系选择下拉框
    $(".stuCollegeId").hide();//存储学院ID
    $(".stuProId").hide();//存储专业ID
    $(".selectSex").hide();//性别选择下拉框
    $(".selectPro").hide();//专业选择下拉框
    $("#btnSure1").hide();
    $("#btnSure2").hide();
    $("#btnSure3").hide();

    //点击性别编辑按钮
    $("#btnEditor1").click(function () {
        $(this).hide();
        $("#btnSure1").show();
        $(".selectSex").show();
        $(".editorStuSex").hide();
    })
    //点击确定按钮
    $("#btnSure1").click(function () {
        var sex = $(".selectStuSex").find("option:selected").val();
        $(".editorStuSex").val(sex);
        $(this).hide();
        $("#btnEditor1").show();
        $(".editorStuSex").show();
        $(".selectSex").hide();
    })

    //点击专业编辑按钮
    $("#btnEditor3").click(function () {
        $(this).hide();
        $("#btnSure3").show();
        $(".selectPro").show();
        $(".editorPro").hide();
    })
    //点击确定按钮
    $("#btnSure3").click(function () {
        var pro = $(".selectStuPro").find("option:selected").text().trim(),
            proId = $(".selectStuPro").find("option:selected").val();
        $(".stuProId").text(proId);
        $(".editorPro").val(pro);
        $(this).hide();
        $("#btnEditor3").show();
        $(".editorPro").show();
        $(".selectPro").hide();
    })

    //点击提交按钮,完成编辑
    $("#saveChange").click(function () {
        var stuNO = $(".editorStuNO").val(),
            stuName = $(".editorStuName").val(),
            stuSex = $(".editorStuSex").val(),
            stuCollege = $(".stuCollegeId").text(),
            stuPro = $(".stuProId").text(),
            stuEmail = $(".editorEmail").val(),
            stuPhone = $(".editorPhone").val(),
            stuPwd = $(".editorStuPwd").val();
        //alert("ajax");
        $.ajax({
            type: 'Post',
            url: 'stuLIst.aspx',
            data: {
                stuNO: stuNO,
                stuName: stuName,
                stuSex: stuSex,
                stuCollege: stuCollege,
                stuPro: stuPro,
                stuEmail: stuEmail,
                stuPhone: stuPhone,
                stuPwd: stuPwd,
                editorOp: "editor"
            },
            dataType: 'text',
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

    //添加模态框验证
    //学号验证
    var pattern = /[a-zA-Z0-9_]{6,10}/;
    $("#stuAccount").blur(function () {
        var stuAccount = $("#stuAccount").val();
        if (!pattern.test(stuAccount)) {
            $("#stu_NO").html("学号只能为数字").css("color", "red");
        }
    })
    $("#stuAccount").focus(function () {
        $("#stu_NO").html("");
    })
    //姓名验证
    $("#realName").blur(function () {
        name = $(this).val();
        var pattern = /^[a-zA-Z\u4e00-\u9fa5]+$/
        if (!pattern.test(name)) {
            $("#stu_name").html("姓名不能含有特殊字符且不能是数字").css("color", "red")
        }
    })
    $("#realName").focus(function () {
        $("#stu_name").html("");
    })
    //邮箱验证
    $("#email").blur(function () {
        teaAccount = $("#email").val();
        var pattern = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
        if (!pattern.test(teaAccount)) {
            $("#stu_email").html("邮箱格式不正确").css("color", "red")
        }
    })
    $("#email").focus(function () {
        $("#stu_email").html("");
    })
    //电话验证
    $("#phone").blur(function () {
        teaAccount = $("#tel").val();
        var pattern = /^1[34578]\d{9}$/;
        if (!pattern.test(teaAccount)) {
            $("#stu_phone").html("请输入正确的手机号码").css("color", "red")
        }
    })
    $("#phone").focus(function () {
        $("#stu_phone").html("");
    })
    //添加学生
    $("#saveSutdent").click(function () {
        var stuAccount = $("#stuAccount").val(),
            pwd = $("#pwd").val(),
            realName = $("#realName").val(),
            sex = $("#sex").find("option:selected").val(),
            pro = $("#pro").find("option:selected").val(),
            phone = $("#phone").val(),
            email = $("#email").val();
        if (stuAccount == "" || pwd == "" || realName == "" || sex == "" || pro == "" || phone == "" || email == "") {
            alert("不能出现未填项！");
        }
        else {
            alert("ajax");
            $.ajax({
                type: 'Post',
                url: 'stuLIst.aspx',
                data: {
                    stuAccount: stuAccount,
                    pwd: pwd,
                    realName: realName,
                    sex: sex,
                    pro: pro,
                    phone: phone,
                    email: email,
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
    })

    //密码表格隐藏
    $(".stuPwd").hide();
    if (parseInt(sessionStorage.getItem("page")) > parseInt(sessionStorage.getItem("countPage"))) {
        {
            jump(parseInt(sessionStorage.getItem("page")) - 1);
        }
    }

})
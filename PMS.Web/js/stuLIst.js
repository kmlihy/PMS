//存储当前页
sessionStorage.setItem("page", $("#page").val());
//存储总页数
sessionStorage.setItem("countPage", $("#countPage").val());
$(document).ready(function () {
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
    //查询
    $("#search").click(function () {
        var strWhere = $("#inputsearch").val();
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
    });
    //地址栏显示信息
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "stuLIst.aspx?currentPage=" + cur
        }
        else {
            window.location.href = "stuLIst.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    }
    //编辑学生
    //获取学生信息到编辑框
    $(".Editor").click(function () {
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
                alert(succ);
                jump(1);
            }
        })
    })

    //添加模态框验证
    //学号
    $("#stuAccount").blur(function () {
        var stuAccount = $("#stuAccount").val();
        var pattern = /[a-zA-Z0-9_]/
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
                    alert(succ);
                    jump(1);
                }
            })
        }
    })

    //删除学生
    $(".deleteStudent").click(function () {
        var stuId = $(this).parent().parent().find(".stuNO").text().trim();
        $.ajax({
            type: 'Post',
            url: 'stuLIst.aspx',
            data: {
                stuId: stuId,
                op: "delete"
            },
            dataType: 'text',
            success: function (succ) {
                alert(succ);
                jump(parseInt(sessionStorage.getItem("page")));
            }
        })
    })
    //下拉选项查询
    $("#chooseStuPro").change(function () {
        var strWhere = $(this).find("option:selected").text().trim();
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
    })
    //密码表格隐藏
    $(".stuPwd").hide();
})
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
        var stuNO = $(this).parent().parent().find(".stuNO").text().trim(),
            stuName = $(this).parent().parent().find(".stuName").text().trim(),
            stuSex = $(this).parent().parent().find(".stuSex").text().trim(),
            stuPro = $(this).parent().parent().find(".stuPro").text().trim(),
            stuProId = $(this).parent().parent().children("td").get(4).id,//专业Id
            stuCollege = $(this).parent().parent().find(".stuCollege").text().trim(),
            stuColId = $(this).parent().parent().children("td").get(5).id;//学院ID
        stuPhone = $(this).parent().parent().find(".stuPhone").text().trim(),
        stuEmail = $(this).parent().parent().find(".stuEmail").text().trim();
        $(".editorStuNO").val(stuNO);
        $(".editorStuName").val(stuName);
        $(".editorStuSex").val(stuSex);
        $(".editorCollege").val(stuCollege);
        $(".editorPro").val(stuPro);
        $(".editorEmail").val(stuEmail);
        $(".editorPhone").val(stuPhone);
        $(".stuCollegeId").text(stuColId);
        $(".stuProId").text(stuProId);
    });
    $(".stuCollegeId").hide();
    $(".stuProId").hide();
    //点击提交按钮
    $("#saveChange").click(function () {
        var stuNO = $(".editorStuNO").val(),
            stuName = $(".editorStuName").val(),
            stuSex = $(".editorStuSex").val(),
            stuCollege = $(".stuCollegeId").text(),
            stuPro = $(".stuProId").text(),
            stuEmail = $(".editorEmail").val(),
            stuPhone = $(".editorPhone").val();
        //alert(stuNO+stuPro+stuEmail);
        alert("ajax");
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
                editorOp: "editor"
            },
            dataType: 'text',
            success: function (succ) {
                alert(succ);
                jump(1);
            }
        })
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
})
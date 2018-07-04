//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);
$(document).ready(function () {
    //分页参数传递
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            case ('<span class="glyphicon glyphicon-chevron-left"></span>'):
                if (parseInt(sessionStorage.getItem("Page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("Page")) - 1);
                    break;
                }
                else {
                    jump(1);
                    break;
                }

            case ('<span class="glyphicon glyphicon-chevron-right"></span>'):
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
    //教师添加函数
    $("#btnAdd").click(function () {
        var collegeId = $("#selectcol").find("option:selected").val(),
            teaType = $("#teaType").find("option:selected").val(),
            teaAccount = $("#teaAccount").val(),
            pwd = $("#pwd").val(),
            teaName = $("#teaName").val(),
            sex = $("#sex").find("option:selected").text(),
            email = $("#email").val(),
            tel = $("#tel").val();
        if (collegeId == "") {
            alert("不能为空")
        }
        else {
            alert("ajax");
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
                    alert(succ);
                    jump(1);
                }
            });
        }
    })
    //查看教师信息
    $(".changebtn").click(function () {
        var btnState = 1;
        //关闭改变btnstate状态
        $("#closeModel").click(function () {
            btnState = 1;
            $("#chbtn").text("编辑");
        })
        $(".bootstrap-select").hide();
        $("#tr-pwd").hide();
        $("#chteaAccount").hide();
        $("#chteaName").hide();
        $("#chemail").hide();
        $("#chtel").hide();

        $("#p-collegeName").show();
        $("#p-chteaType").show();
        $("#p-chsex").show();
        $("#p-chteaAccount").show();
        $("#p-chteaName").show();
        $("#p-chemail").show();
        $("#p-chtel").show();

        $("#p-chteaType").text($(this).parent().parent().find("#tdteatype").text());
        $("#p-chsex").text($(this).parent().parent().find("#tdteaSex").text());
        $("#p-collegeName").text($(this).parent().parent().find("#tdteacoll").text());
        $("#p-chteaAccount").text($(this).parent().parent().find("#tdteaAccount").text());
        $("#p-chteaName").text($(this).parent().parent().find("#tdteaName").text());
        $("#p-chemail").text($(this).parent().parent().find("#tdteaEmail").text());
        $("#p-chtel").text($(this).parent().parent().find("#tdteaTel").text());

        $("#chteaAccount").val($(this).parent().parent().find("#tdteaAccount").text().trim());
        $("#chpwd").val("");
        $("#chteaName").val($(this).parent().parent().find("#tdteaName").text().trim());
        $("#chemail").val($(this).parent().parent().find("#tdteaEmail").text().trim());
        $("#chtel").val($(this).parent().parent().find("#tdteaTel").text().trim())

        //$(this).parent().parent().find("#sex").text();
        //$(this).parent().parent().find("#collegeName").text();
        //$(this).parent().parent().find("#teaType").text();
        //编辑完成保存
        $("#chbtn").click(function () {
            switch (btnState) {
                case (0):
                    var teaAccount = $("#chteaAccount").val(),
                    teaName = $("#chteaName").val(),
                    teaEmail = $("#chemail").val(),
                    teaPhone = $("#chtel").val(),
                    pwd = $("#chpwd").val(),
                    collegeId = $("#chselectcol").find("option:selected").val(),
                    sex = $("#chsex").find("option:selected").text(),
                    teaType = $("#chteaType").find("option:selected").val();
                    if (teaAccount == "" || teaEmail == "" || teaPhone == "" || pwd == "" || collegeId == 0 || sex == "-请选择性别-") {
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
                                alert(succ);
                                jump(1);
                            }
                        });
                        btnState = 1;
                        break;
                    }
                case (1):
                    $("#p-collegeName").hide();
                    $("#p-chteaType").hide();
                    $("#p-chsex").hide();
                    $("#p-chteaAccount").hide();
                    $("#p-chteaName").hide();
                    $("#p-chemail").hide();
                    $("#p-chtel").hide();

                    $(".bootstrap-select").show();
                    $("#tr-pwd").show();
                    $("#chteaAccount").show();
                    $("#chteaName").show();
                    $("#chemail").show();
                    $("#chtel").show();
                    $(this).text("保存");
                    return btnState = 0;
                    break;
            }
        })
    });
    //删除事件
    $(".isdelete").click(function () {

    });

});
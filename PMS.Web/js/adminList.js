//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

$(document).ready(function () {
    //防止当前页数大于总页数
    var page = parseInt(sessionStorage.getItem("page"));
    var countPage = parseInt(sessionStorage.getItem("countPage"));
    if (page > countPage) {
        sessionStorage.setItem("page", countPage);
        jump(parseInt(sessionStorage.getItem("page")));
    }
    //正则表达式
    var txtAccount = /^[0-9]*$/; //数字的正则表达式
    var txtName = /^[a-zA-Z\u4e00-\u9fa5]+$/; //汉字、英文的正则表达式
    var txtEmail = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/; //邮箱的正则表达式
    var TelNum = /^1[3,5,4,7,8]\d{9}$/; //联系电话的正则表达式
    var txtPwd = /^[0-9a-zA-Z_]{1,}$/; //数字、英文、下划线的正则表达式
    //点击翻页按钮
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            //点击上一页按钮时
            case ('<span class="iconfont icon-back"></span>'):
                if (parseInt(sessionStorage.getItem("page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("page")) - 1);
                    sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) - 1);
                    break;
                } else {
                    jump(1);
                    break;
                }
            //点击下一页按钮时
            case ('<span class="iconfont icon-more"></span>'):
                if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {
                    jump(parseInt(sessionStorage.getItem("page")) + 1);
                    sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) + 1);
                    break;
                } else {
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
                }
            //点击首页按钮时
            case ("首页"):
                jump(1);
                break;
            //点击尾页按钮时
            case ("尾页"):
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
        }
    });
    //点击查询按钮时
    $("#btn-search").click(function () {
        var strWhere = $("#inputsearch").val();
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
    });
    //翻页时获取当前页数
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") === null) {
            window.location.href = "adminList.aspx?currentPage=" + cur
        } else {
            window.location.href = "adminList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    }
    //当总页数为1时，首页与尾页按钮隐藏
    if (sessionStorage.getItem("countPage") === "1") {
        $("#first").hide();
        $("#last").hide();
    }
    //每一次点击新增按钮时弹框清空所有的值
    $("#btn-Add").click(function () {
        $("#Iaccount").val("");
        $("#Iname").val("");
        $("#Isex").val("");
        $("#Icoll").val("");
        $("#Iemail").val("");
        $("#Iphone").val("");
        $("#validateAcoount").html("");
        $("#validateName").html("");
        $("#validateSex").html("");
        $("#validateColl").html("");
        $("#validateEmail").html("");
        $("#validateTel").html("");
    })
    //添加分院管理员对象
    $("#btnInsert").click(function () {
        var account = $("#Iaccount").val(),
            name = $("#Iname").val(),
            sex = $("#Isex").val(),
            college = $("#Icoll").val(),
            email = $("#Iemail").val(),
            phone = $("#Iphone").val();
        //alert(account + ":" + name + ":" + sex + ":" + college + ":" + email + ":" + phone);
        //alert($("#Icoll").val() + " : " + $("#Icoll").find("option:selected").text())
        if (account === "") {
            $("#validateAcoount").html("账号不能为空！").css("color", "red");
        }else if (!txtAccount.test(account)) {
            $("#validateAccount").html("账号只能包括数字！").css("color", "red");
        }else if (name === "") {
            $("#validateAcoount").html("")
            $("#validateName").html("姓名不能为空！").css("color", "red");
        } else if (!txtName.test(name)) {
            $("#validateName").html("姓名只能包括汉子/英文字符！").css("color", "red");
        } else if (sex === "") {
            $("#validateName").html("")
            $("#validateSex").html("请选择性别！").css("color", "red");
        } else if (college === "") {
            $("#validateSex").html("")
            $("#validateColl").html("请选择学院！").css("color", "red");
        } else if (email === "") {
            $("#validateColl").html("")
            $("#validateEmail").html("邮箱不能为空！").css("color", "red");
        } else if (!txtEmail.test(email)) {
            $("#validateEmail").html("邮箱地址不合法").css("color", "red");
        } else if (phone === "") {
            $("#validateEmail").html("")
            $("#validateTel").html("联系电话不能为空！").css("color", "red");
        } else if (!TelNum.test(phone)) {
            $("#validateTel").html("联系电话不合法！").css("color", "red");
        }
        else {
            $.ajax({
                type: 'Post',
                url: 'adminList.aspx',
                data: {
                    account: account,
                    name: name,
                    sex: sex,
                    college: college,
                    email: email,
                    phone: phone,
                    op: "add"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "添加成功") {
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
    //点击编辑按钮，编辑弹框绑定数据
    $(".btnEdit").click(function () {
        var Eaccount = $(this).parent().parent().find("#teaAccount").text().trim();
        $("#Eaccount").val(Eaccount);
        var Ename = $(this).parent().parent().find("#teaName").text().trim();
        $("#Ename").val(Ename);
        //var Epwd = $(this).parent().parent().find("#teaPwd").text().trim();
        //$("#Epwd").val(Epwd);
        var EintSex = $(this).parent().parent().find("#sex").text().trim();
        $("#EintSex").val(EintSex);
        var EintColl = $(this).parent().parent().find("#collegeName").text().trim();
        $("#EintColl").val(EintColl);
        var Ephone = $(this).parent().parent().find("#phone").text().trim();
        sessionStorage.setItem("phone", Ephone);
        $("#Ephone").val(Ephone);
        var Eemail = $(this).parent().parent().find("#email").text().trim();
        sessionStorage.setItem("email", Eemail);
        $("#Eemail").val(Eemail);
        var collegeId = $(this).parent().parent().find("#collegeId").val();
        sessionStorage.setItem("collegeId", collegeId);
    })
    //编辑学院
    $("#select").hide();
    //编辑学院-编辑
    sessionStorage.setItem("flag", "false");
    $("#btnEditColl").click(function () {
        $("#select").show();
        $("#input").hide();
        sessionStorage.setItem("flag", "true");
        $(this).hide();
    })
    //编辑性别-编辑
    $("#btnEditSex").click(function () {
        $("#selectSex").show();
        $("#inputSex").hide();
        sessionStorage.setItem("flag", "true");
        $(this).hide();
    })
    //每一次打开编辑弹窗时
    $(".btnEdit").click(function () {
        $("#select").hide();
        $("#input").show();
        $("#btnEditColl").show();
        $("#selectSex").hide();
        $("#inputSex").show();
        $("#btnEditSex").show();
        sessionStorage.setItem("flag", "false");
    })
    //点击提交编辑
    $("#saveEdit").click(function () {
        var Account = $("#Eaccount").val();
        var Name = $("#Ename").val();
        var Phone = $("#Ephone").val();
        var Email = $("#Eemail").val();
        var flag = sessionStorage.getItem("flag");
        var oldCollegeId = sessionStorage.getItem("collegeId");
        var oldEmail = sessionStorage.getItem("email");
        var oldPhone = sessionStorage.getItem("phone");
        var College, Sex;
        if (flag === "false") {
            College = oldCollegeId;
            Sex = $("#EintSex").val();
        } else {
            College = $("#EselColl").val();
            Sex = $("#EselSex").val();
        }
        if (Name === "") {
            $("#validateNameE").html("姓名不能为空！").css("color", "red");
        } else if (!txtName.test(Name)) {
            $("#validateNameE").html("姓名只能包括汉子、英文字符！").css("color", "red");
        }else if (Phone === "") {
            $("#validatePwd").html("")
            $("#validateTelE").html("联系电话不能为空！").css("color", "red");
        } else if (!TelNum.test(Phone)) {
            $("#validateTelE").html("联系电话不合法！").css("color", "red");
        } else if (Email === "") {
            $("#validateTelE").html("")
            $("#validateEmailE").html("邮箱不能为空！").css("color", "red");
        } else if (!txtEmail.test(Email)) {
            $("#validateEmailE").html("邮箱地址不合法").css("color", "red");
        } else {
            $.ajax({
                type: 'Post',
                url: 'adminList.aspx',
                data: {
                    Account: Account,
                    Name: Name,
                    Sex: Sex,
                    College: College,
                    oldCollegeId: oldCollegeId,
                    oldEmail: oldEmail,
                    oldPhone: oldPhone,
                    Email: Email,
                    Phone: Phone,
                    op: "edit"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "更新成功") {
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
    //删除管理员信息
    $(".btnDelete").click(function () {
        var Daccount = $(this).parent().parent().find("#teaAccount").text().trim();
        //Confirm弹窗
        var txt = "确定要删除吗？";
        var option = {
            title: "删除警告",
            btn: parseInt("0011", 2),
            onOk: function () {
                //alert(Daccount);
                $.ajax({
                    type: 'Post',
                    url: 'adminList.aspx',
                    data: {
                        Daccount: Daccount,
                        op: "dele"
                    },
                    dataType: 'text',
                    success: function (succ) {
                        if (succ === "删除成功") {
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
                });
            }
        }
        window.wxc.xcConfirm(txt, "warning", option);
    })
})
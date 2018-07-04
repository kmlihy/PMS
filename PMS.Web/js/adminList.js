//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

$(document).ready(function () {
    //点击翻页按钮
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            //点击上一页按钮时
            case ('<b><span class="iconfont icon-back"></span></b>'):
                if (parseInt(sessionStorage.getItem("page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("page")) - 1);
                    sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) - 1);
                    break;
                } else {
                    jump(1);
                    break;
                }
            //点击下一页按钮时
            case ('<span class="iconfont icon-back"></span>'):
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
    //添加分院管理员对象
    $("#btnInsert").click(function () {
        var account = $("#Iaccount").val(),
            name = $("#Iname").val(),
            sex = $("#Isex").val(),
            college = $("#Icoll").val(),
            email = $("#Iemail").val(),
            phone = $("#Iphone").val();
        //alert(account + ":" + name + ":" + sex + ":" + college + ":" + email + ":" + phone);
        if (account === "") {
            alert("请输入工号");
        } else {
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
                    alert(succ);
                    jump(1);
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
        var Epwd = $(this).parent().parent().find("#teaPwd").text().trim();
        $("#Epwd").val(Epwd);
        var Esex = $(this).parent().parent().find("#sex").text().trim();
        $("#Esex").val(Esex);
        var EintColl = $(this).parent().parent().find("#collegeName").text().trim();
        $("#EintColl").val(EintColl);
        var Ephone = $(this).parent().parent().find("#phone").text().trim();
        $("#Ephone").val(Ephone);
        var Eemail = $(this).parent().parent().find("#email").text().trim();
        $("#Eemail").val(Eemail);
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
    //点击提交编辑
    $("#saveEdit").click(function () {
        var Account = $("#Eaccount").val();
        var Name = $("#Ename").val();
        var Pwd = $("#Epwd").val();
        var Sex = $("#Esex").val();
        var flag = sessionStorage.getItem("flag");
        if (flag == "false") {
            var College = $("#EintColl").val();
        } else {
            var College = $("#EselColl").val();
        }
        var Phone = $("#Ephone").val();
        var Email = $("#Eemail").val();
        if (Account === "") {
            alert("请输入工号");
        } else {
            $.ajax({
                type: 'Post',
                url: 'adminList.aspx',
                data: {
                    Account: Account,
                    Name: Name,
                    Pwd: Pwd,
                    Sex: Sex,
                    College: College,
                    Email: Email,
                    Phone: Phone,
                    op: "edit"
                },
                dataType: 'text',
                success: function (succ) {
                    alert(succ);
                    jump(1);
                }
            });
        }
    })
    //每一次打开编辑弹窗时
    $(".btnEdit").click(function () {
        $("#select").hide();
        $("#input").show();
        $("#btnEditColl").show();
        sessionStorage.setItem("flag", "false");
    })
    //删除分院信息
    $(".btnDelete").click(function () {
        //Confirm弹窗
        var txt = "是否删除？";
        window.wxc.xcConfirm(txt, window.wxc.xcConfirm.typeEnum.warning);
        var Daccount = $(this).parent().parent().find("#teaAccount").text().trim();
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
                alert(succ);
                jump(parseInt(sessionStorage.getItem("page")));
            }
        });
    })
})
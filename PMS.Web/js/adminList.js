$(document).ready(function () {
    //点击翻页按钮
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            //点击上一页按钮时
            case ('<span class="glyphicon glyphicon-chevron-left"></span>'):
                if (parseInt(sessionStorage.getItem("page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("page")) - 1);
                    sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) - 1);
                    break;
                } else {
                    jump(1);
                    break;
                }
            //点击下一页按钮时
            case ('<span class="glyphicon glyphicon-chevron-right"></span>'):
                if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {
                    jump(parseInt(sessionStorage.getItem("page")) + 1);
                    sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) + 1);
                    break;
                } else {
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
                }
                点击首页按钮时
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
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "adminList.aspx?currentPage=" + cur
        } else {
            window.location.href = "adminList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    }
    //当总页数为1时，首页与尾页按钮隐藏
    if (sessionStorage.getItem("countPage") == "1") {
        $("#first").hide();
        $("#last").hide();
    }
    //添加分院对象
    $("#btnInsert").click(function () {
        var account = $("#Iaccount").val(),
            name = $("#Iname").val(),
            sex = $("#Isex").val(),
            college = $("#Icoll").val(),
            email = $("#Iemail").val(),
            phone = $("#Iphone").val();
        //alert(account + ":" + name + ":" + sex + ":" + college + ":" + email + ":" + phone);
        if (account == "") {
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
        var Ecoll = $(this).parent().parent().find("#collegeName").text().trim();
        $("#Ecoll").val(Ecoll);
        var Ephone = $(this).parent().parent().find("#phone").text().trim();
        $("#Ephone").val(Ephone);
        var Eemail = $(this).parent().parent().find("#email").text().trim();
        $("#Eemail").val(Eemail);
    })
    //点击提交编辑
    $("#saveEdit").click(function () {
        var Account = $("#Eaccount").val();
        var Name = $("#Ename").val();
        var Pwd = $("#Epwd").val();
        var Sex = $("#Esex").val();
        var College = $("#Ecoll").val();
        var Phone = $("#Ephone").val();
        var Email = $("#Eemail").val();
        //alert(Account+":"+Name+":"+Pwd+":"+Sex+":"+College+":"+Phone+":"+Email)
        if (Account == "") {
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
});
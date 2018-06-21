// 管理员页面重置
function formReset() {
    $("#form")[0].reset()
}
// 点击切换验证码
function refreshCode() {
    var code = document.getElementById("code");
    code.src = "checkCode.aspx?id=" + Math.random();
}

$(function () {
    $("#okMessage").hide();
})

function edit() {
    var telNum = $.trim($("#telNum").text());
    $("#telNum").text("")
    var txtTelNum = "<input type='text' class='telNum'/>"
    $("#telNum").append(txtTelNum);
    $(".telNum").focus();
    $(".telNum").val(telNum);
    var email = $.trim($("#email").text());
    $("#email").text("")
    var txtEmail = "<input type='text' class='email'/>"
    $("#email").append(txtEmail);
    $(".email").val(email);

    $("#editMessage").hide();
    $("#okMessage").show();
}

function ok() {
    var telNum = $(".telNum").val();
    if (telNum === "") {
        $("#telNum").remove();
    } else {
        $("#telNum").closest("td").text(telNum);
    }
    var email = $(".email").val();
    if (email === "") {
        $("#email").remove();
    } else {
        $("#email").closest("td").text(email);
    }
    $("#okMessage").hide();
    $("#editMessage").show();
}
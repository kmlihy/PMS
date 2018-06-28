﻿$(function() {
    $("#okMessage").hide();
    $(".body").height($(window).height());
})

// 页面重置
function formReset() {
    $("#form")[0].reset()
}

// 点击切换验证码
function refreshCode() {
    var code = document.getElementById("code");
    code.src = "checkCode.aspx?id=" + Math.random();
}

// 个人中心页面
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
    var email = $(".email").val();
    $.ajax({
        type: 'post',
        url: 'adminCenter.aspx',
        data: {
            phone: telNum,
            Email: email
        },
    });
    if (telNum === "") {
        $("#telNum").closest("td").text("");
    } else {
        $("#telNum").closest("td").text(telNum);
    }
    if (email === "") {
        $("#email").closest("td").text("");
    } else {
        $("#email").closest("td").text(email);
    }
    $("#okMessage").hide();
    $("#editMessage").show();
}
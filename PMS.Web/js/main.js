﻿autodivheight();

//获取页面高度
function autodivheight() {
    //函数：获取尺寸
    //获取浏览器窗口高度
    var winHeight = 0;
    if (window.innerHeight) {
        winHeight = window.innerHeight;
    } else if ((document.body) && (document.body.clientHeight)) {
        winHeight = document.body.clientHeight;
    }
    //通过深入Document内部对body进行检测，获取浏览器窗口高度
    if (document.documentElement && document.documentElement.clientHeight) {
        winHeight = document.documentElement.clientHeight;
    }
    //DIV高度为浏览器窗口的高度
    //document.getElementById("test").style.height= winHeight +"px";
    //DIV高度为浏览器窗口高度的一半
    //alert(winHeight);
    //alert(document.getElementById("top").offsetHeight);
    var topheight = document.getElementById("top").offsetHeight;
    document.getElementById("nav-menu").style.height = winHeight - topheight + "px";
    var moddleheight = document.getElementById("top").offsetHeight;
    document.getElementById("moddle").style.height = winHeight - moddleheight + "px";
}
window.onresize = autodivheight; //浏览器窗口发生变化时同时变化DIV高度//
//TODO 只有第一个>符号可以旋转，另一个未完成
function xuanz() {
    x = document.getElementById("trans");
    if (x.style.transform === "") {
        x.style.transform = "rotate(90deg)";
    }
    else {
        x.style.transform = "";
    }
}

function gethref(val) {
    document.getElementById("iframe").src = val;
}
var h = document.documentElement.clientHeight - 110;
x = document.getElementById("iframe");
x.height = h

window.onresize = function () {
    var h = document.documentElement.clientHeight - 110;
    x = document.getElementById("iframe");
    x.height = h
}
//点击右上角菜单里的菜单项时
$(".sidebarclick").click(function () {
    gethref($(this).attr("href"));
    $(".dropdown-menu").hide();
    return false
});
//点击右上角菜单时展开菜单项
$("#dropdownMenu1").click(function () {
        $(".dropdown-menu").toggle(1000);
    return true
});
function logout() {
    //alert("退出登录");
    window.wxc.xcConfirm("确定退出吗？", window.wxc.xcConfirm.typeEnum.confirm, {
        onOk: function (v) {
            $.ajax({
                type: 'get',
                url: 'main.aspx?op=logout',
                datatype: 'text',
                data: {},
                success: function (data) {
                    window.location.href = "../login.aspx";
                }
            });
        }
    });
}


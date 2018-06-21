<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PMS.Web.admin.login" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
        <link rel="stylesheet" href="../css/bootstrap.min.css" />
        <link rel="stylesheet" href="../css/zwh.css" />
    </head>

    <body class="body">
        <div class="container" id="login">
            <div class="panel-heading" id="heading">
                <img src="../images/logo.png" />
                <span>论文管理系统</span>
            </div>
            <hr />
            <div class="panel-body">
                <form class="form-horizontal" id="adminloginfrom" action="login.aspx" method="post" role="form" onsubmit="return checkForm()">

                    <div class="input-group" id="Acontent">
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-user"></span>
                        </span>
                        <input type="text" class="form-control" name="userName" id="userName" placeholder="用户名" />
                        <span></span>
                    </div>

                    <div class="input-group" id="Acontent">
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-lock"></span>
                        </span>
                        <input type="password" class="form-control" name="pwd" id="pwd" placeholder="密码" />
                    </div>
                    <p class="retrievePwd"><a href="#">找回密码</a></p>
                    <div class="form-group">
                        <div id="btn">
                            <button type="button" class="btn btn-default col-xs-3 col-sm-3 col-md-3 col-lg-3 col-xs-push-2 col-sm-push-2 col-md-push-2 col-lg-push-2" onclick="formReset()">重置</button>
                            <button type="submit" class="btn btn-info col-xs-3 col-sm-3 col-md-3 col-lg-3 col-xs-push-4 col-sm-push-4 col-md-push-4 col-lg-push-4" onclick="Msg()">登录</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </body>
    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script>
        // 重置
        function formReset() {
            $("#adminloginfrom")[0].reset()
        }
        // 提示框
        function Msg() {
            var my_toast_plug_name = "mytoast";
            $[my_toast_plug_name] = function(options) {
                var content;
                if ($("#userName").val() == "") {
                    content = "用户名不能为空！";
                } else if ($("#pwd").val() == "") {
                    content = "密码不能为空！";
                }  else {
                    return;
                }
                var jq_toast = $("<div class='my-toast'><div class='my-toast-text'></div></div>");
                var jq_text = jq_toast.find(".my-toast-text");
                jq_text.html(content);
                jq_toast.appendTo($("body")).stop().fadeIn(500).delay(3000).fadeOut(500);
                var w = jq_toast.width() - 10;
                jq_text.width(w);
                var l = -jq_toast.outerWidth() / 2;
                var t = -jq_toast.outerHeight() / 2;
                jq_toast.css({ "margin-left": l + "px", "margin-top": t + "px" });
                var _jq_toast = jq_toast;
                setTimeout(function() {
                    _jq_toast.remove();
                }, 3 * 1000);
            };
            $.mytoast({
                type: "notice"
            });
        }
        // 判断是否提交表单
        function checkForm() {
            if ($("#userName").val() != "" && $("#pwd").val() != "") {
                return true;
            } else {
                return false;
            }
        }
    </script>

    </html>
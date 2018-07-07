<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PMS.Web.login" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>登录界面</title>
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
                <form class="form-horizontal" id="form" action="login.aspx" method="post" role="form" onsubmit="return stucheckForm()">

                    <div class="input-group" id="content">
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-user"></span>
                        </span>
                        <input type="text" class="form-control" name="userName" id="userName" placeholder="用户名" />
                        <span></span>
                    </div>

                    <div class="input-group" id="content">
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-lock"></span>
                        </span>
                        <input type="password" class="form-control" name="pwd" id="pwd" placeholder="密码" />
                    </div>

                    <div class="input-group" id="content">
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-briefcase"></span>
                        </span>
                        <input type="text" class="form-control" name="captcha" id="captcha" placeholder="验证码" />
                        <img src="checkCode.aspx" id="code" onclick="refreshCode()" />
                    </div>
                    <div class="form-group">
                        <div class="radio">
                            <label>
                                <input type="radio" name="user" id="input${1/(\w+)/\u\1/g}" value="teacher" checked="" />
                                    教师
                            </label>
                            <label>
                                <input type="radio" name="user" id="input${1/(\w+)/\u\1/g}" value="student" checked="" />
                                    学生
                            </label>
                            <a href="#" id="retrievePwd">找回密码</a>
                        </div>
                        <div id="btn">
                            <button type="button" class="btn btn-default col-xs-3 col-sm-3 col-md-3 col-lg-3 col-xs-push-2 col-sm-push-2 col-md-push-2 col-lg-push-2" onclick="formReset()">重置</button>
                            <button type="submit" class="btn btn-info col-xs-3 col-sm-3 col-md-3 col-lg-3 col-xs-push-4 col-sm-push-4 col-md-push-4 col-lg-push-4" onclick="stuMsg()">
                                登录
                            </button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </body>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/zwh.js"></script>
    <script>
    </script>

    </html>
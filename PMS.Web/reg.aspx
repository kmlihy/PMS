<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="PMS.Web.reg" %>
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
        <link rel="stylesheet" href="css/bootstrap.min.css">
        <link rel="stylesheet" type="text/css" href="css/lgd.css">
    </head>

    <body>
        <div class="container-fluid">
            <div class="container">
                <h1 class="col-sm-3  col-sm-offset-5">账号注册
                </h1>
            </div>
            <div class="container-fluid" id="regmain">
                <div class="container container-style">
                    <form class="form-horizontal changeform" role="form" id="regform" method="POST">
                        <div class="form-group">
                            <label for="firstname" class="col-sm-2  col-sm-offset-3 control-label">账号:</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control input-sm" id="usercount" name="usercount" placeholder="账号">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">密码:</label>
                            <div class="col-sm-3">
                                <input type="password" class="form-control input-sm" id="pwd" name="pwd" placeholder="请输入密码" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">确认密码:</label>
                            <div class="col-sm-3">
                                <input type="password" class="form-control input-sm" id="confirmPwd" name="confirmPwd" placeholder="请再次输入密码" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">姓名:</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control input-sm" id="username" name="username" placeholder="请输入姓名" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">性别:</label>
                            <div class="col-sm-3">
                                <div class="radio">
                                    <label>
                                        <input type="radio" name="sex" value="" checked="checked">
                                        男
                                    </label>
                                    <label>
                                        <input type="radio" name="sex" value="" checked="checked">
                                        女
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">邮箱:</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control input-sm" id="userEmail" name="userEmail" placeholder="请输入邮箱" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">电话:</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control input-sm" id="usertel" name="usertel" placeholder="请输入电话号码" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">验证码:</label>
                            <div class="input-group  col-sm-3 teldiv">
                                <input type="text" class="form-control input-sm  col-sm-2" id="telverify" name="telverify" placeholder="请输入验证码" />
                                <div class="input-group-btn col-sm-pull-2">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">学历:</label>
                            <div class="col-sm-3">
                                <select class="form-control input-sm">
                                    <option value="">--请选择--</option>
                                    <option value="">本科</option>
                                    <option value="">专科</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">专业:</label>
                            <div class="col-sm-2">
                                <select class="form-control input-sm">
                                    <option value="">--请选择学院--</option>
                                    <option value="">...</option>
                                    <option value="">...</option>
                                </select>
                            </div>
                            <div class="col-sm-2">
                                <select class="form-control input-sm">
                                        <option value="">--请选择专业--</option>
                                        <option value="">...</option>
                                        <option value="">...</option>
                                    </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-6 col-sm-5">
                                <button type="submit" class="btn btn-default">提交</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </body>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.validate.min.js"></script>
    <script src="js/additional-methods.js"></script>
    <script src="js/messages_zh.min.js"></script>
    <script>
        function refresImg() {
            var code = document.getElementById("code");
            code.src = "yanz.aspx?id=" + Math.random();
        }
        $(document).ready(function() {
            $("#regform").validate({
                rules: {
                    usercount: {
                        required: true,
                        digits: true
                    },
                    pwd: {
                        required: true,
                        minlength: 6
                    },
                    confirmPwd: {
                        required: true,
                        minlength: 6,
                        equalTo: "#pwd"
                    },
                    username: {
                        required: true,
                    },
                    userEmail: {
                        required: true,
                        email: true
                    },
                    usertel: {
                        required: true,
                        isMobile: true
                    }
                },
                messages: {
                    usercount: {
                        required: "请输入账号",
                    },
                    pwd: {
                        required: "请输入密码",
                    },
                    confirmPwd: {
                        required: "请输入密码",
                        equalTo: "两次密码输入不一致"
                    },
                    username: {
                        required: "请输入姓名",
                    },
                    userEmail: {
                        required: "请输入邮箱",
                    },
                    usertel: {
                        required: "请输入电话",
                        isMobile: "请输入有效的电话号码"
                    }
                }
            });
        });
    </script>

    </html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePwd.aspx.cs" Inherits="PMS.Web.admin.changePwd" %>
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
        <link rel="stylesheet" href="../css/bootstrap.min.css" />
        <link rel="stylesheet" href="../css/lgd.css" />

        <script src="../js/jquery-3.3.1.min.js "></script>
        <script src="../js/bootstrap.min.js "></script>
        <script src="../js/jquery.validate.min.js "></script>
        <script src="../js/additional-methods.js"></script>
        <script src="../js/messages_zh.min.js "></script>

    </head>

    <body>
        <div class="container-fluid">
            <div class="container">
                <h1 class="col-sm-3  col-sm-offset-5">密码修改
                </h1>
            </div>
            <div class="container-fluid changepwd">
                <div class="container container-style">
                    <form class="form-horizontal changeform" role="form" id="changePwdForm" method="POST">
                        <div class="form-group">
                            <label for="firstname" class="col-sm-2  col-sm-offset-3 control-label">当前账号:</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control input-sm" id="usercount" placeholder="账号" readonly>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">手机号码:</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control input-sm" id="phone" name="phone" placeholder="请输入手机号码" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">验证码:</label>
                            <div class="input-group  col-sm-3 teldiv">
                                <input type="text" class="form-control input-sm  col-sm-2" id="telverify" name="telverify" placeholder="请输入验证码" />
                                <div class="input-group-btn col-sm-pull-2">
                                    <button class="btn btn-default btn-sm" type="button" id="gettelverif">获取验证码</button>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">新密码:</label>
                            <div class="col-sm-3">
                                <input type="password" class="form-control input-sm" id="newpwd" name="newpwd" placeholder="请输入新密码" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">确认新密码:</label>
                            <div class="col-sm-3">
                                <input type="password" class="form-control input-sm" id="confirmPwd" name="confirmPwd" placeholder="请再次输入新密码" />
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
    <script>
        $(document).ready(function() {
            $("#changePwdForm").validate({
                rules: {
                    phone: {
                        required: true,
                        isMobile: true
                    },
                    newpwd: {
                        required: true,
                        minlength: 6
                    },
                    confirmPwd: {
                        required: true,
                        minlength: 6,
                        equalTo: "#newpwd"
                    }
                },
                messages: {
                    phone: {
                        required: "请输入手机号码",
                        isMobile: "请输入正确的手机号码"
                    },
                    newpwd: {
                        required: "请输入密码",
                        minlength: "密码长度不能小于5个字母"
                    },
                    confirmPwd: {
                        required: "请输入密码",
                        minlength: "密码长度不能小于5个字母",
                        equalTo: "两次密码输入不一致"
                    }

                }
            })
        })
    </script>
    <style>
        .error {
            color: red;
        }
    </style>

    </html>
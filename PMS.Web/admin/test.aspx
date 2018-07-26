<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="PMS.Web.admin.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/zwh.css" />
    <link rel="stylesheet" type="text/css" href="../css/xcConfirm.css" />
</head>
<body id="regBody">
    <div class="container col-xs-8 col-sm-8 col-md-6 col-lg-4 col-xs-push-2 col-sm-push-2 col-md-push-3 col-lg-push-4" id="bigbox">
        <div class="container-fluid" id="regmain">
            <div class="container-style">
                <form class="form-horizontal" role="form" id="regform" method="post">

                    <table class="table table-hover">
                        <thead>
                            <h1 class="col-xs-10 col-sm-10 col-md-6 col-lg-6 col-xs-push-4 col-sm-push-4 col-md-push-4 col-lg-push-4">找回密码</h1>
                        </thead>
                        <tbody>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">账号:</label>
                                </td>
                                <td>
                                    <input type="text" class="form-control input-sm" id="account" name="usercount" placeholder="账号" />
                                    <span id="validateAcoount"></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">邮箱:</label>
                                </td>
                                <td>
                                    <input type="text" class="form-control input-sm" id="email" name="userEmail" placeholder="请输入电子邮箱" />
                                    <span id="validateEmail"></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">密码:</label></td>
                                <td>
                                    <input type="password" class="form-control input-sm" id="newpwd" name="pwd" placeholder="请输入新密码" />
                                    <span id="validatePwd"></span>

                                </td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">确认密码:</label></td>
                                <td>
                                    <input type="password" class="form-control input-sm" id="confirmPwd" name="confirmPwd" placeholder="请再次输入新密码" />
                                    <span id="validateConfirmPwd"></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">验证码:</label></td>
                                <td>
                                    <input type="text" class="input-sm" id="regCode" name="telverify" placeholder="请输入验证码" />
                                    <button class="btn-primary btn-sm" type="button" id="getCode">获取验证码</button>
                                    <span id="validateCode"></span></td>
                            </tr>
                            <%--<tr>
                                <td id="regLable">
                                    <label class="control-label">验证码:</label>
                                </td>
                                <td>
                                    <input type="text" class="form-control input-sm  col-sm-2" id="code" name="telverify" placeholder="请输入验证码" />
                                    <div class="input-group-btn">
                                        <button class="btn btn-default btn-sm" type="button" id="getcode">获取验证码</button>
                                    </div>
                                    <span class="col-sm-3  col-sm-offset-5" id="validateCode"></span>
                                </td>
                            </tr>--%>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">用户:</label></td>
                                <td>
                                        <input type="radio" name="user" value="teacher" checked="checked" />
                                        教师
                                        <input type="radio" name="user" value="student" checked="checked" />
                                        学生
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="form-group">
                        <div class="col-sm-offset-2">
                            <button type="button" class="btn btn-info col-xs-9 col-sm-9 col-md-10 col-lg-10 col-xs-push-2 col-sm-push-1 col-md-push-1" id="btnAdd">立即注册</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/jquery.validate.min.js"></script>
<script src="../js/additional-methods.js"></script>
<script src="../js/messages_zh.min.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="../js/reg.js"></script>
</html>

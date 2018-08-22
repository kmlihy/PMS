<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrievePwd.aspx.cs" Inherits="PMS.Web.admin.RetrievePwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="renderer" content="webkit" />
    <title>找回密码</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" type="text/css" href="../css/xcConfirm.css" />
</head>
<body style="color: white;" id="mydiv">
    <div class="container-fluid">
        <div class="container">
            <h1 class="col-sm-3  col-sm-offset-5">找回密码
            </h1>
        </div>
        <div class="box_login">
            <form class="form-horizontal changeform" role="form" id="changePwdForm" method="post">
                <div class="form-group">
                    <label for="firstname" class="col-sm-2  col-sm-offset-3 control-label">当前账号:</label>
                    <div class="col-sm-4">
                        <input type="text" class="form-control" id="account" name="usercount" placeholder="账号" />
                        <span id="validateAcoount"></span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">电子邮箱:</label>
                    <div class="col-sm-4">
                        <input type="text" class="form-control" id="email" name="userEmail" placeholder="请输入电子邮箱" />
                        <span id="validateEmail"></span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">验证码:</label>
                    <div class="input-group  col-sm-4 teldiv">
                        <input type="text" class="form-control" id="code" name="telverify" placeholder="请输入验证码" />
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button" id="getcode">获取验证码</button>
                        </span>
                    </div>
                    <span class="col-sm-3  col-sm-offset-5" id="validateCode"></span>
                </div>
                <div class="form-group">
                    <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">新密码:</label>
                    <div class="col-sm-4">
                        <input type="password" class="form-control" id="newpwd" name="pwd" placeholder="请输入新密码" />
                        <span id="validatePwd"></span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">确认新密码:</label>
                    <div class="col-sm-4">
                        <input type="password" class="form-control" id="confirmPwd" name="confirmPwd" placeholder="请再次输入新密码" />
                        <span id="validateConfirmPwd"></span>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2  col-sm-offset-4 control-label lable_tea">
                        <input type="radio" name="user" value="teacher" checked="checked"/>
                        教师
                    </label>
                    <label class="col-sm-3  control-label">
                        <input type="radio" name="user" value="student" checked="checked"/>
                        学生
                    </label>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-4 col-sm-5">
                        <button type="button" class="btn btn-default oksubmit" id="sumbit">提交</button>
                        <button class="btn btn-primary navbar-btn" id="allNaws_btnBack" type="button" onclick="history.go(-1)">返回</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js "></script>
<script src="../js/bootstrap.min.js "></script>
<script src="../js/jquery.validate.min.js "></script>
<script src="../js/additional-methods.js"></script>
<script src="../js/messages_zh.min.js "></script>
<script src="../js/canvas-particle.js"></script>
<script src="../js/xcConfirm.js"></script>
<script src="../js/retrievePwd.js"></script>
</html>

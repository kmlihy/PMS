<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePwd.aspx.cs" Inherits="PMS.Web.admin.changePwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改密码</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/zwh.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="container">
            <h1 class="col-sm-3  col-sm-offset-5">修改密码</h1>
        </div>
        <form class="form-horizontal changeform" role="form" id="changePwdForm" method="post">
                <div class="center col-xs-8 col-xm-8 col-md-6 col-lg-6 col-xs-push-2 col-sm-push-2 col-md-push-3 col-lg-push-3" id="changePwdBox">
                    <div class="form-group">
                        <label for="firstname" class="col-xs-2 col-sm-2 col-md-2 col-lg-2 col-sm-offset-3 control-label">当前账号:</label>
                        <div class="col-sm-5">
                            <input type="text" class="form-control input-sm" id="usercount" placeholder="账号" readonly="true" value="<%=account %>" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lastname" class="col-xs-2 col-sm-2 col-md-2 col-lg-2 col-sm-offset-3 control-label">原密码:</label>
                        <div class="col-sm-5">
                            <input type="password" class="form-control input-sm input" id="quondampwd" name="quondampwd" placeholder="请输入原密码" />
                            <span id="validateAccount"></span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lastname" class="col-xs-2 col-sm-2 col-md-2 col-lg-2 col-sm-offset-3 control-label">新密码:</label>
                        <div class="col-sm-5">
                            <input type="password" class="form-control input-sm input" id="newpwd" name="newpwd" placeholder="请输入新密码" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lastname" class="col-xs-2 col-sm-2 col-md-2 col-lg-2 col-sm-offset-3 control-label">确认新密码:</label>
                        <div class="col-sm-5">
                            <input type="password" class="form-control input-sm input" id="confirmPwd" name="confirmPwd" placeholder="请再次输入新密码" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-4">
                            <button type="button" class="btn btn-success col-xs-5 col-sm-4 col-md-3 col-lg-3" id="postPwd">提交</button>
                            <button class="btn btn-primary col-xs-5 col-sm-4 col-md-3 col-lg-3 col-xs-push-1 col-sm-push-1 col-md-push-1 col-lg-push-1" id="allNaws_btnBack" onclick="javascript:window.history.back(-1)">返回</button>
                        </div>
                    </div>
                </div>
        </form>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js "></script>
<script src="../js/bootstrap.min.js "></script>
<script src="../js/jquery.validate.min.js "></script>
<script src="../js/additional-methods.js"></script>
<script src="../js/messages_zh.min.js "></script>
<script src="../js/lgd.js"></script>
<script src="../js/changePwd.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

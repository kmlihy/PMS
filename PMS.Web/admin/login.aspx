﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PMS.Web.admin.login" %>

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
            <form class="form-horizontal" id="form" action="login.aspx" method="post" role="form" onsubmit="return admincheckForm()">

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
                    <input type="password" class="form-control" id="pwd" name="pwd" placeholder="密码" />
                </div>
                <p class="retrievePwd"><a href="RetrievePwd.aspx">找回密码</a></p>
                <div class="form-group">
                    <div id="btn">
                        <button type="button" class="btn btn-default col-xs-3 col-sm-3 col-md-3 col-lg-3 col-xs-push-2 col-sm-push-2 col-md-push-2 col-lg-push-2" onclick="formReset()">重置</button>
                        <button type="submit" class="btn btn-info col-xs-3 col-sm-3 col-md-3 col-lg-3 col-xs-push-4 col-sm-push-4 col-md-push-4 col-lg-push-4" onclick="adminMsg();cmdEncrypt();" id="btnlogin">
                            <a href="main.aspx" id="aLogin">登录</a>
                        </button>
                    </div>
                </div>
                <input type="hidden" name="encrypted_pwd" id="encrypted_pwd" />
            </form>
        </div>
    </div>
</body>
<script src="../js/jquery-1.4.1.js"></script>
<script src="../js/jQuery.md5.js" type="text/javascript"></script>
<script src="../js/BigInt.js" type="text/javascript"></script>
<script src="../js/RSA.js" type="text/javascript"></script>
<script src="../js/Barrett.js" type="text/javascript"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/zwh.js"></script>
<script type="text/javascript">
    function cmdEncrypt() {
<%--        setMaxDigits(129);
        var key = new RSAKeyPair("<%=strPublicKeyExponent%>", "", "<%=strPublicKeyModulus%>");
        var pwdMD5Twice = $.md5($.md5($("#pwd").attr("value")));
        var pwdRtn = encryptedString(key, pwdMD5Twice);
        $("#encrypted_pwd").attr("value", pwdRtn);
        $("#form").submit();--%>
    }
</script>
</html>

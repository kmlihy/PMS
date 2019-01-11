<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="PMS.Web.error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>论文管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/404.css" media="screen" />
</head>
<body>
    <div id="da-wrapper" class="fluid">
        <div id="da-content">
            <div class="da-container clearfix">
                <div id="da-error-wrapper">
                    <div id="da-error-pin"></div>
                    <div id="da-error-code">
                        error <span>WTF</span> </div>
                    <h1 class="da-error-heading">会话超时，请重新<a href="login.aspx">登录</a></h1>
                </div>
            </div>
        </div>
    </div>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paperDetail.aspx.cs" Inherits="PMS.Web.paperDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文详细信息</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
</head>

<body>
    <div class="container-fluid col-lg-10 col-lg-offset-1">
        <div class="navbar navbar-default allNews_pageHead" role="navigation">
            <span class="h2 text-info" id="allNews_info">题目信息
            </span>
            <button class="btn btn-primary navbar-btn" id="allNaws_btnBack" onclick="javascript:window.history.back(-1)">返回</button>
        </div>
        <div class="panel">
            <div class="panel-heading text-center">
                <input type="hidden" value="<%=titleId.TitleId %>" id="titleId" />
                <span class="h3"><%=titleId.title %></span>
            </div>
            <div class="panel-body">
                <span><%=titleId.TitleContent %></span>
            </div>
            <div class="panel-footer">
                <label for="text">选题人数上限：<%=titleId.Limit %></label>
                <span>|</span>
                <label for="text">已选人数：<%=titleId.Selected %></label>
                <a class="btn btn-primary navbar-btn selectTitle" id="btn_ToPaperDtailStu">选定题目</a>
            </div>
        </div>
    </div>
    <input type="hidden" value="<%=Session["state"] %>" id="loginUser" />
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/paperDetail.js"></script>
<script src="js/xcConfirm.js"></script>
</html>

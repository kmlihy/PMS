<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaperDtailStu.aspx.cs" Inherits="PMS.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/ml.css">
<link rel="stylesheet" href="css/style.css">
<body>
    <div class="container-fluid col-lg-10 col-lg-offset-1">
        <%--<nav class="navbar navbar-default" role="navigation">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">我的题目信息</a>
                </div>
            </div>
        </nav>--%>
        <div class="navbar navbar-default allNews_pageHead" role="navigation">
            <span class="h2 text-info" id="allNews_info">
                我的题目信息
            </span>
            <button class="btn btn-primary navbar-btn" id="allNaws_btnBack" onclick="javascript:window.history.back(-1)">返回</button>
        </div>
        <div class="panel">
            <div class="panel-heading text-center">
                <label for="title"><%=titleId.title.ToString() %></label>
            </div>
            <div class="panel-body">
                <span>
                    <%=titleId.TitleContent.ToString() %>
                </span>
            </div>
            <div class="panel-footer">
                <%--<ul class="list-group list-inline">
                    <li class="list-group-item">
                        <a href="#">指导教师:<%=titleId.teacher.TeaName.ToString() %></a>
                    </li>
                    <li class="list-group-item">
                        <a href="#">交叉指导老师：XX</a>
                    </li>
                </ul>--%>
                <label>指导教师:<%=titleId.teacher.TeaName.ToString() %></label>
                <span>|</span>
                <label>交叉指导老师：XX</label>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

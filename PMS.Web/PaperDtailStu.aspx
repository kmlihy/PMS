<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaperDtailStu.aspx.cs" Inherits="PMS.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的题目信息</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>
<body>
    <div class="container-fluid col-lg-10 col-lg-offset-1">
        <div class="navbar navbar-default" role="navigation" id="page_head">
            <span class="h3" id="page_info">我的题目信息</span>
            <button class="btn btn-primary navbar-btn" id="btn_back" onclick="javascript :history.back(1);">返回</button>
        </div>
        <div class="panel detail_panel">
            <div class="panel-heading text-center title_head">
                <h2><%=titleId.title.ToString() %></h2>
            </div>
            <div class="panel-body title_content">
                <span>
                    <%=titleId.TitleContent.ToString() %>
                </span>
            </div>
            <div class="panel-footer">
                <label class=""><a href="#">指导教师:<%=titleId.teacher.TeaName.ToString() %></a></label>
                <span>|</span>
                <label class=""><a href="#">交叉指导教师:XXX</a></label>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

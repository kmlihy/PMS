<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paperDetail.aspx.cs" Inherits="PMS.Web.paperDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文详细信息</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>

<body>
    <div class="container-fluid col-lg-10 col-lg-offset-1">
        <div class="navbar navbar-default" role="navigation" id="page_head">
            <span class="h3" id="page_info">我的题目信息</span>
            <button class="btn btn-primary navbar-btn" id="btn_back" onclick="javascript :history.back(1);">返回</button>
        </div>
        <div class="panel detail_panel">
            <div class="panel-heading text-center title_head">
                <h3><%=titleId.title %></h3>
            </div>
            <div class="panel-body title_content">
                <span><%=titleId.TitleContent %></span>
            </div>
            <div class="panel-footer">
                <label for="text">选题人数上限：<%=titleId.Limit %></label>
                <span>|</span>
                <label for="text">已选人数：<%=titleId.Selected %></label>
                <button type="button" class="btn btn-primary navbar-btn" onclick="location.href='PaperDtailStu.aspx?titleid=<%=titleid %>'" id="btn_ToPaperDtailStu">
                    选定题目
                </button>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

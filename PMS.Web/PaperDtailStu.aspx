<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaperDtailStu.aspx.cs" Inherits="PMS.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的题目信息</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>

<body>
    <div class="container-fluid col-lg-10 col-lg-offset-1" id="box" onload="disp_confirm()">
        <div class="navbar navbar-default allNews_pageHead" role="navigation">
            <span class="h2 text-info" id="allNews_info">我的题目信息
            </span>
            <button class="btn btn-primary navbar-btn" id="allNaws_btnBack" onclick="javascript:window.history.back(-1)">返回</button>
        </div>
        <div class="panel">
            <div class="panel-heading text-center">

                <% if (showTitle == null)
                    {
                        showTitle = "";
                    }%>
                <span class="h3">
                    <%=showTitle %>
                </span>
            </div>
            <div class="panel-body">
                <% if (showTitleContent == null)
                    {
                        showTitleContent = "";
                    }%>
                <span>
                    <%=showTitleContent %>
                </span>
            </div>
            <div class="panel-footer">
                <label>
                    <% if (showTeaName == null)
                        {
                            showTeaName = "";
                        }%>
                    <span>我的指导老师：<%=showTeaName %>
                    </span>
                </label>
                <span>|</span>
                <label>交叉指导老师：XX</label>
            </div>
        </div>
    </div>
    <button id="GoSelect" class="btn navbar-btn btn-default">我要去选题</button>
    <span id="stu"><%=stuAccount %></span>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script>
     <%if (showTitle == "")
    {%>
    $(document).ready(function () {
        document.write('<a href="http://localhost:33192/PaperList.aspx">你还没有选题，请点击跳转到选题界面  </a>');
    })
    <% }%>
</script>
</html>

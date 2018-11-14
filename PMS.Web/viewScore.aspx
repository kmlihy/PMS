<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewScore.aspx.cs" Inherits="PMS.Web.viewScore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看毕业论文成绩</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>
<body class="viewScore-body">
    <div class="container viewscore-divbox">
        <%if (content == "暂未选题")
            {%>
        <h3 class="text-primary"><%=content %></h3>
        <% } %>

        <%else if (content == "暂无成绩")
            {%>
        <h3 class="text-primary"><%=content %></h3>
        <%}
            else
            {%>
        <div class="panel panel-heading text-center viewScore_panelhead">
            <h2>毕业论文成绩查询</h2>
        </div>
        <div class="panel panel-body text-center viewScore_panelbody">
            <div>
                <table class="table table-studentInfo">
                    <tr>
                        <td class="viewScoreStudentinfo text-right">姓名:</td>
                        <td class="viewScoreStudentinfo text-left"><%=stuName %></td>
                    </tr>
                    <tr>
                        <td class="viewScoreStudentinfo text-right">学号:</td>
                        <td class="viewScoreStudentinfo text-left"><%=stuAccount %></td>

                    </tr>
                    <tr>
                        <td class="viewScoreStudentinfo text-right">专业:</td>
                        <td class="viewScoreStudentinfo text-left"><%=proName %></td>
                    </tr>
                </table>
            </div>
            <div class="table-score">
                <table class="table table-bordered table-scoreTable">
                    <thead>
                        <tr>
                            <td class="viewScoreStudentinfo">论文题目</td>
                            <td class="viewScoreStudentinfo">得分</td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td><%=title %></td>
                            <td><%=score %></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="panel panel-footer viewScore_panelfooter text-right">
            <button type="button" class="btn btn-success">返回</button>
        </div>
    </div>
    <%} %>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

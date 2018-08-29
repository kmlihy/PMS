<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewScore.aspx.cs" Inherits="PMS.Web.viewScore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看毕业论文成绩</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>
<body>
    <div class="panel panel-heading text-center viewScore_panelhead">
        <h2>2018届毕业生毕业论文成绩查询</h2>
    </div>
    <div class="panel panel-body text-center viewScore_panelbody">
        <div>
            <table class="table" style="width:50%;margin:auto;border:none;">
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
                    <td class="viewScoreStudentinfo text-left"><%=profession %></td>
                </tr>
            </table>
        </div>
        <div class="table-score" style=" margin-top:30px;">
            <table class="table table-bordered" style="width: 50%; margin: auto;">
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
</body>
</html>

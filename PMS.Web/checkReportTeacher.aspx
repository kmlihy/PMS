<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkReportTeacher.aspx.cs" Inherits="PMS.Web.checkReportTeacher" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>下载学生查重报告</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>下载学生查重报告</h1>
        </div>
        <div class="panel-body text-center">
            <table class="table table-bordered text-center">
                <thead>
                    <tr>
                        <th class="text-center">序号</th>
                        <th class="text-center">论文题目</th>
                        <th class="text-center">姓名</th>
                        <th class="text-center">下载</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>
                           大学生在线二手交易网站
                        </td>
                        <td>
                            周杰杰
                        </td>
                        <td>
                            <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-download-alt"></span></button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</body>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-3.3.1.min.js"></script>
</html>

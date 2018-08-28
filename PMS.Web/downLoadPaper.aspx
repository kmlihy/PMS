<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downLoadPaper.aspx.cs" Inherits="PMS.Web.downLoadPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>下载学生论文并评阅</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <style>
        
    </style>
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>下载并评阅论文</h1>
        </div>
        <div class="panel-body">
            <table class="table text-center table-bordered">
                <thead>
                    <tr>
                        <th class="text-center">序号</th>
                        <th class="text-center">论文</th>
                        <th class="text-center">姓名</th>
                        <th class="text-center">下载</th>
                        <th class="text-center">查看历史提交</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td  style="vertical-align:middle">1</td>
                        <td style="vertical-align:middle">航班查询及预订系统</td>
                        <td  style="vertical-align:middle">wudong</td>
                        <td  style="vertical-align:middle">
                            <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-download-alt"></span></button>
                        </td>
                        <td  style="vertical-align:middle">
                            <a href="stuHistoryPaper.aspx">点击跳转</a>
                        </td>
                    </tr>
                    <tr>
                        <td  style="vertical-align:middle">2</td>
                        <td style="vertical-align:middle">汽车4S店车主管理系统</td>
                        <td  style="vertical-align:middle">marry</td>
                        <td  style="vertical-align:middle">
                            <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-download-alt"></span></button>
                        </td>
                        <td  style="vertical-align:middle">
                            <a href="stuHistoryPaper.aspx">点击跳转</a>
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

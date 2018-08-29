<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuHistoryPaper.aspx.cs" Inherits="PMS.Web.stuHistoryPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生历史论文提交</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <style>
        #body {
            height: 500px;
        }
    </style>
</head>
<body>
    <div class="panel text-center">
        <div class="panel-heading">
            <h1>XX学生论文提交</h1>
        </div>
        <div class="panel-body" id="body">
            <table class="table text-center table-bordered">
                <thead>
                    <tr>
                        <th class="text-center">序号</th>
                        <th class="text-center">论文</th>
                        <th class="text-center">提交时间</th>
                        <th class="text-center">下载</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="col-sm-1" style="vertical-align: middle">1</td>
                        <td style="vertical-align: middle">ad</td>
                        <td style="vertical-align: middle">2018</td>
                        <td class="col-sm-1" style="vertical-align: middle">
                            <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-download-alt"></span></button>
                        </td>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>ad</td>
                        <td>2018</td>
                        <td>
                            <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-download-alt"></span></button>
                        </td>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>ad</td>
                        <td>2018</td>
                        <td>
                            <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-download-alt"></span></button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="panel-footer">
            <div class="container-fluid">
                <button class="btn btn-primary navbar-btn" id="allNaws_btnBack" onclick="location.href='downLoadPaper.aspx'">返回</button>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

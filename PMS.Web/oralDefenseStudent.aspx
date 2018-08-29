﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="oralDefenseStudent.aspx.cs" Inherits="PMS.Web.oralDefenseStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文答辩</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body class="oraldefense-student">
    <div class="container oraldefense-div">
        <div class="panel panel-heading text-center">
            <h2>我的答辩小组</h2>
        </div>
        <div class="panel panel-body text-center">
            <table class="table table-bordered oraldefense-table">
                <thead>
                    <tr>
                        <td>姓名</td>
                        <td>负责职务</td>
                        <td>联系方式</td>
                        <td>电子邮箱</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>刘备</td>
                        <td>组长</td>
                        <td>1234567890</td>
                        <td>1234567890@qq.com</td>
                    </tr>
                    <tr>
                        <td>王五</td>
                        <td>副组长</td>
                        <td>9876543210</td>
                        <td>9876543210@qq.com</td>
                    </tr>
                    <tr>
                        <td>李四</td>
                        <td>秘书</td>
                        <td>1593571330</td>
                        <td>1593571330@qq.com</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="panel panel-footer text-right">
            <button class="btn btn-success" data-toggle="modal" data-target="#myModal">查看答辩记录</button>
        </div>
    </div>
    <!--查看答辩记录模态框 -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">查看答辩记录
                    </h4>
                </div>
                <div class="modal-body">
                    <div>
                        <pre id="oraldefenseHistory">
                            文本内容格式自动换行
                        </pre>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

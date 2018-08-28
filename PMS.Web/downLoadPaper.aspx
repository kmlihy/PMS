﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downLoadPaper.aspx.cs" Inherits="PMS.Web.downLoadPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>指导学生论文</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <style>
        #body{
            height:700px;
        }
    </style>
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>指导学生论文</h1>
        </div>
        <div class="panel-body" id="body">
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
    <div class="text-right" id="paging">
            <ul class="pagination pagination-lg">
                <li>
                    <a href="#" class="jump" id="first">首页</a>
                </li>
                <li>
                    <a href="#" class="jump" id="prev">
                        <span class="iconfont icon-back"></span>
                    </a>
                </li>
                <li>
                    <a href="#" class="jump">
                        1
                     <%--   <%=getCurrentPage %>--%>
                    </a>
                </li>
                <li>
                    <a href="#">/</a>
                </li>
                <li>
                   <a href="#" class="jump">
                        10
                     <%--   <%=getCurrentPage %>--%>
                    </a>
                </li>
                <li>
                    <a href="#" id="next" class="jump">
                        <span class="iconfont icon-more"></span>
                    </a>
                </li>
                <li>
                    <a href="#" class="jump" id="last">尾页</a>
                </li>
            </ul>
        </div>
</body>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-3.3.1.min.js"></script>
</html>

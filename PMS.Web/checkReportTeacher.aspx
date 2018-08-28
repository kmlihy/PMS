<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkReportTeacher.aspx.cs" Inherits="PMS.Web.checkReportTeacher" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>下载学生查重报告</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>下载学生查重报告</h1>
        </div>
        <div class="panel-body text-center" id="panelbody">
            <table class="table table-bordered text-center">
                <thead>
                    <tr>
                        <th class="text-center">序号</th>
                        <th class="text-center">姓名</th>
                        <th class="text-center">论文题目</th>
                        <th class="text-center">上传时间</th>
                        <th class="text-center">下载</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>周杰杰
                        </td>
                        <td>大学生在线二手交易网站
                        </td>
                        <td>2018-9-3 15:26:55</td>
                        <td>
                            <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-download-alt"></span></button>
                        </td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>周杰杰
                        </td>
                        <td>大学生在线二手交易网站
                        </td>
                        <td>2018-9-4 10:24:25</td>
                        <td>
                            <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-download-alt"></span></button>
                        </td>
                    </tr>
                </tbody>
            </table>
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
                    <a href="#" class="jump">1
                     <%--   <%=getCurrentPage %>--%>
                    </a>
                </li>
                <li>
                    <a href="#">/</a>
                </li>
                <li>
                    <a href="#" class="jump">10
                    <%-- <% if (count == 0) { count = 1; } %>
                    <a href="#" class="jump">
                        <%=count %>
                    </a>--%>
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
    </div>
    </div>
</body>
<script src="js/bootstrap.min.js"></script>
<script src="js/jquery-3.3.1.min.js"></script>
</html>

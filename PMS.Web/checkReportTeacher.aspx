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
        <div class="panel-body">
            <div class="panel panel-default">
                <div class="pane input-group" id="panel-head">
                    <div class="input-group" id="inputgroups">
                        <input type="text" class="form-control inputsearch" placeholder="请输入搜索条件" id="inputsearch" value="<%=secSearch %>" />
                        <span class="input-group-btn">
                            <button class="btn btn-info" type="button" id="btn-search">
                                <span class="glyphicon glyphicon-search">查询</span>
                            </button>
                        </span>
                    </div>
                </div>
            </div>
            <div class="panel-body text-center" id="panelbody">
                <table class="table table-bordered text-center">
                    <thead>
                        <tr>
                            <th class="text-center">序号</th>
                            <th class="text-center">学号</th>
                            <th class="text-center">姓名</th>
                            <th class="text-center">论文题目</th>
                            <th class="text-center">上传时间</th>
                            <th class="text-center">下载</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            { %>
                        <tr>
                            <td><%=i + 1 + ((getCurrentPage - 1) * pagesize)%></td>
                            <td><%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %></td>
                            <td><%=ds.Tables[0].Rows[i]["realName"].ToString() %></td>
                            <td><%=ds.Tables[0].Rows[i]["title"].ToString() %></td>
                            <td><%=ds.Tables[0].Rows[i]["dateTime"].ToString() %></td>
                            <td>
                                <a href="<%=ds.Tables[0].Rows[i]["path"].ToString() %>">
                                    <button type="button" class="btn btn-success">
                                        <span class="glyphicon glyphicon-download-alt"></span>
                                    </button>
                                </a>
                            </td>
                        </tr>
                        <%} %>
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
                        <a href="#" class="jump"><%=getCurrentPage %></a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <% if (count == 0) { count = 1; } %>
                        <a href="#" class="jump">
                            <%=count %>
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
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
</body>
<script src="js/bootstrap.min.js"></script>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/checkReportTeacher.js"></script>
</html>

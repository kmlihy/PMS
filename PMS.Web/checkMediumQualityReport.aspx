<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkMediumQualityReport.aspx.cs" Inherits="PMS.Web.checkMediumQualityReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <style>
        #body {
            height: 500px;
        }
    </style>
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>我的学生中期质量报告</h1>
        </div>
        <div class="panel-body" id="body">
            <div class="panel panel-default" id="propanelbox">
                <div class="pane input-group" id="panel-head">
                    <div class="input-group" id="inputgroups">
                        <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" value="<%=secSearch %>" />
                        <span class="input-group-btn">
                            <button class="btn btn-info" type="button" id="btn-search">
                                <span class="glyphicon glyphicon-search">查询</span>
                            </button>
                        </span>
                    </div>
                </div>
            </div>
            <table class="table text-center table-bordered">
                <thead>
                    <tr>
                        <th class="text-center">序号</th>
                        <th class="text-center">论文</th>
                        <th class="text-center">学号</th>
                        <th class="text-center">姓名</th>
                        <th class="text-center">查看报告</th>
                    </tr>
                </thead>
                <tbody>
                    <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                    %>
                    <tr>
                        <td style="vertical-align: middle" class="col-sm-1"><%=i + 1 + ((getCurrentPage - 1) * pagesize)%></td>
                        <td style="vertical-align: middle" class="col-sm-2"><%=ds.Tables[0].Rows[i]["title"].ToString() %></td>
                        <td style="vertical-align: middle" class="col-sm-1"><%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %></td>
                        <td style="vertical-align: middle" class="col-sm-1">
                            <%=ds.Tables[0].Rows[i]["realName"].ToString() %>
                        </td>
                        <td style="vertical-align: middle">
                            <a href="mediiumQuality.aspx?stuAccount=<%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %>">
                                <span class="glyphicon glyphicon-hand-right"></span>
                                点击查看
                            </a>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
    </div>
    <div class="panel-footer">
        <%--分页--%>
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
                        <%=getCurrentPage %>
                    </a>
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
    <label><%=Session["state"] %></label>
    <input type="text" value="<%=getCurrentPage %>" id="page" />
    <input type="text" value="<%=count %>" id="countPage" />
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/checkMediumQualityReport.js"></script>
</html>

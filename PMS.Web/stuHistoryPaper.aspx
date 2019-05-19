<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuHistoryPaper.aspx.cs" Inherits="PMS.Web.stuHistoryPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生历史论文提交</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <style>
        #body {
            height: 500px;
        }
    </style>
</head>
<body>
    <div class="panel text-center">
        <div class="panel-heading">
            <h1>历史论文提交</h1>
        </div>
        <div class="panel-body" id="body">
            <table class="table text-center table-bordered">
                <thead>
                    <tr>
                        <th class="text-center"><nobr>序号</nobr></th>
                        <th class="text-center"><nobr>论文</nobr></th>
                        <th class="text-center"><nobr>提交时间</nobr></th>
                        <th class="text-center"><nobr>下载</nobr></th>
                    </tr>
                </thead>
                <tbody>
                    <%for (int i = 0; i < dsPath.Tables[0].Rows.Count; i++)
                        {%>
                    <tr>
                        <td class="col-sm-1" style="vertical-align: middle"><%=i+1+((getCurrentPage-1)*pagesize)%></td>
                        <td style="vertical-align: middle"><%=dsPath.Tables[0].Rows[i]["pathTitle"].ToString() %></td>
                        <td style="vertical-align: middle"><%=dsPath.Tables[0].Rows[i]["dateTime"].ToString() %></td>
                        <td class="col-sm-1" style="vertical-align: middle">
                            <a href="<%=dsPath.Tables[0].Rows[i]["path"].ToString() %>">
                                <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-download-alt"></span></button>
                            </a>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
        <!--翻页区域-->
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
        <input type="hidden" id="stuAccount" value="<%=stuAccount %>" />
        <input type="hidden" value="<%=getCurrentPage %>" id="page" />
        <input type="hidden" value="<%=count %>" id="countPage" />
        <div class="panel-footer">
            <div class="container-fluid">
                <button class="btn btn-primary navbar-btn" id="allNaws_btnBack" onclick="location.href='downLoadPaper.aspx'">返回</button>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/stuHistoryPaper.js"></script>
</html>

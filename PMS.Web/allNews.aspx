<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allNews.aspx.cs" Inherits="PMS.Web.allNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看所有公告列表页</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
</head>

<body>
    <div class="container-fluid table-bordered img-rounded col-lg-10 col-lg-offset-1">
        <div class="navbar allNews_pageHead" role="navigation">
                <span class="h3 text-danger" id="allNews_info">
                    <%=newsType %>
                </span>
                <button class="btn btn-primary navbar-btn" id="allNaws_btnBack" onclick="location.href='newsList.aspx'">返回</button>
            </div>
        <table class="table table-hover" id="allNews_table">
            <thead>
                <th class="text-left">
                    <label for="title">标题</label>
                </th>
                <th class="text-center">
                    <label for="title">发布者</label>
                </th>
                <th class="text-right" id="allNews_timeTH">发布时间</th>
            </thead>
            <tbody>
                <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    { %>
                <tr>
                    <td class="text-left col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <a href="news.aspx?newid=<%=ds.Tables[0].Rows[i]["newsId"].ToString()  %>"><%=ds.Tables[0].Rows[i]["newsTitle"].ToString() %></a>
                    </td>
                    <td class="text-center col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <%=ds.Tables[0].Rows[i]["teaName"].ToString() %>
                    </td>
                    <td class="text-right col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <% DateTime dt = DateTime.Parse(ds.Tables[0].Rows[i]["createTime"].ToString()); %>
                        <%=string.Format("{0:yyyy-MM-dd}",dt) %>
                    </td>
                </tr>
                <%} %>
            </tbody>
        </table>
        <div class="container-fluid text-right" id="drop_Page">
            <ul class="pagination pagination-lg">
                <li>
                    <a href="#" class="jump" id="first">首页</a>
                </li>
                <li>
                    <a href="#" class="jump">
                        <span class="iconfont icon-back" style="font-size: 11px;"></span>
                    </a>
                </li>
                <li>
                    <a href="#" class="jump">第 <%=getCurrentPage %> 页</a>
                </li>
                <li>
                    <% if (count == 0) { count = 1; } %>
                    <a href="#">总共：<%=count %> 页</a>
                </li>
                <li>
                    <a href="#" class="jump">
                        <span class="iconfont icon-more" style="font-size: 11px;"></span>
                    </a>
                </li>
                <li>
                    <a href="#" class="jump" id="last">尾页</a>
                </li>
            </ul>
        </div>
        <%--<div class="container-fluid text-right">
                <ul class="pagination pagination-lg">
                    <li>
                        <a href="#" class="jump" id="prev">上一页
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
                        <a href="#" class="jump"><%=count %></a>
                    </li>
                    <li>
                        <a href="#" id="next" class="jump">下一页
                        </a>
                    </li>
                </ul>
            </div>--%>
    </div>
    <span id="page"><%=getCurrentPage %></span>
    <span id="countPage"><%=count %></span>
    <span id="newsType"><%=roleId %></span> 
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/allNews.js"></script>
</html>

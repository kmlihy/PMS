<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paperList.aspx.cs" Inherits="PMS.Web.paperList" %>

<%= "" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文列表</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
</head>

<body>
    <div class="container-fluid paperlistbox">
        <div class="panel-head">
            <h2>选题列表</h2>
        </div>
        <%--<div class="container">
            <h1 class="col-sm-3  col-sm-offset-5">选题列表
            </h1>
        </div>--%>
        <div class="panel-body" id="panelbody">
            <table class="table table-striped paperlisttable text-center">
                <thead>
                    <tr>
                        <th class="text-center">论文题目
                        </th>
                        <th class="text-center">已选人数/人数上限
                        </th>
                        <th class="text-center">选题截止时间
                        </th>
                        <th class="text-center">状态
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {  %>
                    <tr>
                        <td class="paperlisttd">
                            <a href="paperDetail.aspx?titleId=<%=ds.Tables[0].Rows[i]["titleId"].ToString() %>"><%=ds.Tables[0].Rows[i]["title"].ToString()%></a>
                        </td>
                        <td><%=ds.Tables[0].Rows[i]["selected"].ToString()%>/<%=ds.Tables[0].Rows[i]["limit"].ToString()%>
                        </td>
                        <%--选题截止时间--%>
                        <td>
                            <%=ds.Tables[0].Rows[i]["endTime"].ToString()%>
                        </td>
                        <td>
                            <a class="btn btn-primary selectTitle" id="<%=ds.Tables[0].Rows[i]["titleId"].ToString() %>">选题</a>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
        <div class="container text-right paperpagination-div ">
            <ul class="pagination pagination-lg">
                <li>
                    <a href="#" class="jump" id="first">首页</a>
                </li>
                <li>
                    <a href="#" class="jump" id="prev">
                        <%--<span class="glyphicon glyphicon-chevron-left"></span>--%>
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
                        <%--<span class="glyphicon glyphicon-chevron-right"></span>--%>
                        <span class="iconfont icon-more"></span>
                    </a>
                </li>
                <li>
                    <a href="#" class="jump" id="last">尾页</a>
                </li>
            </ul>
        </div>
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="../js/lgd.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="js/paperList.js"></script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="PMS.Web.news" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>公告查看</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <div class="container-fluid col-lg-6 col-lg-offset-3" id="contentBox">
        <div class="panel table-bordered" id="panelBox">
            <%--<div class="panel-heading">
                    <span class="h3 text-info">通知公告</span>
                    <span class="glyphicon glyphicon-volume-up btn-lg"></span>
                    <hr id="underline" />
                </div>--%>
            <div class="navbar navbar-default news_pageHead" role="navigation">
                <span class="h3" id="page_info">
                    通知公告
                    <i class="glyphicon glyphicon-volume-up btn-lg"></i>
                </span>
                <button class="btn btn-primary navbar-btn" id="news_btn_back" onclick="javascript :history.back(1);">返回</button>
            </div>
            <div class="panel-body container-fluid" id="panelBody">
                <div class="container col-lg-12">
                    <table class="table">
                        <thead>
                            <th colspan="2" class="text-center">
                                <label for="title" class="h3">
                                    <%=newsId.NewsTitle %>
                                </label>
                            </th>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="text-right">
                                    <span class="table">
                                        <span>发布人：</span><%=newsId.teacher.TeaName %>
                                    </span>
                                    <span>&nbsp|&nbsp</span>
                                    <span class="table">
                                        <% DateTime newsTIme = DateTime.Parse(newsId.CreateTime.GetDateTimeFormats('f')[0]); %>
                                        <span>发布时间：</span><%=string.Format("{0:yyyy-MM-dd}",newsTIme) %>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="newsContent">
                                    <label for="text">
                                        <%=newsId.NewsContent %>
                                    </label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

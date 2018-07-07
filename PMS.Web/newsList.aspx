<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsList.aspx.cs" Inherits="PMS.Web.newsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>公告列表页面</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>

<body>
    <div class="container-fluid">


        <div class="container-fluid table-bordered img-rounded" id="school">
            <div class="container-fluid">
                <label for="title" class="h4 text-info">学校公告</label>
                <a href="allNews.aspx?roleId=0" class="a-word">查看更多>></a>
            </div>
            <div class="container-fluid" id="school-list">
                <%--                    <ul class="list-unstyled">--%>
                <table class="table" id="school-table">
                    <%for (int i = 0; i < dsSadmin.Tables[0].Rows.Count; i++)
                        {
                            DateTime dt = DateTime.Parse(dsSadmin.Tables[0].Rows[i]["createTime"].ToString());
                    %>
                    <tr>
                        <td class="newsList_td">
                            <span>
                                <%--[<%=string.Format("{0:d}",dt) %>]--%>
                                [<%=string.Format("{0:yyyy-MM-dd}",dt) %>]
                            </span>
                        </td>
                        <td class="text-left">
                            <a href="news.aspx?newid=<%=dsSadmin.Tables[0].Rows[i]["newsId"].ToString() %>"><%=dsSadmin.Tables[0].Rows[i]["newsTitle"].ToString() %></a>
                        </td>
                    </tr>
                    <%} %>
                </table>
            </div>
        </div>

        <div class="container-fluid table-bordered img-rounded" id="institute">
            <div class="container-fluid" id="institute-word">
                <label for="title" class="h4 text-info">学院公告</label>
                <a href="allNews.aspx?roleId=2" class="a-word">查看更多>></a>
            </div>
            <div class="container-fluid" id="institute-list">
                <table class="table" id="newsListtable">
                    <%for (int i = 0; i < dsAdmin.Tables[0].Rows.Count; i++)
                        {
                            DateTime dt = DateTime.Parse(dsAdmin.Tables[0].Rows[i]["createTime"].ToString());
                    %>
                    <tr>
                        <td class="newsList_td">
                            <span>[<%= string.Format("{0:yyyy-MM-dd}",dt) %>]</span>
                        </td>
                        <td class="text-left">
                            <a href="news.aspx?newid=<%=dsAdmin.Tables[0].Rows[i]["newsId"].ToString() %>"><%=dsAdmin.Tables[0].Rows[i]["newsTitle"].ToString() %></a>
                        </td>
                    </tr>
                    <%} %>
                </table>
            </div>
        </div>


        <div class="container-fluid table-bordered img-rounded" id="Mine">
            <div class="container-fluid" id="Mine-word">
                <label for="title" class="h4 text-info">学生公告</label>
                <a href="allNews.aspx?roleId=1" class="a-word">查看更多>></a>
            </div>
            <div class="container-fluid" id="Mine-list">
                <table class="table table-border" id="Mine-table">
                    <%for (int i = 0; i < dsTea.Tables[0].Rows.Count; i++)
                        {
                            DateTime dt = DateTime.Parse(dsTea.Tables[0].Rows[i]["createTime"].ToString());
                    %>
                    <tr>
                        <td class="newsList_td">
                            <span>[<%=string.Format("{0:yyyy-MM-dd}",dt) %>]</span>
                        </td>
                        <td class="text-left">
                            <a href="news.aspx?newid=<%=dsTea.Tables[0].Rows[i]["newsId"].ToString() %>"><%=dsTea.Tables[0].Rows[i]["newsTitle"].ToString() %></a>
                        </td>
                    </tr>
                    <%} %>
                </table>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

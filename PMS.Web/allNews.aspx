<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allNews.aspx.cs" Inherits="PMS.Web.allNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看所有公告列表页</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/ml.css" />
</head>

<body>
    <div class="container-fluid table-bordered img-rounded col-lg-10 col-lg-offset-1">
        <ul class="list-unstyled">
            <table class="table table-hover">
                <thead>
                    <th>
                        <label for="title"><%=newsType %></label></th>
                    <th>发布时间</th>
                </thead>
                <tbody>
                    <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        { %>
                    <tr>
                        <td>
                            <li>
                                <a href="news.aspx"><%=ds.Tables[0].Rows[i]["newsTitle"].ToString() %></a>
                            </li>
                        </td>
                        <td>
                            <li><%=ds.Tables[0].Rows[i]["createTime"].ToString() %></li>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
            <li>
                <%--<div class="container-fluid text-center">
                    <ul class="pagination pagination-sm">
                        <li>
                            <a href="#">首页</a>
                        </li>
                        <li>
                            <a href="#" class="jump" id="prev">上一页</a>
                        </li>
                        <li>
                            <a href="#" class="jump">1</a>
                        </li>
                        <li>
                            <a href="#" class="jump">2</a>
                        </li>
                        <li>
                            <a href="#" class="jump">3</a>
                        </li>
                        <li>
                            <a href="#"><%=count %></a>
                        </li>
                        <li>
                            <a href="#" class="jump">下一页</a>
                        </li>
                        <li>
                            <a href="#" class="jump">尾页</a>
                        </li>
                    </ul>
                </div>--%>
            </li>
            <div class="container-fluid text-right">
                <ul class="pagination pagination-lg">
                    <li onclick="pageMsg()">
                        <a href="#" class="jump" id="prev">上一页
                        </a>
                    </li>
                    <li>
                        <a href="#" class="jump">1</a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <% if (count == 0) { count = 1; } %>
                        <a href="#" class="jump"><%=count %></a>
                    </li>
                    <li onclick="pageMsg()">
                        <a href="#" id="next" class="jump">下一页
                        </a>
                    </li>
                </ul>
            </div>
        </ul>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script>
    sessionStorage.setItem("page", <%=getCurrentPage %>);
    sessionStorage.setItem("countPage",<%=count %>);
    $(document).ready(function () {
        alert(sessionStorage.getItem("page"));
        $(".jump").click(function () {
            // alert($.trim($(this).html()));          
            switch ($.trim($(this).html())) {
                case ("上一页"):
                    if (parseInt(sessionStorage.getItem("page")) > 1) {
                        jump(parseInt(sessionStorage.getItem("page")) - 1);
                        sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) - 1);
                        break;
                    }
                    else {
                        jump(1);
                        break;
                    }
                case ("下一页"):
                    if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {
                        jump(parseInt(sessionStorage.getItem("page")) + 1);
                        sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) + 1);
                        break;
                    }
                    else {
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                    }
                case ("1"):
                    jump(1);
                    break;
                case (sessionStorage.getItem("countPage")):
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
            }
        });
        function jump(cur) {
            window.location.href = "allNews.aspx?roleId=<%=roleId %>&currentPage=" + cur;
        }
    })
    
</script>
</html>

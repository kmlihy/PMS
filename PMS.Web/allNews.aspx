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
    sessionStorage.setItem("page", <%=getCurrentPage %>);//当前页
    sessionStorage.setItem("countPage",<%=count %>);//总页数
    $(document).ready(function () {
        <%--$(".jump").click(function () {
            // alert($.trim($(this).html()));
            switch ($.trim($(this).html())) {
                case ("上一页"):
                    jump(<%=int.Parse( ViewState["page"].ToString())-1%>);
                    break;
                case ("下一页"):
                    jump(<%=int.Parse( ViewState["page"].ToString())+1%>);
                    break;
                case ("1"):
                    jump(1);
                    break;
                case ("<%=count %>"):
                    jump(<%=count %>);
                    break;
            }
        });--%>
        alert(sessionStorage.getItem("page"));//获取当前页
        alert(sessionStorage.getItem("countPage"));//获取总页数
        
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
            window.location.href = "allNews.aspx?newid=<%=newid %>&currentPage=" + cur;
        }
    })

    function pageMsg() {
        alert("click");
    }

    //分页提示
    //function pageMsg() {
    //    var my_toast_plug_name = "mytoast";
    //    $[my_toast_plug_name] = function (options) {
    //        var content;
    //        if (parseInt(sessionStorage.getItem("page")) < 1) {
    //            content = "前无古人";
    //        } else if (parseInt(sessionStorage.getItem("page")) > parseInt(sessionStorage.getItem("countPage")) {
    //            content = "后无来者";
    //        } else {
    //            return;
    //        }
    //        var jq_toast = $("<div class='my-toast'><div class='my-toast-text'></div></div>");
    //        var jq_text = jq_toast.find(".my-toast-text");
    //        jq_text.html(content);
    //        jq_toast.appendTo($("body")).stop().fadeIn(500).delay(3000).fadeOut(500);
    //        var w = jq_toast.width() - 10;
    //        jq_text.width(w);
    //        var l = -jq_toast.outerWidth() / 2;
    //        var t = -jq_toast.outerHeight() / 2;
    //        jq_toast.css({
    //            "margin-left": l + "px",
    //            "margin-top": t - 50 + "px"
    //        });
    //        var _jq_toast = jq_toast;
    //        setTimeout(function () {
    //            _jq_toast.remove();
    //        }, 3 * 1000);
    //    };
    //    $.mytoast({
    //        type: "notice"
    //    });
    //}
</script>
</html>

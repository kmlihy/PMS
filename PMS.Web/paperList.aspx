<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paperList.aspx.cs" Inherits="PMS.Web.paperList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文列表</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />

</head>

<body>
    <div class="container-fluid paperlistbox">
        <div class="container">
            <h1 class="col-sm-3  col-sm-offset-5">选题列表
            </h1>
        </div>
        <table class="table table-striped paperlisttable">
            <thead>
                <tr>
                    <th>论文题目
                    </th>
                    <th>已选人数/人数上限
                    </th>
                    <th>状态
                    </th>
                </tr>
            </thead>
            <tbody>
                <% for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {  %>
                <tr>
                    <td>
                        <a href="paperDetail.aspx?titleId=<%=ds.Tables[0].Rows[i]["titleId"].ToString() %>"><%=ds.Tables[0].Rows[i]["title"].ToString()%></a>
                    </td>
                    <td><%=ds.Tables[0].Rows[i]["selected"].ToString()%>/<%=ds.Tables[0].Rows[i]["limit"].ToString()%>
                    </td>
                    <td>
                        <a class="btn btn-primary" href="PaperDtailStu.aspx?titleId=<%=ds.Tables[0].Rows[i]["titleId"].ToString() %>">选题</a>
                    </td>
                </tr>
                <%} %>
            </tbody>
        </table>

        <div class="container text-right paperpagination-div ">
            <ul class="pagination pagination-lg">
                <li>
                    <a href="#" class="jump" id="first">首页</a>
                </li>
                <li>
                    <a href="#" class="jump" id="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
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
                        <span class="glyphicon glyphicon-chevron-right"></span>
                    </a>
                </li>
                <li>
                    <a href="#" class="jump" id="last">尾页</a>
                </li>
            </ul>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="../js/lgd.js"></script>
<script>
    //当前页数
    sessionStorage.setItem("Page",<%=getCurrentPage%>);
    //总页
    sessionStorage.setItem("countPage",<%=count%>);
    $(document).ready(function () {
        $(".jump").click(function(){
            switch($.trim($(this).html())){
                case('<span class="glyphicon glyphicon-chevron-left"></span>'):
                    if(parseInt(sessionStorage.getItem("Page"))>1){
                        jump(parseInt(sessionStorage.getItem("Page"))-1);
                        break;
                    }
                    else{
                        jump(1);
                        break;
                    }
                    
                case('<span class="glyphicon glyphicon-chevron-right"></span>'):
                    if(parseInt(sessionStorage.getItem("Page"))<parseInt(sessionStorage.getItem("countPage"))){
                        jump(parseInt(sessionStorage.getItem("Page"))+1);
                        break;
                    }
                    else{
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                    }
                case("首页"):
                    jump(1);
                    break;
                case("尾页"):
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
            }
        });
        $("#btn-search").click(function(){
            var strWhere =$("#inputsearch").val();
            sessionStorage.setItem("strWhere",strWhere);
            jump(1);
        });
        function jump(cur) {
            if(sessionStorage.getItem("strWhere")==null){
                window.location.href = "paperList.aspx?currentPage=" + cur;
            }else{
                window.location.href ="paperList.aspx?currentPage="+cur+"&search="+sessionStorage.getItem("strWhere");
            }
        };
        if (sessionStorage.getItem("countPage") == "1") {
            $("#first").hide();
            $("#last").hide();
        }
    });
</script>
</html>

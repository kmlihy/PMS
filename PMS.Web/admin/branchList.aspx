<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="branchList.aspx.cs" Inherits="PMS.Web.admin.branchList" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
        <link rel="stylesheet" href="../css/bootstrap.min.css" />
        <link rel="stylesheet" href="../css/ml.css" />
        <link rel="stylesheet" href="../css/style.css" />
        <link rel="stylesheet" href="../square/_all.css" />
    </head>

    <body>
        <div class="container-fluid big-box">
            <nav class="navbar navbar-default" role="navigation">
                <div class="container-fluid">
                    <div>
                        <ul class="nav navbar-nav">
                            <li class="active col-sm-4  ">
                                <div class="input-group" style="margin-top: 7px">
                                    <input type="text" id="strQuery" name="strQuery" class="form-control" placeholder="请输入查询条件" />
                                    <span class="input-group-btn">
                                    <button class="btn btn-info" id="btnQuery" type="button" onclick="quaryChange()">
                                        <span id="query" class="glyphicon glyphicon-search"></span>查询
                                    </button>
                                    </span>
                                </div>
                            </li>
                            <li class="active">
                                <button class="btn btn-success" id="btn-Add">
                                <span class="glyphicon glyphicon-plus-sign"></span>
                                新增
                            </button>
                            </li>
                            <li class="active container-fluid">
                                <button class="btn btn-danger" id="btn-Add">
                                <span class="glyphicon glyphicon-trash"></span>
                                批量删除
                            </button>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div class="">
                <table class="table table-bordered table-hover">
                    <thead>
                        <th class="text-center">
                            <input type="checkbox" class="js-checkbox-all" />
                        </th>
                        <th class="text-center">序号</th>
                        <th class="text-center">名称</th>
                        <th class="text-center">操作</th>
                    </thead>
                    <tbody>
                        <% 
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                        %>
                            <tr>
                                <td class="text-center">
                                    <input type="checkbox" />
                                </td>
                                <td class="text-center">
                                    <%=i+1 %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <button class="btn btn-default btn-sm btn-warning">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                                    <button class="btn btn-default btn-sm btn-danger">
                                <span class="glyphicon glyphicon-trash"></span>
                            </button>
                                </td>
                            </tr>
                            <%  }%>
                    </tbody>
                </table>
                <div class="container-fluid text-right">
                    <ul class="pagination pagination-lg">
                        <li>
                            <a href="#" onclick="previousPage()">
                                <span id="upPage" class="glyphicon glyphicon-chevron-left"></span>
                            </a>
                        </li>
                        <%--//TODO 绑定当前页数--%>
                            <li>
                                <a href="#">1</a>
                            </li>
                            <li>
                                <a href="#">/</a>
                            </li>
                            <%--//TODO 绑定总页数--%>
                                <li>
                                    <a href="#">10</a>
                                </li>
                                <li>
                                    <a href="#" onclick="nextPage()">
                                        <span id="downPage" class="glyphicon glyphicon-chevron-right" onclick="nextPage()"></span>
                                    </a>
                                </li>
                    </ul>
                </div>
            </div>
        </div>
    </body>
    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/icheck.min.js"></script>
    <script src="../js/ml.js"></script>
    <script>
        $(function() {
            $(document).ready(function() {
                if (!window.localStorage) {
                    alert("浏览器支持localstorage");
                    return false;
                } else {
                    //alert("OK");
                    var storage = window.localStorage;
                    storage.clear();
                    //存入总页数
                    sessionStorage.setItem("countPage", 10);
                    //存入当前页面
                    sessionStorage.setItem("currentPage", 1);
                }
            });
            //上一页
            function previousPage() {
                var data = {
                    currentPage: sessionStorage.getItem("currentPage"),
                    op: 1
                }
                if (sessionStorage.getItem("countPage") != 1) {
                    $.ajax({
                        type: "POST",
                        url: "branchList.aspx",
                        data: "data"
                    });
                    var x = parseInt(sessionStorage.getItem("currentPage")) - 1;
                    sessionStorage.setItem("currentPage", x);
                }
            }
            //下一页
            function nextPage() {
                var data = {
                    currentPage: sessionStorage.getItem("currentPage"),
                    op: 2
                }
                if (sessionStorage.getItem("currentPage") != sessionStorage.getItem("countPage")) {
                    $.ajax({
                        type: "Post",
                        url: "branchList.aspx",
                        data: data
                    });
                    var x = parseInt(sessionStorage.getItem("currentPage")) + 1;
                    sessionStorage.setItem("currentPage", x);
                }
            }
            //查询条件
            function quaryChange() {

                var strQuery = $("#strQuery").val();
                var storage = window.localStorage;
                var data = {
                    name: strQuery,
                    currentPage: storage.currentPage
                }
                $.ajax({
                    type: "Post",
                    url: "branchList.aspx",
                    data: data
                });
            }
        })
    </script>

    </html>
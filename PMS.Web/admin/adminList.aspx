<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminList.aspx.cs" Inherits="PMS.Web.admin.adminList" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
        <link rel="stylesheet" href="../css/bootstrap.min.css"/>
        <link rel="stylesheet" href="../css/ml.css"/>
        <link rel="stylesheet" href="../css/style.css"/>
        <link rel="stylesheet" href="../square/_all.css"/>
    </head>

    <body>
        <div class="container-fluid big-box">
            <nav class="navbar navbar-default" role="navigation">
                <div class="container-fluid">
                    <div>
                        <ul class="nav navbar-nav">
                            <li class="active col-sm-4  ">
                                <div class="input-group" style="margin-top: 7px">
                                    <input type="text" id="strQuery" name="strQuery" class="form-control" placeholder="请输入查询条件"/>
                                    <span class="input-group-btn">
                                    <button class="btn btn-info" type="button" onclick="queryChange()">
                                        <span class="glyphicon glyphicon-search"></span> 查询
                                    </button>
                                    </span>
                                </div>
                            </li>
                            <li class="active">
                                <div class="form-group checkbox-stu">
                                    <select class="form-control">
                                        <option value="">-请选择分院-</option>
                                        <%for(int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                                          {
                                        %>
                                            <option value="">
                                            <%= dsColl.Tables[0].Rows[i]["collegeName"].ToString() %>
                                            </option>
                                        <%} %>
                                    </select>
                                </div>
                            </li>
                            <li class="active">
                                <button type="button" class="btn-success btn checkbox-stu">
                                    <span class="glyphicon glyphicon-search">查询</span>
                                </button>
                            </li>
                            <li class="active">
                                <button type="button" class="btn-info btn checkbox-stu">
                                    <span class="glyphicon glyphicon-search">新增</span>
                                </button>
                            </li>
                            <li class="active">
                                <button type="button" class="btn-danger btn checkbox-stu">
                                    <span class="glyphicon glyphicon-trash">批量删除</span>
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
                            <input type="checkbox" class="js-checkbox-all"/>
                        </th>
                        <th class="text-center">序号</th>
                        <th class="text-center">工号</th>
                        <th class="text-center">姓名</th>
                        <th class="text-center">性别</th>
                        <th class="text-center">院系</th>
                        <th class="text-center">联系电话</th>
                        <th class="text-center">邮箱</th>
                        <th class="text-center">操作</th>
                    </thead>
                    <tbody>
                        <% 
                            for (int i = 0; i <ds.Tables[0].Rows.Count;i++)
                            {%>
                            <tr>
                                <td class="text-center">
                                    <input type="checkbox"/>
                                </td>
                                <td class="text-center">
                                    <%= i+1 %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["teaAccount"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["teaName"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["sex"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["phone"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["Email"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <button class="btn btn-default btn-sm btn-danger">
                                <span class="glyphicon glyphicon-trash"></span>
                            </button>
                                    <button class="btn btn-default btn-sm btn-warning">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                                </td>
                            </tr>
                            <% }%>
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
        $(document).ready(function() {
            if (!window.localStorage) {
                alert("浏览器支持localstorage");
                return false;
            } else {
                //alert("ok");
                var storage = window.localStorage;
                storage.clear();
                dsCount = ds.Tables[0].Rows.Count;
                if (dsCount / <%=pageSize%> == 0) {
                    allPageNum = dsCount / <%=pageSize%>;
                } else {
                    allPageNum = dsCount / <%=pageSize%> + 1;
                }
                //TODE:存入总页数
                sessionStorage.setItem("countPage", allPageNum);
                pageNum = <%=pageNum%>;
                //TODE:存入当前页
                sessionStorage.setItem("currentPage", pageNum);
            }
        });
        //上一页
        function previousPage() {
            //alert("上一页")
            var data = {
                currentPage: sessionStorage.getItem("currentPage"),
                op: 1
            }
            if (sessionStorage.getItem("currentPage") != 1) {
                $.ajax({
                    type: "Post",
                    url: "adminList.aspx",
                    data: data
                });
                var x = parseInt(sessionStorage.getItem("currentPage")) - 1;
                if (x <= 1) {
                    x = 1;
                }
                sessionStorage.setItem("currentPage", x);
            }
        }
        //下一页
        function nextPage() {
            //alert("下一页")
            var data = {
                currentPage: sessionStorage.getItem("currentPage"),
                op: 2
            }
            if (sessionStorage.getItem("currentPage") != sessionStorage.getItem("countPage")) {
                $.ajax({
                    type: "Post",
                    url: "adminList.aspx",
                    data: data
                });
                var x = parseInt(sessionStorage.getItem("currentPage")) + 1;
                if (x >= allPageNum) {
                    x = allPageNum;
                }
                sessionStorage.setItem("currentPage", x);
            }
        }
        //查询条件
        function queryChange() {

            var strQuery = $("#strQuery").text();
            var storage = window.localStorage;
            var data = {
                name: strQuery,
                currentPage: storage.currentPage
            }
            $.ajax({
                type: "Post",
                url: "adminList.aspx",
                data: data
            });
        }
    </script>
    </html>
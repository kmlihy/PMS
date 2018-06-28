<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="branchList.aspx.cs" Inherits="PMS.Web.admin.branchList" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>分院信息表</title>
        <link rel="stylesheet" href="../css/bootstrap.min.css" />
        <link rel="stylesheet" href="../css/ml.css" />
        <link rel="stylesheet" href="../css/lgd.css">
        <link rel="stylesheet" href="../css/style.css" />
        <link rel="stylesheet" href="../square/_all.css" />
        <link rel="stylesheet" href="../css/bootstrap-select.css" />
    </head>

    <body>
        <div class="container-fluid ">
            <div class="panel panel-default" id="teapanelbox">
                <div class="pane input-group" id="panel-head">
                    <div class="input-group" id="inputgroups">
                        <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" />
                        <span class="input-group-btn">
                        <button class="btn btn-info" type="button" id="btn-search">
                            <span class="glyphicon glyphicon-search" >查询</span>
                        </button>
                        </span>
                        <span class="input-group-btn">
                        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="btn-Add">
                            <span class="glyphicon glyphicon-plus-sign">新增</span>
                        </button>
                        </span>
                        <button class="btn btn-danger" type="button" id="btn-Del">
                        <span class="glyphicon glyphicon-trash"></span>
                        批量删除
                    </button>
                    </div>
                </div>
            </div>
            <div class="">
                <table class="table table-bordered table-hover">
                    <thead>
                        <th class="text-center">
                            <input type="checkbox" class="js-checkbox-all" />
                        </th>
                        <th class="text-center">工号</th>
                        <th class="text-center">学院名称</th>
                        <th class="text-center">操作</th>
                    </thead>
                    <tbody>
                        <%
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                    %>
                            <tr>
                                <td class="text-center">
                                    <input type="checkbox">
                                </td>
                                <td class="text-center">
                                    <%=i+1 %>
                                </td>
                                <td class="text-center">
                                    <%=ds.Tables[0].Rows[i]["collegeName"].ToString() %>
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
                            <%
                        }
                    %>
                    </tbody>
                </table>
                <div class="container-fluid text-right">
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
        </div>
        <!-- 添加分院弹框 -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                        <h4 class="modal-title" id="myModalLabel">添加分院
                        </h4>
                    </div>
                    <div class="modal-body">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="teaLable text-center"><label class="text-span">学院名称</label></td>
                                    <td>
                                        <input class="form-control teaAddinput" type="text" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        <button type="button" class="btn btn-primary">提交更改</button>
                    </div>
                </div>
            </div>
        </div>
    </body>
    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/icheck.min.js"></script>
    <script src="../js/ml.js"></script>
    <script src="../js/bootstrap-select.js"></script>
    <script>
        <!-- 分页 -->
        //存储当前页数
        sessionStorage.setItem("page", <%=getCurrentPage %>);
        //存储总页数
        sessionStorage.setItem("countPage", <%=count %>);
            $(document).ready(function () {
            //sessionStorage.setItem("strWhere", "");
            $(".jump").click(function() {
                switch ($.trim($(this).html())) {
                    //点击上一页按钮时
                    case ('<span class="glyphicon glyphicon-chevron-left"></span>'):
                        if (parseInt(sessionStorage.getItem("page")) > 1) {
                            jump(parseInt(sessionStorage.getItem("page")) - 1);
                            sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) - 1);
                            break;
                        } else {
                            jump(1);
                            break;
                        }
                        //点击下一页按钮时
                    case ('<span class="glyphicon glyphicon-chevron-right"></span>'):
                        if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {
                            jump(parseInt(sessionStorage.getItem("page")) + 1);
                            sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) + 1);
                            break;
                        } else {
                            jump(parseInt(sessionStorage.getItem("countPage")));
                            break;
                        }
                        //点击首页按钮时
                    case ("首页"):
                        jump(1);
                        break;
                        //点击尾页按钮时
                    case ("尾页"):
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                }
            });
            //点击查询按钮时
            $("#btn-search").click(function() {
                var strWhere = $("#inputsearch").val();
                sessionStorage.setItem("strWhere", strWhere);
                jump(1);
            });

            function jump(cur) {
                if (sessionStorage.getItem("strWhere") == null) {
                    window.location.href = "branchList.aspx?currentPage=" + cur
                } else {
                    window.location.href = "branchList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
                    //sessionStorage.setItem("strWhere", null);
                }
            }
            //当总页数为1时，首页与尾页按钮隐藏
            if (sessionStorage.getItem("countPage") == "1") {
                $("#first").hide();
                $("#last").hide();
            }
        })
    </script>

    </html>
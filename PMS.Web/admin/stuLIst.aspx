<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuLIst.aspx.cs" Inherits="PMS.Web.admin.stuLIst" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>学生信息表</title>
        <link rel="stylesheet" href="../css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/ml.css">
    <link rel="stylesheet" href="../css/style.css">
    <link rel="stylesheet" href="../square/_all.css">
    </head>

    <body>
        <div class="container-fluid big-box">
            <nav class="navbar navbar-default" role="navigation">
                <div class="container-fluid">
                    <div>
                        <ul class="nav navbar-nav">
                            <li class="active">
                                <div class="input-group" id="search-stu">
                                    <input type="text" class="form-control" placeholder="请输入查询条件"/>
                                </div>
                            </li>
                            <li class="active">
                                <div class="form-group checkbox-stu">
                                    <select class="form-control">
                                        <option value="">-请选择分院-</option>
                                        <% for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                            { %>
                                            <option value="">
                                                <%= ds.Tables[0].Rows[i]["collegeName"] %>
                                            </option>
                                            <% } %>
                                    </select>
                                </div>
                            </li>
                            <li class="active">
                                <div class="form-group checkbox-stu">
                                    <select class="form-control">
                                        <option value="">-请选择专业-</option>
                                        <% for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                            { %>
                                            <option value="">
                                                <%= ds.Tables[0].Rows[i]["proName"] %>
                                            </option>
                                            <% } %>
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
                        <th class="text-center">学号</th>
                        <th class="text-center">姓名</th>
                        <th class="text-center">性别</th>
                        <th class="text-center">专业</th>
                        <th class="text-center">院系</th>
                        <th class="text-center">联系电话</th>
                        <th class="text-center">邮箱</th>
                        <th class="text-center">操作</th>
                    </thead>
                    <tbody>
                        <% for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            { %>
                            <tr>
                                <td class="text-center">
                                    <input type="checkbox" />
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["stuAccount"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["realName"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["sex"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["proName"].ToString() %>
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
                                    <button class="btn btn-default btn-sm btn-success">
                                        <span class="glyphicon glyphicon-search"></span>
                                    </button>
                                    <button class="btn btn-default btn-sm btn-danger">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </button>
                                    <button class="btn btn-default btn-sm btn-warning">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                    </button>
                                </td>
                            </tr>
                            <% } %>
                    </tbody>
                </table>
                <div class="container-fluid text-right">
                    <ul class="pagination pagination-lg">
                        <li>
                            <a href="">
                                <span class="glyphicon glyphicon-chevron-left" id="pageDown" onclick="value()"></span>
                            </a>
                        </li>
                        <li>
                            <a href="">1</a>
                        </li>
                        <li>
                            <a href="">
                                <span class="glyphicon glyphicon-chevron-right"></span>
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
    </html>
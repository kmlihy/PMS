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
                                    <input type="text" class="form-control" placeholder="请输入查询条件"/>
                                    <span class="input-group-btn">
                                    <button class="btn btn-info" type="button">
                                        <span class="glyphicon glyphicon-search"></span> 查询
                                    </button>
                                    </span>
                                </div>
                            </li>
                            <!-- <li class="active">
                                <button class="btn btn-info" id="btn-search">
                                    <span class="glyphicon glyphicon-search"></span>
                                    查询
                                </button>
                            </li> -->
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">性别
                                    <b class="caret"></b>
                            </a>
                                <ul class="dropdown-menu">
                                    <li>
                                        <a href="#">男</a>
                                    </li>
                                    <li>
                                        <a href="#">女</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">院系
                                    <b class="caret"></b>
                            </a>
                                <ul class="dropdown-menu">
                                    <%for(int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                                      {
                                    %>
                                        <li>
                                            <%= dsColl.Tables[0].Rows[i]["collegeName"].ToString() %>
                                        </li>
                                        <%} %>
                                </ul>
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
                            <a href="">
                                <span class="glyphicon glyphicon-chevron-left"></span>
                            </a>
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
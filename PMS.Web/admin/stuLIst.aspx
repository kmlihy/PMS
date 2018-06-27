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
        <link rel="stylesheet" href="../css/bootstrap-select.css">
    </head>

    <body>
        <div class="container-fluid" style="margin-top: 10px;">
            <div class="input-group" style="margin-bottom: 10px;">
                <div class="input-group" style="position: relative;">
                    <select name="" id="" class="selectpicker">
                        <option value="select">請選擇查詢的專業</option>
                        <option value="1">1</option>
                    </select>
                    <span class="input-group" style="position: relative; width: 300px;margin-left: 5px;">
                        <input type="text" name="" id="" class="form-control" placeholder="請輸入查詢條件">
                        <span class="btn input-group-addon">
                            <i class="glyphicon glyphicon-search"></i>
                            查詢
                        </span>
                    </span>
                </div>
                <div class="input-group" style="position: absolute;margin-top: -34px;margin-left: 460px;">
                    <button class="btn btn-success">
                        <span class="glyphicon glyphicon-plus-sign"></span>
                        新增
                    </button>
                    <button class="btn btn-danger" style="position: absolute; margin-left: 5px;">
                        <span class="glyphicon glyphicon-trash"></span>
                        批量刪除
                    </button>
                </div>
            </div>
            <div class="">
                <table class="table table-bordered table-hover">
                    <thead>
                        <th class="text-center">
                            <input type="checkbox" class="js-checkbox-all" />
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
    <script src="../js/bootstrap-select.js"></script>

    </html>
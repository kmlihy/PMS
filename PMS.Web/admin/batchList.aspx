<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="batchList.aspx.cs" Inherits="PMS.Web.admin.batchList" %>

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
        <div class="container-fluid panel " style="margin-top: 10px;">
                <div class="input-group" style="margin-bottom: 10px;">
                        <div class="input-group" style="position: relative;">
                            <span class="input-group" style="position: relative; width: 300px;margin-left: 5px;">
                                <input type="text" name="" id="" class="form-control" placeholder="請輸入查詢條件">
                                <span class="btn input-group-addon">
                                    <i class="glyphicon glyphicon-search"></i>
                                    查詢
                                </span>
                            </span>
                        </div>
                        <div class="input-group" style="position: absolute;margin-top: -34px;margin-left: 310px;">
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
                            <input type="checkbox" class="js-checkbox-all"/>
                        </th>
                        <th class="text-center">序号</th>
                        <th class="text-center">批次名</th><th class="text-center">开始时间</th>
                        <th class="text-center">结束时间</th>
                        <th class="text-center">所属学院</th>
                        <th class="text-center">激活状态</th>
                        <th class="text-center">操作</th>
                    </thead>
                    <tbody>
                        <%
                            for(int i=0; i < plands.Tables[0].Rows.Count; i++) { 
                        %>
                        <tr>
                            <td class="text-center">
                                <input type="checkbox"/>
                            </td>
                            <td class="text-center">
                                <%= plands.Tables[0].Rows[i]["planId"].ToString() %>
                            </td>
                            <td class="text-center">
                                <%= plands.Tables[0].Rows[i]["planName"].ToString() %>
                            </td>
                            <td class="text-center">
                                <%= plands.Tables[0].Rows[i]["startTime"].ToString() %>
                            </td>
                            <td class="text-center">
                                <%= plands.Tables[0].Rows[i]["endTime"].ToString() %>
                            </td>
                            <td class="text-center">
                                <%= plands.Tables[0].Rows[i]["state"].ToString() %>
                            </td>
                            <td class="text-center">
                                <%= plands.Tables[0].Rows[i]["collegeName"].ToString() %>
                            </td>
                            <td class="text-center">
                                <button class="btn btn-default btn-sm btn-info">
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
                        <%
                            }
                        %>
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
                            <a href="">1</a>
                        </li>
                        <li>
                            <a href="">2</a>
                        </li>
                        <li>
                            <a href="">3</a>
                        </li>
                        <li>
                            <a href="">...</a>
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
</html>

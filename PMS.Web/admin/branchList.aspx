<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="branchList.aspx.cs" Inherits="PMS.Web.admin.branchList" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
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
                            <li class="active col-sm-4  ">
                                <div class="input-group" style="margin-top: 7px">
                                    <input type="text" id="txtQuery" class="form-control" placeholder="请输入查询条件">
                                    <span class="input-group-btn">
                                    <button class="btn btn-info" id="btnQuery" type="button">
                                        <span class="glyphicon glyphicon-search"></span>查询
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
                            <input type="checkbox" class="js-checkbox-all">
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
                                    <input type="checkbox">
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
    <%--<script>
        $("#btnQuery").click(function() {
            var txtQuery = $("#txtQuery").val();
            if (txtQuery == "") {

            } else {

            }
        })
        var $checkboxAll = $(".js-checkbox-all"),
            $checkbox = $("tbody").find("[type='checkbox']"),
            length = $checkbox.length,
            i = 0;

        //启动icheck
        $(("[type='checkbox']")).iCheck({
            checkboxClass: 'icheckbox_square-orange',
        });

        //全选checkbox
        $checkboxAll.on("ifClicked", function(event) {
            if (event.target.checked) {
                $checkbox.iCheck('uncheck');
                i = 1;
            } else {
                $checkbox.iCheck('check');
                i = length;
            }
        });

        //监听计数
        $checkbox.on('ifClicked', function(event) {
            event.target.checked ? i-- : i++;
            if (i == length + 1) {
                $checkboxAll.iCheck('check');
            } else {
                $checkboxAll.iCheck('uncheck');
            }
        });
    </script>--%>

    </html>
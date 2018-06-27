<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="batchList.aspx.cs" Inherits="PMS.Web.admin.batchList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>批次表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ml.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
</head>

<body>
    <div class="container-fluid panel " style="margin-top: 10px;">
        <div class="input-group box">
            <div class="input-group box-1">
                <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" />
                <span class="input-group-btn">
                    <button class="btn btn-info" type="button">
                        <span class="glyphicon glyphicon-search">查询</span>
                    </button>
                </span>
                <span class="input-group-btn">
                    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="btn-Add">
                        <span class="glyphicon glyphicon-plus-sign">新增</span>
                    </button>
                </span>
                <button class="btn btn-danger" type="button" id="btn-delete">
                    <span class="glyphicon glyphicon-trash"></span>
                    批量删除
                </button>
            </div>
        </div>
        <div class="">
            <table class="table table-bordered table-hover">
                <thead>
                    <th class="text-center">
                        <input type="checkbox" class="js-checkbox-all" />
                    </th>
                    <th class="text-center">序号</th>
                    <th class="text-center">批次名</th>
                    <th class="text-center">开始时间</th>
                    <th class="text-center">结束时间</th>
                    <th class="text-center">所属学院</th>
                    <th class="text-center">激活状态</th>
                    <th class="text-center">操作</th>
                </thead>
                <tbody>
                    <%
                        for (int i = 0; i < plands.Tables[0].Rows.Count; i++)
                        {
                    %>
                    <tr>
                        <td class="text-center">
                            <input type="checkbox" />
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
                        <a href="#" class="jump">
                            <span class="glyphicon glyphicon-chevron-left" id="pageDown" onclick="value()"></span>
                        </a>
                    </li>
                    <li>
                        <a href="#" class="jump"><%=getCurrentPage %></a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <a href="#" class="jump"><%=intPageCount %></a>
                    </li>
                    <li>
                        <a href="#" class="jump">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!-- 添加学生弹框（Modal） -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">添加批次
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-hover">
                        <tbody>
                            <tr>
                                <td class="teaLable">批次名称</td>
                                <td>
                                    <input class="form-control" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">开始时间</td>
                                <td>
                                    <input class="form-control" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">结束时间</td>
                                <td>
                                    <input class="form-control" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">激活状态</td>
                                <td>
                                    <input class="form-control" type="text" /></td>
                            </tr>

                            <tr>
                                <td class="teaLable">院系</td>
                                <td>
                                    <select class="selectpicker" data-width="auto">
                                        <option value="">请选择院系</option>
                                        <option value="">信息工程学院</option>
                                    </select>
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
    $(document).ready(function () {
        $(".jump").click(function () {
            switch ($.trim($(this).html())) {
                case ('<span class="glyphicon glyphicon-chevron-left" id="pageDown" onclick="value()"></span>'):
                    jump(<%=int.Parse( ViewState["page"].ToString())-1%>);
                    break;
                case ('<span class="glyphicon glyphicon-chevron-right"></span>'):
                    jump(<%=int.Parse( ViewState["page"].ToString())+1%>);
                    break;
                case ("<%=getCurrentPage %>"):
                    jump(1);
                    break;
                case ("<%=intPageCount %>"):
                    jump(<%=intPageCount %>);
                    break;
            }
        });
        function jump(cur) {
            window.location.href = "batchList.aspx?currentPage=" + cur;
        }
    })
</script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proList.aspx.cs" Inherits="PMS.Web.admin.proList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ml.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
</head>
<body>
    <div class="container-fluid big-box">
        <div class="panel panel-default">
            <div class="input-group col-sm-6">
                <input type="text" class="form-control" placeholder="请输入查询条件" style="margin-top:12px;" />
                <span class="input-group-btn">
                    <button class="btn btn-info" type="button">
                        <span class="glyphicon glyphicon-search">查询</span>
                    </button>
                </span>
                <div class="input-group">
                    <button class="btn btn-success" data-toggle="modal" data-target="#myModal" id="btn-Add">
                        <span class="glyphicon glyphicon-plus-sign"></span>
                        新增
                    </button>
                    <button class="btn btn-danger" id="btn-Del">
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
                    <th class="text-center">序号</th>
                    <th class="text-center">专业名称</th>
                    <th class="text-center">所属分院</th>
                    <th class="text-center">操作</th>
                </thead>
                <tbody>
                    <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        { %>
                    <tr>
                        <td class="text-center">
                            <input type="checkbox" />
                        </td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["proId"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["proName"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["collegeName"].ToString() %></td>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-warning">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-danger">
                                <span class="glyphicon glyphicon-trash"></span>
                            </button>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
            <div class="container-fluid text-right">
                <ul class="pagination pagination-lg">
                    <li>
                        <a href="#" class="jump" id="prev">上一页
                        </a>
                    </li>
                    <li>
                        <a href="#" class="jump"><%=getCurrentPage %></a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <a href="#" class="jump"><%=count %></a>
                    </li>
                    <li>
                        <a href="#" id="next" class="jump">下一页
                        </a>
                    </li>
                </ul>
            </div>

        </div>
    </div>
    <!--添加专业弹窗-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    </button>
                    <h4 class="modal-title" id="myModalLabel">添加专业
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="form-group" style="height: 100px;">
                        <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">姓名:</label>
                        <div class="col-sm-6">
                            <input type="text" class="form-control input-sm" placeholder="请输入姓名" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lastname" class="col-sm-2  col-sm-offset-3 control-label">姓名:</label>
                        <div class="col-sm-6">
                            <input type="text" class="form-control input-sm" placeholder="请输入姓名" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="submit" class="btn btn-primary">提交</button>
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
                case ("上一页"):
                    jump(<%=int.Parse( ViewState["page"].ToString())-1%>);
                    break;
                case ("下一页"):
                    jump(<%=int.Parse( ViewState["page"].ToString())+1%>);
                    break;
                case ("1"):
                    jump(1);
                    break;
                case ("<%=count %>"):
                    jump(<%=count %>);
                    break;
            }
        });
        function jump(cur) {
            window.location.href = "proList.aspx?currentPage=" + cur;
        }
    })
</script>
</html>

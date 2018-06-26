<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teaList.aspx.cs" Inherits="PMS.Web.admin.teaList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教师信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ml.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
</head>
<style>
    .teaLable {
        text-align: right;
    }
</style>

<body>
    <div class="container-fluid big-box">
        <div class="input-group">
            <div class="input-group">
                <input type="text" class="form-control" placeholder="请输入查询条件" style="width: 150px; float: none;" />
                <span class="input-group-btn">
                    <button class="btn btn-info" type="button">
                        <span class="glyphicon glyphicon-search">查询</span>
                    </button>
                </span>
                <div class="input-group">
                    <button class="btn btn-danger" type="button">
                        <span class="glyphicon glyphicon-trash"></span>
                        批量删除
                    </button>
                    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="btn-Add">
                        <span class="glyphicon glyphicon-plus-sign">新增</span>
                    </button>
                </div>
            </div>

        </div>
        <div class="">
            <table class="table table-bordered table-hover">
                <thead>
                    <th class="text-center">
                        <input type="checkbox" class="js-checkbox-all">
                    </th>
                    <th class="text-center">工号</th>
                    <th class="text-center">姓名</th>
                    <th class="text-center">性别</th>
                    <th class="text-center">院系</th>
                    <th class="text-center">教师类别</th>
                    <th class="text-center">联系电话</th>
                    <th class="text-center">邮箱</th>
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
                            <%=ds.Tables[0].Rows[i]["teaAccount"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%=ds.Tables[0].Rows[i]["teaName"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%=ds.Tables[0].Rows[i]["sex"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%=ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%=ds.Tables[0].Rows[i]["teaType"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%=ds.Tables[0].Rows[i]["phone"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%=ds.Tables[0].Rows[i]["Email"].ToString() %>
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
                    <%
                        }
                    %>
                </tbody>
            </table>
            <div class="container-fluid text-right">
                <ul class="pagination pagination-lg">
                    <li>
                        <a href="#" class="jump" id="prev">上一页
                        </a>
                    </li>
                    <li>
                        <a href="#" class="jump">1</a>
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
    <!-- 添加教师弹框（Modal） -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">添加教师
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-hover">
                        <tbody>
                            <tr>
                                <td class="teaLable">工号</td>
                                <td>
                                    <input class="form-control" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">姓名</td>
                                <td>
                                    <input class="form-control" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">性别</td>
                                <td>
                                    <select class="selectpicker" data-width="auto">
                                        <option value="">男</option>
                                        <option value="">女</option>
                                    </select>
                                </td>
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
                            <tr>
                                <td class="teaLable">职称</td>
                                <td>
                                    <select class="selectpicker" data-width="auto">
                                        <option value="">教授</option>
                                        <option value="">副教授</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">邮箱</td>
                                <td>
                                    <input class="form-control" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">联系电话</td>
                                <td>
                                    <input class="form-control" type="text" /></td>
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
            // alert($.trim($(this).html()));
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
            window.location.href = "teaList.aspx?currentPage=" + cur;
        }
    })
</script>
</html>

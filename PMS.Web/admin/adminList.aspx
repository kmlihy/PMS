<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminList.aspx.cs" Inherits="PMS.Web.admin.adminList" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>分院管理员信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ml.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
</head>

<body>
    <div class="container-fluid ">
        <!-- 编辑区-->
        <div class="panel panel-default" id="teapanelbox">
            <div class="pane input-group" id="panel-head">
                <div class="input-group" id="inputgroups">
                    <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" />
                    <span class="input-group-btn">
                        <button class="btn btn-info" type="button" id="btn-search">
                            <span class="glyphicon glyphicon-search">查询</span>
                        </button>
                    </span>
                    <span class="input-group-btn">
                        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="btn-Add">
                            <span class="glyphicon glyphicon-plus-sign">新增</span>
                        </button>
                    </span>
                    <button class="btn btn-danger" type="button" id="btn-Del" onclick="mizhu.toast('前无古人！', 4000);">
                        <span class="glyphicon glyphicon-trash"></span>
                        批量删除
                    </button>
                </div>
            </div>
        </div>
        <!-- 数据展示区-->
        <table class="table table-bordered table-hover">
            <thead>
                <th class="text-center">
                    <input type="checkbox" class="js-checkbox-all" />
                </th>
                <th class="text-center">序号</th>
                <th class="text-center">工号</th>
                <th class="text-center">姓名</th>
                <th class="text-center">密码</th>
                <th class="text-center">性别</th>
                <th class="text-center">院系</th>
                <th class="text-center">联系电话</th>
                <th class="text-center">邮箱</th>
                <th class="text-center">操作</th>
            </thead>
            <tbody>
                <% 
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {%>
                <tr>
                    <td class="text-center">
                        <input type="checkbox" />
                    </td>
                    <td class="text-center">
                        <%= i+1 %>
                    </td>
                    <td class="text-center" id="teaAccount">
                        <%= ds.Tables[0].Rows[i]["teaAccount"].ToString() %>
                    </td>
                    <td class="text-center" id="teaName">
                        <%= ds.Tables[0].Rows[i]["teaName"].ToString() %>
                    </td>
                    <td class="text-center" id="teaPwd">
                        <%= ds.Tables[0].Rows[i]["teaPwd"].ToString() %>
                    </td>
                    <td class="text-center" id="sex">
                        <%= ds.Tables[0].Rows[i]["sex"].ToString() %>
                    </td>
                    <td class="text-center" id="<%= ds.Tables[0].Rows[i]["collegeId"].ToString() %>">
                        <%= ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                    </td>
                    <td class="text-center" id="phone">
                        <%= ds.Tables[0].Rows[i]["phone"].ToString() %>
                    </td>
                    <td class="text-center" id="email">
                        <%= ds.Tables[0].Rows[i]["Email"].ToString() %>
                    </td>
                    <td class="text-center">
                        <button class="btn btn-default btn-sm btn-warning btnEdit" data-toggle="modal" data-target="#editModal">
                            <span class="glyphicon glyphicon-pencil"></span>
                        </button>
                        <button class="btn btn-default btn-sm btn-danger">
                            <span class="glyphicon glyphicon-trash"></span>
                        </button>
                    </td>
                </tr>
                <% }%>
            </tbody>
        </table>
        <!-- 翻页区域-->
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
    <!-- 添加分院管理员弹框-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">添加分院管理员
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="teaLable text-center">
                                    <label class="text-span">工号</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="Iaccount" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">姓名</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="Iname" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="Isex">
                                        <option>请选择性别</option>
                                        <option value="男">男</option>
                                        <option value="女">女</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">院系</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="Icoll">
                                        <option value="">请选择院系</option>
                                        <%for (int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=dsColl.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=dsColl.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                        <%} %>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">邮箱</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="Iemail" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="Iphone" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary" id="btnInsert">提交更改</button>
                </div>
            </div>
        </div>
    </div>
    <!-- 编辑分院管理员弹框 -->
    <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="delModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="delModalLabel">编辑分院</h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="teaLable text-center">
                                    <label class="text-span">工号</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="Eaccount" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">姓名</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="Ename" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">密码</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="Epwd" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="Esex">
                                        <option value="男">男</option>
                                        <option value="女">女</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">院系</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="Ecoll">
                                        <%for (int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                                            {
                                                //if (dsColl.Tables[0].Rows[i]["collegeId"].ToString() == )
                                                //{
                                        %>
                                        <option value="<%=dsColl.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=dsColl.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                        <%}
                                        %>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">邮箱</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="Eemail" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="Ephone" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary" id="saveEdit">提交更改</button>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/ml.js"></script>
<script src="../js/adminList.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script>
    //存储当前页数
    sessionStorage.setItem("page", <%=getCurrentPage %>);
    //存储总页数
    sessionStorage.setItem("countPage", <%=count %>);
</script>

</html>

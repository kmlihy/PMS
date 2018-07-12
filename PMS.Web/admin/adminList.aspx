<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminList.aspx.cs" Inherits="PMS.Web.admin.adminList" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>分院管理员信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
</head>

<body>
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
		    <h2>分院管理员信息列表</h2>
	    </div>
        <div class="panel-body">
            <div class="container-fluid  big-box">
                <!-- 编辑区-->
                <div class="panel panel-default" id="teapanelbox">
                    <div class="pane input-group" id="panel-head">
                        <div class="input-group" id="inputgroups">
                            <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" value="<%=strSearch %>" />
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
                            <button class="btn btn-danger" type="button" id="btn-Del">
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
                        <th class="text-center">工号</th>
                        <th class="text-center">姓名</th>
                        <%--<th class="text-center">密码</th>--%>
                        <th class="text-center">性别</th>
                        <th class="text-center">院系</th>
                        <th class="text-center">联系电话</th>
                        <th class="text-center">邮箱</th>
                        <th class="text-center">用户类型</th>
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
                            <td class="text-center" id="teaAccount">
                                <%= ds.Tables[0].Rows[i]["teaAccount"].ToString() %>
                            </td>
                            <td class="text-center" id="teaName">
                                <%= ds.Tables[0].Rows[i]["teaName"].ToString() %>
                            </td>
                            <%--<td class="text-center" id="teaPwd">
                        <%= ds.Tables[0].Rows[i]["teaPwd"].ToString() %>
                    </td>--%>
                            <td class="text-center" id="sex">
                                <%= ds.Tables[0].Rows[i]["sex"].ToString() %>
                            </td>
                            <td class="text-center" id="collegeName">
                                <%= ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                            </td>
                            <input type="hidden" value="<%= ds.Tables[0].Rows[i]["collegeId"].ToString() %>" id="collegeId" />
                            <td class="text-center" id="phone">
                                <%= ds.Tables[0].Rows[i]["phone"].ToString() %>
                            </td>
                            <td class="text-center" id="email">
                                <%= ds.Tables[0].Rows[i]["Email"].ToString() %>
                            </td>

                            <td class="text-center" id="tdteatype">
                                <%=((ds.Tables[0].Rows[i]["teaType"].ToString()=="2")?"分院管理员":"")%>
                            </td>
                            <td class="text-center">
                                <button class="btn btn-default btn-sm btn-warning btnEdit" data-toggle="modal" data-target="#editModal">
                                    <span class="glyphicon glyphicon-pencil"></span>
                                </button>
                                <button class="btn btn-default btn-sm btn-danger btnDelete">
                                    <span class="glyphicon glyphicon-trash"></span>
                                </button>
                            </td>
                        </tr>
                        <% }%>
                    </tbody>
                </table>
                <!-- 翻页区域-->
                <div class="container-fluid text-right" id="paging">
                    <ul class="pagination pagination-lg">
                        <li>
                            <a href="#" class="jump" id="first">首页</a>
                        </li>
                        <li>
                            <a href="#" class="jump" id="prev">
                                <span class="iconfont icon-back"></span>
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
                                <span class="iconfont icon-more"></span>
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
                                            <input class="form-control teaAddinput" name="account" type="text" id="Iaccount" />
                                            <span id="validateAcoount"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">姓名</label></td>
                                        <td>
                                            <input class="form-control teaAddinput" name="username" type="text" id="Iname" />
                                            <span id="validateName"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">性别</label></td>
                                        <td>
                                            <select class="selectpicker select" data-width="auto" name="sex" id="Isex">
                                                <option value="">请选择性别</option>
                                                <option value="男">男</option>
                                                <option value="女">女</option>
                                            </select>
                                            <span id="validateSex"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">院系</label></td>
                                        <td>
                                            <select class="selectpicker select" data-width="auto" name="college" id="Icoll">
                                                <option value="">请选择院系</option>
                                                <%for (int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                                                    { %>
                                                <option value="<%=dsColl.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=dsColl.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                                <%} %>
                                            </select>
                                            <span id="validateColl"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">邮箱</label></td>
                                        <td>
                                            <input class="form-control teaAddinput" type="text" name="email" id="Iemail" />
                                            <span id="validateEmail"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">联系电话</label></td>
                                        <td>
                                            <input class="form-control teaAddinput" type="text" name="telNum" id="Iphone" />
                                            <span id="validateTel"></span>
                                        </td>
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
                                            <input class="form-control teaAddinput" type="text" id="Eaccount" readonly="true" /></td>
                                    </tr>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">姓名</label></td>
                                        <td>
                                            <input class="form-control teaAddinput" type="text" id="Ename" />
                                            <span id="validateNameE"></span>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                <td class="teaLable">
                                    <label class="text-span">密码</label></td>
                                <td>--%>
                                    <input class="form-control teaAddinput" type="hidden" id="Epwd" />
                                    <%--<span id="validatePwd"></span>
                                </td>
                            </tr>--%>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">性别</label></td>
                                        <td>
                                            <div id="inputSex">
                                                <input type="text" readonly="true" class="form-control teaAddinput" id="EintSex" />
                                            </div>
                                            <div id="selectSex">
                                                <select class="selectpicker" data-width="auto" id="EselSex">
                                                    <option value="男">男</option>
                                                    <option value="女">女</option>
                                                </select>
                                            </div>
                                            <button type="button" class="btn btn-info btnEditor" id="btnEditSex">编辑</button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">院系</label></td>
                                        <td>
                                            <div id="input">
                                                <input class="form-control teaAddinput" type="text" id="EintColl" readonly="true" />
                                            </div>
                                            <div id="select">
                                                <select class="selectpicker" data-width="auto" id="EselColl">
                                                    <%for (int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                                                        {
                                                    %>
                                                    <option value="<%=dsColl.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=dsColl.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                                    <%}
                                                    %>
                                                </select>
                                            </div>
                                            <button type="button" class="btn btn-info btnEditor" id="btnEditColl">编辑</button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">联系电话</label></td>
                                        <td>
                                            <input class="form-control teaAddinput" type="text" id="Ephone" />
                                            <span id="validateTelE"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="teaLable">
                                            <label class="text-span">邮箱</label></td>
                                        <td>
                                            <input class="form-control teaAddinput" type="text" id="Eemail" />
                                            <span id="validateEmailE"></span>
                                        </td>
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
        </div>
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/ml.js"></script>
<script src="../js/adminList.js"></script>
<script src="../js/xcConfirm.js"></script>
<script src="../js/bootstrap-select.js"></script>

</html>

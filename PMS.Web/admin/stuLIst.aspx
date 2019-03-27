<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuLIst.aspx.cs" Inherits="PMS.Web.admin.stuLIst" Debug="true" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ml.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
</head>

<body>
    <div class="panel panel-default" id="panel" style="margin-top: -20px">
        <div class="panel-head">
            <h2>学生信息管理列表</h2>
        </div>
        <div class="panel-body" id="panelbody">
            <div class="container-fluid big-box">
                <div class="panel panel-default" id="teapanelbox">
                    <div class="pane input-group" id="panel-head">
                        <div class="input-group" id="inputgroups">
                            <select class="selectpicker selectcollegeId" data-width="auto" id="selectcollegeId">
                                <option value="0">-查询所有分院-</option>
                                <%if (userType == "0")
                                    {%>
                                <%for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                    {
                                        if (colds.Tables[0].Rows[i]["collegeId"].ToString() == showcollegedrop)
                                        {%>
                                <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString()%>" selected="selected"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                <%}%>
                                <%else
                                    {%>
                                <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString()%>"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                <%} %>
                                <%} %>
                                <%} %>
                            </select>
                            &nbsp
                            <select class="selectpicker" id="chooseStuPro">
                                <%if (showstr == "0")
                                    { %>
                                <option value="0" selected="selected">-查询全部专业-</option>
                                <%}
                                    else
                                    { %>
                                <option value="0">-查询全部专业-</option>
                                <% for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                                    {
                                        if (prods.Tables[0].Rows[i]["proId"].ToString() == showstr)
                                        {%>
                                <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>" selected="selected"><%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                                <% }
                                    else
                                    {%>
                                <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>"><%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                                <%}
                                        }
                                    } %>
                            </select>
                            <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" value="<%=showmsg %>" />
                            <span class="input-group-btn">
                                <button class="btn btn-info" type="button" id="btn-search">
                                    <span class="glyphicon glyphicon-search" id="search">查询</span>
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
                <div class="">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <th class="text-center">
                                <input type="checkbox" class="js-checkbox-all" />
                            </th>
                            <th class="text-center"><nobr>序号</nobr></th>
                            <th class="text-center"><nobr>学号</nobr></th>
                            <th class="text-center"><nobr>姓名</nobr></th>
                            <th class="text-center"><nobr>性别</nobr></th>
                            <th class="text-center"><nobr>专业编号</nobr></th>
                            <th class="text-center"><nobr>专业名称</nobr></th>
                            <th class="text-center"><nobr>学院编号</nobr></th>
                            <th class="text-center"><nobr>学院名称</nobr></th>
                            <th class="text-center"><nobr>联系电话</nobr></th>
                            <th class="text-center"><nobr>邮箱</nobr></th>
                            <th class="text-center"><nobr>操作</nobr></th>
                        </thead>
                        <tbody>
                            <% for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {

                                    string x = ds.Tables[0].Rows[i]["collegeName"].ToString();
                            %>
                            <tr>
                                <td class="text-center">
                                    <input type="checkbox" />
                                </td>
                                <td class="text-center">
                                    <%=i+1+((getCurrentPage-1)*pagesize)%>
                                </td>
                                <td class="text-center stuNO">
                                    <%= ds.Tables[0].Rows[i]["stuAccount"].ToString() %>
                                </td>
                                <td class="text-center stuName">
                                    <%= ds.Tables[0].Rows[i]["realName"].ToString() %>
                                </td>
                                <td class="text-center stuSex">
                                    <%= ds.Tables[0].Rows[i]["sex"].ToString() %>
                                </td>
                                <td class="text-center stuPro">
                                    <%= ds.Tables[0].Rows[i]["proId"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["proName"].ToString() %>
                                </td>
                                <td class="text-center stuCollege">
                                    <%= ds.Tables[0].Rows[i]["collegeId"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                </td>
                                <td class="text-center stuPhone">
                                    <%= ds.Tables[0].Rows[i]["phone"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <%= ds.Tables[0].Rows[i]["Email"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <button class="btn btn-default resetPwd">重置密码</button>
                                    <button class="btn btn-default btn-sm btn-warning Editor" data-toggle="modal" data-target="#myEditor">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                    </button>
                                    <button class="btn btn-default btn-sm btn-danger deleteStudent" id="Delete">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </button>
                                </td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="container-fluid text-right">
            <ul class="pagination pagination-lg">
                <li>
                    <a href="#" class="jump">首页</a>
                </li>
                <li>
                    <a href="#" class="jump" id="prev">
                        <span class="iconfont icon-back"></span>
                        <%--上一页--%>
                    </a>
                </li>
                <li>
                    <a href="#" class="jump"><%=getCurrentPage %></a>
                </li>
                <li>
                    <a href="#">/</a>
                </li>
                <li>
                    <% if (count == 0) { count = 1; } %>
                    <a href="#" class="jump"><%=count %></a>
                </li>
                <li>
                    <a href="#" id="next" class="jump">
                        <span class="iconfont icon-more"></span>
                        <%--下一页--%>
                    </a>
                </li>
                <li>
                    <a href="#" class="jump">尾页</a>
                </li>
            </ul>
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
                    <h4 class="modal-title" id="myModalLabel">添加学生
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="teaLable text-center">
                                    <label class="text-span">学号</label>
                                </td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="stuAccount" />
                                    <span id="stu_NO"></span>
                                </td>
                            </tr>
                            <%--<tr>
                                <td class="teaLable text-center">
                                    <label class="text-span">初始密码</label>
                                </td>
                                <td>
                                    <input class="form-control teaAddinput" type="password" id="pwd" value="000000" />
                                    <span id="stu_pwd"></span>
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">姓名</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="realName" />
                                    <span id="stu_name"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="sex">
                                        <option value="">请选择性别</option>
                                        <option value="男">男</option>
                                        <option value="女">女</option>
                                    </select>
                                </td>
                            </tr>
                            <tr id="trCollegeId">
                                <td class="teaLable">
                                    <label class="text-span">所属分院</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="stuAddCollege">
                                        <option>请选择分院</option>
                                        <% for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>">
                                            <%=colds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                        </option>
                                        <%} %>
                                    </select>
                                </td>
                            </tr>
                            <tr id="trPro">
                                <td class="teaLable">
                                    <label class="text-span">专业</label>
                                </td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="pro">
                                        <option>请选择专业</option>
                                        <% for (int i = 0; i < stuAddProds.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=stuAddProds.Tables[0].Rows[i]["proId"].ToString() %>">
                                            <%=stuAddProds.Tables[0].Rows[i]["proName"].ToString() %>
                                        </option>
                                        <%} %>
                                    </select>
                                </td>
                            </tr>
                            <tr id="trstuPro">
                                <td class="teaLable">
                                    <label class="text-span">专业</label></td>
                                <td>
                                    <select class="selectpicker pro" data-width="auto">
                                        <option>请选择专业</option>
                                        <% for (int i = 0; i < stuAddProds.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=stuAddProds.Tables[0].Rows[i]["proId"].ToString() %>">
                                            <%=stuAddProds.Tables[0].Rows[i]["proName"].ToString() %>
                                        </option>
                                        <%} %>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">邮箱</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="email" />
                                    <span id="stu_email"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="phone" />
                                    <span id="stu_phone"></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary" id="saveSutdent">添加</button>
                </div>
            </div>
        </div>
    </div>
    <!--编辑按钮弹框-->
    <div class="modal fade" id="myEditor" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myEditorLabel">编辑学生
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="teaLable text-center">
                                    <label class="text-span">学号</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorStuNO" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">姓名</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorStuName" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorStuSex" type="text" />
                                    <div class="selectSex">
                                        <select class="selectpicker selectStuSex" data-width="auto">
                                            <option value="男">男</option>
                                            <option value="女">女</option>
                                        </select>
                                    </div>
                                    <button type="button" class="btn btn-default btnEditor" id="btnEditor1">编辑</button>
                                    <button type="button" class="btn btn-default btnEditor" id="btnSure1">确定</button>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">院系</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorCollege" type="text" disabled="disabled" />
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">专业</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorPro" type="text" />
                                    <div class="selectPro">
                                        <select class="selectpicker selectStuPro" data-width="auto">
                                            <option value="0">-请选择专业-</option>
                                            <% for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                                                { %>
                                            <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>">
                                                <%=prods.Tables[0].Rows[i]["proName"].ToString() %>
                                            </option>
                                            <% } %>
                                        </select>
                                    </div>
                                    <button type="button" class="btn btn-default btnEditor" id="btnEditor3">编辑</button>
                                    <button type="button" class="btn btn-default btnEditor" id="btnSure3">确定</button>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">邮箱</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorEmail" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorPhone" type="text" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <span class="stuCollegeId"></span>
                    <span class="stuProId"></span>
                    <button type="button" class="btn btn-default" data-dismiss="modal" id="btn-close">关闭</button>
                    <button type="button" class="btn btn-primary" id="saveChange">提交更改</button>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
    <input type="hidden" value="<%=userType %>" id="userType" />
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/ml.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script src="../js/jquery.validate.min.js"></script>
<script src="../js/stuLIst.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

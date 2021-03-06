﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="branchList.aspx.cs" Inherits="PMS.Web.admin.branchList" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>分院信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
</head>

<body>
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>学院信息列表</h2>
        </div>
        <div class="panel-body" id="panelbody">
            <div class="container-fluid big-box">
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
                                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#addModal" id="btn-Add">
                                    <span class="glyphicon glyphicon-plus-sign">新增</span>
                                </button>
                            </span>
                            <button class="btn btn-primary" type="button" id="btn-Adds" data-toggle="modal" data-target="#addsModal">
                                <span class="glyphicon glyphicon-plus-sign"></span>
                                批量导入
                            </button>
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
                            <input type="checkbox" name="checkboxAll" class="js-checkbox-all" />
                        </th>
                        <th class="text-center"><nobr>序号</nobr></th>
                        <th class="text-center"><nobr>学院名称</nobr></th>
                        <th class="text-center"><nobr>操作</nobr></th>
                    </thead>
                    <tbody>
                        <%
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                        %>
                        <tr>
                            <td class="text-center">
                                <input type="checkbox" name="checkbox" class="check" value="<%=ds.Tables[0].Rows[i]["collegeId"].ToString() %>" />
                            </td>
                            <td class="text-center">
                                <%=i+1+((getCurrentPage-1)*pagesize)%>
                            </td>
                            <input type="hidden" class="collegeId" value="<%=ds.Tables[0].Rows[i]["collegeId"].ToString() %>" />
                            <td class="text-center collegeName">
                                <%=ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                            </td>
                            <td class="text-center">
                                <button class="btn btn-default btn-sm btn-warning btnEdit" data-toggle="modal" data-target="#editModal">
                                    <span class="glyphicon glyphicon-pencil"></span>
                                </button>
                                <button class="btn btn-default btn-sm btn-danger btnDlete">
                                    <span class="glyphicon glyphicon-trash"></span>
                                </button>
                            </td>
                        </tr>
                        <%
                            }
                        %>
                    </tbody>
                </table>
            </div>
        </div>
        <!-- 翻页区域-->
        <div class="container-fluid text-right">
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
        <!-- 添加分院弹框 -->
        <div class="modal fade" id="addModal" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;
                        </button>
                        <h4 class="modal-title" id="addModalLabel">添加分院
                        </h4>
                    </div>
                    <div class="modal-body">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="teaLable text-center">
                                        <label class="text-span">学院名称</label>
                                    </td>
                                    <td>
                                        <input class="form-control teaAddinput" type="text" id="insertColl" />
                                        <span id="validate"></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        <button type="button" class="btn btn-primary" id="saveCollege">提交更改</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- 批量导入弹框 -->
        <div class="modal fade" id="addsModal" tabindex="-1" role="dialog" aria-labelledby="addsModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;
                        </button>
                        <h4 class="modal-title" id="addsModalLabel">批量导入学院信息
                        </h4>
                    </div>
                    <%--<form id="form1" runat="server" method="post" enctype="multipart/form-data" action="branchList.aspx?op=upload">--%>
                        <div class="modal-body">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <td class="text-center">
                                            <div>
                                                <a href="javascript:;" class="file">选择文件
                                                <input type="file" name="upload" id="upload" />
                                                    <label class="showFileName"></label>
                                                    <label class="fileerrorTip"></label>
                                                </a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text-center" id="download">
                                            <a href="../upload/信息模板下载/college.xlsx">
                                                <button type="button" class="btn btn-primary">下载模板</button></a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" id="btnupload">导入</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        </div>
                    <%--</form>--%>
                </div>
            </div>
        </div>
        <!-- 编辑分院弹框 -->
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
                                        <label class="text-span">学院名称</label></td>
                                    <td>
                                        <input class="form-control teaAddinput" type="text" id="editColl" />
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
        <%-- 导入模态框 --%>
        <div class="modal fade" id="importModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="static" aria-hidden="true">
            <div class="modal-dialog" style="width: 310px; height: 150px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="">导入过程中请勿关闭页面或者断网
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="modal-body">
                            <img src="../images/load.gif"  style="width: 200px; height: 150px;margin-left:20px"/>
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
<script src="../js/branchList.js"></script>
<script src="../js/xcConfirm.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script src="../js/ajaxfileupload.js"></script>
</html>

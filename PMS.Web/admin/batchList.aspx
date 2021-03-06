﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="batchList.aspx.cs" Inherits="PMS.Web.admin.batchList" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>批次表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
    <link rel="stylesheet" href="../css/jquery-ui.min.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
<script type="text/javascript" src="../js/jedate.js"></script>
    <link type="text/css" rel="stylesheet" href="../css/jedate.css" id="jeDateSkin" />
</head>

<body>
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>批次信息列表</h2>
        </div>
        <div class="panel-body" id="panelbody">
            <div class="container-fluid big-box">
                <!-- 编辑区-->
                <div class="panel panel-default" id="teapanelbox">
                    <div class="pane input-group" id="panel-head">
                        <div class="input-group" id="inputgroups">
                            <select class="selectpicker" id="chooseStuPro">
                                <%if (showstr == "0")
                                    { %>
                                <option value="0" selected="selected">-查询全部学院-</option>
                                <%}
                                    else
                                    { %>
                                <option value="0">-查询全部学院-</option>
                                <% for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                    {
                                        if (colds.Tables[0].Rows[i]["collegeId"].ToString() == showstr)
                                        {%>
                                <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>" selected="selected"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                <% }
                                    else
                                    {%>
                                <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                <%}
                                        }
                                    } %>
                            </select>
                            <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" value="<%=secSearch %>" />
                            <span class="input-group-btn">
                                <button class="btn btn-info" type="button" id="btn-search">
                                    <span class="glyphicon glyphicon-search" id="search">查询</span>
                                </button>
                            </span>
                            <%if (state != 0)
                                { %>
                            <span class="input-group-btn">
                                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="btn-Add">
                                    <span class="glyphicon glyphicon-plus-sign">新增</span>
                                </button>
                            </span>
                            <button class="btn btn-danger" type="button" id="btn-Del">
                                <span class="glyphicon glyphicon-trash"></span>
                                批量删除
                            </button>
                            <%}%>
                        </div>
                    </div>
                </div>
                <!-- 数据展示区-->
                <table class="table table-bordered table-hover" style="font-size:14px">
                    <thead>
                        <th class="text-center" style="width:40px">
                            <input type="checkbox" class="js-checkbox-all" />
                        </th>
                        <th class="text-center"><nobr><b>序号</b></nobr></th>
                        <th class="text-center"><nobr><b>批次名称</b></nobr></th>
                        <th class="text-center"><nobr><b>开始时间</b></nobr></th>
                        <th class="text-center"><nobr><b>结束时间</b></nobr></th>
                        <th class="text-center"><nobr><b>激活状态</b></nobr></th>
                        <th class="text-center"><nobr><b>所属学院</b></nobr></th>
                        <%if (state != 0)
                          { %>
                        <th class="text-center"><nobr><b>操作</b></nobr></th>
                        <%} %>
                    </thead>
                    <tbody>
                        <%
                            for (int i = 0; i < plands.Tables[0].Rows.Count; i++)
                            {
                                DateTime startTime = DateTime.Parse(plands.Tables[0].Rows[i]["startTime"].ToString());
                                DateTime endTime = DateTime.Parse(plands.Tables[0].Rows[i]["endTime"].ToString());
                        %>
                        <tr>
                            <td class="text-center">
                                <input type="checkbox" />
                            </td>
                            <td class="text-center" class="orderNum">
                                <%=i+1+((getCurrentPage-1)*pagesize)%>
                            </td>
                            <input type="hidden" class="planNO" value="<%= plands.Tables[0].Rows[i]["planId"].ToString() %>" />
                            <td class="text-center">
                                <%= plands.Tables[0].Rows[i]["planName"].ToString() %>
                            </td>
                            <td class="text-center">
                                <%=string.Format("{0:yyyy-MM-dd HH:mm:ss}", startTime) %>
                            </td>
                            <td class="text-center">
                                <%=string.Format("{0:yyyy-MM-dd HH:mm:ss}", endTime) %>
                            </td>
                            <td class="text-center">
                                <span class="stateData" id="<%=plands.Tables[0].Rows[i]["state"].ToString() %>">
                                    <%= ((plands.Tables[0].Rows[i]["state"].ToString() == "1") ? "已激活" : "未激活") %>
                                </span>
                            </td>
                            <td class="text-center" id="<%= plands.Tables[0].Rows[i]["collegeId"].ToString() %>">
                                <%= plands.Tables[0].Rows[i]["collegeName"].ToString() %>
                            </td>
                        <%if (state != 0)
                          { %>
                            <td class="text-center">
                                <button class="btn btn-default btn-sm btn-warning planEditor" data-toggle="modal" data-target="#myEditor">
                                    <span class="glyphicon glyphicon-pencil"></span>
                                </button>
                                <button class="btn btn-default btn-sm btn-danger planDelete">
                                    <span class="glyphicon glyphicon-trash"></span>
                                </button>
                            </td>
                            <%} %>
                        </tr>
                        <%
                            }
                        %>
                    </tbody>
                </table>
            </div>
        </div>
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
        <!-- 添加批次弹框（Modal） -->
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
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="teaLable text-center">
                                        <label class="text-span">批次名称</label></td>
                                    <td>
                                        <input class="form-control teaAddinput" type="text" id="planName" />
                                        <span class="validate" id="p_name"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">开始时间</label></td>
                                    <td>
                                        <input class="form-control teaAddinput editorStartTime datetimepicker" id="startTime" type="text" />
                                        <%--<input class="form-control teaAddinput datetimepicker" type="text" id="startTime" />--%>
                                        <span class="validate" id="p_start"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">结束时间</label></td>
                                    <td>
                                        <input class="form-control teaAddinput editorStartTime datetimepicker" id="endTime" type="text" />
                                        <%--<input class="form-control teaAddinput datetimepicker" type="text" id="endTime" />--%>
                                        <span class="validate" id="p_end"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">激活状态</label></td>
                                    <td>
                                        <select class="selectpicker" data-width="auto" id="state">
                                            <option value="">请选择激活状态</option>
                                            <option value="1">是</option>
                                            <option value="0">否</option>
                                        </select>
                                        <span class="validate" id="p_state"></span>
                                    </td>
                                </tr>
                                <%--                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">所属院系</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="collegeId">
                                        <option value="">请选择院系</option>
                                        <% for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>">
                                            <%=colds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                        </option>
                                        <% } %>
                                    </select>
                                    <span class="validate" id="p_college"></span>
                                </td>
                            </tr>--%>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        <button type="button" class="btn btn-primary" id="savePlan">提交更改</button>
                    </div>
                </div>
            </div>
        </div>
        <!--编辑批次弹框-->
        <div class="modal fade" id="myEditor" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;
                        </button>
                        <h4 class="modal-title" id="myEditorLabel">编辑批次
                        </h4>
                    </div>
                    <div class="modal-body">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="teaLable text-center">
                                        <label class="text-span">批次名称</label>

                                    </td>
                                    <td>
                                        <input class="editorPlanId" type="hidden" />
                                        <input class="form-control teaAddinput editorPlanName" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">开始时间</label></td>
                                    <td>
                                        <input class="form-control teaAddinput editorStartTime datetimepicker" id="editorStartTime" type="text" />
                                        <%--<input class="form-control teaAddinput editorStartTime datetimepicker" type="text" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">结束时间</label></td>
                                    <td>
                                        <input class="form-control teaAddinput editorEndTime datetimepicker" id="editorEndTime" type="text" /></td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">激活状态</label></td>
                                    <td>
                                        <input class="form-control teaAddinput editorState" type="text" />
                                        <div class="batchState">
                                            <select class="selectpicker" data-width="auto">
                                                <option value="1">是</option>
                                                <option value="0">否</option>
                                            </select>
                                        </div>
                                        <button type="button" class="btn btn-default btnEditor" id="btnEditor1">编辑</button>
                                        <button type="button" class="btn btn-default btnEditor" id="btnSure1">确定</button>
                                    </td>
                                </tr>
                                <%--                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">所属院系</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorCollege" type="text" />
                                    <div class="batchCollege">
                                        <select class="selectpicker selectCollege" data-width="auto">
                                            <option value="">请选择院系</option>
                                            <% for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                                { %>
                                            <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>">
                                                <%=colds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                            </option>
                                            <% } %>
                                        </select>
                                    </div>
                                    <button type="button" class="btn btn-default btnEditor" id="btnEditor2">编辑</button>
                                    <button type="button" class="btn btn-default btnEditor" id="btnSure2">确定</button>
                                </td>
                            </tr>--%>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <span class="editorStateId"></span>
                        <span class="planCollegeId"></span>
                        <button type="button" class="btn btn-default" id="close" data-dismiss="modal">关闭</button>
                        <button type="button" class="btn btn-primary saveEditor">提交更改</button>
                    </div>
                </div>
            </div>
        </div>
        <input type="hidden" value="<%=getCurrentPage %>" id="page" />
        <input type="hidden" value="<%=count %>" id="countPage" />
        <input type="hidden" id="userState" value="<%=Session["state"] %>" />
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/ml.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script src="../js/jquery.validate.min.js"></script>
<script src="../js/batchList.js"></script>
<script src="../js/jquery-ui.min.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

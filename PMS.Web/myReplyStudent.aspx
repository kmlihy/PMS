<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myReplyStudent.aspx.cs" Inherits="PMS.Web.myReplyStudent" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的答辩学生</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="square/_all.css" />
    <link rel="stylesheet" href="css/bootstrap-select.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <style>
        .check_box {
            width: 50px;
        }

        .Serial_number {
            width: 60px;
        }

        #body {
            height: 500px;
        }

        #btn_backForReplyStu {
            position: absolute;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>我的答辩学生</h1>
        </div>
        <div class="panel-body" id="body">
            <%--查询框--%>
            <div class="panel panel-default" id="propanelbox">
                <div class="pane input-group" id="panel-head">
                    <div class="input-group" id="inputgroups">
                        <%if (state == 0)
                                { %>
                        <select class="selectpicker selectdrop" data-width="auto" id="chooseStuColl">
                            <option value="0">-显示所有学院-</option>
                            <%for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                {
                                    if (colds.Tables[0].Rows[i]["collegeId"].ToString() == dropstrWherecoll)
                                    {%>
                            <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>" selected="selected">
                                <%=colds.Tables[0].Rows[i]["collegeName"].ToString() %>
                            </option>
                            <% }
                                else
                                {%>
                            <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>">
                                <%=colds.Tables[0].Rows[i]["collegeName"].ToString() %>
                            </option>
                            <%}%>
                            <%} %>
                        </select>
                        &nbsp
                        <%} %>
                        <select class="selectpicker selectdrop" data-width="auto" id="chooseStuPro">
                            <option value="0">-显示所有专业-</option>
                            <%for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                                {
                                    if (prods.Tables[0].Rows[i]["proId"].ToString() == dropstrWherepro)
                                    {%>
                            <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>" selected="selected">
                                <%=prods.Tables[0].Rows[i]["proName"].ToString() %>
                            </option>
                            <% }
                                else
                                {%>
                            <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>">
                                <%=prods.Tables[0].Rows[i]["proName"].ToString() %>
                            </option>
                            <%}%>
                            <%} %>
                        </select>
                        &nbsp
                        <select class="selectpicker selectdrop" data-width="auto" id="choosePlan">
                            <option value="0">--显示所有批次--</option>
                            <%for (int i = 0; i < plads.Tables[0].Rows.Count; i++)
                                {
                                    if (plads.Tables[0].Rows[i]["planId"].ToString() == dropstrWhereplan)
                                    {%>
                            <option value="<%=plads.Tables[0].Rows[i]["planId"].ToString() %>" selected="selected">
                                <%=plads.Tables[0].Rows[i]["planName"].ToString() %>
                            </option>
                            <%}
                                else
                                { %>
                            <option value="<%=plads.Tables[0].Rows[i]["planId"].ToString() %>">
                                <%=plads.Tables[0].Rows[i]["planName"].ToString() %>
                            </option>
                            <%} %>
                            <%} %>
                        </select>
                        <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" value="<%=secSearch %>" />
                        <span class="input-group-btn">
                            <button class="btn btn-info" type="button" id="btn-search">
                                <span class="glyphicon glyphicon-search" id="search">查询</span>
                            </button>
                        </span>
                    </div>
                </div>
            </div>
            <table class="table table-bordered table-responsive text-center">
                <thead>
                    <tr>
                        <th class="text-center">
                            <input type="checkbox" class="js-checkbox-all check_box" />
                        </th>
                        <th class="text-center Serial_number"><nobr>序号</nobr></th>
                        <%if (state == 0)
                            { %>
                        <th class="text-center"><nobr>学院</nobr></th>
                        <%} %>
                        <th class="text-center"><nobr>批次</nobr></th>
                        <th class="text-center"><nobr>专业</nobr></th>
                        <th class="text-center"><nobr>学号</nobr></th>
                        <th class="text-center"><nobr>姓名</nobr></th>
                        <%if (state == 2)
                            { %>
                        <th class="text-center"><nobr>操作</nobr></th>
                        <%} %>
                    </tr>
                </thead>
                <tbody>
                    <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        { %>
                    <tr>
                        <td class="text-center check_box">
                            <input type="checkbox" />
                        </td>
                        <td class="text-center"><%=i+1+((getCurrentPage-1)*pagesize)%></td>
                        <%if (state == 0)
                            { %>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["collegeName"]%></td>
                        <%} %>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["planName"]%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["proName"]%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["stuAccount"]%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["realName"]%></td>
                        <%if (state == 2)
                        { %>
                        <td class="text-center">
                            <input type="hidden" value="<%=ds.Tables[0].Rows[i]["defenRecordId"].ToString()%>" id="defenRecordId" />
                            <button class="btn btn-default btn-sm btn-danger deleteStudent" id="Delete">
                                <span class="glyphicon glyphicon-trash"></span>
                            </button>
                        </td>
                        <%} %>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
        <div class="panel-footer" id="footer">
            <button class="btn btn-info" type="button" id="btn_backForReplyStu" onclick="javascript:history.back(-1);">
                <span class="glyphicon glyphicon-arrow-left"></span>
                返回
            </button>
            <%--分页--%>
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
                        <a href="#" class="jump"><%=getCurrentPage %>
                        </a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <% if (count == 0) { count = 1; } %>
                        <a href="#" class="jump"><%=count %>
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
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/bootstrap-select.js"></script>
<script src="js/icheck.min.js"></script>
<script src="js/myReplyStudent.js"></script>
<script src="js/ml.js"></script>
<script src="js/xcConfirm.js"></script>
</html>

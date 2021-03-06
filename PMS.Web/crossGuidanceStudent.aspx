﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crossGuidanceStudent.aspx.cs" Inherits="PMS.Web.crossGuidanceStudent" %>

<%="" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的交叉指导学生</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="square/_all.css" />
    <link rel="stylesheet" href="css/_all.css" />
    <link rel="stylesheet" href="css/bootstrap-select.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
</head>
<body>
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>我的交叉指导学生列表</h2>
        </div>
        <div class="panel panel-body" id="panelbody">
            <div class="container-fluid big-box">
                <div class="panel panel-default" id="selectToppanelbox">
                    <div class="pane input-group" id="panel-head">
                        <!--操作区-->
                        <div class="input-group" id="inputgroups">
                            <input type="text" value="" style="display: none" id="search" />
                            <select class="selectpicker selectdrop" data-width="auto" id="chooseStuPro">
                                <option value="0">-显示所有专业-</option>
                                <%for (int i = 0; i < dsPro.Tables[0].Rows.Count; i++)
                                    {
                                        if (dsPro.Tables[0].Rows[i]["proId"].ToString() == dropstrWherepro)
                                        {
                                %>
                                <option value="<%=dsPro.Tables[0].Rows[i]["proId"].ToString()%>" selected="selected">
                                    <%=dsPro.Tables[0].Rows[i]["proName"].ToString() %></option>
                                <%}
                                    else
                                    {%>
                                <option value="<%=dsPro.Tables[0].Rows[i]["proId"].ToString()%>">
                                    <%=dsPro.Tables[0].Rows[i]["proName"].ToString() %></option>
                                <%
                                        }
                                    }%>
                            </select>&nbsp;
                            <select class="selectpicker selectdrop" data-width="auto" id="choosePlan">
                                <option value="0">--显示所有批次--</option>
                                <%for (int i = 0; i < dsPlan.Tables[0].Rows.Count; i++)
                                    {
                                        if (dsPlan.Tables[0].Rows[i]["planId"].ToString() == dropstrWhereplan)
                                        {
                                %>
                                <option value="<%=dsPlan.Tables[0].Rows[i]["planId"].ToString()%>" selected="selected">
                                    <%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                                <%}
                                    else
                                    {%>
                                <option value="<%=dsPlan.Tables[0].Rows[i]["planId"].ToString()%>">
                                    <%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                                <%
                                        }
                                    }%>
                            </select>
                            <input type="text" class="form-control inputsearch" placeholder="请输入搜索条件" id="inputsearch" value="<%=secSearch %>" />
                            <span class="input-group-btn">
                                <button class="btn btn-info" type="button" id="btn-search">
                                    <span class="glyphicon glyphicon-search">查询</span>
                                </button>
                            </span>
                        </div>
                    </div>
                </div>
                <!--数据显示区-->
                <div id="selectToptab">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <th class="text-center">
                                <input type="checkbox" class="js-checkbox-all" />
                            </th>
                            <th class="text-center"><nobr>编号</nobr></th>
                            <th class="text-center"><nobr>姓名</nobr></th>
                            <th class="text-center"><nobr>联系电话</nobr></th>
                            <th class="text-center"><nobr>专业</nobr></th>
                            <th class="text-center"><nobr>题目</nobr></th>
                            <th class="text-center"><nobr>批次</nobr></th>
                            <th class="text-center"><nobr>性别</nobr></th>
                            <th class="text-center"><nobr>选题时间</nobr></th>
                            <th class="text-center"><nobr>操作</nobr></th>
                        </thead>
                        <tbody>
                            <%for (int i = 0; i < dsTR.Tables[0].Rows.Count; i++)
                                {%>
                            <tr>
                                <td class="text-center" id="msg">
                                    <input type="checkbox" />
                                </td>
                                <td class="text-center"><%=i + 1 + ((getCurrentPage - 1) * pagesize)%></td>
                                <td class="text-center" id="realName"><%=dsTR.Tables[0].Rows[i]["realName"].ToString() %></td>
                                <td class="text-center" id="phone"><%=dsTR.Tables[0].Rows[i]["phone"].ToString() %></td>
                                <td class="text-center" id="proName"><%=dsTR.Tables[0].Rows[i]["proName"].ToString() %></td>
                                <td class="text-center" id="title"><%=dsTR.Tables[0].Rows[i]["title"].ToString() %></td>
                                <td class="text-center" id="planName"><%=dsTR.Tables[0].Rows[i]["planName"].ToString() %></td>
                                <td class="text-center" id="sex"><%=dsTR.Tables[0].Rows[i]["sex"].ToString() %></td>
                                <td class="text-center" id="recordtime"><%=dsTR.Tables[0].Rows[i]["createTime"].ToString() %></td>
                                <td class="text-center">
                                    <a href="crossGuide.aspx?stuAccount=<%=dsTR.Tables[0].Rows[i]["stuAccount"].ToString() %>">
                                        <span class="glyphicon glyphicon-hand-right"></span>
                                        评定及成绩
                                    </a>
                                </td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <!--翻页区域-->
        <div class="text-right" id="paging">
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
    <!-- 存储分页数和当前页数，不可见-->
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/icheck.min.js"></script>
<script src="js/bootstrap-select.js"></script>
<script src="js/lgd.js"></script>
<script src="js/crossStuList.js"></script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="titleReadList.aspx.cs" Inherits="PMS.Web.admin.titleReadList" %>

<%=" " %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>题目信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
</head>
<body>

    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>题目信息列表</h2>
        </div>
        <div class="panel-body" id="panelbody">
            <div class="container-fluid big-box">
                <div class="panel panel-default" id="propanelbox">
                    <div class="pane input-group" id="panel-head">
                        <div class="input-group" id="inputgroups">
                            <%if(state == "0"){ %>
                                <select class="selectpicker selectdrop" data-width="auto" id="chooseStuColl">
                                    <option value="0">-显示所有分院-</option>
                                    <%for (int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                                        {
                                            if (dsColl.Tables[0].Rows[i]["collegeId"].ToString() == dropstrWhereColl)
                                            {%>
                                    <option value="<%=dsColl.Tables[0].Rows[i]["collegeId"].ToString() %>" selected="selected">
                                        <%=dsColl.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                         <% }else{%>
                                    <option value="<%=dsColl.Tables[0].Rows[i]["collegeId"].ToString() %>">
                                        <%=dsColl.Tables[0].Rows[i]["collegeName"].ToString() %>
                                    </option>
                                    <%}%>
                                <%} %>
                                </select>
                                &nbsp
                            <%} else{%>
                                <select class="selectpicker selectdrop" data-width="auto" id="chooseStuPro">
                                    <option value="0">-显示所有专业-</option>
                                    <%for (int i = 0; i < dsPro.Tables[0].Rows.Count; i++)
                                        {
                                            if (dsPro.Tables[0].Rows[i]["proId"].ToString() == dropstrWherepro)
                                            {%>
                                    <option value="<%=dsPro.Tables[0].Rows[i]["proId"].ToString() %>" selected="selected">
                                        <%=dsPro.Tables[0].Rows[i]["proName"].ToString() %></option>
                                        <% }else{%>
                                    <option value="<%=dsPro.Tables[0].Rows[i]["proId"].ToString() %>">
                                        <%=dsPro.Tables[0].Rows[i]["proName"].ToString() %>
                                    </option>
                                        <%}%>
                                    <%} %>
                                </select>
                                &nbsp
                                <select class="selectpicker selectdrop" data-width="auto" id="choosePlan">
                                    <option value="0">--显示所有批次--</option>
                                    <%for (int i = 0; i < dsPlan.Tables[0].Rows.Count; i++)
                                        {
                                            if (dsPlan.Tables[0].Rows[i]["planId"].ToString() == dropstrWhereplan)
                                            {%>
                                    <option value="<%=dsPlan.Tables[0].Rows[i]["planId"].ToString() %>" selected="selected">
                                        <%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                                        <%}else{ %>
                                    <option value="<%=dsPlan.Tables[0].Rows[i]["planId"].ToString() %>">
                                        <%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %>
                                    </option>
                                        <%} %>
                                    <%} %>
                                </select>
                            <%} %>
                            <%if (showinput == null)
                                {
                                    showinput = "请输入搜索条件";
                                } %>
                            <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" value="<%=secSearch %>" />
                            <span class="input-group-btn">
                                <button class="btn btn-info" type="button" id="btn-search">
                                    <span class="glyphicon glyphicon-search">查询</span>
                                </button>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <th class="text-center">
                                <input type="checkbox" class="js-checkbox-all" />
                            </th>
                            <th class="text-center">标题编号</th>
                            <th class="text-center">标题</th>
                            <th class="text-center">批次</th>
                            <th class="text-center">专业</th>
                            <th class="text-center">发布人</th>
                            <th class="text-center">已选人数/人数上限</th>
                            <th class="text-center">创建时间</th>
                            <th class="text-center">查看详细信息</th>
                        </thead>
                        <tbody>
                            <%
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                            %>
                            <tr>
                                <td class="text-center td-check">
                                    <input type="checkbox" />
                                </td>
                                <td class="text-center" id="titleId">
                                    <%=ds.Tables[0].Rows[i]["titleId"].ToString() %>
                                </td>
                                <td class="text-center" id="title">
                                    <%=ds.Tables[0].Rows[i]["title"].ToString() %>
                                </td>
                                <td class="text-center" id="planName">
                                    <%=ds.Tables[0].Rows[i]["planName"].ToString() %>
                                </td>
                                <td class="text-center" id="proName">
                                    <%=ds.Tables[0].Rows[i]["proName"].ToString() %>
                                </td>
                                <td class="text-center" id="teaName">
                                    <%=ds.Tables[0].Rows[i]["teaName"].ToString() %>
                                </td>
                                <td class="text-center" id="titleNumber">
                                    <span id="nowSelected"><%=ds.Tables[0].Rows[i]["selected"].ToString() %></span>
                                    /<span id="limit"><%=ds.Tables[0].Rows[i]["limit"].ToString()%></span>
                                </td>
                                <td class="text-center" id="createTime">
                                    <%=ds.Tables[0].Rows[i]["createTime"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <button class="btn btn-success btn-sm btnSearch" data-toggle="modal" data-target="#searchModal">
                                        <span class="glyphicon glyphicon-search"></span>
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
        </div>
        <!--翻页区域-->
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
    <%--管理员查看题目信息模态框--%>
    <%--    <div class="modal fade" id="searchModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="searchModalLabel">题目详细信息
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered" id="selecttab">
                        <tbody class="tablebody">
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">题目编号:</label></td>
                                <td>
                                    <p id="searchTitleId" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">标题:</label></td>
                                <td>
                                    <p id="searchTitle" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">批次:</label></td>
                                <td>
                                    <p id="searchPlan" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">专业:</label></td>
                                <td>
                                    <p id="searchPro" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">发布人:</label></td>
                                <td>
                                    <p id="searchAuthor" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">创建时间:</label></td>
                                <td>
                                    <p id="searchCreateTime" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">已选人数:</label></td>
                                <td>
                                    <p id="searchSelected" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">人数上限:</label></td>
                                <td>
                                    <p id="searchAll" class="text-span"></p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>--%>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />

    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/icheck.min.js"></script>
    <script src="../js/bootstrap-select.js"></script>
    <script src="../js/ml.js"></script>
    <script src="../js/titleReadList.js"></script>
</body>
</html>


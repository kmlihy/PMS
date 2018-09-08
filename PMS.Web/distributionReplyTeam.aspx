<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="distributionReplyTeam.aspx.cs" Inherits="PMS.Web.distributionReplyTeam" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>分配答辩小组</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
</head>
<body>
    <div class="panel">
        <div class=" panel-heading">
            <h2>分配答辩小组</h2>
        </div>
        <div class="panel-body">
            <% if (state == 2)
                { %>
            <!--添加答辩小组-->
            <table class="table" style="width: 80%; margin: 0 auto;">
                <thead>
                    <tr>
                        <th>所属批次</th>
                        <th>组长</th>
                        <th>副助长</th>
                        <th>秘书</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="col-sm-3">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1  usertype" id="plan" data-live-search="true" data-max-options="1">
                                <option value="">请选择批次</option>
                                <%for (int i = 0; i < getPlan.Tables[0].Rows.Count; i++)
                                    {
                                        if (_planId == getPlan.Tables[0].Rows[i]["planId"].ToString())
                                        {%>
                                <option value="<%=getPlan.Tables[0].Rows[i]["planId"].ToString()%>" selected="selected"><%=getPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                                <%}
                                    else
                                    { %>
                                <option value="<%=getPlan.Tables[0].Rows[i]["planId"].ToString()%>"><%=getPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                                <%}
                                    } %>
                            </select>
                        </td>
                        <td class="col-sm-2">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1 usertype" id="leader" data-live-search="true" data-max-options="1">
                                <option value="">请选择组长</option>
                                <%for (int i = 0; i < getLeader.Tables[0].Rows.Count; i++)
                                    {
                                        if (leader == getLeader.Tables[0].Rows[i]["teaAccount"].ToString())
                                        {%>
                                <option value="<%=getLeader.Tables[0].Rows[i]["teaAccount"].ToString()%>" selected="selected"><%=getLeader.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                    else
                                    { %>
                                <option value="<%=getLeader.Tables[0].Rows[i]["teaAccount"].ToString()%>"><%=getLeader.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                    }%>
                            </select>
                        </td>
                        <td class="col-sm-2">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1 usertype" id="member" data-max-options="1" data-live-search="true">
                                <option value="">请选择副组长</option>
                                <%for (int i = 0; i < getMember.Tables[0].Rows.Count; i++)
                                    {
                                        if (member == getMember.Tables[0].Rows[i]["teaAccount"].ToString())
                                        {%>
                                <option value="<%=getMember.Tables[0].Rows[i]["teaAccount"].ToString()%>" selected="selected"><%=getMember.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                    else
                                    { %>
                                <option value="<%=getMember.Tables[0].Rows[i]["teaAccount"].ToString()%>"><%=getMember.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                    } %>
                            </select>
                        </td>
                        <td class="col-sm-2">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1 usertype" id="record" data-max-options="1" data-live-search="true">
                                <option value="">请选择秘书</option>
                                <%for (int i = 0; i < getRecord.Tables[0].Rows.Count; i++)
                                    {
                                        if (record == getRecord.Tables[0].Rows[i]["teaAccount"].ToString())
                                        {%>
                                <option value="<%=getRecord.Tables[0].Rows[i]["teaAccount"].ToString()%>" selected="selected"><%=getRecord.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                    else
                                    { %>
                                <option value="<%=getRecord.Tables[0].Rows[i]["teaAccount"].ToString()%>"><%=getRecord.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                    } %>
                            </select>
                        </td>
                        <td class="">
                            <button type="button" class="btn btn-info" id="confirm">
                                <span class="glyphicon glyphicon-ok"></span>
                                确定人选
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <%} %>
            <table class="table table-bordered text-center">
                <!--查询区域-->
                <thead>
                    <tr>
                        <th colspan="6">
                            <div class="panel panel-default" id="propanelbox">
                                <div class="pane input-group" id="panel-head">
                                    <div class="input-group" id="inputgroups">
                                    <%if (ds != null)
                                    {%>
                                        <%if (state == 0)
                                        { %>
                                        <select class="selectpicker selectcollegeId" data-width="auto" id="selectcollegeId">
                                            <option value="0">请选择查询学院 </option>
                                            <%for (int i = 0; i < getColl.Tables[0].Rows.Count; i++)
                                                {
                                                if (collegeid == getColl.Tables[0].Rows[i]["collegeId"].ToString())
                                                {%>
                                                    <option value="<%=getColl.Tables[0].Rows[i]["collegeId"].ToString()%>" selected="selected"><%=getColl.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                                 <%}
                                                else
                                                { %>
                                                    <option value="<%=getColl.Tables[0].Rows[i]["collegeId"].ToString()%>"><%=getColl.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                                <%}
                                        } %>
                                        </select>
                                        <%} %>
                                        <select class="selectpicker" data-width="auto" id="chooseStuPro">
                                            <option value="0">请选择查询批次</option>
                                            <%for (int i = 0; i < dsPlan.Tables[0].Rows.Count; i++)
                                            {
                                                if (planId == dsPlan.Tables[0].Rows[i]["planId"].ToString())
                                                {%>
                                                    <option value="<%=dsPlan.Tables[0].Rows[i]["planId"].ToString()%>" selected="selected"><%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                                                    <%}
                                                else
                                                { %>
                                                    <option value="<%=dsPlan.Tables[0].Rows[i]["planId"].ToString()%>"><%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                                                <%}
                                            } %>
                                        </select>
                                        <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" value="<%=showmsg %>" />
                                        <span class="input-group-btn">
                                            <button class="btn btn-info" type="button" id="btn-search">
                                                <span class="glyphicon glyphicon-search" id="search">查询</span>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-center">所属学院</th>
                        <th class="text-center">所属批次</th>
                        <th class="text-center">组长</th>
                        <th class="text-center">副组长</th>
                        <th class="text-center">秘书</th>
                        <th class="text-center">分配</th>
                        <th class="text-center">查看</th>
                    </tr>
                </thead>
                <!--数据展示区-->
                <tbody>
                    <% for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    { %>
                    <tr>
                        <td class="col-sm-2"><%=ds.Tables[0].Rows[i]["collegeName"].ToString() %></td>
                        <td class="col-sm-2"><%=ds.Tables[0].Rows[i]["planName"].ToString() %></td>
                        <td class="col-sm-2"><%=ds.Tables[0].Rows[i]["leaderName"].ToString() %></td>
                        <td class="col-sm-2"><%=ds.Tables[0].Rows[i]["memberName"].ToString() %></td>
                        <td class="col-sm-2"><%=ds.Tables[0].Rows[i]["recordName"].ToString() %></td>
                        <td class="col-sm-2">
                            <button type="button" class="btn btn-info" onclick="window.location.href='distributionReplyStudent.aspx?defenGroupId=<%=ds.Tables[0].Rows[i]["defenGroupId"].ToString() %>'">分配答辩学生</button>
                        </td>
                        <td class="col-sm-2"><button type="button" class="btn btn-info" onclick="window.location.href='myReplyStudent.aspx'">查看答辩学生</button></td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
        <!--分页区域-->
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
                    </a>
                </li>
                <li>
                    <a href="#" class="jump" id="last">尾页</a>
                </li>
            </ul>
        </div>
        <% }else{ %>
        <h3>无答辩小组</h3>
        <%} %>
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
    <input type="hidden" value="<%=userType %>" id="userType" />
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="js/bootstrap-select.js"></script>
<script src="js/distributionReplyTeam.js"></script>
</html>

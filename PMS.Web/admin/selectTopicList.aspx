<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectTopicList.aspx.cs" Inherits="PMS.Web.admin.selectTopicList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>选题管理列表</title>

    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
</head>

<body>
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>选题管理列表</h2>
        </div>
        <div class="panel-body" id="panelbody">
            <div class="container-fluid big-box">
                <div class="panel panel-default" id="selectToppanelbox">
                    <div class="pane input-group" id="panel-head">
                        <div class="input-group" id="inputgroups">
                            <select class="selectpicker selectdrop" data-width="auto" id="selectdrop">
                                <option value="0">-查询全部专业-</option>
                                <%for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                                    {
                                        if (prods.Tables[0].Rows[i]["proId"].ToString() == showstr)
                                        {%>
                                <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString()%>" selected="selected"><%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                                <%}%>
                                <%else
                                    {%>
                                <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString()%>"><%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                                <%} %>
                                <%} %>
                            </select>
                            &nbsp
                    <select class="selectpicker selectdropbatch" data-width="auto" id="selectdropbatch">
                        <option value="0">-请选择批次-</option>

                        <%for (int i = 0; i < plands.Tables[0].Rows.Count; i++)
                            {
                                if (plands.Tables[0].Rows[i]["planId"].ToString() == showbacthdrop)
                                {%>
                        <option value="<%=plands.Tables[0].Rows[i]["planId"].ToString()%>" selected="selected"><%=plands.Tables[0].Rows[i]["planName"].ToString() %></option>
                        <%}%>
                        <%else
                            {%>
                        <option value="<%=plands.Tables[0].Rows[i]["planId"].ToString()%>"><%=plands.Tables[0].Rows[i]["planName"].ToString() %></option>
                        <%} %>
                        <%} %>
                    </select>
                            <input type="text" class="form-control inputsearch" placeholder="请输入查询条件" id="inputsearch" value="<%=showinput %>" />
                            <span class="input-group-btn">
                                <button class="btn btn-info" type="button" id="btn-search">
                                    <span class="glyphicon glyphicon-search">查询</span>
                                </button>
                            </span>
                            <button class="btn btn-success" type="button" id="btn-export">
                                <span class="glyphicon glyphicon-share-alt"></span>
                                导出
                            </button>
                            <button class="btn btn-danger" type="button" id="btn-Del">
                                <span class="glyphicon glyphicon-trash"></span>
                                批量删除
                            </button>
                        </div>
                    </div>
                </div>

                <div id="selectToptab">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <th class="text-center">
                                <input type="checkbox" class="js-checkbox-all" />
                            </th>
                            <th class="text-center">选题记录编号</th>
                            <th class="text-center">题目</th>
                            <th class="text-center">出题教师</th>
                            <th class="text-center">选题学生</th>
                            <th class="text-center">所属批次</th>
                            <th class="text-center">所属专业</th>
                            <th class="text-center">已选人数/人数上限</th>
                            <th class="text-center">选题时间</th>
                            <th class="text-center">所属分院</th>
                            <th class="text-center">操作</th>
                        </thead>
                        <tbody>
                            <tr>
                                <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {%>
                                <td class="text-center" id="msg">
                                    <input type="checkbox" />
                                    <p class="hidemsg" id="teacount"><%=ds.Tables[0].Rows[i]["teaAccount"].ToString() %></p>
                                    <p class="hidemsg" id="stuaccount"><%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %></p>
                                    <p class="hidemsg" id="phone"><%=ds.Tables[0].Rows[i]["phone"].ToString() %></p>
                                    <p class="hidemsg" id="email"><%=ds.Tables[0].Rows[i]["Email"].ToString() %></p>
                                    <p class="hidemsg" id="stusex"><%=ds.Tables[0].Rows[i]["sex"].ToString() %></p>
                                </td>
                                <td class="text-center" id="recordid"><%=ds.Tables[0].Rows[i]["titleRecordId"].ToString() %></td>
                                <td class="text-center" id="title"><%=ds.Tables[0].Rows[i]["title"].ToString() %></td>
                                <td class="text-center" id="teaname"><%=ds.Tables[0].Rows[i]["teaName"].ToString() %></td>
                                <td class="text-center" id="realname"><%=ds.Tables[0].Rows[i]["realName"].ToString() %></td>
                                <td class="text-center" id="planname"><%=ds.Tables[0].Rows[i]["planName"].ToString() %></td>
                                <td class="text-center" id="proname"><%=ds.Tables[0].Rows[i]["proName"].ToString() %></td>
                                <td class="text-center"><%=ds.Tables[0].Rows[i]["selected"].ToString() %>/<%=ds.Tables[0].Rows[i]["limit"].ToString() %></td>
                                <td class="text-center" id="recordtime"><%=ds.Tables[0].Rows[i]["recordCreateTime"].ToString() %></td>
                                <td class="text-center" id="collegename"><%=ds.Tables[0].Rows[i]["collegeName"].ToString() %></td>
                                <td class="text-center">
                                    <button class="btn btn-default btn-sm btn-success btnSearch" data-toggle="modal" data-target="#myModal">
                                        <span class="glyphicon glyphicon-search"></span>
                                    </button>
                                    <button class="btn btn-default btn-sm btn-danger btnDel">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </button>
                                </td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
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
            </div>
        </div>
    </div>
    <!-- 查看选题记录弹框（Modal） -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">详细信息
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered" id="selecttab">
                        <tbody class="tablebody">
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">序号:</label></td>
                                <td>
                                    <p id="RecordId" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">批次名称:</label></td>
                                <td>
                                    <p id="PlanName" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">题目标题:</label></td>
                                <td>
                                    <p id="Title" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">教师账号:</label></td>
                                <td>
                                    <p id="TeaAccount" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">教师名字:</label></td>
                                <td>
                                    <p id="TeaName" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">学生账号:</label></td>
                                <td>
                                    <p id="StuAccount" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">学生姓名:</label></td>
                                <td>
                                    <p id="StuName" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">学生性别:</label></td>
                                <td>
                                    <p id="StuSex" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">学生电话:</label></td>
                                <td>
                                    <p id="StuTel" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">学生邮箱:</label></td>
                                <td>
                                    <p id="StuEmail" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">专业名称:</label></td>
                                <td>
                                    <p id="ProName" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">分院名字:</label></td>
                                <td class="teaLable">
                                    <p id="CollegeName" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">学生选题时间:</label></td>
                                <td>
                                    <p id="RecordTime" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span"></label>
                                </td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
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
<script src="../js/bootstrap-select.js"></script>
<script src="../js/lgd.js"></script>
<script src="../js/selectTopicList.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

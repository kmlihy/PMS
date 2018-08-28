<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crossGuidanceStudent.aspx.cs" Inherits="PMS.Web.crossGuidanceStudent" %>


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
                                <%-- <%for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                                    {
                                        if (prods.Tables[0].Rows[i]["proId"].ToString() == dropstrWherepro)
                                        {
                                %>
                                <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString()%>" selected="selected">
                                    <%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                                <%}
                                    else
                                    {%>
                                <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString()%>">
                                    <%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                                <%
                                        }
                                    }%>--%>
                            </select>&nbsp;
                            <select class="selectpicker selectdrop" data-width="auto" id="choosePlan">
                                <option value="0">--显示所有批次--</option>

                            </select>
                            <input type="text" class="form-control inputsearch" placeholder="请输入搜索条件" id="inputsearch" />
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
                            <th class="text-center">编号</th>
                            <th class="text-center">姓名</th>
                            <th class="text-center">联系电话</th>
                            <th class="text-center">专业</th>
                            <th class="text-center">题目</th>
                            <th class="text-center">批次</th>
                            <th class="text-center">性别</th>
                            <th class="text-center">选题时间</th>
                            <th class="text-center">操作</th>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="text-center" id="msg">
                                    <input type="checkbox" />
                                </td>
                                <td class="text-center">1</td>
                                <td class="text-center">周杰杰</td>
                                <td class="text-center">14769635334</td>
                                <td class="text-center">计算机科学与技术</td>
                                <td class="text-center">大学生在线二手交易平台</td>
                                <td class="text-center">2018年信息工程学院第一批次</td>
                                <td class="text-center">男</td>
                                <td class="text-center">2018-09-10 16:36:03</td>
                                <td class="text-center">
                                    <button class="btn btn-default btn-sm btn-success btnSearch" data-toggle="modal" data-target="#myModal">
                                        <span class="glyphicon glyphicon-search"></span>
                                    </button>
                                </td>
                            </tr>
                            <tr>
                                <td class="text-center" id="msg">
                                    <input type="checkbox" />
                                </td>
                                <td class="text-center">1</td>
                                <td class="text-center">周杰杰</td>
                                <td class="text-center">14769635334</td>
                                <td class="text-center">计算机科学与技术</td>
                                <td class="text-center">大学生在线二手交易平台</td>
                                <td class="text-center">2018年信息工程学院第一批次</td>
                                <td class="text-center">男</td>
                                <td class="text-center">2018-09-10 16:36:03</td>
                                <td class="text-center">
                                    <button class="btn btn-default btn-sm btn-success btnSearch" data-toggle="modal" data-target="#myModal">
                                        <span class="glyphicon glyphicon-search"></span>
                                    </button>
                                </td>
                            </tr>
                            <%--<%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {%>
                                <td class="text-center" id="msg">
                                    <input type="checkbox" />
                                </td>
                                <td class="text-center" id="titleRecordId"><%=ds.Tables[0].Rows[i]["titleRecordId"].ToString() %></td>
                                <td class="text-center" id="realName"><%=ds.Tables[0].Rows[i]["realName"].ToString() %></td>
                                <td class="text-center" id="phone"><%=ds.Tables[0].Rows[i]["phone"].ToString() %></td>
                                <td class="text-center" id="proName"><%=ds.Tables[0].Rows[i]["proName"].ToString() %></td>
                                <td class="text-center" id="title"><%=ds.Tables[0].Rows[i]["title"].ToString() %></td>
                                <td class="text-center" id="planName"><%=ds.Tables[0].Rows[i]["planName"].ToString() %></td>
                                <td class="text-center" id="sex"><%=ds.Tables[0].Rows[i]["sex"].ToString() %></td>
                                <td class="text-center" id="recordtime"><%=ds.Tables[0].Rows[i]["recordCreateTime"].ToString() %></td>
                                <td class="text-center">
                                    <button class="btn btn-default btn-sm btn-success btnSearch" data-toggle="modal" data-target="#myModal">
                                        <span class="glyphicon glyphicon-search"></span>
                                    </button>
                                </td>
                            </tr>
                            <%} %>--%>
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
                    <a href="#" class="jump">1
                     <%--   <%=getCurrentPage %>--%>
                    </a>
                </li>
                <li>
                    <a href="#">/</a>
                </li>
                <li>
                    <a href="#" class="jump">10
                    <%-- <% if (count == 0) { count = 1; } %>
                    <a href="#" class="jump">
                        <%=count %>
                    </a>--%>
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
    <!-- 查看我的交叉指导学生弹框（Modal） -->
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
                                    <label class="text-span">编号:</label></td>
                                <td>
                                    <p id="titleRecordId1" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">姓名:</label></td>
                                <td>
                                    <p id="realName1" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别:</label></td>
                                <td>
                                    <p id="sex1" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">联系电话:</label></td>
                                <td>
                                    <p id="phone1" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">专业名称:</label></td>
                                <td>
                                    <p id="proName1" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">题目:</label></td>
                                <td>
                                    <p id="title1" class="text-span"></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">所属批次:</label></td>
                                <td>
                                    <p id="planName1" class="text-span"></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">选题时间:</label></td>
                                <td>
                                    <p id="recordtime1" class="text-span"></p>
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
    </div>
    <!-- 存储分页数和当前页数，不可见-->
    <%--<input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />--%>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/icheck.min.js"></script>
<script src="js/bootstrap-select.js"></script>
<script src="js/lgd.js"></script>
<script src="js/myStudent.js"></script>
</html>

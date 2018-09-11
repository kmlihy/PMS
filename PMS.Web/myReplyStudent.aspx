<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myReplyStudent.aspx.cs" Inherits="PMS.Web.myReplyStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的答辩学生</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
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
                        <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" />
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
                        <th class="text-center Serial_number">序号</th>
                        <th class="text-center">批次</th>
                        <th class="text-center">专业</th>
                        <th class="text-center">学号</th>
                        <th class="text-center">姓名</th>
                        <th class="text-center">操作</th>
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
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["planName"]%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["proName"]%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["stuAccount"]%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["realName"]%></td>
                        <%if(){ %>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-danger deleteStudent" id="Delete">
                                <span class="glyphicon glyphicon-trash"></span>
                            </button>
                        </td>
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
                        </a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <a href="#" class="jump">4
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
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script src="../js/ml.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

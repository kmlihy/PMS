﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="titleReadList.aspx.cs" Inherits="PMS.Web.admin.titleReadList" %>

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
    <div class="container-fluid big-box">
        <div class="panel panel-default" id="propanelbox">
            <div class="pane input-group" id="panel-head">
                <div class="input-group" id="inputgroups">
                    <select class="selectpicker selectdrop" data-width="auto" id="chooseStuPro">
                        <option value="0">-显示所有专业-</option>
                        <%for (int i = 0; i < dsPro.Tables[0].Rows.Count; i++)
                            {
                                if(dsPro.Tables[0].Rows[i]["proId"].ToString() == dropstrWherepro)
                                {%>
                                     <option value="<%=dsPro.Tables[0].Rows[i]["proId"].ToString() %>" selected="selected">
                                         <%=dsPro.Tables[0].Rows[i]["proName"].ToString() %>
                                     </option>
                                <% }
                                else
                                {%>
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
                                        <%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %>
                                    </option>
                                 <%}
                                else
                                { %>
                                    <option value="<%=dsPlan.Tables[0].Rows[i]["planId"].ToString() %>">
                                        <%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %>
                                    </option>
                                <%} %>
                        <%} %>
                    </select>
                    <%if (showinput == null) {
                            showinput = "请输入搜索条件";
                        } %>
                    <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" />
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
                            <span><%=ds.Tables[0].Rows[i]["selected"].ToString() %></span>
                            /<span id="limit"><%=ds.Tables[0].Rows[i]["limit"].ToString()%></span>
                        </td>
                        <td class="text-center" id="createTime">
                            <%=ds.Tables[0].Rows[i]["createTime"].ToString() %>
                        </td>
                        <td class="text-center">
                            <button class="btn btn-success btn-sm btnSearch" data-toggle="modal" data-target="#myModa2">
                                <span class="glyphicon glyphicon-search"></span>
                            </button>
                        </td>
                    </tr>
                    <%
                        }
                    %>
                </tbody>
            </table>
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
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />

    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/icheck.min.js"></script>
    <script src="../js/bootstrap-select.js"></script>
    <script src="../js/ml.js"></script>
    <script>
        //存储当前页数
        var page = $("#page").val();
        sessionStorage.setItem("Page", page);
        //存储总页数
        var countPage = $("#countPage").val();
        sessionStorage.setItem("countPage", countPage);
        
        $(document).ready(function () {
            //分页参数传递
            $(".jump").click(function () {
                switch ($.trim($(this).html())) {
                    case ('<span class="iconfont icon-back"></span>'):
                        if (parseInt(sessionStorage.getItem("Page")) > 1) {
                            jump(parseInt(sessionStorage.getItem("Page")) - 1);
                            break;
                        }
                        else {
                            jump(1);
                            break;
                        }

                    case ('<span class="iconfont icon-more"></span>'):
                        if (parseInt(sessionStorage.getItem("Page")) < parseInt(sessionStorage.getItem("countPage"))) {
                            jump(parseInt(sessionStorage.getItem("Page")) + 1);
                            break;
                        }
                        else {
                            jump(parseInt(sessionStorage.getItem("countPage")));
                            break;
                        }
                    case ("首页"):
                        jump(1);
                        break;
                    case ("尾页"):
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                }
            });
            $(".btnSearch").click(function () {
                var titleId = $(this).parent().parent().find("#titleId").text().trim();
                window.location.href = "../paperDetail.aspx?titleId=" + titleId;
            })
            //查询按钮点击事件
            $("#btn-search").click(function () {
                var strWhere = $("#inputsearch").val();
                sessionStorage.setItem("strWhere", strWhere);
                jump(1);
            });
            //获取当前页面
            function jump(cur) {
                if (sessionStorage.getItem("strWhere") == null) {
                    window.location.href = "titleReadList.aspx?currentPage=" + cur;
                } else {
                    window.location.href = "titleReadList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
                }
            };
            //自动隐藏导航栏首页尾页
            if (sessionStorage.getItem("countPage") == "1") {
                $("#first").hide();
                $("#last").hide();
            }
           
            //下拉选项查询
            //$("#chooseStuPro").change(function () {
            //    var strWhere = $(this).find("option:selected").text().trim();
            //    sessionStorage.setItem("strWhere", strWhere);
            //    jump(1);
            //});

            //$("#choosePlan").change(function () {
            //    var strWhere = $(this).find("option:selected").text().trim();
            //    sessionStorage.setItem("strWhere", strWhere);
            //    jump(1);
            //})

        });
    </script>
</body>
</html>

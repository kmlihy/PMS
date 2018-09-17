<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminViewScore.aspx.cs" Inherits="PMS.Web.admin.adminViewScore" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看学生成绩</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
</head>
<body>
    <div class="panel panel-default">
        <div class="panel-head">
            <h2>学生成绩</h2>
        </div>
        <div class="panel panel-default" id="selectToppanelbox">
            <div class="pane input-group" id="panel-head">
                <div class="input-group" id="inputgroups">
                    <select class="selectpicker selectdropbatch" data-width="auto" id="choosePlan">
                        <option value="0">-请选择批次-</option>
                        <%for (int i = 0; i < dsPlan.Tables[0].Rows.Count; i++)
                            { if (planId == dsPlan.Tables[0].Rows[i]["planId"].ToString())
                            {%>
                                <option value="<%=dsPlan.Tables[0].Rows[i]["planId"].ToString() %>" selected="selected"><%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                            <%}
                            else
                            { %>
                                <option value="<%=dsPlan.Tables[0].Rows[i]["planId"].ToString() %>"><%=dsPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                            <%}
                        } %>
                    </select>
                    &nbsp
                    <select class="selectpicker selectdrop" data-width="auto" id="chooseStuPro">
                        <option value="0">-查询全部专业-</option>
                        <%for (int i = 0; i < dsPro.Tables[0].Rows.Count; i++)
                        {
                            if (proId == dsPro.Tables[0].Rows[i]["proId"].ToString())
                            {%>
                                <option value="<%=dsPro.Tables[0].Rows[i]["proId"].ToString() %>" selected="selected"><%=dsPro.Tables[0].Rows[i]["proName"].ToString() %></option>
                            <%}
                            else
                            { %>
                                <option value="<%=dsPro.Tables[0].Rows[i]["proId"].ToString() %>"><%=dsPro.Tables[0].Rows[i]["proName"].ToString() %></option>
                            <%}
                        } %>
                    </select>
                    &nbsp
                    <select class="selectpicker selectdrop" data-width="auto" id="order">
                        <%if (order == "up")
                            { %>
                        <option value="up" selected="selected">-升序-</option>
                        <option value="down">-降序-</option>
                        <%}
                            else
                            {  %>
                        <option value="up">-升序-</option>
                        <option value="down" selected="selected">-降序-</option>
                        <%}%>
                    </select>
                    <input type="text" class="form-control inputsearch" placeholder="请输入查询条件" id="inputsearch" value="<%=strSearch %>" />
                    <span class="input-group-btn">
                        <button class="btn btn-info" type="button" id="btn-search">
                            <span class="glyphicon glyphicon-search">查询</span>
                        </button>
                    </span>
                    <button class="btn btn-success" type="button" id="btn-export">
                        <span class="glyphicon glyphicon-share-alt"></span>
                        导出
                    </button>
                </div>
            </div>
        </div>
        <div id="selectToptab">
            <table class="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th class="text-center">序号</th>
                        <th class="text-center">学号</th>
                        <th class="text-center">学生姓名</th>
                        <th class="text-center">论文题目</th>
                        <th class="text-center">出题教师</th>
                        <th class="text-center">分数</th>
                    </tr>
                </thead>
                <tbody>
                    <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        { %>
                    <tr>
                        <td class="text-center">1</td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["realName"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["title"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["teaName"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["result"].ToString() %></td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
        <!-- 翻页区域 -->
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

                    <a href="#" class="jump">1
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
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script src="../js/xcConfirm.js"></script>
<script src="../js/adminViewScore.js"></script>
<script>

</script>
</html>

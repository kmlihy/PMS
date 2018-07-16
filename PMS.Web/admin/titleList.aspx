<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="titleList.aspx.cs" Inherits="PMS.Web.admin.titleList" %>

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
    <link rel="stylesheet" href="../css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
</head>
<body>
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>题目信息列表</h2>
        </div>
        <div class="panel-body">
            <div class="container-fluid big-box">
                <div class="panel panel-default" id="propanelbox">
                    <div class="pane input-group" id="panel-head">
                        <div class="input-group" id="inputgroups">
                            <input type="text" value="<%=secSearch %>" style="display: none" id="search" />
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
                            <%if (showinput == null)
                                {
                                    showinput = "请输入搜索条件";
                                } %>
                            <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" />

                            <span class="input-group-btn">
                                <button class="btn btn-info" type="button" id="btn-search">
                                    <span class="glyphicon glyphicon-search">查询</span>
                                </button>
                            </span>
                            <span class="input-group-btn">
                                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="btn-Add">
                                    <span class="glyphicon glyphicon-plus-sign">新增</span>
                                </button>
                            </span>
                            <button class="btn btn-primary" type="button" id="btn-Adds" data-toggle="modal" data-target="#addsModal">
                                <span class="glyphicon glyphicon-plus-sign"></span>
                                批量导入
                            </button>
                            <button class="btn btn-danger" type="button" id="btn-Del">
                                <span class="glyphicon glyphicon-trash"></span>
                                批量删除
                            </button>
                        </div>
                    </div>
                </div>
                <div class="">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <th class="text-center">
                                <input type="checkbox" class="js-checkbox-all" />
                            </th>
                            <th class="text-center">题目编号</th>
                            <th class="text-center">标题</th>
                            <th class="text-center">批次</th>
                            <th class="text-center">专业</th>
                            <th class="text-center">发布人</th>
                            <th class="text-center">已选人数/人数上限</th>
                            <th class="text-center">创建时间</th>
                            <th class="text-center">操作</th>
                        </thead>
                        <tbody>
                            <%
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                            %>
                            <tr>
                                <td class="text-center td-check">
                                    <input type="checkbox" />
                                    <input type="hidden" value="<%=ds.Tables[0].Rows[i]["titleContent"].ToString() %>" id="titleContent" />
                                    <input type="hidden" value="<%=ds.Tables[0].Rows[i]["selected"].ToString() %>" id="selected" />
                                </td>
                                <td class="text-center" id="titleId">
                                    <%=ds.Tables[0].Rows[i]["titleId"].ToString() %>
                                </td>
                                <td class="text-center" id="title">
                                    <%=ds.Tables[0].Rows[i]["title"].ToString() %>
                                </td>
                                <td class="text-center" id="plaName">
                                    <%=ds.Tables[0].Rows[i]["planName"].ToString() %>
                                </td>
                                <input type="hidden" id="planId" value="<%=ds.Tables[0].Rows[i]["planId"].ToString() %>" />
                                <td class="text-center" id="proName">
                                    <%=ds.Tables[0].Rows[i]["proName"].ToString() %>
                                </td>
                                <input type="hidden" id="proId" value="<%=ds.Tables[0].Rows[i]["proId"].ToString() %>" />
                                <td class="text-center" id="teaName">
                                    <%=ds.Tables[0].Rows[i]["teaName"].ToString() %>
                                </td>
                                <input type="hidden" id="teaAccount" value="<%=ds.Tables[0].Rows[i]["teaAccount"].ToString() %>" />
                                <td class="text-center" id="titleNumber">
                                    <span><%=ds.Tables[0].Rows[i]["selected"].ToString() %></span>
                                    /<span id="limit"><%=ds.Tables[0].Rows[i]["limit"].ToString()%></span>
                                </td>
                                <td class="text-center" id="createTime">
                                    <%=ds.Tables[0].Rows[i]["createTime"].ToString() %>
                                </td>
                                <td class="text-center">
                                    <button class="btn btn-default btn-sm btn-warning btnEdit" data-toggle="modal" data-target="#myModa2">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                    </button>
                                    <button class="btn btn-default btn-sm btn-danger btnDel">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </button>
                                </td>
                            </tr>
                            <%
                                }
                            %>
                        </tbody>
                    </table>
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
        </div>
    </div>
    <!-- 批量导入弹框 -->
    <div class="modal fade" id="addsModal" tabindex="-1" role="dialog" aria-labelledby="addsModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="addsModalLabel">批量导入学院信息
                    </h4>
                </div>
                <form id="form1" runat="server" method="post" enctype="multipart/form-data" action="titleList.aspx?op=upload">
                    <div class="modal-body">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="text-center">
                                        <div>
                                            <a href="javascript:;" class="file">选择文件
                                                <input type="file" name="upload" id="upload" />
                                                <label class="showFileName"></label>
                                                <label class="fileerrorTip"></label>
                                            </a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center" id="download">
                                        <a href="~/upload/信息模板下载/题目信息表.xls" download="题目信息表.xls">
                                            <button type="button" class="btn btn-primary">下载模板</button></a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-success" id="btnupload">上传</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!-- 编辑信息弹框（Modal） -->
    <div class="modal fade" id="myModa2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModal2">题目信息修改
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="titleId text-right">
                                    <label class="text-span">题目编号:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediTitleId" />
                                    <span id="titleIdValidate"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="title text-right">
                                    <label class="text-span">题目:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediTitle" />
                                    <span id="titleValidate"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="plan text-right">
                                    <label class="text-span">批次:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediPlan" />
                                    <span id="planValidate"></span>
                                </td>
                            </tr>
                            <tr id="prof">
                                <td class="teaLable text-right">
                                    <label class="text-span">专业:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediProf" />
                                    <span id="profValidate"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaName text-right">
                                    <label class="text-span">发布人:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediTeaName" />
                                    <span id="teaNameValidate"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="limit text-right">
                                    <label class="text-span">人数上限:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediLimit" />
                                    <span id="limitValidate"></span>
                                </td>
                            </tr>

                            <tr>
                                <td class="createTime text-right">
                                    <label class="text-span">创建时间:</label>
                                </td>
                                <td>
                                    <input class="form-control chemail" type="text" id="ediCreateTime" />
                                    <span id="createTimeValidate"></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default chID" data-dismiss="modal" id="btnClose">关闭</button>
                    <button type="button" class="btn btn-primary" id="btnSave">保存更改</button>
                </div>
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
    <script src="../js/xcConfirm.js"></script>
    <script src="../js/titleList.js"></script>
</body>
</html>
